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
  public partial class UpdateRestRatingForm : Form {
    private int _RestRatingId = 0;
    private RestRating _selectedRestRating = new RestRating();
    private RestRatingsProvider _RestRatingRestRating = new RestRatingsProvider();
    private RestaurantsProvider _RestaurantsProvider = new RestaurantsProvider();
    private List<Restaurant> _RestaurantsList = new List<Restaurant>();
    private CustomersProvider _CustomersProvider = new CustomersProvider();
    private List<Customers> _CustomersList = new List<Customers>();

    private ValidationMy _validation = new ValidationMy();

    public UpdateRestRatingForm(int RestRatingId) {
      InitializeComponent();
      _RestRatingId = RestRatingId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _RestRatingRestRating.UpdateRestRating(Convert.ToInt32(CustomerCBox.SelectedValue), Convert.ToInt32(RestaurantCBox.SelectedValue),
          Convert.ToDouble(AvgRatingTBox.Text), Convert.ToDouble(RatingTBox.Text), _RestRatingId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _RestRatingRestRating.DeleteRestRatingById(_RestRatingId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _RestaurantsList = _RestaurantsProvider.GetAllRestaurant();
      RestaurantCBox.DataSource = _RestaurantsList;
      RestaurantCBox.ValueMember = "RestaurantId";
      RestaurantCBox.DisplayMember = "RestaurantName";

      _CustomersList = _CustomersProvider.GetAllCustomers();
      CustomerCBox.DataSource = _CustomersList;
      CustomerCBox.ValueMember = "CustomerId";
      CustomerCBox.DisplayMember = "FullName";

      _selectedRestRating = _RestRatingRestRating.SelectedRestRatingById(_RestRatingId);
      RestaurantCBox.SelectedValue = _selectedRestRating.RestaurantId;
      CustomerCBox.SelectedValue = _selectedRestRating.CustomerId;
      AvgRatingTBox.Text = _selectedRestRating.AvgRating.ToString();
      RatingTBox.Text = _selectedRestRating.Rating.ToString();
    }


    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (Convert.ToInt32(CustomerCBox.SelectedValue) > 0) {
        CustomerValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CustomerValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (Convert.ToInt32(RestaurantCBox.SelectedValue) > 0) {
        RestaurantValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RestaurantValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataInThisScope(1.0, 5.0, Convert.ToDouble(AvgRatingTBox.Text))) {
        AvgRatingValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        AvgRatingValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataInThisScope(1.0, 5.0, Convert.ToDouble(RatingTBox.Text))) {
        RatingValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        RatingValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
