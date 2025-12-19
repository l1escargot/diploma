using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRecApp.Providers {
  internal class GenData {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertRandomCustomers() {
      Random rnd = new Random();

      string[] maleFirstNames = { "Іван", "Петро", "Олександр", "Михайло", "Андрій", "Сергій", "Василь", "Дмитро", "Олег", "Юрій", "Роман", "Віталій" };
      string[] femaleFirstNames = { "Олена", "Наталія", "Ірина", "Тетяна", "Марія", "Світлана", "Ганна", "Оксана", "Вікторія", "Катерина", "Людмила", "Алла" };

      string[] maleLastNames = { "Коваль", "Шевченко", "Мельник", "Бондар", "Ткаченко", "Кравець", "Гуменюк", "Петренко", "Савчук", "Лисенко", "Руденко", "Бойко" };
      string[] femaleLastNames = { "Коваль", "Шевченко", "Мельник", "Бондар", "Ткаченко", "Кравець", "Гуменюк", "Петренко", "Савчук", "Лисенко", "Руденко", "Бойко" };

      string[] cities = { "Київ", "Львів", "Харків", "Одеса", "Дніпро", "Полтава", "Чернівці", "Тернопіль", "Рівне", "Житомир" };
      string[] streets = { "Шевченка", "Грушевського", "Соборна", "Лесі Українки", "Мазепи", "Незалежності", "Франка", "Данила Галицького", "Перемоги", "Бандери" };

      for (int i = 0; i < 100; i++) {
        // Випадковий вибір статі
        bool isFemale = rnd.NextDouble() < 0.5;

        string firstName = isFemale
            ? femaleFirstNames[rnd.Next(femaleFirstNames.Length)]
            : maleFirstNames[rnd.Next(maleFirstNames.Length)];

        string lastName = isFemale
            ? femaleLastNames[rnd.Next(femaleLastNames.Length)]
            : maleLastNames[rnd.Next(maleLastNames.Length)];

        // Генерація телефону, адреси, email
        string phone = $"+380{rnd.Next(50, 99)}{rnd.Next(1000000, 9999999)}";
        string city = cities[rnd.Next(cities.Length)];
        string address = $"вул. {streets[rnd.Next(streets.Length)]}, буд. {rnd.Next(1, 150)}, м. {city}";
        string email = $"{firstName.ToLower()}.{lastName.ToLower()}{rnd.Next(1, 100)}@gmail.com";

        // Виклик існуючого методу InsertCustomers
        InsertCustomers(firstName, lastName, phone, address, email);
      }
    }

    private void InsertCustomers(string FirstName, string LastName, string Phone, string Address, string Email) {
      SqlConnection connection = new SqlConnection(_ConnString);
      string query = "INSERT into Customers (FirstName, LastName, Phone, Address, Email) " +
        "VALUES (@FirstName, @LastName, @Phone, @Address, @Email)";
      SqlCommand command = new SqlCommand(query, connection);
      command.Parameters.AddWithValue("@FirstName", FirstName);
      command.Parameters.AddWithValue("@LastName", LastName);
      command.Parameters.AddWithValue("@Phone", Phone);
      command.Parameters.AddWithValue("@Address", Address);
      command.Parameters.AddWithValue("@Email", Email);
      connection.Open();
      command.ExecuteNonQuery();
      connection.Close();
    }

    public void InsertRandomRestaurants() {
      Random rnd = new Random();

      string[] restaurantNames = {
        "Ресторація Галичина", "Київська брама", "Старий Млин", "Bistro Verde", "Смачна Хата",
        "Urban Garden", "Винний Дім", "Панорама", "Villa Italia", "Млинці & Кава",
        "Fusion Grill", "Львівська копальня кави", "Рибний Рай", "Олів'є", "City Food Hall",
        "Gastro Point", "Під Замком", "Морепродукти+", "Стейкхаус 21", "Дім Кулінарії"
    };

      string[] cities = { "Київ", "Львів", "Харків", "Одеса", "Дніпро", "Чернівці", "Полтава", "Тернопіль", "Івано-Франківськ", "Рівне" };
      string[] streets = { "Шевченка", "Грушевського", "Соборна", "Лесі Українки", "Мазепи", "Франка", "Бандери", "Незалежності", "Сагайдачного", "Володимирська" };

      string country = "Україна";

      for (int i = 0; i < restaurantNames.Length; i++) {
        string city = cities[rnd.Next(cities.Length)];
        string street = streets[rnd.Next(streets.Length)];
        string address = $"вул. {street}, буд. {rnd.Next(1, 200)}, м. {city}";
        string link = $"https://{restaurantNames[i].ToLower().Replace(' ', '-')}.ua";

        InsertRestaurant(
            restaurantNames[i],
            link,
            country,
            city,
            address
        );
      }
    }

    private void InsertRestaurant(string RestaurantName, string RestaurantLink, string Country, string City, string Address) {
      string SqlString = "INSERT INTO Restaurants (RestaurantName, RestaurantLink, Country, City, Address) " +
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

    public void InsertPatternedRestRatings() {
      Random rnd = new Random();

      int totalCustomers = 100;  // кількість користувачів
      int totalRestaurants = 20; // кількість ресторанів

      for (int custId = 1; custId <= totalCustomers; custId++) {
        for (int restId = 1; restId <= totalRestaurants; restId++) {
          double baseRating;

          // Формування шаблонів за групами ресторанів
          if (restId <= 5)
            baseRating = 4.5 + rnd.NextDouble() * 0.5; // 4.5–5.0 (топові ресторани)
          else if (restId <= 10)
            baseRating = 3.5 + rnd.NextDouble() * 1.0; // 3.5–4.5 (вище середнього)
          else if (restId <= 15)
            baseRating = 2.5 + rnd.NextDouble() * 1.0; // 2.5–3.5 (посередні)
          else
            baseRating = 1.5 + rnd.NextDouble() * 1.0; // 1.5–2.5 (низькі оцінки)

          // Індивідуальна варіація користувача
          double userShift = (rnd.NextDouble() - 0.5) * 0.4; // ±0.2
          double rating = Math.Max(1.0, Math.Min(5.0, baseRating + userShift));

          // Імітація середнього рейтингу ресторану (приблизно стабільна величина)
          double avgRating = Math.Round(baseRating, 2);

          InsertRestRating(custId, restId, avgRating, Math.Round(rating, 2));
        }
      }
    }

    private void InsertRestRating(int? CustomerId, int RestaurantId, double AvgRating, double Rating) {
      string SqlString = "INSERT INTO RestRatings (CustomerId, RestaurantId, AvgRating, Rating) " +
                         "VALUES (@CustomerId, @RestaurantId, @AvgRating, @Rating)";

      using (SqlConnection conn = new SqlConnection(_ConnString))
      using (SqlCommand cmd = new SqlCommand(SqlString, conn)) {
        cmd.CommandType = CommandType.Text;

        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
        cmd.Parameters.AddWithValue("@RestaurantId", RestaurantId);
        cmd.Parameters.AddWithValue("@AvgRating", AvgRating);
        cmd.Parameters.AddWithValue("@Rating", Rating);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    }

  }
}
