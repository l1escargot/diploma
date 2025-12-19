namespace RestaurantRecApp.Forms.Dictinary {
  partial class RestRatingsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.AddPanel = new System.Windows.Forms.Panel();
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.RatingValiadtionLbl = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.AddBtn = new System.Windows.Forms.Button();
      this.PhoneLbl = new System.Windows.Forms.Label();
      this.RestRatingsGridView = new System.Windows.Forms.DataGridView();
      this.FirstNameLbl = new System.Windows.Forms.Label();
      this.AvgRatingTBox = new System.Windows.Forms.TextBox();
      this.AvgRatingValidationLbl = new System.Windows.Forms.Label();
      this.RestaurantCBox = new System.Windows.Forms.ComboBox();
      this.CustomerValidationLbl = new System.Windows.Forms.Label();
      this.CustomerCBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.RestaurantValiadtionLbl = new System.Windows.Forms.Label();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.RatingTBox = new System.Windows.Forms.TextBox();
      this.AddPanel.SuspendLayout();
      this.AddGBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.RestRatingsGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // AddPanel
      // 
      this.AddPanel.BackColor = System.Drawing.SystemColors.Control;
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(432, 190);
      this.AddPanel.TabIndex = 108;
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.RatingTBox);
      this.AddGBox.Controls.Add(this.RestaurantCBox);
      this.AddGBox.Controls.Add(this.CustomerValidationLbl);
      this.AddGBox.Controls.Add(this.CustomerCBox);
      this.AddGBox.Controls.Add(this.label3);
      this.AddGBox.Controls.Add(this.RestaurantValiadtionLbl);
      this.AddGBox.Controls.Add(this.СomputerLbl);
      this.AddGBox.Controls.Add(this.RatingValiadtionLbl);
      this.AddGBox.Controls.Add(this.AvgRatingValidationLbl);
      this.AddGBox.Controls.Add(this.AvgRatingTBox);
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.ClearBtn);
      this.AddGBox.Controls.Add(this.AddBtn);
      this.AddGBox.Controls.Add(this.PhoneLbl);
      this.AddGBox.Controls.Add(this.FirstNameLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(10, -1);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(416, 174);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // RatingValiadtionLbl
      // 
      this.RatingValiadtionLbl.AutoSize = true;
      this.RatingValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.RatingValiadtionLbl.Location = new System.Drawing.Point(117, 112);
      this.RatingValiadtionLbl.Name = "RatingValiadtionLbl";
      this.RatingValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.RatingValiadtionLbl.TabIndex = 24;
      this.RatingValiadtionLbl.Text = "*";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ExitBtn.Location = new System.Drawing.Point(329, 143);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 23;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // ClearBtn
      // 
      this.ClearBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ClearBtn.Location = new System.Drawing.Point(223, 143);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(81, 25);
      this.ClearBtn.TabIndex = 22;
      this.ClearBtn.Text = "Очистити";
      this.ClearBtn.UseVisualStyleBackColor = false;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.AddBtn.Location = new System.Drawing.Point(120, 143);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 21;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // PhoneLbl
      // 
      this.PhoneLbl.AutoSize = true;
      this.PhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PhoneLbl.Location = new System.Drawing.Point(6, 112);
      this.PhoneLbl.Name = "PhoneLbl";
      this.PhoneLbl.Size = new System.Drawing.Size(64, 16);
      this.PhoneLbl.TabIndex = 3;
      this.PhoneLbl.Text = "Рейтинг:";
      // 
      // RestRatingsGridView
      // 
      this.RestRatingsGridView.AllowUserToAddRows = false;
      this.RestRatingsGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.RestRatingsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.RestRatingsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.RestRatingsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.RestRatingsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RestRatingsGridView.GridColor = System.Drawing.SystemColors.Control;
      this.RestRatingsGridView.Location = new System.Drawing.Point(432, 0);
      this.RestRatingsGridView.MultiSelect = false;
      this.RestRatingsGridView.Name = "RestRatingsGridView";
      this.RestRatingsGridView.ReadOnly = true;
      this.RestRatingsGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RestRatingsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.RestRatingsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.RestRatingsGridView.Size = new System.Drawing.Size(368, 190);
      this.RestRatingsGridView.TabIndex = 109;
      this.RestRatingsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RestRatingsGridView_CellClick);
      // 
      // FirstNameLbl
      // 
      this.FirstNameLbl.AutoSize = true;
      this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FirstNameLbl.Location = new System.Drawing.Point(5, 84);
      this.FirstNameLbl.Name = "FirstNameLbl";
      this.FirstNameLbl.Size = new System.Drawing.Size(111, 16);
      this.FirstNameLbl.TabIndex = 0;
      this.FirstNameLbl.Text = "Середня оцінка:";
      // 
      // AvgRatingTBox
      // 
      this.AvgRatingTBox.BackColor = System.Drawing.SystemColors.Info;
      this.AvgRatingTBox.Location = new System.Drawing.Point(139, 81);
      this.AvgRatingTBox.MaxLength = 1;
      this.AvgRatingTBox.Name = "AvgRatingTBox";
      this.AvgRatingTBox.Size = new System.Drawing.Size(89, 22);
      this.AvgRatingTBox.TabIndex = 3;
      this.AvgRatingTBox.Text = "5";
      this.AvgRatingTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // AvgRatingValidationLbl
      // 
      this.AvgRatingValidationLbl.AutoSize = true;
      this.AvgRatingValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.AvgRatingValidationLbl.Location = new System.Drawing.Point(117, 84);
      this.AvgRatingValidationLbl.Name = "AvgRatingValidationLbl";
      this.AvgRatingValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.AvgRatingValidationLbl.TabIndex = 23;
      this.AvgRatingValidationLbl.Text = "*";
      // 
      // RestaurantCBox
      // 
      this.RestaurantCBox.BackColor = System.Drawing.SystemColors.Info;
      this.RestaurantCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.RestaurantCBox.DropDownWidth = 400;
      this.RestaurantCBox.FormattingEnabled = true;
      this.RestaurantCBox.Location = new System.Drawing.Point(120, 45);
      this.RestaurantCBox.Name = "RestaurantCBox";
      this.RestaurantCBox.Size = new System.Drawing.Size(290, 24);
      this.RestaurantCBox.TabIndex = 2;
      // 
      // CustomerValidationLbl
      // 
      this.CustomerValidationLbl.AutoSize = true;
      this.CustomerValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.CustomerValidationLbl.Location = new System.Drawing.Point(101, 19);
      this.CustomerValidationLbl.Name = "CustomerValidationLbl";
      this.CustomerValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.CustomerValidationLbl.TabIndex = 152;
      this.CustomerValidationLbl.Text = "*";
      // 
      // CustomerCBox
      // 
      this.CustomerCBox.BackColor = System.Drawing.SystemColors.Info;
      this.CustomerCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CustomerCBox.DropDownWidth = 400;
      this.CustomerCBox.FormattingEnabled = true;
      this.CustomerCBox.Location = new System.Drawing.Point(120, 16);
      this.CustomerCBox.Name = "CustomerCBox";
      this.CustomerCBox.Size = new System.Drawing.Size(290, 24);
      this.CustomerCBox.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(6, 19);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 16);
      this.label3.TabIndex = 151;
      this.label3.Text = "Клієнт:";
      // 
      // RestaurantValiadtionLbl
      // 
      this.RestaurantValiadtionLbl.AutoSize = true;
      this.RestaurantValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.RestaurantValiadtionLbl.Location = new System.Drawing.Point(101, 49);
      this.RestaurantValiadtionLbl.Name = "RestaurantValiadtionLbl";
      this.RestaurantValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.RestaurantValiadtionLbl.TabIndex = 149;
      this.RestaurantValiadtionLbl.Text = "*";
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(6, 48);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(73, 16);
      this.СomputerLbl.TabIndex = 148;
      this.СomputerLbl.Text = "Ресторан:";
      // 
      // RatingTBox
      // 
      this.RatingTBox.BackColor = System.Drawing.SystemColors.Info;
      this.RatingTBox.Location = new System.Drawing.Point(139, 109);
      this.RatingTBox.MaxLength = 1;
      this.RatingTBox.Name = "RatingTBox";
      this.RatingTBox.Size = new System.Drawing.Size(89, 22);
      this.RatingTBox.TabIndex = 4;
      this.RatingTBox.Text = "5";
      this.RatingTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // RestRatingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 190);
      this.Controls.Add(this.RestRatingsGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RestRatingsForm";
      this.ShowIcon = false;
      this.Text = "Рейтинги";
      this.AddPanel.ResumeLayout(false);
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.RestRatingsGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Label RatingValiadtionLbl;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.Label PhoneLbl;
    private System.Windows.Forms.DataGridView RestRatingsGridView;
    private System.Windows.Forms.ComboBox RestaurantCBox;
    private System.Windows.Forms.Label CustomerValidationLbl;
    private System.Windows.Forms.ComboBox CustomerCBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label RestaurantValiadtionLbl;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.Label AvgRatingValidationLbl;
    private System.Windows.Forms.TextBox AvgRatingTBox;
    private System.Windows.Forms.Label FirstNameLbl;
    private System.Windows.Forms.TextBox RatingTBox;
  }
}