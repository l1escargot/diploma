using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationsPlatformsApp.Providers {
  class UsersProvider {
    private EncryptData _encryptData = new EncryptData();
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertUsers(string FirstName, string LastName, string UsersName, string UsersPassword,
   int RoleId, string Description, string Email) {
      SqlConnection connection = new SqlConnection(_ConnString);
      string query = "INSERT into Users (FirstName, LastName, UsersName, UsersPassword, RoleId, Description, Email) " +
        "VALUES (@FirstName, @LastName, @UsersName, @UsersPassword, @RoleId, @Description, @Email)";
      SqlCommand command = new SqlCommand(query, connection);
      command.Parameters.AddWithValue("@FirstName", FirstName);
      command.Parameters.AddWithValue("@LastName", LastName);
      command.Parameters.AddWithValue("@UsersName", UsersName);
      command.Parameters.AddWithValue("@UsersPassword", _encryptData.Encrypt(UsersPassword));
      command.Parameters.AddWithValue("@RoleId", RoleId);
      command.Parameters.AddWithValue("@Description", Description);
      command.Parameters.AddWithValue("@Email", Email);
      connection.Open();
      command.ExecuteNonQuery();
      connection.Close();
    }

    public List<Users> GetAllUsers() {
      int i = 0;
      List<Users> UsersList = new List<Users>();
      string sqlExpression = "SELECT * FROM Users ORDER BY LastName ASC";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            Users oneUsers = new Users();
            oneUsers.Number = ++i;
            oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
            oneUsers.FirstName = reader["FirstName"].ToString();
            oneUsers.LastName = reader["LastName"].ToString();
            oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
            oneUsers.UsersName = reader["UsersName"].ToString();
            oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
            oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
            oneUsers.RoleName = GetRoleName(oneUsers.RoleId);
            oneUsers.Description = reader["Description"].ToString();
            oneUsers.Email = reader["Email"].ToString();
            UsersList.Add(oneUsers);
          }
        }
        reader.Close();
      }
      if (UsersList.Count == 0) {
        Users noUsers = new Users();
        noUsers.UsersId = 0;
        noUsers.Message = NamesMy.NoDataNames.NoDataInUsers;
        UsersList.Add(noUsers);
      }

      return UsersList;
    }


    private string GetRoleName(int RoleId) {
      RoleApp roleApp = new RoleApp();
      for (int i = 0; i < roleApp.GetRoleList().Count(); i++) {
        if (RoleId == roleApp.GetRoleList()[i].RoleId) {
          return roleApp.GetRoleList()[i].RoleName;
        }
      }
      return "";
    }

    public Users SelectedUsersByUsersId(int UsersId) {
      Users oneUsers = new Users();
      string sqlExpression = "SELECT * FROM Users WHERE UsersId=" + UsersId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
            oneUsers.FirstName = reader["FirstName"].ToString();
            oneUsers.LastName = reader["LastName"].ToString();
            oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
            oneUsers.UsersName = reader["UsersName"].ToString();
            oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
            oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
            oneUsers.RoleName = GetRoleName(oneUsers.RoleId);
            oneUsers.Description = reader["Description"].ToString();
            oneUsers.Email = reader["Email"].ToString();
          }
        }
        reader.Close();
      }
      return oneUsers;
    }

    public List<Users> GetAllUsersListForCBox() {
      int i = 0;
      List<Users> UsersList = new List<Users>();
      string sqlExpression = "SELECT UsersId, UsersName, UsersPassword FROM Users ORDER BY UsersName ASC";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            Users oneUsers = new Users();
            oneUsers.UsersId = Convert.ToInt32(reader["UsersId"].ToString());
            oneUsers.UsersName = reader["UsersName"].ToString();
            oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
            UsersList.Add(oneUsers);
          }
        }
        reader.Close();
      }
      if (UsersList.Count == 0) {
        Users noUsers = new Users();
        noUsers.UsersId = 0;
        noUsers.Message = NamesMy.NoDataNames.NoDataInUsers;
        UsersList.Add(noUsers);
      }

      return UsersList;
    }

    public List<Users> SelectedUsersByUsersNameAndUsersPassword(string UsersName, string UsersPassword) {
      List<Users> UsersList = new List<Users>();
      string sqlExpression = "SELECT * FROM Users WHERE UsersName='" + UsersName + "' AND UsersPassword='" + _encryptData.Encrypt(UsersPassword) + "'";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            Users oneUsers = new Users();
            oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
            oneUsers.FirstName = reader["FirstName"].ToString();
            oneUsers.LastName = reader["LastName"].ToString();
            oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
            oneUsers.UsersName = reader["UsersName"].ToString();
            oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
            oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
            oneUsers.RoleName = GetRoleName(oneUsers.RoleId);
            oneUsers.Description = reader["Description"].ToString();
            UsersList.Add(oneUsers);
          }
        }
        reader.Close();
      }
      return UsersList;
    }

    public void UpdateUsers(string FirstName, string LastName, string UsersName, string UsersPassword,
   int RoleId, string Description, string Email, int UsersId) {
      using (SqlConnection con = new SqlConnection(_ConnString)) {
        using (SqlCommand cmd = new SqlCommand("UPDATE Users SET FirstName = @FirstName, LastName = @LastName,  " +
          "UsersName = @UsersName, UsersPassword=@UsersPassword, RoleId=@RoleId, Description=@Description, Email=@Email  " +
          " WHERE UsersId = @UsersId", con)) {
          cmd.Parameters.AddWithValue("FirstName", FirstName);
          cmd.Parameters.AddWithValue("LastName", LastName);
          cmd.Parameters.AddWithValue("UsersName", UsersName);
          cmd.Parameters.AddWithValue("UsersPassword", _encryptData.Encrypt(UsersPassword));
          cmd.Parameters.AddWithValue("RoleId", RoleId);
          cmd.Parameters.AddWithValue("Description", Description);
          cmd.Parameters.AddWithValue("Email", Email);
          cmd.Parameters.AddWithValue("UsersId", UsersId);
          con.Open();
          int rowsAffected = cmd.ExecuteNonQuery();
          con.Close();
        }
      }
    }

    public void DeleteUsersByUsersId(int UsersId) {
      string sqlExpression = "DELETE  FROM Users WHERE UsersId=" + UsersId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        command.ExecuteNonQuery();
        connection.Close();
      }
    }


    public int GetCountUsers() {
      Users oneUsers = new Users();
      string sqlExpression = "SELECT COUNT(*) FROM Users";
      int count = 0;

      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        connection.Open();
        count = (int)command.ExecuteScalar();

      }
      return count;
    }


  }
}


public class Users {
  private int _Number;
  private int _UsersId;
  private string _FirstName;
  private string _LastName;
  private string _UsersName;
  private string _FIO;
  private string _UsersPassword;
  private int _RoleId;
  private string _RoleName;
  private string _Email;
  private string _Description;
  private int _GroupsId;
  private string _Message;

  public Users() {
    _UsersId = 0;
    _FirstName = String.Empty;
    _LastName = String.Empty;
    _UsersName = String.Empty;
    _FIO = String.Empty;
    _UsersPassword = String.Empty;
    _RoleId = 0;
    _Email = String.Empty;
    _Description = String.Empty;
    _GroupsId = 0;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int UsersId {
    set { _UsersId = value; }
    get { return _UsersId; }
  }
  public string FirstName {
    set { _FirstName = value; }
    get { return _FirstName; }
  }
  public string LastName {
    set { _LastName = value; }
    get { return _LastName; }
  }
  public string FIO {
    set { _FIO = value; }
    get { return _FIO; }
  }
  public string UsersName {
    set { _UsersName = value; }
    get { return _UsersName; }
  }
  public string UsersPassword {
    set { _UsersPassword = value; }
    get { return _UsersPassword; }
  }
  public int RoleId {
    set { _RoleId = value; }
    get { return _RoleId; }
  }
  public string RoleName {
    set { _RoleName = value; }
    get { return _RoleName; }
  }
  public string Email {
    set { _Email = value; }
    get { return _Email; }
  }
  public string Description {
    set { _Description = value; }
    get { return _Description; }
  }
  public int GroupsId {
    set { _GroupsId = value; }
    get { return _GroupsId; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}

