﻿
namespace OTS.Ticketing.Win.Tickets
{
    partial class AddTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTicket));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAddCompany = new System.Windows.Forms.PictureBox();
            this.BtnAddSoftware = new System.Windows.Forms.PictureBox();
            this.CombSoftware = new System.Windows.Forms.ComboBox();
            this.CombEmployee = new System.Windows.Forms.ComboBox();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblSoftware = new System.Windows.Forms.Label();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblRevisionTitle = new System.Windows.Forms.Label();
            this.LblNumberTitle = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.CombPhoneNumbers = new System.Windows.Forms.ComboBox();
            this.LblPhoneNumber = new System.Windows.Forms.Label();
            this.BtnAddPhoneNumber = new System.Windows.Forms.PictureBox();
            this.DtgUnclosedTickets = new System.Windows.Forms.DataGridView();
            this.LblUnclosedTickets = new System.Windows.Forms.Label();
            this.LblNumber = new System.Windows.Forms.Label();
            this.LblRevision = new System.Windows.Forms.Label();
            this.BtnEditCompany = new System.Windows.Forms.PictureBox();
            this.BtnEditPhoneNumber = new System.Windows.Forms.PictureBox();
            this.BtnEditSoftware = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSoftware)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddPhoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUnclosedTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditPhoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAddCompany
            // 
            this.BtnAddCompany.BackColor = System.Drawing.Color.White;
            this.BtnAddCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.ErrorImage")));
            this.BtnAddCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.Image")));
            this.BtnAddCompany.Location = new System.Drawing.Point(531, 36);
            this.BtnAddCompany.Name = "BtnAddCompany";
            this.BtnAddCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnAddCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddCompany.TabIndex = 22;
            this.BtnAddCompany.TabStop = false;
            // 
            // BtnAddSoftware
            // 
            this.BtnAddSoftware.BackColor = System.Drawing.Color.White;
            this.BtnAddSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddSoftware.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddSoftware.ErrorImage")));
            this.BtnAddSoftware.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddSoftware.Image")));
            this.BtnAddSoftware.Location = new System.Drawing.Point(207, 36);
            this.BtnAddSoftware.Name = "BtnAddSoftware";
            this.BtnAddSoftware.Size = new System.Drawing.Size(25, 25);
            this.BtnAddSoftware.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddSoftware.TabIndex = 23;
            this.BtnAddSoftware.TabStop = false;
            // 
            // CombSoftware
            // 
            this.CombSoftware.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombSoftware.FormattingEnabled = true;
            this.CombSoftware.Location = new System.Drawing.Point(232, 36);
            this.CombSoftware.Name = "CombSoftware";
            this.CombSoftware.Size = new System.Drawing.Size(180, 25);
            this.CombSoftware.TabIndex = 19;
            // 
            // CombEmployee
            // 
            this.CombEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombEmployee.FormattingEnabled = true;
            this.CombEmployee.Location = new System.Drawing.Point(232, 85);
            this.CombEmployee.Name = "CombEmployee";
            this.CombEmployee.Size = new System.Drawing.Size(180, 25);
            this.CombEmployee.TabIndex = 20;
            // 
            // CombCompanies
            // 
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(556, 36);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(180, 25);
            this.CombCompanies.TabIndex = 21;
            this.CombCompanies.SelectedValueChanged += new System.EventHandler(this.CombCompanies_SelectedValueChanged);
            // 
            // LblSoftware
            // 
            this.LblSoftware.AutoSize = true;
            this.LblSoftware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblSoftware.Location = new System.Drawing.Point(418, 41);
            this.LblSoftware.Name = "LblSoftware";
            this.LblSoftware.Size = new System.Drawing.Size(49, 15);
            this.LblSoftware.TabIndex = 14;
            this.LblSoftware.Text = "البرنامج :";
            // 
            // LblEmployee
            // 
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblEmployee.Location = new System.Drawing.Point(418, 90);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(55, 15);
            this.LblEmployee.TabIndex = 15;
            this.LblEmployee.Text = "الموظف :";
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(742, 41);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 16;
            this.LblCompany.Text = "الشركة :";
            // 
            // LblRevisionTitle
            // 
            this.LblRevisionTitle.AutoSize = true;
            this.LblRevisionTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRevisionTitle.Location = new System.Drawing.Point(907, 90);
            this.LblRevisionTitle.Name = "LblRevisionTitle";
            this.LblRevisionTitle.Size = new System.Drawing.Size(74, 15);
            this.LblRevisionTitle.TabIndex = 17;
            this.LblRevisionTitle.Text = "رقم المراجعة :";
            // 
            // LblNumberTitle
            // 
            this.LblNumberTitle.AutoSize = true;
            this.LblNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumberTitle.Location = new System.Drawing.Point(907, 41);
            this.LblNumberTitle.Name = "LblNumberTitle";
            this.LblNumberTitle.Size = new System.Drawing.Size(69, 15);
            this.LblNumberTitle.TabIndex = 18;
            this.LblNumberTitle.Text = "رقم البطاقة :";
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(22, 75);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 24;
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
            this.BtnAdd.Location = new System.Drawing.Point(22, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 25;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // CombPhoneNumbers
            // 
            this.CombPhoneNumbers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombPhoneNumbers.FormattingEnabled = true;
            this.CombPhoneNumbers.Location = new System.Drawing.Point(556, 85);
            this.CombPhoneNumbers.Name = "CombPhoneNumbers";
            this.CombPhoneNumbers.Size = new System.Drawing.Size(180, 25);
            this.CombPhoneNumbers.TabIndex = 21;
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.AutoSize = true;
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPhoneNumber.Location = new System.Drawing.Point(742, 90);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(65, 15);
            this.LblPhoneNumber.TabIndex = 16;
            this.LblPhoneNumber.Text = "رقم الهاتف :";
            // 
            // BtnAddPhoneNumber
            // 
            this.BtnAddPhoneNumber.BackColor = System.Drawing.Color.White;
            this.BtnAddPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddPhoneNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddPhoneNumber.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddPhoneNumber.ErrorImage")));
            this.BtnAddPhoneNumber.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddPhoneNumber.Image")));
            this.BtnAddPhoneNumber.Location = new System.Drawing.Point(531, 85);
            this.BtnAddPhoneNumber.Name = "BtnAddPhoneNumber";
            this.BtnAddPhoneNumber.Size = new System.Drawing.Size(25, 25);
            this.BtnAddPhoneNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddPhoneNumber.TabIndex = 22;
            this.BtnAddPhoneNumber.TabStop = false;
            // 
            // DtgUnclosedTickets
            // 
            this.DtgUnclosedTickets.AllowUserToAddRows = false;
            this.DtgUnclosedTickets.AllowUserToDeleteRows = false;
            this.DtgUnclosedTickets.AllowUserToOrderColumns = true;
            this.DtgUnclosedTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUnclosedTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgUnclosedTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgUnclosedTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgUnclosedTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgUnclosedTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgUnclosedTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgUnclosedTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgUnclosedTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgUnclosedTickets.ColumnHeadersHeight = 28;
            this.DtgUnclosedTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgUnclosedTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgUnclosedTickets.EnableHeadersVisualStyles = false;
            this.DtgUnclosedTickets.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgUnclosedTickets.Location = new System.Drawing.Point(12, 168);
            this.DtgUnclosedTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgUnclosedTickets.MultiSelect = false;
            this.DtgUnclosedTickets.Name = "DtgUnclosedTickets";
            this.DtgUnclosedTickets.ReadOnly = true;
            this.DtgUnclosedTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgUnclosedTickets.RowHeadersVisible = false;
            this.DtgUnclosedTickets.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUnclosedTickets.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgUnclosedTickets.RowTemplate.Height = 26;
            this.DtgUnclosedTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgUnclosedTickets.Size = new System.Drawing.Size(1026, 427);
            this.DtgUnclosedTickets.TabIndex = 26;
            this.DtgUnclosedTickets.DoubleClick += new System.EventHandler(this.DtgUnclosedTickets_DoubleClick);
            // 
            // LblUnclosedTickets
            // 
            this.LblUnclosedTickets.AutoSize = true;
            this.LblUnclosedTickets.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.LblUnclosedTickets.Location = new System.Drawing.Point(809, 133);
            this.LblUnclosedTickets.Name = "LblUnclosedTickets";
            this.LblUnclosedTickets.Size = new System.Drawing.Size(226, 31);
            this.LblUnclosedTickets.TabIndex = 17;
            this.LblUnclosedTickets.Text = "البطاقات الغير مغلقة :";
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblNumber.Location = new System.Drawing.Point(873, 36);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblNumber.Size = new System.Drawing.Size(34, 25);
            this.LblNumber.TabIndex = 18;
            this.LblNumber.Text = "99";
            // 
            // LblRevision
            // 
            this.LblRevision.AutoSize = true;
            this.LblRevision.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblRevision.Location = new System.Drawing.Point(873, 85);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRevision.Size = new System.Drawing.Size(34, 25);
            this.LblRevision.TabIndex = 18;
            this.LblRevision.Text = "99";
            // 
            // BtnEditCompany
            // 
            this.BtnEditCompany.BackColor = System.Drawing.Color.White;
            this.BtnEditCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.ErrorImage")));
            this.BtnEditCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.Image")));
            this.BtnEditCompany.Location = new System.Drawing.Point(506, 36);
            this.BtnEditCompany.Name = "BtnEditCompany";
            this.BtnEditCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnEditCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditCompany.TabIndex = 22;
            this.BtnEditCompany.TabStop = false;
            // 
            // BtnEditPhoneNumber
            // 
            this.BtnEditPhoneNumber.BackColor = System.Drawing.Color.White;
            this.BtnEditPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditPhoneNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditPhoneNumber.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditPhoneNumber.ErrorImage")));
            this.BtnEditPhoneNumber.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditPhoneNumber.Image")));
            this.BtnEditPhoneNumber.Location = new System.Drawing.Point(506, 85);
            this.BtnEditPhoneNumber.Name = "BtnEditPhoneNumber";
            this.BtnEditPhoneNumber.Size = new System.Drawing.Size(25, 25);
            this.BtnEditPhoneNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditPhoneNumber.TabIndex = 22;
            this.BtnEditPhoneNumber.TabStop = false;
            // 
            // BtnEditSoftware
            // 
            this.BtnEditSoftware.BackColor = System.Drawing.Color.White;
            this.BtnEditSoftware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditSoftware.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditSoftware.ErrorImage")));
            this.BtnEditSoftware.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditSoftware.Image")));
            this.BtnEditSoftware.Location = new System.Drawing.Point(182, 36);
            this.BtnEditSoftware.Name = "BtnEditSoftware";
            this.BtnEditSoftware.Size = new System.Drawing.Size(25, 25);
            this.BtnEditSoftware.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditSoftware.TabIndex = 23;
            this.BtnEditSoftware.TabStop = false;
            // 
            // AddTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.DtgUnclosedTickets);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnEditPhoneNumber);
            this.Controls.Add(this.BtnAddPhoneNumber);
            this.Controls.Add(this.BtnEditCompany);
            this.Controls.Add(this.BtnAddCompany);
            this.Controls.Add(this.BtnEditSoftware);
            this.Controls.Add(this.BtnAddSoftware);
            this.Controls.Add(this.CombSoftware);
            this.Controls.Add(this.CombEmployee);
            this.Controls.Add(this.CombPhoneNumbers);
            this.Controls.Add(this.CombCompanies);
            this.Controls.Add(this.LblSoftware);
            this.Controls.Add(this.LblEmployee);
            this.Controls.Add(this.LblPhoneNumber);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblUnclosedTickets);
            this.Controls.Add(this.LblRevisionTitle);
            this.Controls.Add(this.LblRevision);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.LblNumberTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTicket";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddTicket";
            this.Load += new System.EventHandler(this.AddTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddSoftware)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddPhoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUnclosedTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditPhoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditSoftware)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BtnAddCompany;
        private System.Windows.Forms.PictureBox BtnAddSoftware;
        private System.Windows.Forms.ComboBox CombSoftware;
        private System.Windows.Forms.ComboBox CombEmployee;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblSoftware;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblRevisionTitle;
        private System.Windows.Forms.Label LblNumberTitle;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ComboBox CombPhoneNumbers;
        private System.Windows.Forms.Label LblPhoneNumber;
        private System.Windows.Forms.PictureBox BtnAddPhoneNumber;
        private System.Windows.Forms.DataGridView DtgUnclosedTickets;
        private System.Windows.Forms.Label LblUnclosedTickets;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.Label LblRevision;
        private System.Windows.Forms.PictureBox BtnEditCompany;
        private System.Windows.Forms.PictureBox BtnEditPhoneNumber;
        private System.Windows.Forms.PictureBox BtnEditSoftware;
    }
}