namespace RecommendationsPlatformsApp.Forms.Systems {
  partial class UpdateUsersForm {
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.EmailTBox = new System.Windows.Forms.TextBox();
      this.EmailValiadtionLbl = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.DeleteBtn = new System.Windows.Forms.Button();
      this.SaveBtn = new System.Windows.Forms.Button();
      this.FirstNameLbl = new System.Windows.Forms.Label();
      this.FirstNameTBox = new System.Windows.Forms.TextBox();
      this.FirstNameValiadtionLbl = new System.Windows.Forms.Label();
      this.LastNameValiadtionLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.LastNameTBox = new System.Windows.Forms.TextBox();
      this.UserLoginValidationLbl = new System.Windows.Forms.Label();
      this.LastNameLbl = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.PasswordTbx = new System.Windows.Forms.TextBox();
      this.DescriptionTbx = new System.Windows.Forms.TextBox();
      this.RePasswordValidationLbl = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.RolesCBox = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.RePasswordTbx = new System.Windows.Forms.TextBox();
      this.PasswordAndRePasswordDontMatchLbl = new System.Windows.Forms.Label();
      this.PasswordValidationLbl = new System.Windows.Forms.Label();
      this.UserLoginTbx = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.EmailTBox);
      this.groupBox1.Controls.Add(this.EmailValiadtionLbl);
      this.groupBox1.Controls.Add(this.ExitBtn);
      this.groupBox1.Controls.Add(this.DeleteBtn);
      this.groupBox1.Controls.Add(this.SaveBtn);
      this.groupBox1.Controls.Add(this.FirstNameLbl);
      this.groupBox1.Controls.Add(this.FirstNameTBox);
      this.groupBox1.Controls.Add(this.FirstNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.LastNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.LastNameTBox);
      this.groupBox1.Controls.Add(this.UserLoginValidationLbl);
      this.groupBox1.Controls.Add(this.LastNameLbl);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.PasswordTbx);
      this.groupBox1.Controls.Add(this.DescriptionTbx);
      this.groupBox1.Controls.Add(this.RePasswordValidationLbl);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.RolesCBox);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.RePasswordTbx);
      this.groupBox1.Controls.Add(this.PasswordAndRePasswordDontMatchLbl);
      this.groupBox1.Controls.Add(this.PasswordValidationLbl);
      this.groupBox1.Controls.Add(this.UserLoginTbx);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(11, 1);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(375, 404);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(51, 83);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 16);
      this.label1.TabIndex = 92;
      this.label1.Text = "E-mail:";
      // 
      // EmailTBox
      // 
      this.EmailTBox.BackColor = System.Drawing.SystemColors.Info;
      this.EmailTBox.Location = new System.Drawing.Point(145, 80);
      this.EmailTBox.MaxLength = 200;
      this.EmailTBox.Name = "EmailTBox";
      this.EmailTBox.Size = new System.Drawing.Size(212, 22);
      this.EmailTBox.TabIndex = 91;
      // 
      // EmailValiadtionLbl
      // 
      this.EmailValiadtionLbl.AutoSize = true;
      this.EmailValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.EmailValiadtionLbl.Location = new System.Drawing.Point(116, 83);
      this.EmailValiadtionLbl.Name = "EmailValiadtionLbl";
      this.EmailValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.EmailValiadtionLbl.TabIndex = 93;
      this.EmailValiadtionLbl.Text = "*";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.ExitBtn.ForeColor = System.Drawing.Color.Black;
      this.ExitBtn.Location = new System.Drawing.Point(267, 370);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(91, 25);
      this.ExitBtn.TabIndex = 90;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // DeleteBtn
      // 
      this.DeleteBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.DeleteBtn.ForeColor = System.Drawing.Color.Black;
      this.DeleteBtn.Location = new System.Drawing.Point(159, 370);
      this.DeleteBtn.Name = "DeleteBtn";
      this.DeleteBtn.Size = new System.Drawing.Size(91, 25);
      this.DeleteBtn.TabIndex = 89;
      this.DeleteBtn.Text = "Видалити";
      this.DeleteBtn.UseVisualStyleBackColor = false;
      this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
      // 
      // SaveBtn
      // 
      this.SaveBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.SaveBtn.ForeColor = System.Drawing.Color.Black;
      this.SaveBtn.Location = new System.Drawing.Point(57, 370);
      this.SaveBtn.Name = "SaveBtn";
      this.SaveBtn.Size = new System.Drawing.Size(91, 25);
      this.SaveBtn.TabIndex = 88;
      this.SaveBtn.Text = "Зберегти";
      this.SaveBtn.UseVisualStyleBackColor = false;
      this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
      // 
      // FirstNameLbl
      // 
      this.FirstNameLbl.AutoSize = true;
      this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FirstNameLbl.ForeColor = System.Drawing.Color.Black;
      this.FirstNameLbl.Location = new System.Drawing.Point(67, 52);
      this.FirstNameLbl.Name = "FirstNameLbl";
      this.FirstNameLbl.Size = new System.Drawing.Size(32, 16);
      this.FirstNameLbl.TabIndex = 84;
      this.FirstNameLbl.Text = "Ім\'я:";
      // 
      // FirstNameTBox
      // 
      this.FirstNameTBox.BackColor = System.Drawing.SystemColors.Info;
      this.FirstNameTBox.Location = new System.Drawing.Point(145, 49);
      this.FirstNameTBox.MaxLength = 200;
      this.FirstNameTBox.Name = "FirstNameTBox";
      this.FirstNameTBox.Size = new System.Drawing.Size(214, 22);
      this.FirstNameTBox.TabIndex = 65;
      // 
      // FirstNameValiadtionLbl
      // 
      this.FirstNameValiadtionLbl.AutoSize = true;
      this.FirstNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.FirstNameValiadtionLbl.Location = new System.Drawing.Point(118, 52);
      this.FirstNameValiadtionLbl.Name = "FirstNameValiadtionLbl";
      this.FirstNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.FirstNameValiadtionLbl.TabIndex = 87;
      this.FirstNameValiadtionLbl.Text = "*";
      // 
      // LastNameValiadtionLbl
      // 
      this.LastNameValiadtionLbl.AutoSize = true;
      this.LastNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.LastNameValiadtionLbl.Location = new System.Drawing.Point(118, 24);
      this.LastNameValiadtionLbl.Name = "LastNameValiadtionLbl";
      this.LastNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.LastNameValiadtionLbl.TabIndex = 86;
      this.LastNameValiadtionLbl.Text = "*";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Black;
      this.label2.Location = new System.Drawing.Point(58, 277);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 16);
      this.label2.TabIndex = 74;
      this.label2.Text = "Логін:";
      // 
      // LastNameTBox
      // 
      this.LastNameTBox.BackColor = System.Drawing.SystemColors.Info;
      this.LastNameTBox.Location = new System.Drawing.Point(145, 21);
      this.LastNameTBox.MaxLength = 200;
      this.LastNameTBox.Name = "LastNameTBox";
      this.LastNameTBox.Size = new System.Drawing.Size(214, 22);
      this.LastNameTBox.TabIndex = 64;
      // 
      // UserLoginValidationLbl
      // 
      this.UserLoginValidationLbl.AutoSize = true;
      this.UserLoginValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.UserLoginValidationLbl.Location = new System.Drawing.Point(119, 280);
      this.UserLoginValidationLbl.Name = "UserLoginValidationLbl";
      this.UserLoginValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.UserLoginValidationLbl.TabIndex = 79;
      this.UserLoginValidationLbl.Text = "*";
      // 
      // LastNameLbl
      // 
      this.LastNameLbl.AutoSize = true;
      this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LastNameLbl.ForeColor = System.Drawing.Color.Black;
      this.LastNameLbl.Location = new System.Drawing.Point(34, 24);
      this.LastNameLbl.Name = "LastNameLbl";
      this.LastNameLbl.Size = new System.Drawing.Size(72, 16);
      this.LastNameLbl.TabIndex = 85;
      this.LastNameLbl.Text = "Прізвище:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.ForeColor = System.Drawing.Color.Black;
      this.label9.Location = new System.Drawing.Point(34, 110);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(43, 16);
      this.label9.TabIndex = 80;
      this.label9.Text = "Опис:";
      // 
      // PasswordTbx
      // 
      this.PasswordTbx.BackColor = System.Drawing.SystemColors.Info;
      this.PasswordTbx.Location = new System.Drawing.Point(144, 311);
      this.PasswordTbx.MaxLength = 20;
      this.PasswordTbx.Name = "PasswordTbx";
      this.PasswordTbx.Size = new System.Drawing.Size(216, 22);
      this.PasswordTbx.TabIndex = 69;
      this.PasswordTbx.UseSystemPasswordChar = true;
      // 
      // DescriptionTbx
      // 
      this.DescriptionTbx.BackColor = System.Drawing.SystemColors.Info;
      this.DescriptionTbx.Location = new System.Drawing.Point(37, 129);
      this.DescriptionTbx.MaxLength = 200;
      this.DescriptionTbx.Multiline = true;
      this.DescriptionTbx.Name = "DescriptionTbx";
      this.DescriptionTbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.DescriptionTbx.Size = new System.Drawing.Size(320, 96);
      this.DescriptionTbx.TabIndex = 66;
      // 
      // RePasswordValidationLbl
      // 
      this.RePasswordValidationLbl.AutoSize = true;
      this.RePasswordValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.RePasswordValidationLbl.Location = new System.Drawing.Point(119, 341);
      this.RePasswordValidationLbl.Name = "RePasswordValidationLbl";
      this.RePasswordValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.RePasswordValidationLbl.TabIndex = 78;
      this.RePasswordValidationLbl.Text = "*";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.Color.Black;
      this.label5.Location = new System.Drawing.Point(14, 341);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 16);
      this.label5.TabIndex = 77;
      this.label5.Text = "Підтвердити:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.Color.Black;
      this.label4.Location = new System.Drawing.Point(48, 314);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 16);
      this.label4.TabIndex = 75;
      this.label4.Text = "Пароль:";
      // 
      // RolesCBox
      // 
      this.RolesCBox.BackColor = System.Drawing.Color.Aquamarine;
      this.RolesCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.RolesCBox.FormattingEnabled = true;
      this.RolesCBox.Location = new System.Drawing.Point(143, 231);
      this.RolesCBox.Name = "RolesCBox";
      this.RolesCBox.Size = new System.Drawing.Size(215, 24);
      this.RolesCBox.TabIndex = 67;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.Color.Black;
      this.label6.Location = new System.Drawing.Point(65, 234);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(42, 16);
      this.label6.TabIndex = 81;
      this.label6.Text = "Роль:";
      // 
      // RePasswordTbx
      // 
      this.RePasswordTbx.BackColor = System.Drawing.SystemColors.Info;
      this.RePasswordTbx.Location = new System.Drawing.Point(143, 338);
      this.RePasswordTbx.MaxLength = 20;
      this.RePasswordTbx.Name = "RePasswordTbx";
      this.RePasswordTbx.Size = new System.Drawing.Size(216, 22);
      this.RePasswordTbx.TabIndex = 70;
      this.RePasswordTbx.UseSystemPasswordChar = true;
      // 
      // PasswordAndRePasswordDontMatchLbl
      // 
      this.PasswordAndRePasswordDontMatchLbl.AutoSize = true;
      this.PasswordAndRePasswordDontMatchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PasswordAndRePasswordDontMatchLbl.ForeColor = System.Drawing.Color.Red;
      this.PasswordAndRePasswordDontMatchLbl.Location = new System.Drawing.Point(149, 260);
      this.PasswordAndRePasswordDontMatchLbl.Name = "PasswordAndRePasswordDontMatchLbl";
      this.PasswordAndRePasswordDontMatchLbl.Size = new System.Drawing.Size(184, 12);
      this.PasswordAndRePasswordDontMatchLbl.TabIndex = 83;
      this.PasswordAndRePasswordDontMatchLbl.Text = "Поля пароль і підтвердити не співпадають";
      this.PasswordAndRePasswordDontMatchLbl.Visible = false;
      // 
      // PasswordValidationLbl
      // 
      this.PasswordValidationLbl.AutoSize = true;
      this.PasswordValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.PasswordValidationLbl.Location = new System.Drawing.Point(119, 314);
      this.PasswordValidationLbl.Name = "PasswordValidationLbl";
      this.PasswordValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.PasswordValidationLbl.TabIndex = 76;
      this.PasswordValidationLbl.Text = "*";
      // 
      // UserLoginTbx
      // 
      this.UserLoginTbx.BackColor = System.Drawing.SystemColors.Info;
      this.UserLoginTbx.Location = new System.Drawing.Point(143, 277);
      this.UserLoginTbx.MaxLength = 50;
      this.UserLoginTbx.Name = "UserLoginTbx";
      this.UserLoginTbx.Size = new System.Drawing.Size(216, 22);
      this.UserLoginTbx.TabIndex = 68;
      // 
      // UpdateUsersForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(394, 410);
      this.Controls.Add(this.groupBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdateUsersForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редагувати";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button DeleteBtn;
    private System.Windows.Forms.Button SaveBtn;
    private System.Windows.Forms.Label FirstNameLbl;
    private System.Windows.Forms.TextBox FirstNameTBox;
    private System.Windows.Forms.Label FirstNameValiadtionLbl;
    private System.Windows.Forms.Label LastNameValiadtionLbl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox LastNameTBox;
    private System.Windows.Forms.Label UserLoginValidationLbl;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox PasswordTbx;
    private System.Windows.Forms.TextBox DescriptionTbx;
    private System.Windows.Forms.Label RePasswordValidationLbl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox RolesCBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox RePasswordTbx;
    private System.Windows.Forms.Label PasswordAndRePasswordDontMatchLbl;
    private System.Windows.Forms.Label PasswordValidationLbl;
    private System.Windows.Forms.TextBox UserLoginTbx;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox EmailTBox;
    private System.Windows.Forms.Label EmailValiadtionLbl;
  }
}