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
  public partial class RestRatingsForm : Form {
    private int _selectedRowIndex = 0;
    private ValidationMy _validation = new ValidationMy();
    private RestRatingsProvider _RestRatingProvider = new RestRatingsProvider();
    private List<RestRating> _RestRatingList = new List<RestRating>();
    private RestaurantsProvider _RestaurantsProvider = new RestaurantsProvider();
    private List<Restaurant> _RestaurantsList = new List<Restaurant>();
    private CustomersProvider _CustomersProvider = new CustomersProvider();
    private List<Customers> _CustomersList = new List<Customers>();


    public RestRatingsForm() {
      InitializeComponent();
      LoadAllDate();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _RestRatingProvider.InsertRestRating(Convert.ToInt32(CustomerCBox.SelectedValue), Convert.ToInt32(RestaurantCBox.SelectedValue), 
          Convert.ToDouble(AvgRatingTBox.Text), Convert.ToDouble(RatingTBox.Text));
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

    private void RestRatingsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && RestRatingsGridView[0, e.RowIndex].Value.ToString() != _RestRatingList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateRestRatingForm updateRestRatingForm = new UpdateRestRatingForm(Convert.ToInt32(RestRatingsGridView[0, e.RowIndex].Value.ToString()));
        updateRestRatingForm.ShowDialog();
        DataLoad();
      }
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
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (RestRatingsGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = RestRatingsGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _RestRatingList = _RestRatingProvider.GetAllRestRatings();
        LoadDataInRestRatingsGridView(_RestRatingList);
        if (_selectedRowIndex == RestRatingsGridView.Rows.Count) {
          _selectedRowIndex = RestRatingsGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          RestRatingsGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          RestRatingsGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInRestRatingsGridView(List<RestRating> RestRatingList) {
      RestRatingsGridView.DataSource = null;
      RestRatingsGridView.Columns.Clear();
      RestRatingsGridView.AutoGenerateColumns = false;
      RestRatingsGridView.RowHeadersVisible = false;

      RestRatingsGridView.DataSource = RestRatingList;

      if (RestRatingList.Count > 0) {
        if (RestRatingList[0].Message == NamesMy.NoDataNames.NoDataInRestRatings) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = RestRatingsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          RestRatingsGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn RestRatingIdColumn = new DataGridViewTextBoxColumn();
          RestRatingIdColumn.DataPropertyName = "RestRatingId";
          RestRatingsGridView.Columns.Add(RestRatingIdColumn);
          RestRatingsGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = 50;
          RestRatingsGridView.Columns.Add(numberColumn);

          DataGridViewColumn RestaurantNameColumn = new DataGridViewTextBoxColumn();
          RestaurantNameColumn.HeaderText = "Ресторан";
          RestaurantNameColumn.DataPropertyName = "RestaurantName";
          RestaurantNameColumn.Width = 200;
          RestRatingsGridView.Columns.Add(RestaurantNameColumn);

          DataGridViewColumn FullNameColumn = new DataGridViewTextBoxColumn();
          FullNameColumn.HeaderText = "Клієнт";
          FullNameColumn.DataPropertyName = "FullName";
          FullNameColumn.Width = 150;
          RestRatingsGridView.Columns.Add(FullNameColumn);

          DataGridViewColumn AvgRatingColumn = new DataGridViewTextBoxColumn();
          AvgRatingColumn.HeaderText = "Середня оцінка";
          AvgRatingColumn.DataPropertyName = "AvgRating";
          AvgRatingColumn.Width = 130;
          AvgRatingColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          RestRatingsGridView.Columns.Add(AvgRatingColumn);

          DataGridViewColumn RatingColumn = new DataGridViewTextBoxColumn();
          RatingColumn.HeaderText = "Рейтинг";
          RatingColumn.DataPropertyName = "Rating";
          RatingColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          RatingColumn.Width = 80;
          RestRatingsGridView.Columns.Add(RatingColumn);


        }
        for (int i = 0; i < RestRatingsGridView.Columns.Count; i++) {
          RestRatingsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      CustomerCBox.SelectedItem = 0;
      RestaurantCBox.SelectedItem = 0;
      AvgRatingTBox.Text = "0";
      RatingTBox.Text = "0";
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
