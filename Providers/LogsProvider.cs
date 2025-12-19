using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationsPlatformsApp.Providers {
  class LogsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];


    public void InsertLogs(int UsersId, string EventNameShow, DateTime EventDate) {
      SqlConnection connection = new SqlConnection(_ConnString);
      string query = "INSERT into Logs (UsersId, EventNameShow, EventDate) " +
        "VALUES (@UsersId, @EventNameShow, @EventDate)";
      SqlCommand command = new SqlCommand(query, connection);
      command.Parameters.AddWithValue("@UsersId", UsersId);
      command.Parameters.AddWithValue("@EventNameShow", EventNameShow);
      command.Parameters.AddWithValue("@EventDate", EventDate.ToString("yyyy-MM-dd HH:mm:ss"));
      connection.Open();
      command.ExecuteNonQuery();
      connection.Close();
    }


    public List<Logs> GetAllLogs() {
      int i = 0;
      List<Logs> listAllLogs = new List<Logs>();
      string sqlExpression = "SELECT Logs.LogsId, Logs.UsersId, Logs.EventNameShow, Logs.EventDate, Users.UsersName " +
      "FROM Logs INNER JOIN Users ON Users.UsersId = Logs.UsersId  ORDER BY Logs.EventDate DESC";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) // если есть данные
        {
          // выводим названия столбцов
          while (reader.Read()) // построчно считываем данные
            {
            Logs oneLogs = new Logs();
            oneLogs.Number = ++i;
            oneLogs.LogsId = Convert.ToInt32(reader["LogsId"]);
            oneLogs.UsersId = Convert.ToInt32(reader["UsersId"]);
            oneLogs.EventNameShow = reader["EventNameShow"].ToString();
            oneLogs.EventDate = Convert.ToDateTime(reader["EventDate"]);
            oneLogs.UsersName = reader["UsersName"].ToString();
            listAllLogs.Add(oneLogs);
          }
        }
        reader.Close();
      }
      if (listAllLogs.Count == 0) {
        Logs noLogs = new Logs();
        noLogs.LogsId = 0;
        noLogs.Message = NamesMy.NoDataNames.NoDataInLogs;
        listAllLogs.Add(noLogs);
      }
      return listAllLogs;
    }

  }
}



public class Logs {
  private int _Number;
  private int _LogsId;
  private int _UsersId;
  private string _UsersName;
  private string _EventNameShow;
  private DateTime _EventDate;
  private string _Message;

  public Logs() {
    _Number = 0;
    _LogsId = 0;
    _UsersId = 0;
    _UsersName = String.Empty;
    _EventNameShow = String.Empty;
    _EventDate = new DateTime();
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int LogsId {
    set { _LogsId = value; }
    get { return _LogsId; }
  }
  public int UsersId {
    set { _UsersId = value; }
    get { return _UsersId; }
  }
  public string UsersName {
    set { _UsersName = value; }
    get { return _UsersName; }
  }
  public string EventNameShow {
    set { _EventNameShow = value; }
    get { return _EventNameShow; }
  }
  public DateTime EventDate {
    set { _EventDate = value; }
    get { return _EventDate; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
