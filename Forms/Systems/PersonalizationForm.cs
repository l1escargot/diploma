using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Providers;
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
  public partial class PersonalizationForm : Form {
    private int _UserId = 0;
    private Users _selectedUser = new Users();
    private UsersProvider _UserProvider = new UsersProvider();
    private ValidationMy _validation = new ValidationMy();

    public PersonalizationForm(int UserId) {
      InitializeComponent();
      if (UserId == 0) {
        this.Text = "Реєстрація";
      } else {
        _UserId = UserId;
        LoadAllDate();
      }
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        if (_UserId != 0) {
          _UserProvider.UpdateUsers(FirstNameTBox.Text, LastNameTBox.Text, UserLoginTbx.Text, PasswordTbx.Text,
            _selectedUser.RoleId, DescriptionTbx.Text, EmailTBox.Text, _UserId);
        } else {
          int usersCount = _UserProvider.GetCountUsers();
          if (usersCount > 0) {
            _UserProvider.InsertUsers(FirstNameTBox.Text, LastNameTBox.Text, UserLoginTbx.Text, PasswordTbx.Text,
                2, DescriptionTbx.Text, EmailTBox.Text);
          } else {
            _UserProvider.InsertUsers(FirstNameTBox.Text, LastNameTBox.Text, UserLoginTbx.Text, PasswordTbx.Text,
                1, DescriptionTbx.Text, EmailTBox.Text);
          }
        }
        this.Close();
      }
    }


    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedUser = _UserProvider.SelectedUsersByUsersId(_UserId);
      FirstNameTBox.Text = _selectedUser.FirstName;
      LastNameTBox.Text = _selectedUser.LastName;
      UserLoginTbx.Text = _selectedUser.UsersName;
      EmailTBox.Text = _selectedUser.Email;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(FirstNameTBox.Text)) {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(LastNameTBox.Text)) {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsPasswordMatch(PasswordTbx.Text, RePasswordTbx.Text)) {
        PasswordAndRePasswordDontMatchLbl.Visible = false;
      } else {
        PasswordAndRePasswordDontMatchLbl.Visible = true;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(UserLoginTbx.Text)) {
        UserLoginValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UserLoginValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(PasswordTbx.Text)) {
        PasswordValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PasswordValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(RePasswordTbx.Text)) {
        RePasswordValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RePasswordValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      if (_validation.IsValidEmail(EmailTBox.Text)) {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }

      return isCorrect;
    }

  }
}
