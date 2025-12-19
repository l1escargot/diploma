namespace RecommendationsPlatformsApp.Forms.Systems {
  partial class LoginForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
      this.UserNameCBox = new System.Windows.Forms.ComboBox();
      this.UserPasswordValidation = new System.Windows.Forms.Label();
      this.UserNameValiadtionLbl = new System.Windows.Forms.Label();
      this.SubmitBtn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.UserPasswordTbx = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.RegisterLink = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // UserNameCBox
      // 
      this.UserNameCBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.UserNameCBox.FormattingEnabled = true;
      this.UserNameCBox.Location = new System.Drawing.Point(95, 22);
      this.UserNameCBox.Name = "UserNameCBox";
      this.UserNameCBox.Size = new System.Drawing.Size(155, 21);
      this.UserNameCBox.TabIndex = 50;
      // 
      // UserPasswordValidation
      // 
      this.UserPasswordValidation.AutoSize = true;
      this.UserPasswordValidation.ForeColor = System.Drawing.Color.Red;
      this.UserPasswordValidation.Location = new System.Drawing.Point(78, 58);
      this.UserPasswordValidation.Name = "UserPasswordValidation";
      this.UserPasswordValidation.Size = new System.Drawing.Size(11, 13);
      this.UserPasswordValidation.TabIndex = 49;
      this.UserPasswordValidation.Text = "*";
      // 
      // UserNameValiadtionLbl
      // 
      this.UserNameValiadtionLbl.AutoSize = true;
      this.UserNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.UserNameValiadtionLbl.Location = new System.Drawing.Point(78, 25);
      this.UserNameValiadtionLbl.Name = "UserNameValiadtionLbl";
      this.UserNameValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.UserNameValiadtionLbl.TabIndex = 48;
      this.UserNameValiadtionLbl.Text = "*";
      // 
      // SubmitBtn
      // 
      this.SubmitBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.SubmitBtn.ForeColor = System.Drawing.Color.Black;
      this.SubmitBtn.Location = new System.Drawing.Point(165, 81);
      this.SubmitBtn.Name = "SubmitBtn";
      this.SubmitBtn.Size = new System.Drawing.Size(85, 25);
      this.SubmitBtn.TabIndex = 47;
      this.SubmitBtn.Text = "Підтвердити";
      this.SubmitBtn.UseVisualStyleBackColor = false;
      this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(17, 24);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 15);
      this.label3.TabIndex = 46;
      this.label3.Text = "Логін";
      // 
      // UserPasswordTbx
      // 
      this.UserPasswordTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.UserPasswordTbx.Location = new System.Drawing.Point(95, 55);
      this.UserPasswordTbx.Name = "UserPasswordTbx";
      this.UserPasswordTbx.Size = new System.Drawing.Size(155, 20);
      this.UserPasswordTbx.TabIndex = 45;
      this.UserPasswordTbx.UseSystemPasswordChar = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(17, 54);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 15);
      this.label2.TabIndex = 44;
      this.label2.Text = "Пароль";
      // 
      // RegisterLink
      // 
      this.RegisterLink.AutoSize = true;
      this.RegisterLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RegisterLink.Location = new System.Drawing.Point(17, 104);
      this.RegisterLink.Name = "RegisterLink";
      this.RegisterLink.Size = new System.Drawing.Size(90, 16);
      this.RegisterLink.TabIndex = 51;
      this.RegisterLink.TabStop = true;
      this.RegisterLink.Text = "Реєстрація";
      this.RegisterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterLink_LinkClicked);
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(266, 126);
      this.Controls.Add(this.RegisterLink);
      this.Controls.Add(this.UserNameCBox);
      this.Controls.Add(this.UserPasswordValidation);
      this.Controls.Add(this.UserNameValiadtionLbl);
      this.Controls.Add(this.SubmitBtn);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.UserPasswordTbx);
      this.Controls.Add(this.label2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LoginForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Авторизація в системі";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox UserNameCBox;
    private System.Windows.Forms.Label UserPasswordValidation;
    private System.Windows.Forms.Label UserNameValiadtionLbl;
    private System.Windows.Forms.Button SubmitBtn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox UserPasswordTbx;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.LinkLabel RegisterLink;
  }
}