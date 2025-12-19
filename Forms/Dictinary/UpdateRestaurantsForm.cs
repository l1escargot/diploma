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
  public partial class UpdateRestaurantsForm : Form {
    private int _RestaurantId = 0;
    private Restaurant _selectedRestaurant = new Restaurant();
    private RestaurantsProvider _RestaurantsRestaurants = new RestaurantsProvider();
    private ValidationMy _validation = new ValidationMy();

    public UpdateRestaurantsForm(int RestaurantId) {
      InitializeComponent();
      _RestaurantId = RestaurantId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _RestaurantsRestaurants.UpdateRestaurant(RestaurantNameTBox.Text, RestaurantLinkTBox.Text, CountryTBox.Text, CityTBox.Text, AddressTBox.Text, _RestaurantId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _RestaurantsRestaurants.DeleteRestaurantByRestaurantId(_RestaurantId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedRestaurant = _RestaurantsRestaurants.SelectedRestaurantByRestaurantId(_RestaurantId);
      RestaurantNameTBox.Text = _selectedRestaurant.RestaurantName;
      RestaurantLinkTBox.Text = _selectedRestaurant.RestaurantLink;
      CountryTBox.Text = _selectedRestaurant.Country;
      AddressTBox.Text = _selectedRestaurant.Address;
      CityTBox.Text = _selectedRestaurant.City;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(RestaurantNameTBox.Text)) {
        RestaurantNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RestaurantNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(RestaurantLinkTBox.Text)) {
        RestaurantLinkValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RestaurantLinkValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(CountryTBox.Text)) {
        CountryValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CountryValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(CityTBox.Text)) {
        CityValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CityValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }



  }
}
