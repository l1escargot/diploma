using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRecApp.Providers {
  internal class RestaurantsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertRestaurant(string RestaurantName, string RestaurantLink, 
      string Country, string City, string Address) {
      string SqlString = "INSERT INTO Restaurants (RestaurantName, RestaurantLink, " +
                                                    "Country, City, Address) " +
                         "VALUES (@RestaurantName, @RestaurantLink, @Country, @City, @Address)";
      using (SqlConnection conn = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("@RestaurantName", RestaurantName);
          cmd.Parameters.AddWithValue("@RestaurantLink", RestaurantLink);
          cmd.Parameters.AddWithValue("@Country", Country);
          cmd.Parameters.AddWithValue("@City", City);
          cmd.Parameters.AddWithValue("@Address", Address);

          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public List<Restaurant> GetAllRestaurant() {
      int i = 0;
      string SqlString = "SELECT * FROM Restaurants ORDER BY RestaurantName";

      List<Restaurant> listAllRestaurant = new List<Restaurant>();

      using (SqlConnection conn = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
          conn.Open();
          using (SqlDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Restaurant oneRestaurant = new Restaurant();

              oneRestaurant.Number = ++i; // порядковий номер
              oneRestaurant.RestaurantId = Convert.ToInt32(reader["RestaurantId"]);
              oneRestaurant.RestaurantName = reader["RestaurantName"].ToString();
              oneRestaurant.RestaurantLink = reader["RestaurantLink"].ToString();
              oneRestaurant.Country = reader["Country"].ToString();
              oneRestaurant.City = reader["City"].ToString();
              oneRestaurant.Address = reader["Address"].ToString();

              listAllRestaurant.Add(oneRestaurant);
            }
          }
          conn.Close();
        }
      }

      // Якщо записів немає — повернути службове повідомлення
      if (listAllRestaurant.Count == 0) {
        Restaurant noRestaurant = new Restaurant();
        noRestaurant.RestaurantId = 0;
        noRestaurant.Message = NamesMy.NoDataNames.NoDataInRestaurants; // стандартне службове повідомлення
        listAllRestaurant.Add(noRestaurant);
      }
      return listAllRestaurant;
    }


    // === Отримати один ресторан за його ідентифікатором ==========================
    public Restaurant SelectedRestaurantByRestaurantId(int RestaurantId) {
      string SqlString = "SELECT * FROM Restaurants WHERE RestaurantId=@RestaurantId";

      Restaurant oneRestaurant = new Restaurant();

      using (SqlConnection conn = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
          cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);
          conn.Open();

          using (SqlDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              oneRestaurant.RestaurantId = Convert.ToInt32(reader["RestaurantId"]);
              oneRestaurant.RestaurantName = reader["RestaurantName"].ToString();
              oneRestaurant.RestaurantLink = reader["RestaurantLink"].ToString();
              oneRestaurant.Country = reader["Country"].ToString();
              oneRestaurant.City = reader["City"].ToString();
              oneRestaurant.Address = reader["Address"].ToString();
            }
          }
          conn.Close();
        }
      }
      return oneRestaurant;
    }

    // === Оновити дані про ресторан ==============================================
    public void UpdateRestaurant(string RestaurantName, string RestaurantLink, string Country, string City, string Address, int RestaurantId) {
      string SqlString = "UPDATE Restaurants SET " +
                         "RestaurantName=@RestaurantName, " +
                         "RestaurantLink=@RestaurantLink, " +
                         "Country=@Country, City=@City, Address=@Address " +
                         "WHERE RestaurantId=@RestaurantId";

      using (SqlConnection conn = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("@RestaurantName", RestaurantName);
          cmd.Parameters.AddWithValue("@RestaurantLink", RestaurantLink);
          cmd.Parameters.AddWithValue("@Country", Country);
          cmd.Parameters.AddWithValue("@City", City);
          cmd.Parameters.AddWithValue("@Address", Address);
          cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);

          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    // === Видалити ресторан за ідентифікатором ===================================
    public void DeleteRestaurantByRestaurantId(int RestaurantId) {
      string SqlString = "DELETE FROM Restaurants WHERE RestaurantId=@RestaurantId";

      using (SqlConnection conn = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
          cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }



  }
}


/// <summary>
/// Клас Restaurant — модель для таблиці Restaurants.
/// Містить основні атрибути ресторану з додатковими службовими полями Number та Message.
/// </summary>
public class Restaurant {
  // === Приватні поля ==================================================
  private int _Number;            // Порядковий номер запису у відображенні
  private int _RestaurantId;      // Ідентифікатор ресторану (PK)
  private string _RestaurantName; // Назва ресторану
  private string _RestaurantLink; // Посилання на сторінку ресторану
  private string _Country;        // Країна, де розташований ресторан
  private string _City;           // Місто
  private string _Address;        // Повна адреса ресторану
  private string _Message;        // Службове повідомлення (стан, коментар тощо)

  // === Конструктор за замовчуванням ==================================
  public Restaurant() {
    _Number = 0;
    _RestaurantId = 0;
    _RestaurantName = string.Empty;
    _RestaurantLink = string.Empty;
    _Country = string.Empty;
    _City = string.Empty;
    _Address = string.Empty;
    _Message = string.Empty;
  }

  // === Властивості (Properties) ======================================

  /// <summary>Порядковий номер запису (службове поле для інтерфейсу)</summary>
  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }

  /// <summary>Унікальний ідентифікатор ресторану (PRIMARY KEY)</summary>
  public int RestaurantId {
    set { _RestaurantId = value; }
    get { return _RestaurantId; }
  }

  /// <summary>Назва ресторану</summary>
  public string RestaurantName {
    set { _RestaurantName = value; }
    get { return _RestaurantName; }
  }

  /// <summary>Посилання на сторінку ресторану або його веб-ресурс</summary>
  public string RestaurantLink {
    set { _RestaurantLink = value; }
    get { return _RestaurantLink; }
  }

  /// <summary>Країна розташування ресторану</summary>
  public string Country {
    set { _Country = value; }
    get { return _Country; }
  }

  /// <summary>Місто, у якому знаходиться ресторан</summary>
  public string City {
    set { _City = value; }
    get { return _City; }
  }

  /// <summary>Адреса ресторану (вулиця, будинок тощо)</summary>
  public string Address {
    set { _Address = value; }
    get { return _Address; }
  }

  /// <summary>Службове повідомлення (для логів, звітів, коментарів)</summary>
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
