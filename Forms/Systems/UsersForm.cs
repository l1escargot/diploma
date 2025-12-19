using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Forms.Systems;
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
  public partial class UsersForm : Form {
    private int _selectedRowIndex = 0;
    ValidationMy _validation = new ValidationMy();
    private UsersProvider _UserProvider = new UsersProvider();
    private List<Users> _UserList = new List<Users>();
    private RoleApp _RoleApp = new RoleApp();
    private List<Role> _RoleList = new List<Role>();
    public UsersForm() {
      InitializeComponent();
      LoadAllDate();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _UserProvider.InsertUsers(FirstNameTBox.Text, LastNameTBox.Text, UserLoginTbx.Text, PasswordTbx.Text,
          Convert.ToInt32(RolesCBox.SelectedValue), DescriptionTbx.Text, EmailTBox.Text);
        DataLoad();
        ClearAllControls();
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllControls();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (UsersGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = UsersGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _UserList = _UserProvider.GetAllUsers();
        LoadDataInKlientGridView(_UserList);
        if (_selectedRowIndex == UsersGridView.Rows.Count) {
          _selectedRowIndex = UsersGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          UsersGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          UsersGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInKlientGridView(List<Users> UserList) {
      UsersGridView.DataSource = null;
      UsersGridView.Columns.Clear();
      UsersGridView.AutoGenerateColumns = false;
      UsersGridView.RowHeadersVisible = false;

      UsersGridView.DataSource = UserList;

      if (UserList.Count > 0) {
        if (UserList[0].Message == NamesMy.NoDataNames.NoDataInUsers) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = UsersGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          UsersGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn deviseIdColumn = new DataGridViewTextBoxColumn();
          deviseIdColumn.DataPropertyName = "UsersId";
          UsersGridView.Columns.Add(deviseIdColumn);
          UsersGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ п/п";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          UsersGridView.Columns.Add(numberColumn);

          DataGridViewColumn lastNameColumn = new DataGridViewTextBoxColumn();
          lastNameColumn.HeaderText = "Прізвище";
          lastNameColumn.DataPropertyName = "LastName";
          lastNameColumn.Width = NamesMy.SizeOptins.Name;
          UsersGridView.Columns.Add(lastNameColumn);

          DataGridViewColumn firstNameColumn = new DataGridViewTextBoxColumn();
          firstNameColumn.HeaderText = "Ім'я";
          firstNameColumn.DataPropertyName = "FirstName";
          firstNameColumn.Width = NamesMy.SizeOptins.Name;
          UsersGridView.Columns.Add(firstNameColumn);

          DataGridViewColumn UserNameColumn = new DataGridViewTextBoxColumn();
          UserNameColumn.HeaderText = "Логін";
          UserNameColumn.DataPropertyName = "UsersName";
          UserNameColumn.Width = NamesMy.SizeOptins.Name;
          UsersGridView.Columns.Add(UserNameColumn);

          DataGridViewColumn roleNameColumn = new DataGridViewTextBoxColumn();
          roleNameColumn.HeaderText = "Роль";
          roleNameColumn.DataPropertyName = "RoleName";
          roleNameColumn.Width = 90;
          UsersGridView.Columns.Add(roleNameColumn);
        }
        for (int i = 0; i < UsersGridView.Columns.Count; i++) {
          UsersGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      FirstNameTBox.Text = String.Empty;
      LastNameTBox.Text = String.Empty;
      DescriptionTbx.Text = String.Empty;
      UserLoginTbx.Text = String.Empty;
      PasswordTbx.Text = String.Empty;
      RePasswordTbx.Text = String.Empty;
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
        PasswordAndRePasswordDontMatchLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PasswordAndRePasswordDontMatchLbl.Visible = true;
        PasswordAndRePasswordDontMatchLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
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

    private void LoadAllDate() {
      _RoleList = _RoleApp.GetRoleList();
      RolesCBox.DataSource = _RoleList;
      RolesCBox.ValueMember = "RoleId";
      RolesCBox.DisplayMember = "RoleName";
    }

    private void UsersGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && UsersGridView[0, e.RowIndex].Value.ToString() != _UserList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateUsersForm updateUsersForm = new UpdateUsersForm(Convert.ToInt32(UsersGridView[0, e.RowIndex].Value.ToString()));
        updateUsersForm.ShowDialog();
        DataLoad();
      }
    }
  }
}
