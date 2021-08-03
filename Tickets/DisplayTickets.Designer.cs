
namespace OTS.Ticketing.Software.Tickets
{
    partial class DisplayTickets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.DtgTickets = new System.Windows.Forms.DataGridView();
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.LblNumber = new System.Windows.Forms.Label();
            this.DtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.LblOpenDate = new System.Windows.Forms.Label();
            this.LblCloseDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.CombEmployee = new System.Windows.Forms.ComboBox();
            this.LblSoftware = new System.Windows.Forms.Label();
            this.CombSoftware = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(12, 212);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnEdit.FlatAppearance.BorderSize = 2;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnEdit.Location = new System.Drawing.Point(138, 212);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(120, 45);
            this.BtnEdit.TabIndex = 4;
            this.BtnEdit.Text = "تعديل";
            this.BtnEdit.UseVisualStyleBackColor = false;
            // 
            // DtgTickets
            // 
            this.DtgTickets.AllowUserToAddRows = false;
            this.DtgTickets.AllowUserToDeleteRows = false;
            this.DtgTickets.AllowUserToOrderColumns = true;
            this.DtgTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DtgTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DtgTickets.ColumnHeadersHeight = 28;
            this.DtgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgTickets.DefaultCellStyle = dataGridViewCellStyle7;
            this.DtgTickets.EnableHeadersVisualStyles = false;
            this.DtgTickets.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTickets.Location = new System.Drawing.Point(12, 262);
            this.DtgTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgTickets.MultiSelect = false;
            this.DtgTickets.Name = "DtgTickets";
            this.DtgTickets.ReadOnly = true;
            this.DtgTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgTickets.RowHeadersVisible = false;
            this.DtgTickets.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DtgTickets.RowTemplate.Height = 26;
            this.DtgTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTickets.Size = new System.Drawing.Size(1026, 333);
            this.DtgTickets.TabIndex = 5;
            // 
            // TxtNumber
            // 
            this.TxtNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtNumber.Location = new System.Drawing.Point(804, 43);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Size = new System.Drawing.Size(100, 25);
            this.TxtNumber.TabIndex = 6;
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumber.Location = new System.Drawing.Point(910, 48);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(69, 15);
            this.LblNumber.TabIndex = 7;
            this.LblNumber.Text = "رقم البطاقة :";
            // 
            // DtpStartDate
            // 
            this.DtpStartDate.CustomFormat = "dddd dd-MM-yyyy mm:HH";
            this.DtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartDate.Location = new System.Drawing.Point(704, 106);
            this.DtpStartDate.Name = "DtpStartDate";
            this.DtpStartDate.RightToLeftLayout = true;
            this.DtpStartDate.Size = new System.Drawing.Size(200, 25);
            this.DtpStartDate.TabIndex = 8;
            // 
            // LblOpenDate
            // 
            this.LblOpenDate.AutoSize = true;
            this.LblOpenDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblOpenDate.Location = new System.Drawing.Point(910, 114);
            this.LblOpenDate.Name = "LblOpenDate";
            this.LblOpenDate.Size = new System.Drawing.Size(96, 15);
            this.LblOpenDate.TabIndex = 7;
            this.LblOpenDate.Text = "تاريخ فتح البطاقة :";
            // 
            // LblCloseDate
            // 
            this.LblCloseDate.AutoSize = true;
            this.LblCloseDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCloseDate.Location = new System.Drawing.Point(910, 177);
            this.LblCloseDate.Name = "LblCloseDate";
            this.LblCloseDate.Size = new System.Drawing.Size(105, 15);
            this.LblCloseDate.TabIndex = 7;
            this.LblCloseDate.Text = "تاريخ إغلاق البطاقة :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dddd dd-MM-yyyy mm:HH";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(704, 169);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // CombCompanies
            // 
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(399, 43);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(121, 25);
            this.CombCompanies.TabIndex = 9;
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(526, 48);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 7;
            this.LblCompany.Text = "الشركة :";
            // 
            // LblEmployee
            // 
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblEmployee.Location = new System.Drawing.Point(526, 174);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(55, 15);
            this.LblEmployee.TabIndex = 7;
            this.LblEmployee.Text = "الموظف :";
            // 
            // CombEmployee
            // 
            this.CombEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombEmployee.FormattingEnabled = true;
            this.CombEmployee.Location = new System.Drawing.Point(399, 169);
            this.CombEmployee.Name = "CombEmployee";
            this.CombEmployee.Size = new System.Drawing.Size(121, 25);
            this.CombEmployee.TabIndex = 9;
            // 
            // LblSoftware
            // 
            this.LblSoftware.AutoSize = true;
            this.LblSoftware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblSoftware.Location = new System.Drawing.Point(526, 111);
            this.LblSoftware.Name = "LblSoftware";
            this.LblSoftware.Size = new System.Drawing.Size(49, 15);
            this.LblSoftware.TabIndex = 7;
            this.LblSoftware.Text = "البرنامج :";
            // 
            // CombSoftware
            // 
            this.CombSoftware.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombSoftware.FormattingEnabled = true;
            this.CombSoftware.Location = new System.Drawing.Point(399, 106);
            this.CombSoftware.Name = "CombSoftware";
            this.CombSoftware.Size = new System.Drawing.Size(121, 25);
            this.CombSoftware.TabIndex = 9;
            // 
            // DisplayTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.CombSoftware);
            this.Controls.Add(this.CombEmployee);
            this.Controls.Add(this.CombCompanies);
            this.Controls.Add(this.LblCloseDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.LblSoftware);
            this.Controls.Add(this.DtpStartDate);
            this.Controls.Add(this.LblEmployee);
            this.Controls.Add(this.LblOpenDate);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.TxtNumber);
            this.Controls.Add(this.DtgTickets);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayTickets";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "DisplayTickets";
            this.Load += new System.EventHandler(this.DisplayTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.DataGridView DtgTickets;
        private System.Windows.Forms.TextBox TxtNumber;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.DateTimePicker DtpStartDate;
        private System.Windows.Forms.Label LblOpenDate;
        private System.Windows.Forms.Label LblCloseDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.ComboBox CombEmployee;
        private System.Windows.Forms.Label LblSoftware;
        private System.Windows.Forms.ComboBox CombSoftware;
    }
}