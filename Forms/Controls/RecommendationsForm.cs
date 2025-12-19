using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.ML;
using Microsoft.ML.Data;
using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;        // лише для шляху до моделі
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RestaurantRecApp.Forms.Controls {
  public partial class RecommendationsForm : Form {
    private readonly ValidationMy _Validation = new ValidationMy();
    private Models _SelectedModels = new Models();
    private readonly ModelsProvider _ModelsProvider = new ModelsProvider();
    private List<Models> _ModelsList = new List<Models>();

    // Стан вхідних операцій (мультизапуски)
    private readonly List<ModelOperation> _AllModelOperation = new List<ModelOperation>();

    // ===== ML.NET артефакти ====================================================
    private readonly MLContext _Context = new MLContext(seed: 0);
    private ITransformer _LoadedModel;
    private PredictionEngine<RawRating, CalibOutput> _PredictionEngine;
    // Кандидати для рекомендацій (беремо з моделі). Використовуємо RawRating як DTO.
    private List<RawRating> _AllUniqueRestaurants = new List<RawRating>();


    private bool _IsGloballyWarmedUp = false;
    public RecommendationsForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void LoadAllDate() {
      _ModelsList = _ModelsProvider.GetAllModels();
      ModelsCBox.DataSource = _ModelsList;
      ModelsCBox.ValueMember = "ModelsId";
      ModelsCBox.DisplayMember = "ModelsName";
    }

    // ===========================================================================
    // 1) Вибір моделі → Завантаження → Витяг «ресторанів» ІЗ МОДЕЛІ
    // ===========================================================================
    private void SelectBtn_Click(object sender, EventArgs e) {
      if (!IsModelSelect()) return;
      _SelectedModels = _ModelsProvider.SelectedModelsByModelsId(
        Convert.ToInt32(ModelsCBox.SelectedValue));
      LoadModel(_SelectedModels.ModelsFileModel);
    }

    private void LoadModel(string filePathFromDb) {
      string modelPath = Application.StartupPath + filePathFromDb;
      // 1) Завантаження моделі
      DataViewSchema modelSchema;
      _LoadedModel = _Context.Model.Load(modelPath, out modelSchema);
      // 2) PredictionEngine: RawRating (вхід) → CalibOutput (вихід).
      _PredictionEngine = _Context.Model.CreatePredictionEngine<RawRating, CalibOutput>(_LoadedModel);
      // 3) Кандидати: лише з KeyValues моделі (без файлів)
      _AllUniqueRestaurants = ExtractItemsFromModelKeyValues(_LoadedModel);
      // 4) Інформування
      RaportTBox.Clear();
      RaportTBox.AppendText("Модель успішно завантажено.\r\n");
      RaportTBox.AppendText($"Кількість доступних для рекомендацій об’єктів:" +
        $" {_AllUniqueRestaurants.Count}\r\n");
    }

    // ===========================================================================
    // 2) Додавання «операції» (customer_id + N)
    // ===========================================================================
    private void AddBtn_Click(object sender, EventArgs e) {
      if (!IsDataEnteringCorrecting()) return;

      var op = new ModelOperation {
        CustomerId = Convert.ToInt32(CustomerIdTBox.Text),
        NumberRecommendations = Convert.ToInt32(NumberRecommendationsTBox.Text),
        FullName = GenerateRandomFullName()   // ← автоматична генерація ПІБ
      };

      _AllModelOperation.Add(op);
      LoadDataInLargeArrayGW(_AllModelOperation);
      ClearOpInputs();
    }

    // ===========================================================================
    // 3) Запуск прогнозування для всіх операцій + час/пам’ять + графік
    // ===========================================================================
    private void TestBtn_Click(object sender, EventArgs e) {
      if (_LoadedModel == null || _PredictionEngine == null) {
        MessageBox.Show("Спочатку завантажте модель.", "Увага!");
        return;
      }
      if (_AllUniqueRestaurants == null || _AllUniqueRestaurants.Count <= 1 ||
        _AllModelOperation == null || _AllModelOperation.Count == 0) {
        MessageBox.Show("Немає або недостатньо доступних позицій для рекомендацій.",
          "Увага!");
        return;
      }
      InitializeChart();
      RaportTBox.Clear();

      // Раз прогріли до всіх вимірів
      GlobalWarmUpPrediction(reps: 2, sampleK: 256);
      var scored = new List<(RawRating item, float score)>(_AllUniqueRestaurants.Count);
      var input = new RawRating();
      foreach (var op in _AllModelOperation) {
        int M = _AllUniqueRestaurants.Count;
        int N = Math.Min(op.NumberRecommendations, M);
        // ——— 1) ІНФЕРЕНС: проходимо всі M (медіана з 5 повторів, перший відкидаємо) ———
        double inferenceMs = MeasureMs(() => {
          scored.Clear(); // реюз
          for (int i = 0; i < M; i++) {
            var item = _AllUniqueRestaurants[i];
            input.customer_id = op.CustomerId;
            input.restaurant_link = item.restaurant_link;
            input.restaurant_name = item.restaurant_name;
            input.avg_rating = item.avg_rating;
            input.Label = 0f;

            var pred = _PredictionEngine.Predict(input);
            scored.Add((item, pred.Score));
          }
        });

        // ——— 2) ВІДБІР ТОП-N: partial-select (медіана з 5 повторів) ———
        List<(RawRating item, float score)> topN = null;
        double selectMs = MeasureMs(() => {
          // ВАЖЛИВО: працюємо на копії/знімку, бо QuickSelect створює idx, але data не мутує
          topN = TopNByScore_QuickSelect(scored, N);
        });

        // ——— 3) Пам’ять (після дій) ———
        long memoryAfter = GC.GetTotalMemory(forceFullCollection: false);
        op.ExecutionTimeMilliseconds = inferenceMs + selectMs;
        op.MemoryUsedMB = memoryAfter / (1024.0 * 1024.0);

        // ——— 4) Лог (поза замірами) ———
        RaportTBox.AppendText($"Операція № {op.Number}\r\n");
        RaportTBox.AppendText($"CustomerId: {op.CustomerId}\r\n");
        RaportTBox.AppendText($"Кількість рекомендацій: {op.NumberRecommendations}\r\n");
        RaportTBox.AppendText($"Час інференсу (медіана з повторів): {inferenceMs:F2} мс (M={M})\r\n");
        RaportTBox.AppendText($"Час відбору ТОП-N (медіана): {selectMs:F2} мс (N={N})\r\n");
        RaportTBox.AppendText($"Загальний час (контроль): {op.ExecutionTimeMilliseconds:F2} мс\r\n");
        RaportTBox.AppendText($"Використана пам’ять: {op.MemoryUsedMB:F2} MB\r\n");
        RaportTBox.AppendText("Рекомендації:\r\n");
        foreach (var rec in topN) {
          string name = string.IsNullOrWhiteSpace(rec.item.restaurant_name)
                      ? rec.item.restaurant_link
                      : rec.item.restaurant_name;
          RaportTBox.AppendText($"• {name}  | Score: {rec.score:F4}\r\n");
        }
        RaportTBox.AppendText("\r\n");
      }
      UpdateChartWithData();
    }


    // Повертає ТОП-N у спадаючому порядку без повного сортування всього масиву.
    private static List<(RawRating item, float score)> TopNByScore_QuickSelect(
        List<(RawRating item, float score)> data, int N) {
      int M = data.Count;
      if (N <= 0 || M == 0) return new List<(RawRating, float)>(0);
      if (N >= M) return data.OrderByDescending(s => s.score).ToList();

      // Якщо N відносно велике — повний сортувальний шлях вигідніший на практиці
      if ((long)N * 32L > M)
        return data.OrderByDescending(s => s.score).Take(N).ToList();

      // Копія лише індексів, QuickSelect працює по оцінках
      int[] idx = Enumerable.Range(0, M).ToArray();

      // Знайдемо порогове значення N-тої найбільшої оцінки (еквівалент nth_element)
      int target = N - 1;
      QuickSelect(idx, data, 0, M - 1, target);

      float threshold = data[idx[target]].score;

      // Забираємо всі елементи >= threshold
      var bucket = new List<(RawRating item, float score)>(N * 2);
      for (int i = 0; i < M; i++)
        if (data[i].score >= threshold) bucket.Add(data[i]);

      // Якщо потрапило більше ніж N — локально відсортуємо й обріжемо
      bucket.Sort((a, b) => b.score.CompareTo(a.score));
      if (bucket.Count > N) bucket.RemoveRange(N, bucket.Count - N);
      return bucket;
    }

    private static void QuickSelect(
        int[] idx, List<(RawRating item, float score)> data, int left, int right, int k) {
      var rnd = new Random(1234567);
      while (left < right) {
        int pivotIndex = left + rnd.Next(right - left + 1);
        pivotIndex = Partition(idx, data, left, right, pivotIndex);

        if (k == pivotIndex) return;
        else if (k < pivotIndex) right = pivotIndex - 1;
        else left = pivotIndex + 1;
      }
    }

    private static int Partition(
        int[] idx, List<(RawRating item, float score)> data, int left, int right, int pivotIndex) {
      float pivotScore = data[idx[pivotIndex]].score;
      (idx[pivotIndex], idx[right]) = (idx[right], idx[pivotIndex]); // move pivot to end
      int store = left;
      for (int i = left; i < right; i++) {
        // Розміщуємо "більші" ліворуч, щоб шукати N-ту найбільшу
        if (data[idx[i]].score > pivotScore) {
          (idx[store], idx[i]) = (idx[i], idx[store]);
          store++;
        }
      }
      (idx[right], idx[store]) = (idx[store], idx[right]);
      return store;
    }

    private static double MeasureMs(Action action, int repeats = 5, bool discardFirst = true) {
      // Мінімізація шуму
      var oldProcPrio = Process.GetCurrentProcess().PriorityClass;
      var oldThreadPrio = Thread.CurrentThread.Priority;
      Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
      Thread.CurrentThread.Priority = ThreadPriority.Highest;

      GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();

      var times = new List<double>(repeats);
      var sw = new Stopwatch();

      for (int i = 0; i < repeats; i++) {
        sw.Restart();
        action();
        sw.Stop();
        times.Add(sw.Elapsed.TotalMilliseconds);
      }

      // Відкат пріоритетів
      Thread.CurrentThread.Priority = oldThreadPrio;
      Process.GetCurrentProcess().PriorityClass = oldProcPrio;

      if (discardFirst && times.Count > 1) times.RemoveAt(0); // знімаємо холодний прогін
      times.Sort();
      return times[times.Count / 2]; // медіана
    }


    /// Глобальний прогрів один раз на кількох користувачах (знімає JIT/ініціалізацію)
    private void GlobalWarmUpPrediction(int reps = 2, int sampleK = 128) {
      if (_PredictionEngine == null || _AllUniqueRestaurants == null || _AllUniqueRestaurants.Count == 0 || _IsGloballyWarmedUp)
        return;

      int K = Math.Min(sampleK, _AllUniqueRestaurants.Count);
      // Візьмемо до 3 різних користувачів з черги операцій (якщо є)
      var warmIds = _AllModelOperation?.Select(x => x.CustomerId).Distinct().Take(3).ToList() ?? new List<int> { 1 };

      var input = new RawRating();
      for (int r = 0; r < reps; r++) {
        foreach (var cid in warmIds) {
          for (int i = 0; i < K; i++) {
            var item = _AllUniqueRestaurants[i];
            input.customer_id = cid;
            input.restaurant_link = item.restaurant_link;
            input.restaurant_name = item.restaurant_name;
            input.avg_rating = item.avg_rating;
            input.Label = 0f;
            _ = _PredictionEngine.Predict(input);
          }
        }
      }

      _IsGloballyWarmedUp = true;
      GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
    }


    // ===========================================================================
    // Валідації, грід, графік (без категорій)
    // ===========================================================================
    private bool IsModelSelect() {
      bool isCorrect = true;
      if (Convert.ToInt32(ModelsCBox.SelectedValue) > 0) {
        ModelsValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ModelsValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private bool IsDataEnteringCorrecting() {
      bool isCorrect = true;

      if (_Validation.IsDataConvertToInt(CustomerIdTBox.Text) &&
          _Validation.IsDataInThisScope(1, 10000000, Convert.ToInt32(CustomerIdTBox.Text))) {
        CustomerIdValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CustomerIdValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      if (_Validation.IsDataConvertToInt(NumberRecommendationsTBox.Text) &&
          _Validation.IsDataInThisScope(1, 10000000, Convert.ToInt32(NumberRecommendationsTBox.Text))) {
        NumberRecommendationsValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        NumberRecommendationsValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      isCorrect = IsModelSelect() && isCorrect;
      return isCorrect;
    }

    private void LoadDataInLargeArrayGW(List<ModelOperation> ModelOperationArray) {
      ChangeNumber();
      ModelOperationGridView.DataSource = null;
      ModelOperationGridView.Columns.Clear();
      ModelOperationGridView.AutoGenerateColumns = false;
      ModelOperationGridView.RowHeadersVisible = false;

      ModelOperationGridView.DataSource = ModelOperationArray;

      if (ModelOperationArray.Count > 0) {
        var numberColumn = new DataGridViewTextBoxColumn {
          HeaderText = "№",
          DataPropertyName = "Number",
          DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight },
          Width = 30
        };
        ModelOperationGridView.Columns.Add(numberColumn);

        var userIdColumn = new DataGridViewTextBoxColumn {
          HeaderText = "Ід.клієнта",
          DataPropertyName = "CustomerId",
          Name = "CustomerId",
          DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight },
          Width = 80
        };
        ModelOperationGridView.Columns.Add(userIdColumn);

        var fullNameColumn = new DataGridViewTextBoxColumn {
          HeaderText = "Клієнт",
          DataPropertyName = "FullName",
          Name = "FullName",
          Width = 180
        };
        ModelOperationGridView.Columns.Add(fullNameColumn);


        var nRecColumn = new DataGridViewTextBoxColumn {
          HeaderText = "К-сть рекомендацій",
          DataPropertyName = "NumberRecommendations",
          Name = "NumberRecommendations",
          DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight },
          Width = 150
        };
        ModelOperationGridView.Columns.Add(nRecColumn);

        var delBtn = new DataGridViewButtonColumn {
          Text = "Видалити",
          UseColumnTextForButtonValue = true,
          ToolTipText = "Видалити",
          Width = NamesMy.SizeOptins.DeleteBtnSize
        };
        ModelOperationGridView.Columns.Add(delBtn);

        for (int i = 0; i < ModelOperationGridView.Columns.Count; i++) {
          ModelOperationGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ChangeNumber() {
      for (int i = 0; i < _AllModelOperation.Count; i++) {
        _AllModelOperation[i].Number = i + 1;
      }
    }

    private void ClearOpInputs() {
      CustomerIdTBox.Text = "0";
      NumberRecommendationsTBox.Text = "0";
    }

    // Ініціалізація графіка (LiveCharts)
    private void InitializeChart() {
      GraphicsCC.Series.Clear();
      GraphicsCC.AxisX.Clear();
      GraphicsCC.AxisY.Clear();

      var executionTimeSeries = new LineSeries { Title = "Час прогнозування (мс)", Values = new ChartValues<double>() };
      var memoryUsedSeries = new LineSeries { Title = "Використана пам'ять (MB)", Values = new ChartValues<double>() };

      GraphicsCC.Series.Add(executionTimeSeries);
      GraphicsCC.Series.Add(memoryUsedSeries);

      GraphicsCC.AxisX.Add(new LiveCharts.Wpf.Axis {
        Title = "Операції",
        Labels = _AllModelOperation.Select(op => op.Number.ToString()).ToArray(),
        Separator = new LiveCharts.Wpf.Separator { Step = 1 }
      });

      GraphicsCC.AxisY.Add(new LiveCharts.Wpf.Axis {
        Title = "Час (мс) / Пам'ять (MB)",
        LabelFormatter = value => value.ToString("N")
      });
    }

    private void UpdateChartWithData() {
      if (GraphicsCC.Series.Count > 0) {
        var executionTimeSeries = (LineSeries)GraphicsCC.Series[0];
        var memoryUsedSeries = (LineSeries)GraphicsCC.Series[1];

        executionTimeSeries.Values.Clear();
        memoryUsedSeries.Values.Clear();

        foreach (var op in _AllModelOperation) {
          executionTimeSeries.Values.Add(op.ExecutionTimeMilliseconds);
          memoryUsedSeries.Values.Add(op.MemoryUsedMB);
        }
      }
    }

    // ===========================================================================
    // 4) Витяг списку item’ів з моделі (KeyValues) — БЕЗ TryGetColumnIndex/AnnotationUtils
    // ===========================================================================
    private List<RawRating> ExtractItemsFromModelKeyValues(ITransformer model) {
      var result = new List<RawRating>();

      // Порожнє джерело з потрібною вхідною схемою (RawRating)
      var emptyData = _Context.Data.LoadFromEnumerable(new List<RawRating>(0));
      var transformed = model.Transform(emptyData);
      var schema = transformed.Schema;

      // Назва колонки, закодованої MapValueToKey для item’а
      string[] candidateNames = new[] { "restaurant_linkEncoded", "ItemIdEncoded", "ISBNEncoded" };

      int colIndex = -1;
      foreach (var name in candidateNames) {
        for (int i = 0; i < schema.Count; i++) {
          if (string.Equals(schema[i].Name, name, StringComparison.OrdinalIgnoreCase)) {
            colIndex = i; break;
          }
        }
        if (colIndex >= 0) break;
      }
      if (colIndex < 0) return result; // не знайшли — повертаємо порожній список

      var col = schema[colIndex];

      // Дістаємо анотацію "KeyValues" (VBuffer<ReadOnlyMemory<char>>) без AnnotationUtils
      if (col.Annotations.Schema != null && col.Annotations.Schema.Count > 0) {
        int kvAnnIdx = -1;
        for (int i = 0; i < col.Annotations.Schema.Count; i++) {
          if (string.Equals(col.Annotations.Schema[i].Name, "KeyValues", StringComparison.Ordinal)) {
            kvAnnIdx = i; break;
          }
        }
        if (kvAnnIdx >= 0) {
          var keyValues = default(VBuffer<ReadOnlyMemory<char>>);
          col.Annotations.GetValue("KeyValues", ref keyValues);

          foreach (var kv in keyValues.DenseValues()) {
            string link = kv.ToString();
            if (string.IsNullOrWhiteSpace(link)) continue;

            result.Add(new RawRating {
              customer_id = 0,
              restaurant_link = link,
              restaurant_name = link, // без сайд-кара у назві лишаємо посилання
              avg_rating = 0f,        // дефолт
              Label = 0f
            });
          }
        }
      }
      return result;
    }

    private void ModelOperationGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 3 && ModelOperationGridView[0, e.RowIndex].Value.ToString() != _AllModelOperation[0].Message) {
        int num = Convert.ToInt32(ModelOperationGridView[0, e.RowIndex].Value.ToString());
        for (int i = 0; i < _AllModelOperation.Count; i++) {
          if (num == _AllModelOperation[i].Number) {
            _AllModelOperation.RemoveAt(i);
            break;
          }
        }
        LoadDataInLargeArrayGW(_AllModelOperation);
      }
    }

    private string GenerateRandomFullName() {
      Random rnd = new Random();

      // === 1. Випадковий вибір статі (0 - чоловіча, 1 - жіноча) ===
      bool isFemale = rnd.NextDouble() < 0.5; // 50% імовірності для кожної статі

      // === 2. Масиви імен, прізвищ і по батькові ===================
      string[] maleFirstNames = { "Іван", "Петро", "Олександр", "Михайло", "Андрій", "Сергій", "Василь", "Дмитро", "Олег", "Юрій" };
      string[] femaleFirstNames = { "Олена", "Наталія", "Ірина", "Тетяна", "Марія", "Світлана", "Ганна", "Оксана", "Вікторія", "Катерина" };

      string[] maleLastNames = { "Коваль", "Шевченко", "Мельник", "Бондар", "Ткаченко", "Кравець", "Гуменюк", "Петренко", "Савчук", "Лисенко" };
      string[] femaleLastNames = { "Коваль", "Шевченко", "Мельник", "Бондар", "Ткаченко", "Кравець", "Гуменюк", "Петренко", "Савчук", "Лисенко" };


      // === 3. Вибір повного імені відповідно до статі ==============
      string fullName;
      if (isFemale) {
        fullName = $"{femaleLastNames[rnd.Next(femaleLastNames.Length)]} {femaleFirstNames[rnd.Next(femaleFirstNames.Length)]}";
      } else {
        fullName = $"{maleLastNames[rnd.Next(maleLastNames.Length)]} {maleFirstNames[rnd.Next(maleFirstNames.Length)]}";
      }

      return fullName;
    }


  }

  // Узгодьте з вашим існуючим класом (якщо вже є — цей дубль не потрібен)
  public class ModelOperation {
    public int Number { get; set; }
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public int NumberRecommendations { get; set; }
    public double ExecutionTimeMilliseconds { get; set; }
    public double MemoryUsedMB { get; set; }
    public string Message { get; set; } = "no-message";
  }
}
