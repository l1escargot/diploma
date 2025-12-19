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
  public partial class SystemLogForm : Form {
    private int _selectedRowIndex = 0;
    private LogsProvider _LogsProvider = new LogsProvider();
    private List<Logs> _LogsList = new List<Logs>();
    public SystemLogForm() {
      InitializeComponent();
      DataLoad();
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (LogsGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = LogsGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _LogsList = _LogsProvider.GetAllLogs();
        LoadDataInLogsGridView(_LogsList);
        if (_selectedRowIndex == LogsGridView.Rows.Count) {
          _selectedRowIndex = LogsGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          LogsGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          LogsGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInLogsGridView(List<Logs> LogsList) {
      LogsGridView.DataSource = null;
      LogsGridView.Columns.Clear();
      LogsGridView.AutoGenerateColumns = false;
      LogsGridView.RowHeadersVisible = false;

      LogsGridView.DataSource = LogsList;

      if (LogsList.Count > 0) {
        if (LogsList[0].Message == NamesMy.NoDataNames.NoDataInLogs) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = LogsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          LogsGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
          DetailIdColumn.DataPropertyName = "LogsId";
          LogsGridView.Columns.Add(DetailIdColumn);
          LogsGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          LogsGridView.Columns.Add(numberColumn);

          DataGridViewColumn UsersNameColumn = new DataGridViewTextBoxColumn();
          UsersNameColumn.HeaderText = "Користувач";
          UsersNameColumn.DataPropertyName = "UsersName";
          UsersNameColumn.Width = 150;
          LogsGridView.Columns.Add(UsersNameColumn);

          DataGridViewColumn EventNameShowColumn = new DataGridViewTextBoxColumn();
          EventNameShowColumn.HeaderText = "Подія";
          EventNameShowColumn.DataPropertyName = "EventNameShow";
          EventNameShowColumn.Width = 600;
          LogsGridView.Columns.Add(EventNameShowColumn);

          DataGridViewColumn EvendDateColumn = new DataGridViewTextBoxColumn();
          EvendDateColumn.HeaderText = "Дата";
          EvendDateColumn.DataPropertyName = "EventDate";
          EvendDateColumn.Width = NamesMy.SizeOptins.Date;
          LogsGridView.Columns.Add(EvendDateColumn);

        }
        for (int i = 0; i < LogsGridView.Columns.Count; i++) {
          LogsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

  }
}
