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
  public partial class UpdateCustomersForm : Form {
    private int _CustomerId = 0;
    private Customers _selectedCustomers = new Customers();
    private CustomersProvider _CustomersCustomers = new CustomersProvider();
    private ValidationMy _validation = new ValidationMy();

    public UpdateCustomersForm(int CustomerId) {
      InitializeComponent();
      _CustomerId = CustomerId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _CustomersCustomers.UpdateCustomers(FirstNameTBox.Text, LastNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text, _CustomerId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _CustomersCustomers.DeleteCustomersByCustomerId(_CustomerId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedCustomers = _CustomersCustomers.SelectedCustomersByCustomerId(_CustomerId);
      LastNameTBox.Text = _selectedCustomers.LastName;
      FirstNameTBox.Text = _selectedCustomers.FirstName;
      PhoneTBox.Text = _selectedCustomers.Phone;
      AddressTBox.Text = _selectedCustomers.Address;
      EmailTBox.Text = _selectedCustomers.Email;
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
