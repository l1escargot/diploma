
using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Providers;
using RestaurantRecApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecommendationsPlatformsApp.Forms.Systems {
  public partial class LoginForm : Form {
    public static Users CurrentUser = new Users();

    private UsersProvider _UserProvider = new UsersProvider();
    private ValidationMy _validation = new ValidationMy();
    private LogsProvider _LogsProvider = new LogsProvider();
    private List<Users> _UserList = new List<Users>();
    public LoginForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void SubmitBtn_Click(object sender, EventArgs e) {
      GetSubmitData();
    }

    private void DataLoad() {
      _LogsProvider.InsertLogs(CurrentUser.UsersId, "Користувач ввійшов в систему", DateTime.Now);
      this.Visible = false;
      (new RestaurantMDI()).ShowDialog();
      _LogsProvider.InsertLogs(CurrentUser.UsersId, "Користувач вийшов із системи", DateTime.Now);
      this.Close();
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(UserNameCBox.Text)) {
        UserNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UserNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(UserPasswordTbx.Text)) {
        UserPasswordValidation.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UserPasswordValidation.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

    private void LoadAllDate() {
      _UserList = _UserProvider.GetAllUsersListForCBox();
      UserNameCBox.DataSource = _UserList;
      UserNameCBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      UserNameCBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      UserNameCBox.ValueMember = "UsersId";
      UserNameCBox.DisplayMember = "UsersName";
    }

    private void GetSubmitData() {
      try {
        if (IsDataEnteringCorrect()) {
          List<Users> listUsers = new List<Users>();
          listUsers = _UserProvider.SelectedUsersByUsersNameAndUsersPassword(UserNameCBox.Text, UserPasswordTbx.Text);
          if (listUsers.Count > 0) {
            CurrentUser = listUsers[0];
            DataLoad();
          } else {
            MessageBox.Show(NamesMy.MessageBoxExaption.ThisUserLoginAndUserPasswordNotExistInSystem, NamesMy.MessageBoxExaption.CaptionMessage);
          }
        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }

    private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      PersonalizationForm personalizationForm = new PersonalizationForm(0);
      personalizationForm.Show();
    }
  }
}
