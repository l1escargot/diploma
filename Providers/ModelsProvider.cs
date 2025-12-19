using RecommendationsPlatformsApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationsPlatformsApp.Providers {
  public class ModelsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];
    public void InsertModels(string ModelsName, string ModelsFileModel) {
      SqlConnection connection = new SqlConnection(_ConnString);
      string query = "INSERT into Models (ModelsName, CreateDate, ModelsFileModel) " +
        "VALUES (@ModelsName, @CreateDate, @ModelsFileModel)";
      SqlCommand command = new SqlCommand(query, connection);
      command.Parameters.AddWithValue("@ModelsName", ModelsName);
      command.Parameters.AddWithValue("@CreateDate", DateTime.Now);
      command.Parameters.AddWithValue("@ModelsFileModel", ModelsFileModel);
      connection.Open();
      command.ExecuteNonQuery();
      connection.Close();
    }

    public Models SelectedModelsByModelsId(int ModelsId) {
      int i = 0;
      Models selectedModels = new Models();
      string sqlExpression = "SELECT * FROM Models WHERE ModelsId=" + ModelsId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            selectedModels.Number = ++i;
            selectedModels.ModelsId = Convert.ToInt32(reader["ModelsId"]);
            selectedModels.ModelsName = reader["ModelsName"].ToString();
            selectedModels.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
            selectedModels.ModelsFileModel = reader["ModelsFileModel"].ToString();
          }
        }
        reader.Close();
      }
      return selectedModels;
    }


    public List<Models> GetAllModels() {
      int i = 0;
      List<Models> ModelsList = new List<Models>();
      string sqlExpression = "SELECT * FROM Models ";
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows) {
          while (reader.Read()) {
            Models selectedModels = new Models();
            selectedModels.Number = ++i;
            selectedModels.ModelsId = Convert.ToInt32(reader["ModelsId"]);
            selectedModels.ModelsName = reader["ModelsName"].ToString();
            selectedModels.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
            selectedModels.ModelsFileModel = reader["ModelsFileModel"].ToString();
            ModelsList.Add(selectedModels);
          }
        }
        reader.Close();
      }
      if (ModelsList.Count == 0) {
        Models noModels = new Models();
        noModels.ModelsId = 0;
        noModels.Message = NamesMy.NoDataNames.NoDataInModels;
        ModelsList.Add(noModels);
      }
      return ModelsList;
    }


    public void DeleteModelsByModelsId(int ModelsId) {
      string sqlExpression = "DELETE  FROM Models WHERE ModelsId=" + ModelsId.ToString();
      using (SqlConnection connection = new SqlConnection(_ConnString)) {
        connection.Open();
        SqlCommand command = new SqlCommand(sqlExpression, connection);
        command.ExecuteNonQuery();
        connection.Close();
      }
    }


  }
}



public class Models {
  private int _Number;
  private int _ModelsId;
  private string _ModelsName;
  private DateTime _CreateDate;
  private string _ModelsFileModel;
  private string _Message;

  public Models() {
    _Number = 0;
    _ModelsId = 0;
    _ModelsFileModel = String.Empty;
    _CreateDate = new DateTime();
    _ModelsName = String.Empty;
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int ModelsId {
    set { _ModelsId = value; }
    get { return _ModelsId; }
  }
  public string ModelsFileModel {
    set { _ModelsFileModel = value; }
    get { return _ModelsFileModel; }
  }
  public DateTime CreateDate {
    set { _CreateDate = value; }
    get { return _CreateDate; }
  }
  public string ModelsName {
    set { _ModelsName = value; }
    get { return _ModelsName; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}

