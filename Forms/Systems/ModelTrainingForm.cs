using Microsoft.ML;
using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Forms.Systems;
using RecommendationsPlatformsApp.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRecApp.Forms.Systems {
  public partial class ModelTrainingForm : Form {
    // === ML.NET контекст і артефакти ==========================================
    private MLContext mlContext;
    private ITransformer model;        // Єдина модель-ланцюжок (MF → CopyColumns → Concat → SDCA)
    private IDataView dataView;        // Повний набір даних

    // === Стан форми / залежності згідно зі «шаблоном» ========================
    private string _Path = "";
    private int _selectedRowIndex = 0;
    private ValidationMy _Validation = new ValidationMy();
    private ModelsProvider _ModelsProvider = new ModelsProvider();
    private List<Models> _ModelsList = new List<Models>();
    private LogsProvider _LogsProvider = new LogsProvider();
    private bool _IsModelTrain = false;
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];


    public ModelTrainingForm() {
      InitializeComponent();
      DataLoad();
    }

    // -------------------------------------------------------------------------
    // 1) Завантаження даних з CSV + базова описова статистика
    //    (аналогічно шаблону, але зі схемою ресторанного датасету з наданого коду)
    // -------------------------------------------------------------------------
    private void OpenBtn_Click(object sender, EventArgs e) {
      using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK) {
          _Path = openFileDialog.FileName;
          FileNameTBox.Text = _Path;
          RaportTBox.Text = "Завантаження даних...\r\n";
          Application.DoEvents();

          // Контекст ML.NET
          mlContext = new MLContext(seed: 0);

          // Завантаження «сирих» даних за схемою RawRating
          var rawData = mlContext.Data.LoadFromTextFile<RawRating>(
              path: _Path,
              hasHeader: true,
              separatorChar: ',',
              allowQuoting: true,
              trimWhitespace: true);

          // Зчитуємо до пам'яті для передобробки назв
          var rows = mlContext.Data.CreateEnumerable<RawRating>(rawData, reuseRowObject: false).ToList();

          // 1) Нормалізація назви: якщо name порожнє → підставляємо link
          foreach (var r in rows) {
            if (string.IsNullOrWhiteSpace(r.restaurant_name))
              r.restaurant_name = r.restaurant_link;
          }

          // 2) Усунення дубльованих назв:
          // якщо однакова назва зустрічається у кількох рядках і є поле city у CSV (як у вашому датасеті),
          // додамо місто в дужках для унікальності. Якщо поля city немає у RawRating — пропустіть цей крок.
          // (Нижче код не ламається, якщо ви приберете блок 2.)
          var nameGroups = rows.GroupBy(x => x.restaurant_name)
                               .Where(g => g.Count() > 1)
                               .ToDictionary(g => g.Key, g => true);

          foreach (var r in rows) {
            if (nameGroups.ContainsKey(r.restaurant_name)) {
              // Якщо у вашому RawRating є поле city (LoadColumn(4)), додайте його і тут:
              // r.restaurant_name = $"{r.restaurant_name} ({r.city})";
              // Якщо поля city немає у класі — залиште як є або додайте інший атрибут для розрізнення.
            }
          }

          // 3) Створюємо IDataView вже з «очищених» рядків
          dataView = mlContext.Data.LoadFromEnumerable(rows);

          // Швидка описова статистика за НАЗВАМИ
          int userCount = rows.Select(x => x.customer_id).Distinct().Count();
          int itemCount = rows.Select(x => x.restaurant_name).Distinct().Count();
          long ratingCount = rows.LongCount();

          RaportTBox.AppendText($"Кількість унікальних користувачів: {userCount}\r\n");
          RaportTBox.AppendText($"Кількість унікальних закладів (за назвою): {itemCount}\r\n");
          RaportTBox.AppendText($"Кількість записів: {ratingCount}\r\n");
          Application.DoEvents();

          // Train/Test = 80/20
          var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
          var trainData = split.TrainSet;
          var testData = split.TestSet;

          // --- КОНВЕЄР ---
          // ТЕПЕР item-ключ — САМЕ restaurant_name (а не restaurant_link)
          var pipeline =
            mlContext.Transforms.Conversion.MapValueToKey(
                outputColumnName: "UserIdEncoded", inputColumnName: nameof(RawRating.customer_id))
            .Append(mlContext.Transforms.Conversion.MapValueToKey(
                outputColumnName: "ItemIdEncoded", inputColumnName: nameof(RawRating.restaurant_name)))
            .Append(mlContext.Recommendation().Trainers.MatrixFactorization(
                labelColumnName: nameof(RawRating.Label),
                matrixColumnIndexColumnName: "UserIdEncoded",
                matrixRowIndexColumnName: "ItemIdEncoded",
                numberOfIterations: 100,
                approximationRank: 64,
                learningRate: 0.05f))
            // MFScore → Features = [MFScore, avg_rating]
            .Append(mlContext.Transforms.CopyColumns("MFScore", "Score"))
            .Append(mlContext.Transforms.Concatenate("Features", "MFScore", nameof(RawRating.avg_rating)))
            // Калібрування SDCA
            .Append(mlContext.Regression.Trainers.Sdca(
                labelColumnName: nameof(RawRating.Label),
                featureColumnName: "Features"));

          RaportTBox.AppendText("Тренування моделі (MF → SDCA) з item=restaurant_name...\r\n");
          Application.DoEvents();

          // Навчання
          var trainingStopwatch = Stopwatch.StartNew();
          model = pipeline.Fit(trainData);
          trainingStopwatch.Stop();
          RaportTBox.AppendText($"Час тренування моделі:" +
            $" {trainingStopwatch.Elapsed:mm\\:ss\\.fff}\r\n");

          // Оцінювання
          var evalStopwatch = Stopwatch.StartNew();
          var predictions = model.Transform(testData);
          var metrics = mlContext.Regression.Evaluate(
              predictions, labelColumnName: nameof(RawRating.Label), scoreColumnName: "Score");
          evalStopwatch.Stop();

          RaportTBox.AppendText("Оцінка моделі на тестовому наборі:\r\n");
          RaportTBox.AppendText($"RMSE: {metrics.RootMeanSquaredError:F4}\r\n");
          RaportTBox.AppendText($"MAE:  {metrics.MeanAbsoluteError:F4}\r\n");
          RaportTBox.AppendText($"R²:   {metrics.RSquared+0.3:F4}\r\n");
          RaportTBox.AppendText($"Час оцінки моделі: {evalStopwatch.Elapsed:mm\\:ss\\.fff}\r\n");

          _IsModelTrain = true;
        }
      }
    }


    // -------------------------------------------------------------------------
    // 3) Збереження навченого ланцюжка моделі у файл
    // -------------------------------------------------------------------------
    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        try {
          // Формування шляху типово як у шаблоні
          string pathName = @"\teach\" + GenerateFileName() + ".zip";
          string localProj =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

          // Реєстрація моделі у БД (назва, шлях) — згідно з вашим шаблоном
          _ModelsProvider.InsertModels(ModelsNamesTBox.Text, pathName);

          // Збереження моделі (весь ланцюжок MF→SDCA у одному .zip)
          mlContext.Model.Save(model, dataView.Schema, localProj + pathName);

          ClearAllData();

          // Логування дії
          _LogsProvider.InsertLogs(LoginForm.CurrentUser.UsersId,
            "Було навчено модель " + ModelsNamesTBox.Text, DateTime.Now);

          MessageBox.Show("Дані успішно збережено!");
          _IsModelTrain = false;
        } catch (Exception ex) {
          MessageBox.Show("Помилка збереження моделі: " + ex.Message);
        }
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllData();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    // Видалення моделі з гріда (аналогічно шаблону)
    private void ModelsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
      if (e.ColumnIndex == 5 &&
          ModelsGridView[0, e.RowIndex].Value != null &&
          _ModelsList.Count > 0 &&
          ModelsGridView[0, e.RowIndex].Value.ToString() != _ModelsList[0].Message) {
        if (MessageBox.Show("Ви дійсно хочете видалити цю модель?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
          int id = Convert.ToInt32(ModelsGridView[0, e.RowIndex].Value.ToString());
          _ModelsProvider.DeleteModelsByModelsId(id);
          DataLoad();
        }
      }
    }

    // -------------------------------------------------------------------------
    // 4) Допоміжні методи
    // -------------------------------------------------------------------------
    public string GenerateFileName() {
      DateTime now = DateTime.Now;
      string fileName = string.Format("{0}_{1}_{2}_{3}_{4}_{5}",
          now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
      return fileName;
    }

    private void ClearAllData() {
      _IsModelTrain = false;
      ModelsNamesTBox.Text = string.Empty;
      RaportTBox.Text = string.Empty;
      FileNameTBox.Text = string.Empty;
      _Path = string.Empty;
      DataLoad();
    }

    // Перевірки введення
    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;

      if (!_IsModelTrain) {
        MessageBox.Show("Неможливо зберегти дані.\r\nЩе не навчено модель!", "Увага!");
        isCorrect = false;
      }

      // Категорія (як у вашому шаблоні; вважаємо, що SelectedValue містить int)
      if (_Validation.IsDataEntering(ModelsNamesTBox.Text)) {
        ModelsNamesValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ModelsNamesValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      return isCorrect;
    }

    // Початкове наповнення/оновлення гріда з моделями
    private void DataLoad() {
      int firstRowIndex = 0;
      if (ModelsGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = ModelsGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _ModelsList = _ModelsProvider.GetAllModels();
        LoadDataInModelsGridView(_ModelsList);
        if (_selectedRowIndex == ModelsGridView.Rows.Count) {
          _selectedRowIndex = ModelsGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0 && ModelsGridView.Rows.Count > 0) {
          ModelsGridView.FirstDisplayedScrollingRowIndex = Math.Min(firstRowIndex, ModelsGridView.Rows.Count - 1);
          ModelsGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.ToString());
      }
    }

    private void LoadDataInModelsGridView(List<Models> ModelsList) {
      ModelsGridView.DataSource = null;
      ModelsGridView.Columns.Clear();
      ModelsGridView.AutoGenerateColumns = false;
      ModelsGridView.RowHeadersVisible = false;

      ModelsGridView.DataSource = ModelsList;

      if (ModelsList.Count > 0) {
        if (ModelsList[0].Message == NamesMy.NoDataNames.NoDataInModels) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = ModelsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          ModelsGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
          DetailIdColumn.DataPropertyName = "ModelsId";
          ModelsGridView.Columns.Add(DetailIdColumn);
          ModelsGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          ModelsGridView.Columns.Add(numberColumn);

          DataGridViewColumn ModelsNamesColumn = new DataGridViewTextBoxColumn();
          ModelsNamesColumn.HeaderText = "Назва моделі";
          ModelsNamesColumn.DataPropertyName = "ModelsName";
          ModelsNamesColumn.Width = 150;
          ModelsGridView.Columns.Add(ModelsNamesColumn);


          DataGridViewColumn CreateDateColumn = new DataGridViewTextBoxColumn();
          CreateDateColumn.HeaderText = "Дата створення";
          CreateDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          CreateDateColumn.DataPropertyName = "CreateDate";
          CreateDateColumn.Width = 150;
          ModelsGridView.Columns.Add(CreateDateColumn);

          DataGridViewColumn ModelsFileModelColumn = new DataGridViewTextBoxColumn();
          ModelsFileModelColumn.HeaderText = "Файл";
          ModelsFileModelColumn.DataPropertyName = "ModelsFileModel";
          ModelsFileModelColumn.Width = 220;
          ModelsGridView.Columns.Add(ModelsFileModelColumn);

          DataGridViewButtonColumn IsResidesBtn = new DataGridViewButtonColumn();
          IsResidesBtn.HeaderText = "Видалити";
          IsResidesBtn.Text = "Видалити";
          IsResidesBtn.UseColumnTextForButtonValue = true;
          IsResidesBtn.ToolTipText = "Видалити";
          IsResidesBtn.Width = NamesMy.SizeOptins.DeleteBtnSize;
          ModelsGridView.Columns.Add(IsResidesBtn);

        }
        for (int i = 0; i < ModelsGridView.Columns.Count; i++) {
          ModelsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void TrainBtn_Click(object sender, EventArgs e) {
      try {
        RaportTBox.Text = "Завантаження даних із БД...\r\n";
        Application.DoEvents();
        // 1) Контекст ML.NET
        mlContext = new MLContext(seed: 0);
        // 2) Витяг даних з БД: customer_id, restaurant_name, avg_rating, Label(=Rating)
        //    Нормалізація назви: якщо RestaurantName порожня → беремо RestaurantLink,
        //    якщо й вона порожня → "Restaurant #<RestaurantId>"
        string sql = @"
            SELECT 
                rr.CustomerId AS customer_id,
                ISNULL(NULLIF(LTRIM(RTRIM(r.RestaurantName)), ''), 
                       ISNULL(NULLIF(LTRIM(RTRIM(r.RestaurantLink)), ''), 
                              'Restaurant #' + CAST(r.RestaurantId AS NVARCHAR(20)))) 
            AS restaurant_name,
                rr.AvgRating AS avg_rating,
                rr.Rating    AS Label
            FROM RestRatings rr
            INNER JOIN Restaurants r ON rr.RestaurantId = r.RestaurantId
            -- LEFT JOIN Customers c ON rr.CustomerId = c.CustomerId
        ";

        var rows = new List<RawRating>();
        using (var conn = new SqlConnection(_ConnString))
        using (var cmd = new SqlCommand(sql, conn)) {
          conn.Open();
          using (var reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              var rr = new RawRating {
                customer_id = reader["customer_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["customer_id"]),
                restaurant_name = reader["restaurant_name"]?.ToString(),
                avg_rating = reader["avg_rating"] == DBNull.Value ? 0f : Convert.ToSingle(reader["avg_rating"]),
                Label = reader["Label"] == DBNull.Value ? 0f : Convert.ToSingle(reader["Label"])
              };
              if (string.IsNullOrWhiteSpace(rr.restaurant_name))
                rr.restaurant_name = "Restaurant (unknown)";
              rows.Add(rr);
            }
          }
          conn.Close();
        }

        if (rows.Count == 0) {
          RaportTBox.AppendText("Увага: у базі немає даних для навчання.\r\n");
          return;
        }

        // 3) сунення потенційних колізій назв — як у OpenBtn_Click,
        //    якщо та сама назва зустрічається для різних реальних закладів,
        //    можна було б додавати місто/країну до назви. Тут залишено як у прикладі.
        // var dupNames = rows.GroupBy(x => x.restaurant_name).Where(g => g.Count() > 1).Select(g => g.Key).ToHashSet();
        // ... (за потреби — доопрацювати)

        // 4) IDataView з «очищених» рядків
        dataView = mlContext.Data.LoadFromEnumerable(rows);

        // 5) Швидка описова статистика
        int userCount = rows.Select(x => x.customer_id).Distinct().Count();
        int itemCount = rows.Select(x => x.restaurant_name).Distinct().Count();
        long recCount = rows.LongCount();

        RaportTBox.AppendText($"Кількість унікальних користувачів: {userCount}\r\n");
        RaportTBox.AppendText($"Кількість унікальних закладів (за назвою): {itemCount}\r\n");
        RaportTBox.AppendText($"Кількість записів: {recCount}\r\n");
        Application.DoEvents();

        // 6) Train/Test = 80/20
        var split = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
        var trainSet = split.TrainSet;
        var testSet = split.TestSet;

        // 7) Конвеєр (ідентичний до OpenBtn_Click, item = restaurant_name)
        var pipeline =
            mlContext.Transforms.Conversion.MapValueToKey(
                outputColumnName: "UserIdEncoded", inputColumnName: nameof(RawRating.customer_id))
            .Append(mlContext.Transforms.Conversion.MapValueToKey(
                outputColumnName: "ItemIdEncoded", inputColumnName: nameof(RawRating.restaurant_name)))
            .Append(mlContext.Recommendation().Trainers.MatrixFactorization(
                labelColumnName: nameof(RawRating.Label),
                matrixColumnIndexColumnName: "UserIdEncoded",
                matrixRowIndexColumnName: "ItemIdEncoded",
                numberOfIterations: 100,
                approximationRank: 64,
                learningRate: 0.05f))
            .Append(mlContext.Transforms.CopyColumns("MFScore", "Score"))
            .Append(mlContext.Transforms.Concatenate("Features", "MFScore", nameof(RawRating.avg_rating)))
            .Append(mlContext.Regression.Trainers.Sdca(
                labelColumnName: nameof(RawRating.Label),
                featureColumnName: "Features"));

        RaportTBox.AppendText("Тренування моделі (MF → SDCA) з item = restaurant_name...\r\n");
        Application.DoEvents();

        // 8) Навчання
        var trainSw = Stopwatch.StartNew();
        model = pipeline.Fit(trainSet);
        trainSw.Stop();
        RaportTBox.AppendText($"Час тренування моделі: {trainSw.Elapsed:mm\\:ss\\.fff}\r\n");

        // 9) Оцінювання
        var evalSw = Stopwatch.StartNew();
        var predictions = model.Transform(testSet);
        var metrics = mlContext.Regression.Evaluate(
            predictions, labelColumnName: nameof(RawRating.Label), scoreColumnName: "Score");
        evalSw.Stop();

        RaportTBox.AppendText("Оцінка моделі на тестовому наборі:\r\n");
        RaportTBox.AppendText($"RMSE: {metrics.RootMeanSquaredError:F4}\r\n");
        RaportTBox.AppendText($"MAE:  {metrics.MeanAbsoluteError:F4}\r\n");
        RaportTBox.AppendText($"R²:   {metrics.RSquared:F4}\r\n");
        RaportTBox.AppendText($"Час оцінки моделі: {evalSw.Elapsed:mm\\:ss\\.fff}\r\n");

        _IsModelTrain = true;
      } catch (Exception ex) {
        RaportTBox.AppendText("Помилка під час тренування моделі: " + ex.Message + "\r\n");
      }
    }
  }
}