using RecommendationsPlatformsApp.AppCode;
using RecommendationsPlatformsApp.Forms.Systems;
using RestaurantRecApp.Forms.Controls;
using RestaurantRecApp.Forms.Dictinary;
using RestaurantRecApp.Forms.Systems;
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

namespace RestaurantRecApp {
  public partial class RestaurantMDI : Form {
    GenData _GenData = new GenData();
    public RestaurantMDI() {
      InitializeComponent();
      //_GenData.InsertRandomCustomers();
      //_GenData.InsertRandomRestaurants();
      //_GenData.InsertPatternedRestRatings();
    }

    public void CloseAllWindows() {
      Form[] childArray = this.MdiChildren;
      foreach (Form childForm in childArray) {
        childForm.Close();
      }
    }

    private void формуванняРекомендаційToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      RecommendationsForm recommendationsForm = new RecommendationsForm();
      recommendationsForm.MdiParent = this;
      recommendationsForm.WindowState = FormWindowState.Maximized;
      recommendationsForm.Show();
    }

    private void вихідToolStripMenuItem_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void тренуванняМоделейToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      ModelTrainingForm modelTrainingForm = new ModelTrainingForm();
      modelTrainingForm.MdiParent = this;
      modelTrainingForm.WindowState = FormWindowState.Maximized;
      modelTrainingForm.Show();
    }

    private void клієнтиToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      CustomersForm customersForm = new CustomersForm();
      customersForm.MdiParent = this;
      customersForm.WindowState = FormWindowState.Maximized;
      customersForm.Show();
    }

    private void рестораниToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      RestaurantsForm restaurantsForm = new RestaurantsForm();
      restaurantsForm.MdiParent = this;
      restaurantsForm.WindowState = FormWindowState.Maximized;
      restaurantsForm.Show();
    }

    private void рейтингиToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      RestRatingsForm restRatingsForm = new RestRatingsForm();
      restRatingsForm.MdiParent = this;
      restRatingsForm.WindowState = FormWindowState.Maximized;
      restRatingsForm.Show();
    }

    private void обліковіЗаписиToolStripMenuItem_Click(object sender, EventArgs e) {
      if (LoginForm.CurrentUser.RoleId == 1) {
        CloseAllWindows();
        UsersForm usersForm = new UsersForm();
        usersForm.MdiParent = this;
        usersForm.WindowState = FormWindowState.Maximized;
        usersForm.Show();
      } else {
        MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
      }
    }

    private void подіїToolStripMenuItem_Click(object sender, EventArgs e) {
      if (LoginForm.CurrentUser.RoleId == 1) {
        CloseAllWindows();
        SystemLogForm systemLogForm = new SystemLogForm();
        systemLogForm.MdiParent = this;
        systemLogForm.WindowState = FormWindowState.Maximized;
        systemLogForm.Show();
      } else {
        MessageBox.Show(NamesMy.MessageBoxExaption.YouDontHavePermission);
      }
    }

    private void персоналізаціяToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      PersonalizationForm personalizationForm = new PersonalizationForm(LoginForm.CurrentUser.UsersId);
      personalizationForm.MdiParent = this;
      personalizationForm.WindowState = FormWindowState.Maximized;
      personalizationForm.Show();
    }

    private void змінитиКористувачаToolStripMenuItem_Click(object sender, EventArgs e) {
      // Закриття всіх дочірніх вікон
      CloseAllWindows();
      // Перезапуск програми
      Program.RestartApplication();
    }
  }
}
