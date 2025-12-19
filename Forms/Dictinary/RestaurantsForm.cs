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
  public partial class RestaurantsForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _validation = new ValidationMy();
    RestaurantsProvider _RestaurantsProvider = new RestaurantsProvider();
    List<Restaurant> _RestaurantsList = new List<Restaurant>();

    public RestaurantsForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _RestaurantsProvider.InsertRestaurant(RestaurantNameTBox.Text, RestaurantLinkTBox.Text, CountryTBox.Text, CityTBox.Text, AddressTBox.Text);
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

    private void RestaurantsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && RestaurantsGridView[0, e.RowIndex].Value.ToString() != _RestaurantsList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateRestaurantsForm updateRestaurantsForm = new UpdateRestaurantsForm(Convert.ToInt32(RestaurantsGridView[0, e.RowIndex].Value.ToString()));
        updateRestaurantsForm.ShowDialog();
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (RestaurantsGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = RestaurantsGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _RestaurantsList = _RestaurantsProvider.GetAllRestaurant();
        LoadDataInRestaurantsGridView(_RestaurantsList);
        if (_selectedRowIndex == RestaurantsGridView.Rows.Count) {
          _selectedRowIndex = RestaurantsGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          RestaurantsGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          RestaurantsGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInRestaurantsGridView(List<Restaurant> RestaurantsList) {
      RestaurantsGridView.DataSource = null;
      RestaurantsGridView.Columns.Clear();
      RestaurantsGridView.AutoGenerateColumns = false;
      RestaurantsGridView.RowHeadersVisible = false;

      RestaurantsGridView.DataSource = RestaurantsList;

      if (RestaurantsList.Count > 0) {
        if (RestaurantsList[0].Message == NamesMy.NoDataNames.NoDataInRestaurants) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = RestaurantsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          RestaurantsGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn RestaurantIdColumn = new DataGridViewTextBoxColumn();
          RestaurantIdColumn.DataPropertyName = "RestaurantId";
          RestaurantsGridView.Columns.Add(RestaurantIdColumn);
          RestaurantsGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          RestaurantsGridView.Columns.Add(numberColumn);

          DataGridViewColumn RestaurantName = new DataGridViewTextBoxColumn();
          RestaurantName.HeaderText = "Ресторан";
          RestaurantName.DataPropertyName = "RestaurantName";
          RestaurantName.Width = 200;
          RestaurantsGridView.Columns.Add(RestaurantName);

          DataGridViewColumn CountryColumn = new DataGridViewTextBoxColumn();
          CountryColumn.HeaderText = "Країна";
          CountryColumn.DataPropertyName = "Country";
          CountryColumn.Width = 150;
          RestaurantsGridView.Columns.Add(CountryColumn);

          DataGridViewColumn CityColumn = new DataGridViewTextBoxColumn();
          CityColumn.HeaderText = "Місто";
          CityColumn.DataPropertyName = "City";
          CityColumn.Width = 150;
          RestaurantsGridView.Columns.Add(CityColumn);

        }
        for (int i = 0; i < RestaurantsGridView.Columns.Count; i++) {
          RestaurantsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      RestaurantNameTBox.Text = String.Empty;
      RestaurantLinkTBox.Text = String.Empty;
      CountryTBox.Text = String.Empty;
      CityTBox.Text = String.Empty;
      AddressTBox.Text = String.Empty;
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
