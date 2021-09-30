
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
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.LblNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.BtnLogin, "BtnLogin");
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Crimson;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.BtnExit, "BtnExit");
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtUserName
            // 
            resources.ApplyResources(this.TxtUserName, "TxtUserName");
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Enter += new System.EventHandler(this.TxtUserName_Enter);
            this.TxtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyDown);
            // 
            // TxtPassword
            // 
            resources.ApplyResources(this.TxtPassword, "TxtPassword");
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // LblUserName
            // 
            resources.ApplyResources(this.LblUserName, "LblUserName");
            this.LblUserName.Name = "LblUserName";
            // 
            // LblPassword
            // 
            resources.ApplyResources(this.LblPassword, "LblPassword");
            this.LblPassword.Name = "LblPassword";
            // 
            // LblTitle
            // 
            resources.ApplyResources(this.LblTitle, "LblTitle");
            this.LblTitle.Name = "LblTitle";
            // 
            // ImbLogo
            // 
            resources.ApplyResources(this.ImbLogo, "ImbLogo");
            this.ImbLogo.Name = "ImbLogo";
            this.ImbLogo.TabStop = false;
            this.ImbLogo.Click += new System.EventHandler(this.ImbLogo_Click);
            // 
            // TxtNumber
            // 
            resources.ApplyResources(this.TxtNumber, "TxtNumber");
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // LblNumber
            // 
            resources.ApplyResources(this.LblNumber, "LblNumber");
            this.LblNumber.Name = "LblNumber";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ImbLogo);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TxtNumber);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
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
        private System.Windows.Forms.TextBox TxtNumber;
        private System.Windows.Forms.Label LblNumber;
    }
}