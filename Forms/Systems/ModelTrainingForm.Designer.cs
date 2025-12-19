namespace RestaurantRecApp.Forms.Systems {
  partial class ModelTrainingForm {
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
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.ModelsNamesTBox = new System.Windows.Forms.TextBox();
      this.AddBtn = new System.Windows.Forms.Button();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.ModelsNamesValidationLbl = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.OpenBtn = new System.Windows.Forms.Button();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.FileNameTBox = new System.Windows.Forms.TextBox();
      this.ServiceNameValiadtionLbl = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.TrainBtn = new System.Windows.Forms.Button();
      this.RaportTBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ModelsGridView = new System.Windows.Forms.DataGridView();
      this.AddPanel.SuspendLayout();
      this.AddGBox.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ModelsGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // AddPanel
      // 
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(472, 511);
      this.AddPanel.TabIndex = 142;
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.groupBox3);
      this.AddGBox.Controls.Add(this.groupBox2);
      this.AddGBox.Controls.Add(this.groupBox1);
      this.AddGBox.Controls.Add(this.RaportTBox);
      this.AddGBox.Controls.Add(this.label1);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(10, 2);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(452, 501);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.ModelsNamesTBox);
      this.groupBox3.Controls.Add(this.AddBtn);
      this.groupBox3.Controls.Add(this.ClearBtn);
      this.groupBox3.Controls.Add(this.ModelsNamesValidationLbl);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Controls.Add(this.ExitBtn);
      this.groupBox3.Location = new System.Drawing.Point(9, 409);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(429, 86);
      this.groupBox3.TabIndex = 149;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Зберігання:";
      // 
      // ModelsNamesTBox
      // 
      this.ModelsNamesTBox.BackColor = System.Drawing.SystemColors.Info;
      this.ModelsNamesTBox.Location = new System.Drawing.Point(107, 21);
      this.ModelsNamesTBox.MaxLength = 200;
      this.ModelsNamesTBox.Name = "ModelsNamesTBox";
      this.ModelsNamesTBox.Size = new System.Drawing.Size(316, 22);
      this.ModelsNamesTBox.TabIndex = 145;
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.AddBtn.Location = new System.Drawing.Point(138, 49);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 3;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // ClearBtn
      // 
      this.ClearBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ClearBtn.Location = new System.Drawing.Point(240, 49);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(81, 25);
      this.ClearBtn.TabIndex = 4;
      this.ClearBtn.Text = "Очистити";
      this.ClearBtn.UseVisualStyleBackColor = false;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // ModelsNamesValidationLbl
      // 
      this.ModelsNamesValidationLbl.AutoSize = true;
      this.ModelsNamesValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.ModelsNamesValidationLbl.Location = new System.Drawing.Point(84, 24);
      this.ModelsNamesValidationLbl.Name = "ModelsNamesValidationLbl";
      this.ModelsNamesValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.ModelsNamesValidationLbl.TabIndex = 146;
      this.ModelsNamesValidationLbl.Text = "*";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(4, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 16);
      this.label4.TabIndex = 144;
      this.label4.Text = "Назва:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ExitBtn.Location = new System.Drawing.Point(342, 49);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 5;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.OpenBtn);
      this.groupBox2.Controls.Add(this.СomputerLbl);
      this.groupBox2.Controls.Add(this.FileNameTBox);
      this.groupBox2.Controls.Add(this.ServiceNameValiadtionLbl);
      this.groupBox2.Location = new System.Drawing.Point(9, 65);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(429, 84);
      this.groupBox2.TabIndex = 148;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Навчання із використанням датасету:";
      // 
      // OpenBtn
      // 
      this.OpenBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.OpenBtn.Location = new System.Drawing.Point(75, 21);
      this.OpenBtn.Name = "OpenBtn";
      this.OpenBtn.Size = new System.Drawing.Size(81, 25);
      this.OpenBtn.TabIndex = 140;
      this.OpenBtn.Text = "Відкрити";
      this.OpenBtn.UseVisualStyleBackColor = false;
      this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(4, 24);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(45, 16);
      this.СomputerLbl.TabIndex = 135;
      this.СomputerLbl.Text = "Файл:";
      // 
      // FileNameTBox
      // 
      this.FileNameTBox.BackColor = System.Drawing.SystemColors.Info;
      this.FileNameTBox.Enabled = false;
      this.FileNameTBox.Location = new System.Drawing.Point(7, 50);
      this.FileNameTBox.MaxLength = 200;
      this.FileNameTBox.Name = "FileNameTBox";
      this.FileNameTBox.Size = new System.Drawing.Size(416, 22);
      this.FileNameTBox.TabIndex = 136;
      // 
      // ServiceNameValiadtionLbl
      // 
      this.ServiceNameValiadtionLbl.AutoSize = true;
      this.ServiceNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.ServiceNameValiadtionLbl.Location = new System.Drawing.Point(56, 24);
      this.ServiceNameValiadtionLbl.Name = "ServiceNameValiadtionLbl";
      this.ServiceNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.ServiceNameValiadtionLbl.TabIndex = 137;
      this.ServiceNameValiadtionLbl.Text = "*";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.TrainBtn);
      this.groupBox1.Location = new System.Drawing.Point(9, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(429, 47);
      this.groupBox1.TabIndex = 147;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Навчання із використанням БД:";
      // 
      // TrainBtn
      // 
      this.TrainBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.TrainBtn.Location = new System.Drawing.Point(267, 16);
      this.TrainBtn.Name = "TrainBtn";
      this.TrainBtn.Size = new System.Drawing.Size(100, 25);
      this.TrainBtn.TabIndex = 141;
      this.TrainBtn.Text = "Тренувати";
      this.TrainBtn.UseVisualStyleBackColor = false;
      this.TrainBtn.Click += new System.EventHandler(this.TrainBtn_Click);
      // 
      // RaportTBox
      // 
      this.RaportTBox.BackColor = System.Drawing.SystemColors.Info;
      this.RaportTBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(9, 171);
      this.RaportTBox.MaxLength = 300;
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(429, 232);
      this.RaportTBox.TabIndex = 139;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(6, 152);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 16);
      this.label1.TabIndex = 138;
      this.label1.Text = "Результати:";
      // 
      // ModelsGridView
      // 
      this.ModelsGridView.AllowUserToAddRows = false;
      this.ModelsGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.ModelsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.ModelsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.ModelsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ModelsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ModelsGridView.GridColor = System.Drawing.SystemColors.Control;
      this.ModelsGridView.Location = new System.Drawing.Point(472, 0);
      this.ModelsGridView.MultiSelect = false;
      this.ModelsGridView.Name = "ModelsGridView";
      this.ModelsGridView.ReadOnly = true;
      this.ModelsGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ModelsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.ModelsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ModelsGridView.Size = new System.Drawing.Size(369, 511);
      this.ModelsGridView.TabIndex = 143;
      this.ModelsGridView.TabStop = false;
      this.ModelsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModelsGridView_CellClick);
      // 
      // ModelTrainingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(841, 511);
      this.Controls.Add(this.ModelsGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ModelTrainingForm";
      this.ShowIcon = false;
      this.Text = "Тренування моделей";
      this.AddPanel.ResumeLayout(false);
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ModelsGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Label ModelsNamesValidationLbl;
    private System.Windows.Forms.TextBox ModelsNamesTBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button OpenBtn;
    private System.Windows.Forms.TextBox RaportTBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label ServiceNameValiadtionLbl;
    private System.Windows.Forms.TextBox FileNameTBox;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.DataGridView ModelsGridView;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button TrainBtn;
  }
}