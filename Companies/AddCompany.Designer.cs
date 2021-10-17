
namespace OTS.Ticketing.Win.Companies
{
    partial class AddCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCompany));
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.BtnEditBranch = new System.Windows.Forms.PictureBox();
            this.BtnAddBranch = new System.Windows.Forms.PictureBox();
            this.CombBranches = new System.Windows.Forms.ComboBox();
            this.LblBranches = new System.Windows.Forms.Label();
            this.LblRemarks = new System.Windows.Forms.Label();
            this.LblAddress = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.PnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddBranch)).BeginInit();
            this.SuspendLayout();
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
            this.BtnExit.Text = "إلغاء الأمر";
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
            this.BtnAdd.Location = new System.Drawing.Point(251, 274);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblName.Location = new System.Drawing.Point(287, 40);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(68, 15);
            this.LblName.TabIndex = 6;
            this.LblName.Text = "اسم الشركة :";
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtName.Location = new System.Drawing.Point(138, 35);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(143, 25);
            this.TxtName.TabIndex = 0;
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContainer.Controls.Add(this.BtnEditBranch);
            this.PnlContainer.Controls.Add(this.BtnAddBranch);
            this.PnlContainer.Controls.Add(this.CombBranches);
            this.PnlContainer.Controls.Add(this.LblBranches);
            this.PnlContainer.Controls.Add(this.LblRemarks);
            this.PnlContainer.Controls.Add(this.LblAddress);
            this.PnlContainer.Controls.Add(this.LblName);
            this.PnlContainer.Controls.Add(this.BtnExit);
            this.PnlContainer.Controls.Add(this.TxtRemarks);
            this.PnlContainer.Controls.Add(this.TxtAddress);
            this.PnlContainer.Controls.Add(this.TxtName);
            this.PnlContainer.Controls.Add(this.BtnAdd);
            this.PnlContainer.Location = new System.Drawing.Point(10, 10);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(418, 344);
            this.PnlContainer.TabIndex = 0;
            // 
            // BtnEditBranch
            // 
            this.BtnEditBranch.BackColor = System.Drawing.Color.White;
            this.BtnEditBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditBranch.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditBranch.ErrorImage")));
            this.BtnEditBranch.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditBranch.Image")));
            this.BtnEditBranch.Location = new System.Drawing.Point(88, 131);
            this.BtnEditBranch.Name = "BtnEditBranch";
            this.BtnEditBranch.Size = new System.Drawing.Size(25, 25);
            this.BtnEditBranch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditBranch.TabIndex = 36;
            this.BtnEditBranch.TabStop = false;
            this.BtnEditBranch.Click += new System.EventHandler(this.BtnEditBranch_Click);
            // 
            // BtnAddBranch
            // 
            this.BtnAddBranch.BackColor = System.Drawing.Color.White;
            this.BtnAddBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddBranch.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddBranch.ErrorImage")));
            this.BtnAddBranch.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddBranch.Image")));
            this.BtnAddBranch.Location = new System.Drawing.Point(113, 131);
            this.BtnAddBranch.Name = "BtnAddBranch";
            this.BtnAddBranch.Size = new System.Drawing.Size(25, 25);
            this.BtnAddBranch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddBranch.TabIndex = 37;
            this.BtnAddBranch.TabStop = false;
            this.BtnAddBranch.Click += new System.EventHandler(this.BtnAddBranch_Click);
            // 
            // CombBranches
            // 
            this.CombBranches.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombBranches.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombBranches.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombBranches.FormattingEnabled = true;
            this.CombBranches.Location = new System.Drawing.Point(138, 131);
            this.CombBranches.Name = "CombBranches";
            this.CombBranches.Size = new System.Drawing.Size(143, 25);
            this.CombBranches.TabIndex = 2;
            // 
            // LblBranches
            // 
            this.LblBranches.AutoSize = true;
            this.LblBranches.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblBranches.Location = new System.Drawing.Point(287, 136);
            this.LblBranches.Name = "LblBranches";
            this.LblBranches.Size = new System.Drawing.Size(38, 15);
            this.LblBranches.TabIndex = 8;
            this.LblBranches.Text = "الفرع :";
            // 
            // LblRemarks
            // 
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemarks.Location = new System.Drawing.Point(287, 174);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(58, 15);
            this.LblRemarks.TabIndex = 9;
            this.LblRemarks.Text = "ملاحظات :";
            // 
            // LblAddress
            // 
            this.LblAddress.AutoSize = true;
            this.LblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblAddress.Location = new System.Drawing.Point(287, 78);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(48, 15);
            this.LblAddress.TabIndex = 7;
            this.LblAddress.Text = "العنوان :";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(73, 169);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(208, 74);
            this.TxtRemarks.TabIndex = 3;
            // 
            // TxtAddress
            // 
            this.TxtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtAddress.Location = new System.Drawing.Point(73, 73);
            this.TxtAddress.Multiline = true;
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(208, 45);
            this.TxtAddress.TabIndex = 1;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 366);
            this.Controls.Add(this.PnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddCompany";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddCompany";
            this.Load += new System.EventHandler(this.AddCompany_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddCompany_KeyDown);
            this.PnlContainer.ResumeLayout(false);
            this.PnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.ComboBox CombBranches;
        private System.Windows.Forms.Label LblBranches;
        private System.Windows.Forms.Label LblRemarks;
        private System.Windows.Forms.Label LblAddress;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.PictureBox BtnEditBranch;
        private System.Windows.Forms.PictureBox BtnAddBranch;
    }
}