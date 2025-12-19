using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRecApp.Providers {
  internal class CustomersProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertCustomers(string FirstName, string LastName, string Phone, string Address, string Email) {
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

    public Customers SelectedCustomersByCustomerId(int CustomerId) {
      int i = 0;
      Customers selectedCustomers = new Customers();
      string sqlExpression = "SELECT * FROM Customers WHERE CustomerId=" + CustomerId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            selectedCustomers.Number = ++i;
            selectedCustomers.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            selectedCustomers.LastName = reader["LastName"].ToString();
            selectedCustomers.FirstName = reader["FirstName"].ToString();
            selectedCustomers.Phone = reader["Phone"].ToString();
            selectedCustomers.Address = reader["Address"].ToString();
            selectedCustomers.Email = reader["Email"].ToString();
          }
        }
        reader.Close();
      }
      return selectedCustomers;
    }

    public List<Customers> GetAllCustomers() {
      int i = 0;
      List<Customers> CustomersList = new List<Customers>();
      string sqlExpression = "SELECT * FROM Customers";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            Customers selectedCustomers = new Customers();
            selectedCustomers.Number = ++i;
            selectedCustomers.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            selectedCustomers.LastName = reader["LastName"].ToString();
            selectedCustomers.FirstName = reader["FirstName"].ToString();
            selectedCustomers.FullName = selectedCustomers.LastName + " " + selectedCustomers.FirstName;
            selectedCustomers.Phone = reader["Phone"].ToString();
            selectedCustomers.Address = reader["Address"].ToString();
            selectedCustomers.Email = reader["Email"].ToString();
            CustomersList.Add(selectedCustomers);
          }
        }
        reader.Close();
      }
      if (CustomersList.Count == 0) {
        Customers noCustomers = new Customers();
        noCustomers.CustomerId = 0;
        noCustomers.Message = NamesMy.NoDataNames.NoDataInCustomers;
        CustomersList.Add(noCustomers);
      }

      return CustomersList;
    }


    public void UpdateCustomers(string FirstName, string LastName, string Phone, string Address, string Email, int CustomerId) {
      using (SqlConnection con = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand("UPDATE Customers SET FirstName = @FirstName, LastName = @LastName,  " +
          "Phone = @Phone, Address=@Address, Email=@Email  " +
          " WHERE CustomerId = @CustomerId", con)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("@LastName", LastName);
          cmd.Parameters.AddWithValue("@FirstName", FirstName);
          cmd.Parameters.AddWithValue("@Phone", Phone);
          cmd.Parameters.AddWithValue("@Address", Address);
          cmd.Parameters.AddWithValue("@Email", Email);
          cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
          con.Open();
          int rowsAffected = cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }

    public void DeleteCustomersByCustomerId(int CustomerId) {
      string sqlExpression = "DELETE  FROM Customers WHERE CustomerId=" + CustomerId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        command.ExecuteNonQuery();
        connection.Close();
      }
    }



  }
}


public class Customers {
  private int _Number;
  private int _CustomerId;
  private string _FirstName;
  private string _LastName;
  public string _FullName;
  private string _Phone;
  private string _Address;
  private string _Email;
  private string _Message;

  public Customers() {
    _Number = 0;
    _CustomerId = 0;
    _FirstName = String.Empty;
    _LastName = String.Empty;
    _FullName = String.Empty;
    _Phone = String.Empty;
    _Address = String.Empty;
    _Email = String.Empty;
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int CustomerId {
    set { _CustomerId = value; }
    get { return _CustomerId; }
  }
  public string FirstName {
    set { _FirstName = value; }
    get { return _FirstName; }
  }
  public string LastName {
    set { _LastName = value; }
    get { return _LastName; }
  }
  public string FullName {
    set { _FullName = value; }
    get { return _FullName; }
  }
  public string Phone {
    set { _Phone = value; }
    get { return _Phone; }
  }
  public string Address {
    set { _Address = value; }
    get { return _Address; }
  }
  public string Email {
    set { _Email = value; }
    get { return _Email; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}

