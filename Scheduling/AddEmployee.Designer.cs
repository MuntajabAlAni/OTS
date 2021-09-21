
namespace OTS.Ticketing.Win.Scheduling
{
    partial class AddEmployee
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
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.LblName = new System.Windows.Forms.Label();
            this.LblRemarks = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.CbState = new System.Windows.Forms.CheckBox();
            this.PnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContainer.Controls.Add(this.CbState);
            this.PnlContainer.Controls.Add(this.LblName);
            this.PnlContainer.Controls.Add(this.LblRemarks);
            this.PnlContainer.Controls.Add(this.BtnExit);
            this.PnlContainer.Controls.Add(this.TxtName);
            this.PnlContainer.Controls.Add(this.TxtRemarks);
            this.PnlContainer.Controls.Add(this.BtnAdd);
            this.PnlContainer.Location = new System.Drawing.Point(10, 11);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(418, 344);
            this.PnlContainer.TabIndex = 2;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblName.Location = new System.Drawing.Point(294, 61);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(78, 15);
            this.LblName.TabIndex = 6;
            this.LblName.Text = "اسم الموظف :";
            // 
            // LblRemarks
            // 
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemarks.Location = new System.Drawing.Point(294, 99);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(58, 15);
            this.LblRemarks.TabIndex = 6;
            this.LblRemarks.Text = "ملاحظات :";
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(37, 274);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(44, 99);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(244, 107);
            this.TxtRemarks.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(251, 274);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtName.Location = new System.Drawing.Point(145, 56);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(143, 25);
            this.TxtName.TabIndex = 0;
            // 
            // CbState
            // 
            this.CbState.AutoSize = true;
            this.CbState.Checked = true;
            this.CbState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CbState.Location = new System.Drawing.Point(238, 212);
            this.CbState.Name = "CbState";
            this.CbState.Size = new System.Drawing.Size(50, 19);
            this.CbState.TabIndex = 7;
            this.CbState.Text = "فعال";
            this.CbState.UseVisualStyleBackColor = true;
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 366);
            this.Controls.Add(this.PnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddEmployee";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "AddEmployee";
            this.Load += new System.EventHandler(this.AddEmployee_Load);
            this.PnlContainer.ResumeLayout(false);
            this.PnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblRemarks;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.CheckBox CbState;
    }
}