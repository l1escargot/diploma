using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRecApp.Providers {
  internal class RestRatingsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertRestRating(int? CustomerId, int RestaurantId, double AvgRating, double Rating) {
      string SqlString = "INSERT INTO RestRatings (CustomerId, RestaurantId, AvgRating, Rating) " +
                         "VALUES (@CustomerId, @RestaurantId, @AvgRating, @Rating)";

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("@CustomerId",CustomerId);
        cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);
        cmd.Parameters.AddWithValue("@AvgRating", AvgRating );
        cmd.Parameters.AddWithValue("@Rating", Rating);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    }

    public List<RestRating> GetAllRestRatings() {
      int i = 0;

      // SQL-запит з об’єднанням таблиць Customers і Restaurants
      string SqlString = @"
        SELECT 
            rr.RestRatingId,
            rr.CustomerId,
            rr.RestaurantId,
            rr.AvgRating,
            rr.Rating,
            c.LastName + ' ' + c.FirstName AS FullName,
            r.RestaurantName
        FROM RestRatings rr
        LEFT JOIN Customers c ON rr.CustomerId = c.CustomerId
        LEFT JOIN Restaurants r ON rr.RestaurantId = r.RestaurantId
        ORDER BY rr.RestRatingId";

      List<RestRating> listAll = new List<RestRating>();

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        conn.Open();
        using (SqlDataReader reader = cmd.ExecuteReader()) {
          while (reader.Read()) {
            RestRating rr = new RestRating();

            rr.Number = ++i;
            rr.RestRatingId = Convert.ToInt32(reader["RestRatingId"]);

            rr.CustomerId = reader["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CustomerId"]);
            rr.RestaurantId = reader["RestaurantId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RestaurantId"]);
            rr.AvgRating = reader["AvgRating"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["AvgRating"]);
            rr.Rating = reader["Rating"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Rating"]);

            // Отримання додаткових даних з об’єднаних таблиць
            rr.FullName = reader["FullName"] == DBNull.Value ? "—" : reader["FullName"].ToString();
            rr.RestaurantName = reader["RestaurantName"] == DBNull.Value ? "—" : reader["RestaurantName"].ToString();

            listAll.Add(rr);
          }
        }
        conn.Close();
      }

      // Якщо записів немає — створити службовий об’єкт
      if (listAll.Count == 0) {
        RestRating none = new RestRating();
        none.RestRatingId = 0;
        none.Message = NamesMy.NoDataNames.NoDataInRestRatings;
        listAll.Add(none);
      }

      return listAll;
    }


    public RestRating SelectedRestRatingById(int RestRatingId) {
      string SqlString = "SELECT * FROM RestRatings WHERE RestRatingId=@RestRatingId";

      RestRating rr = new RestRating();

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        cmd.Parameters.AddWithValue("@RestRatingId", RestRatingId);

        conn.Open();
        using (SqlDataReader reader = cmd.ExecuteReader()) {
          while (reader.Read()) {
            rr.RestRatingId = Convert.ToInt32(reader["RestRatingId"]);
            rr.CustomerId = reader["CustomerId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CustomerId"]);
            rr.RestaurantId = reader["RestaurantId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RestaurantId"]);
            rr.AvgRating = reader["AvgRating"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["AvgRating"]);
            rr.Rating = reader["Rating"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Rating"]);
          }
        }
        conn.Close();
      }

      return rr;
    }

    public void UpdateRestRating(int CustomerId, int RestaurantId, double AvgRating, double Rating, int RestRatingId) {
      string SqlString = "UPDATE RestRatings SET " +
                         "CustomerId=@CustomerId, RestaurantId=@RestaurantId, " +
                         "AvgRating=@AvgRating, Rating=@Rating " +
                         "WHERE RestRatingId=@RestRatingId";

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
        cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);
        cmd.Parameters.AddWithValue("@AvgRating", AvgRating);
        cmd.Parameters.AddWithValue("@Rating", Rating);
        cmd.Parameters.AddWithValue("@RestRatingId", RestRatingId);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    }

    public void DeleteRestRatingById(int RestRatingId) {
      string SqlString = "DELETE FROM RestRatings WHERE RestRatingId=@RestRatingId";

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        cmd.Parameters.AddWithValue("@RestRatingId", RestRatingId);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    }


  }
}


/// <summary>
/// Клас RestRating — модель для таблиці RestRatings.
/// Містить інформацію про оцінювання ресторану користувачем.
/// </summary>
public class RestRating {
  // === Приватні поля ==================================================
  private int _Number;           // Порядковий номер запису у відображенні
  private int _RestRatingId;     // Ідентифікатор запису оцінки (PK)
  private int _CustomerId;       // Ідентифікатор користувача, який поставив оцінку
  private int _RestaurantId;     // Ідентифікатор ресторану, якому поставлена оцінка
  private string _FullName;        // ПІБ користувача, який залишив оцінку
  private string _RestaurantName;  // Назва ресторану
  private double _AvgRating;     // Середня оцінка ресторану
  private double _Rating;        // Індивідуальна оцінка користувача
  private string _Message;       // Службове повідомлення (стан, коментар тощо)

  // === Конструктор за замовчуванням ==================================
  public RestRating() {
    _Number = 0;
    _RestRatingId = 0;
    _CustomerId = 0;
    _RestaurantId = 0;
    _FullName = string.Empty;
    _RestaurantName = string.Empty;
    _AvgRating = 0.0;
    _Rating = 0.0;
    _Message = string.Empty;
  }

  // === Властивості (Properties) ======================================

  /// <summary>Порядковий номер запису (службове поле для відображення)</summary>
  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }

  /// <summary>Унікальний ідентифікатор запису (PRIMARY KEY)</summary>
  public int RestRatingId {
    set { _RestRatingId = value; }
    get { return _RestRatingId; }
  }

  /// <summary>Ідентифікатор користувача, який залишив оцінку</summary>
  public int CustomerId {
    set { _CustomerId = value; }
    get { return _CustomerId; }
  }

  /// <summary>Ідентифікатор ресторану, який оцінюється</summary>
  public int RestaurantId {
    set { _RestaurantId = value; }
    get { return _RestaurantId; }
  }
  public string FullName {
    set { _FullName = value; }
    get { return _FullName; }
  }

  public string RestaurantName {
    set { _RestaurantName = value; }
    get { return _RestaurantName; }
  }
  /// <summary>Середня оцінка ресторану, розрахована за всіма відгуками</summary>
  public double AvgRating {
    set { _AvgRating = value; }
    get { return _AvgRating; }
  }

  /// <summary>Оцінка ресторану, виставлена конкретним користувачем</summary>
  public double Rating {
    set { _Rating = value; }
    get { return _Rating; }
  }

  /// <summary>Службове повідомлення (наприклад: “дані відсутні”)</summary>
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
