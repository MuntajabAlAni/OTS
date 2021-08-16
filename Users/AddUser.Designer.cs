
namespace OTS.Ticketing.Win.Users
{
    partial class AddUser
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
            this.LblRemarks = new System.Windows.Forms.Label();
            this.LblDisplayName = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.TxtDisplayName = new System.Windows.Forms.TextBox();
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtIp = new System.Windows.Forms.TextBox();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblIp = new System.Windows.Forms.Label();
            this.CbState = new System.Windows.Forms.CheckBox();
            this.PnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblRemarks
            // 
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemarks.Location = new System.Drawing.Point(289, 187);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(58, 15);
            this.LblRemarks.TabIndex = 35;
            this.LblRemarks.Text = "ملاحظات :";
            // 
            // LblDisplayName
            // 
            this.LblDisplayName.AutoSize = true;
            this.LblDisplayName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblDisplayName.Location = new System.Drawing.Point(289, 39);
            this.LblDisplayName.Name = "LblDisplayName";
            this.LblDisplayName.Size = new System.Drawing.Size(78, 15);
            this.LblDisplayName.TabIndex = 36;
            this.LblDisplayName.Text = "اسم الموظف :";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(75, 182);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(208, 74);
            this.TxtRemarks.TabIndex = 34;
            // 
            // TxtDisplayName
            // 
            this.TxtDisplayName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtDisplayName.Location = new System.Drawing.Point(140, 34);
            this.TxtDisplayName.Name = "TxtDisplayName";
            this.TxtDisplayName.Size = new System.Drawing.Size(143, 25);
            this.TxtDisplayName.TabIndex = 33;
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContainer.Controls.Add(this.CbState);
            this.PnlContainer.Controls.Add(this.TxtRemarks);
            this.PnlContainer.Controls.Add(this.LblRemarks);
            this.PnlContainer.Controls.Add(this.BtnExit);
            this.PnlContainer.Controls.Add(this.LblIp);
            this.PnlContainer.Controls.Add(this.LblPassword);
            this.PnlContainer.Controls.Add(this.LblUserName);
            this.PnlContainer.Controls.Add(this.LblDisplayName);
            this.PnlContainer.Controls.Add(this.BtnAdd);
            this.PnlContainer.Controls.Add(this.TxtIp);
            this.PnlContainer.Controls.Add(this.TxtPassword);
            this.PnlContainer.Controls.Add(this.TxtUserName);
            this.PnlContainer.Controls.Add(this.TxtDisplayName);
            this.PnlContainer.Location = new System.Drawing.Point(11, 12);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(418, 376);
            this.PnlContainer.TabIndex = 37;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(13, 306);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(269, 306);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtUserName
            // 
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtUserName.Location = new System.Drawing.Point(140, 71);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(143, 25);
            this.TxtUserName.TabIndex = 33;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtPassword.Location = new System.Drawing.Point(140, 108);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(143, 25);
            this.TxtPassword.TabIndex = 33;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtIp
            // 
            this.TxtIp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtIp.Location = new System.Drawing.Point(140, 145);
            this.TxtIp.Name = "TxtIp";
            this.TxtIp.Size = new System.Drawing.Size(143, 25);
            this.TxtIp.TabIndex = 33;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblUserName.Location = new System.Drawing.Point(289, 76);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(84, 15);
            this.LblUserName.TabIndex = 36;
            this.LblUserName.Text = "اسم المستخدم :";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPassword.Location = new System.Drawing.Point(289, 113);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(60, 15);
            this.LblPassword.TabIndex = 36;
            this.LblPassword.Text = "كلمة السر :";
            // 
            // LblIp
            // 
            this.LblIp.AutoSize = true;
            this.LblIp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblIp.Location = new System.Drawing.Point(289, 150);
            this.LblIp.Name = "LblIp";
            this.LblIp.Size = new System.Drawing.Size(68, 15);
            this.LblIp.TabIndex = 36;
            this.LblIp.Text = "IP Address :";
            // 
            // CbState
            // 
            this.CbState.AutoSize = true;
            this.CbState.Checked = true;
            this.CbState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CbState.Location = new System.Drawing.Point(233, 268);
            this.CbState.Name = "CbState";
            this.CbState.Size = new System.Drawing.Size(50, 19);
            this.CbState.TabIndex = 37;
            this.CbState.Text = "فعال";
            this.CbState.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 400);
            this.Controls.Add(this.PnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.PnlContainer.ResumeLayout(false);
            this.PnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblRemarks;
        private System.Windows.Forms.Label LblDisplayName;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.TextBox TxtDisplayName;
        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.CheckBox CbState;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label LblIp;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtIp;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUserName;
    }
}