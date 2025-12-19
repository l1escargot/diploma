using RecommendationsPlatformsApp.AppCode;
using RestaurantRecApp.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRecApp.Forms.Dictinary {
  public partial class CustomersForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _validation = new ValidationMy();
    CustomersProvider _CustomersProvider = new CustomersProvider();
    List<Customers> _CustomersList = new List<Customers>();

    public CustomersForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _CustomersProvider.InsertCustomers(FirstNameTBox.Text, LastNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text);
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

    private void CustomersGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && CustomersGridView[0, e.RowIndex].Value.ToString() != _CustomersList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateCustomersForm updateCustomersForm = new UpdateCustomersForm(Convert.ToInt32(CustomersGridView[0, e.RowIndex].Value.ToString()));
        updateCustomersForm.ShowDialog();
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (CustomersGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = CustomersGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _CustomersList = _CustomersProvider.GetAllCustomers();
        LoadDataInCustomersGridView(_CustomersList);
        if (_selectedRowIndex == CustomersGridView.Rows.Count) {
          _selectedRowIndex = CustomersGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          CustomersGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          CustomersGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInCustomersGridView(List<Customers> CustomersList) {
      CustomersGridView.DataSource = null;
      CustomersGridView.Columns.Clear();
      CustomersGridView.AutoGenerateColumns = false;
      CustomersGridView.RowHeadersVisible = false;

      CustomersGridView.DataSource = CustomersList;

      if (CustomersList.Count > 0) {
        if (CustomersList[0].Message == NamesMy.NoDataNames.NoDataInCustomers) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = CustomersGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          CustomersGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn CustomerIdColumn = new DataGridViewTextBoxColumn();
          CustomerIdColumn.DataPropertyName = "CustomerId";
          CustomersGridView.Columns.Add(CustomerIdColumn);
          CustomersGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          CustomersGridView.Columns.Add(numberColumn);

          DataGridViewColumn LastNameColumn = new DataGridViewTextBoxColumn();
          LastNameColumn.HeaderText = "Прізвище";
          LastNameColumn.DataPropertyName = "LastName";
          LastNameColumn.Width = 200;
          CustomersGridView.Columns.Add(LastNameColumn);

          DataGridViewColumn FirstNameColumn = new DataGridViewTextBoxColumn();
          FirstNameColumn.HeaderText = "Ім'я";
          FirstNameColumn.DataPropertyName = "FirstName";
          FirstNameColumn.Width = 200;
          CustomersGridView.Columns.Add(FirstNameColumn);

          DataGridViewColumn PhoneColumn = new DataGridViewTextBoxColumn();
          PhoneColumn.HeaderText = "№ телефону";
          PhoneColumn.DataPropertyName = "Phone";
          PhoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          PhoneColumn.Width = 150;
          CustomersGridView.Columns.Add(PhoneColumn);

        }
        for (int i = 0; i < CustomersGridView.Columns.Count; i++) {
          CustomersGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      LastNameTBox.Text = String.Empty;
      FirstNameTBox.Text = String.Empty;
      PhoneTBox.Text = String.Empty;
      EmailTBox.Text = String.Empty;
      AddressTBox.Text = String.Empty;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(LastNameTBox.Text)) {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(FirstNameTBox.Text)) {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(PhoneTBox.Text)) {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }



  }
}
