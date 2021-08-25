
namespace OTS.Ticketing.Win.Tickets
{
    partial class DisplayOldTickets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.DtgOldTickets = new System.Windows.Forms.DataGridView();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.DtpToDate = new System.Windows.Forms.DateTimePicker();
            this.DtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.CombUser = new System.Windows.Forms.ComboBox();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.CbToDate = new System.Windows.Forms.CheckBox();
            this.CbFromDate = new System.Windows.Forms.CheckBox();
            this.CbUnclosed = new System.Windows.Forms.CheckBox();
            this.BtnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgOldTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnEdit.FlatAppearance.BorderSize = 2;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnEdit.Location = new System.Drawing.Point(893, 453);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(120, 45);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // DtgOldTickets
            // 
            this.DtgOldTickets.AllowUserToAddRows = false;
            this.DtgOldTickets.AllowUserToDeleteRows = false;
            this.DtgOldTickets.AllowUserToOrderColumns = true;
            this.DtgOldTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgOldTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgOldTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgOldTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgOldTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgOldTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgOldTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgOldTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgOldTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgOldTickets.ColumnHeadersHeight = 34;
            this.DtgOldTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgOldTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgOldTickets.EnableHeadersVisualStyles = false;
            this.DtgOldTickets.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgOldTickets.Location = new System.Drawing.Point(12, 62);
            this.DtgOldTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgOldTickets.MultiSelect = false;
            this.DtgOldTickets.Name = "DtgOldTickets";
            this.DtgOldTickets.ReadOnly = true;
            this.DtgOldTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgOldTickets.RowHeadersVisible = false;
            this.DtgOldTickets.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgOldTickets.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgOldTickets.RowTemplate.Height = 26;
            this.DtgOldTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgOldTickets.Size = new System.Drawing.Size(1001, 386);
            this.DtgOldTickets.TabIndex = 11;
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(12, 453);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 10;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnUpdate.FlatAppearance.BorderSize = 2;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(12, 12);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 45);
            this.BtnUpdate.TabIndex = 7;
            this.BtnUpdate.Text = "تحديث";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // DtpToDate
            // 
            this.DtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpToDate.CustomFormat = "";
            this.DtpToDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpToDate.Location = new System.Drawing.Point(249, 22);
            this.DtpToDate.Name = "DtpToDate";
            this.DtpToDate.Size = new System.Drawing.Size(106, 25);
            this.DtpToDate.TabIndex = 5;
            // 
            // DtpFromDate
            // 
            this.DtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpFromDate.CustomFormat = "";
            this.DtpFromDate.Enabled = false;
            this.DtpFromDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFromDate.Location = new System.Drawing.Point(416, 22);
            this.DtpFromDate.Name = "DtpFromDate";
            this.DtpFromDate.Size = new System.Drawing.Size(104, 25);
            this.DtpFromDate.TabIndex = 3;
            this.DtpFromDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // CombUser
            // 
            this.CombUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombUser.FormattingEnabled = true;
            this.CombUser.Location = new System.Drawing.Point(579, 22);
            this.CombUser.Name = "CombUser";
            this.CombUser.Size = new System.Drawing.Size(126, 25);
            this.CombUser.TabIndex = 1;
            this.CombUser.SelectedValueChanged += new System.EventHandler(this.CombUser_SelectedValueChanged);
            // 
            // CombCompanies
            // 
            this.CombCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombCompanies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombCompanies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(772, 22);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(180, 25);
            this.CombCompanies.TabIndex = 0;
            // 
            // LblUser
            // 
            this.LblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUser.AutoSize = true;
            this.LblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblUser.Location = new System.Drawing.Point(711, 27);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(55, 15);
            this.LblUser.TabIndex = 27;
            this.LblUser.Text = "الموظف :";
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(958, 27);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 26;
            this.LblCompany.Text = "الشركة :";
            // 
            // CbToDate
            // 
            this.CbToDate.AutoSize = true;
            this.CbToDate.Checked = true;
            this.CbToDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CbToDate.Location = new System.Drawing.Point(361, 26);
            this.CbToDate.Name = "CbToDate";
            this.CbToDate.Size = new System.Drawing.Size(49, 19);
            this.CbToDate.TabIndex = 4;
            this.CbToDate.Text = "الى :";
            this.CbToDate.UseVisualStyleBackColor = true;
            this.CbToDate.CheckedChanged += new System.EventHandler(this.CbToDate_CheckedChanged);
            // 
            // CbFromDate
            // 
            this.CbFromDate.AutoSize = true;
            this.CbFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CbFromDate.Location = new System.Drawing.Point(526, 26);
            this.CbFromDate.Name = "CbFromDate";
            this.CbFromDate.Size = new System.Drawing.Size(47, 19);
            this.CbFromDate.TabIndex = 2;
            this.CbFromDate.Text = "من :";
            this.CbFromDate.UseVisualStyleBackColor = true;
            this.CbFromDate.CheckedChanged += new System.EventHandler(this.CbFromDate_CheckedChanged);
            // 
            // CbUnclosed
            // 
            this.CbUnclosed.AutoSize = true;
            this.CbUnclosed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CbUnclosed.Location = new System.Drawing.Point(161, 26);
            this.CbUnclosed.Name = "CbUnclosed";
            this.CbUnclosed.Size = new System.Drawing.Size(82, 19);
            this.CbUnclosed.TabIndex = 6;
            this.CbUnclosed.Text = "الغير مغلقة";
            this.CbUnclosed.UseVisualStyleBackColor = true;
            // 
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExcel.FlatAppearance.BorderSize = 2;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExcel.Location = new System.Drawing.Point(767, 453);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(120, 45);
            this.BtnExcel.TabIndex = 9;
            this.BtnExcel.Text = "تصدير";
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // DisplayOldTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 509);
            this.Controls.Add(this.CbUnclosed);
            this.Controls.Add(this.CbFromDate);
            this.Controls.Add(this.CbToDate);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.CombCompanies);
            this.Controls.Add(this.CombUser);
            this.Controls.Add(this.DtpFromDate);
            this.Controls.Add(this.DtpToDate);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.DtgOldTickets);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DisplayOldTickets";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DisplayOldTickets";
            this.Load += new System.EventHandler(this.DisplayOldTickets_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayOldTickets_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgOldTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.DataGridView DtgOldTickets;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.DateTimePicker DtpToDate;
        private System.Windows.Forms.DateTimePicker DtpFromDate;
        private System.Windows.Forms.ComboBox CombUser;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.CheckBox CbToDate;
        private System.Windows.Forms.CheckBox CbFromDate;
        private System.Windows.Forms.CheckBox CbUnclosed;
        private System.Windows.Forms.Button BtnExcel;
    }
}