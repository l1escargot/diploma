namespace RestaurantRecApp.Forms.Controls {
  partial class RecommendationsForm {
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.GraphicsCC = new LiveCharts.WinForms.CartesianChart();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.AddBtn = new System.Windows.Forms.Button();
      this.ModelOperationGridView = new System.Windows.Forms.DataGridView();
      this.TestBtn = new System.Windows.Forms.Button();
      this.NumberRecommendationsValiadtionLbl = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.NumberRecommendationsTBox = new System.Windows.Forms.TextBox();
      this.CustomerIdValiadtionLbl = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.CustomerIdTBox = new System.Windows.Forms.TextBox();
      this.SelectBtn = new System.Windows.Forms.Button();
      this.ModelsCBox = new System.Windows.Forms.ComboBox();
      this.ModelsValidationLbl = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.RaportTBox = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ModelOperationGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(598, 607);
      this.panel1.TabIndex = 116;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.GraphicsCC);
      this.groupBox1.Controls.Add(this.groupBox2);
      this.groupBox1.Controls.Add(this.SelectBtn);
      this.groupBox1.Controls.Add(this.ModelsCBox);
      this.groupBox1.Controls.Add(this.ModelsValidationLbl);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(12, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(568, 594);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Вхідні дані";
      // 
      // GraphicsCC
      // 
      this.GraphicsCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.GraphicsCC.Location = new System.Drawing.Point(10, 346);
      this.GraphicsCC.Name = "GraphicsCC";
      this.GraphicsCC.Size = new System.Drawing.Size(552, 242);
      this.GraphicsCC.TabIndex = 196;
      this.GraphicsCC.Text = "cartesianChart1";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.AddBtn);
      this.groupBox2.Controls.Add(this.ModelOperationGridView);
      this.groupBox2.Controls.Add(this.TestBtn);
      this.groupBox2.Controls.Add(this.NumberRecommendationsValiadtionLbl);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.NumberRecommendationsTBox);
      this.groupBox2.Controls.Add(this.CustomerIdValiadtionLbl);
      this.groupBox2.Controls.Add(this.label16);
      this.groupBox2.Controls.Add(this.CustomerIdTBox);
      this.groupBox2.Location = new System.Drawing.Point(10, 50);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(552, 293);
      this.groupBox2.TabIndex = 194;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Формування списку";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(252, 75);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(153, 16);
      this.label1.TabIndex = 194;
      this.label1.Text = "Провести тестування:";
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.AddBtn.Location = new System.Drawing.Point(383, 40);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(82, 25);
      this.AddBtn.TabIndex = 14;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // ModelOperationGridView
      // 
      this.ModelOperationGridView.AllowUserToAddRows = false;
      this.ModelOperationGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.ModelOperationGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.ModelOperationGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.ModelOperationGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ModelOperationGridView.GridColor = System.Drawing.Color.PaleGreen;
      this.ModelOperationGridView.Location = new System.Drawing.Point(12, 102);
      this.ModelOperationGridView.MultiSelect = false;
      this.ModelOperationGridView.Name = "ModelOperationGridView";
      this.ModelOperationGridView.ReadOnly = true;
      this.ModelOperationGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ModelOperationGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.ModelOperationGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ModelOperationGridView.Size = new System.Drawing.Size(534, 185);
      this.ModelOperationGridView.TabIndex = 192;
      this.ModelOperationGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ModelOperationGridView_CellClick);
      // 
      // TestBtn
      // 
      this.TestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.TestBtn.Location = new System.Drawing.Point(413, 71);
      this.TestBtn.Name = "TestBtn";
      this.TestBtn.Size = new System.Drawing.Size(52, 25);
      this.TestBtn.TabIndex = 193;
      this.TestBtn.Text = "ОК";
      this.TestBtn.UseVisualStyleBackColor = false;
      this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
      // 
      // NumberRecommendationsValiadtionLbl
      // 
      this.NumberRecommendationsValiadtionLbl.AutoSize = true;
      this.NumberRecommendationsValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.NumberRecommendationsValiadtionLbl.Location = new System.Drawing.Point(271, 46);
      this.NumberRecommendationsValiadtionLbl.Name = "NumberRecommendationsValiadtionLbl";
      this.NumberRecommendationsValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.NumberRecommendationsValiadtionLbl.TabIndex = 149;
      this.NumberRecommendationsValiadtionLbl.Text = "*";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(97, 46);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(161, 16);
      this.label4.TabIndex = 147;
      this.label4.Text = "Кількість рекомендацій:";
      // 
      // NumberRecommendationsTBox
      // 
      this.NumberRecommendationsTBox.BackColor = System.Drawing.SystemColors.Info;
      this.NumberRecommendationsTBox.Location = new System.Drawing.Point(289, 43);
      this.NumberRecommendationsTBox.MaxLength = 10;
      this.NumberRecommendationsTBox.Name = "NumberRecommendationsTBox";
      this.NumberRecommendationsTBox.Size = new System.Drawing.Size(88, 22);
      this.NumberRecommendationsTBox.TabIndex = 2;
      this.NumberRecommendationsTBox.Text = "10";
      this.NumberRecommendationsTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // CustomerIdValiadtionLbl
      // 
      this.CustomerIdValiadtionLbl.AutoSize = true;
      this.CustomerIdValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.CustomerIdValiadtionLbl.Location = new System.Drawing.Point(272, 18);
      this.CustomerIdValiadtionLbl.Name = "CustomerIdValiadtionLbl";
      this.CustomerIdValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.CustomerIdValiadtionLbl.TabIndex = 175;
      this.CustomerIdValiadtionLbl.Text = "*";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label16.Location = new System.Drawing.Point(66, 18);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(192, 16);
      this.label16.TabIndex = 173;
      this.label16.Text = "Ідентифікатор користувача:";
      // 
      // CustomerIdTBox
      // 
      this.CustomerIdTBox.BackColor = System.Drawing.SystemColors.Info;
      this.CustomerIdTBox.Location = new System.Drawing.Point(289, 15);
      this.CustomerIdTBox.MaxLength = 12;
      this.CustomerIdTBox.Name = "CustomerIdTBox";
      this.CustomerIdTBox.Size = new System.Drawing.Size(88, 22);
      this.CustomerIdTBox.TabIndex = 6;
      this.CustomerIdTBox.Text = "50";
      this.CustomerIdTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // SelectBtn
      // 
      this.SelectBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.SelectBtn.Location = new System.Drawing.Point(393, 21);
      this.SelectBtn.Name = "SelectBtn";
      this.SelectBtn.Size = new System.Drawing.Size(82, 25);
      this.SelectBtn.TabIndex = 191;
      this.SelectBtn.Text = "Обрати";
      this.SelectBtn.UseVisualStyleBackColor = false;
      this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
      // 
      // ModelsCBox
      // 
      this.ModelsCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ModelsCBox.DropDownWidth = 400;
      this.ModelsCBox.FormattingEnabled = true;
      this.ModelsCBox.Location = new System.Drawing.Point(116, 21);
      this.ModelsCBox.Name = "ModelsCBox";
      this.ModelsCBox.Size = new System.Drawing.Size(270, 24);
      this.ModelsCBox.TabIndex = 188;
      // 
      // ModelsValidationLbl
      // 
      this.ModelsValidationLbl.AutoSize = true;
      this.ModelsValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.ModelsValidationLbl.Location = new System.Drawing.Point(97, 25);
      this.ModelsValidationLbl.Name = "ModelsValidationLbl";
      this.ModelsValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.ModelsValidationLbl.TabIndex = 190;
      this.ModelsValidationLbl.Text = "*";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(13, 25);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(60, 16);
      this.label5.TabIndex = 189;
      this.label5.Text = "Модель:";
      // 
      // RaportTBox
      // 
      this.RaportTBox.BackColor = System.Drawing.SystemColors.Info;
      this.RaportTBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RaportTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(598, 0);
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(379, 607);
      this.RaportTBox.TabIndex = 117;
      this.RaportTBox.TabStop = false;
      // 
      // RecommendationsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(977, 607);
      this.Controls.Add(this.RaportTBox);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RecommendationsForm";
      this.ShowIcon = false;
      this.Text = "Формування рекомендацій";
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ModelOperationGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private LiveCharts.WinForms.CartesianChart GraphicsCC;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.DataGridView ModelOperationGridView;
    private System.Windows.Forms.Button TestBtn;
    private System.Windows.Forms.Label NumberRecommendationsValiadtionLbl;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox NumberRecommendationsTBox;
    private System.Windows.Forms.Label CustomerIdValiadtionLbl;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox CustomerIdTBox;
    private System.Windows.Forms.Button SelectBtn;
    private System.Windows.Forms.ComboBox ModelsCBox;
    private System.Windows.Forms.Label ModelsValidationLbl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox RaportTBox;
  }
}