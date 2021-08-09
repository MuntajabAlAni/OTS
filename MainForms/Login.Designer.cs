
namespace OTS.Ticketing.Win.MainForms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.ImbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnLogin.Location = new System.Drawing.Point(200, 159);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 31);
            this.BtnLogin.TabIndex = 3;
            this.BtnLogin.Text = "دخول";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Crimson;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(57, 159);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 31);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "خروج";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtUserName.Location = new System.Drawing.Point(37, 67);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(169, 23);
            this.TxtUserName.TabIndex = 1;
            this.TxtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyDown);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtPassword.Location = new System.Drawing.Point(37, 113);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(169, 23);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblUserName.Location = new System.Drawing.Point(212, 70);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblUserName.Size = new System.Drawing.Size(84, 15);
            this.LblUserName.TabIndex = 2;
            this.LblUserName.Text = "اسم المستخدم :";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPassword.Location = new System.Drawing.Point(212, 116);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblPassword.Size = new System.Drawing.Size(60, 15);
            this.LblPassword.TabIndex = 2;
            this.LblPassword.Text = "كلمة السر :";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(95, 23);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(179, 25);
            this.LblTitle.TabIndex = 5;
            this.LblTitle.Text = "Ticketing Software";
            // 
            // ImbLogo
            // 
            this.ImbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ImbLogo.Image")));
            this.ImbLogo.Location = new System.Drawing.Point(19, 12);
            this.ImbLogo.Name = "ImbLogo";
            this.ImbLogo.Size = new System.Drawing.Size(77, 45);
            this.ImbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImbLogo.TabIndex = 6;
            this.ImbLogo.TabStop = false;
            this.ImbLogo.Click += new System.EventHandler(this.ImbLogo_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(332, 215);
            this.Controls.Add(this.ImbLogo);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ImbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.PictureBox ImbLogo;
    }
}