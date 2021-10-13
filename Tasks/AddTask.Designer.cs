
namespace OTS.Ticketing.Win.Tasks
{
    partial class AddTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTask));
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.LblDate = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblTo = new System.Windows.Forms.Label();
            this.LblFrom = new System.Windows.Forms.Label();
            this.DtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.DtpToTime = new System.Windows.Forms.DateTimePicker();
            this.BtnEditEmployee = new System.Windows.Forms.PictureBox();
            this.BtnEditCompany = new System.Windows.Forms.PictureBox();
            this.BtnAddEmployee = new System.Windows.Forms.PictureBox();
            this.BtnAddCompany = new System.Windows.Forms.PictureBox();
            this.CombEmployees = new System.Windows.Forms.ComboBox();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblTaskDetails = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.TxtTaskDetails = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.PnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContainer.Controls.Add(this.LblDate);
            this.PnlContainer.Controls.Add(this.DtpDate);
            this.PnlContainer.Controls.Add(this.LblTo);
            this.PnlContainer.Controls.Add(this.LblFrom);
            this.PnlContainer.Controls.Add(this.DtpFromTime);
            this.PnlContainer.Controls.Add(this.DtpToTime);
            this.PnlContainer.Controls.Add(this.BtnEditEmployee);
            this.PnlContainer.Controls.Add(this.BtnEditCompany);
            this.PnlContainer.Controls.Add(this.BtnAddEmployee);
            this.PnlContainer.Controls.Add(this.BtnAddCompany);
            this.PnlContainer.Controls.Add(this.CombEmployees);
            this.PnlContainer.Controls.Add(this.CombCompanies);
            this.PnlContainer.Controls.Add(this.LblEmployeeName);
            this.PnlContainer.Controls.Add(this.LblCompany);
            this.PnlContainer.Controls.Add(this.LblTaskDetails);
            this.PnlContainer.Controls.Add(this.BtnExit);
            this.PnlContainer.Controls.Add(this.TxtTaskDetails);
            this.PnlContainer.Controls.Add(this.BtnAdd);
            this.PnlContainer.Location = new System.Drawing.Point(10, 11);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(418, 344);
            this.PnlContainer.TabIndex = 0;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblDate.Location = new System.Drawing.Point(289, 108);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(73, 15);
            this.LblDate.TabIndex = 10;
            this.LblDate.Text = "تاريخ المهمة :";
            // 
            // DtpDate
            // 
            this.DtpDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpDate.CustomFormat = "";
            this.DtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(179, 100);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.RightToLeftLayout = true;
            this.DtpDate.Size = new System.Drawing.Size(104, 25);
            this.DtpDate.TabIndex = 2;
            this.DtpDate.Value = new System.DateTime(2021, 8, 4, 0, 0, 0, 0);
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblTo.Location = new System.Drawing.Point(289, 190);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(30, 15);
            this.LblTo.TabIndex = 12;
            this.LblTo.Text = "الى :";
            // 
            // LblFrom
            // 
            this.LblFrom.AutoSize = true;
            this.LblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblFrom.Location = new System.Drawing.Point(289, 149);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(28, 15);
            this.LblFrom.TabIndex = 11;
            this.LblFrom.Text = "من :";
            // 
            // DtpFromTime
            // 
            this.DtpFromTime.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpFromTime.CustomFormat = "";
            this.DtpFromTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpFromTime.Location = new System.Drawing.Point(177, 141);
            this.DtpFromTime.Name = "DtpFromTime";
            this.DtpFromTime.RightToLeftLayout = true;
            this.DtpFromTime.ShowUpDown = true;
            this.DtpFromTime.Size = new System.Drawing.Size(104, 25);
            this.DtpFromTime.TabIndex = 3;
            this.DtpFromTime.Value = new System.DateTime(2021, 9, 21, 10, 0, 0, 0);
            // 
            // DtpToTime
            // 
            this.DtpToTime.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpToTime.CustomFormat = "";
            this.DtpToTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtpToTime.Location = new System.Drawing.Point(177, 182);
            this.DtpToTime.Name = "DtpToTime";
            this.DtpToTime.RightToLeftLayout = true;
            this.DtpToTime.ShowUpDown = true;
            this.DtpToTime.Size = new System.Drawing.Size(106, 25);
            this.DtpToTime.TabIndex = 4;
            this.DtpToTime.Value = new System.DateTime(2021, 9, 21, 18, 0, 0, 0);
            // 
            // BtnEditEmployee
            // 
            this.BtnEditEmployee.BackColor = System.Drawing.Color.White;
            this.BtnEditEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditEmployee.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditEmployee.ErrorImage")));
            this.BtnEditEmployee.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditEmployee.Image")));
            this.BtnEditEmployee.Location = new System.Drawing.Point(88, 59);
            this.BtnEditEmployee.Name = "BtnEditEmployee";
            this.BtnEditEmployee.Size = new System.Drawing.Size(25, 25);
            this.BtnEditEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditEmployee.TabIndex = 36;
            this.BtnEditEmployee.TabStop = false;
            this.BtnEditEmployee.Click += new System.EventHandler(this.BtnEditEmployee_Click);
            // 
            // BtnEditCompany
            // 
            this.BtnEditCompany.BackColor = System.Drawing.Color.White;
            this.BtnEditCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.ErrorImage")));
            this.BtnEditCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.Image")));
            this.BtnEditCompany.Location = new System.Drawing.Point(88, 18);
            this.BtnEditCompany.Name = "BtnEditCompany";
            this.BtnEditCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnEditCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditCompany.TabIndex = 36;
            this.BtnEditCompany.TabStop = false;
            this.BtnEditCompany.Click += new System.EventHandler(this.BtnEditCompany_Click);
            // 
            // BtnAddEmployee
            // 
            this.BtnAddEmployee.BackColor = System.Drawing.Color.White;
            this.BtnAddEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddEmployee.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddEmployee.ErrorImage")));
            this.BtnAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddEmployee.Image")));
            this.BtnAddEmployee.Location = new System.Drawing.Point(113, 59);
            this.BtnAddEmployee.Name = "BtnAddEmployee";
            this.BtnAddEmployee.Size = new System.Drawing.Size(25, 25);
            this.BtnAddEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddEmployee.TabIndex = 37;
            this.BtnAddEmployee.TabStop = false;
            this.BtnAddEmployee.Click += new System.EventHandler(this.BtnAddEmployee_Click);
            // 
            // BtnAddCompany
            // 
            this.BtnAddCompany.BackColor = System.Drawing.Color.White;
            this.BtnAddCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.ErrorImage")));
            this.BtnAddCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.Image")));
            this.BtnAddCompany.Location = new System.Drawing.Point(113, 18);
            this.BtnAddCompany.Name = "BtnAddCompany";
            this.BtnAddCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnAddCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddCompany.TabIndex = 37;
            this.BtnAddCompany.TabStop = false;
            this.BtnAddCompany.Click += new System.EventHandler(this.BtnAddCompany_Click);
            // 
            // CombEmployees
            // 
            this.CombEmployees.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombEmployees.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombEmployees.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombEmployees.FormattingEnabled = true;
            this.CombEmployees.Location = new System.Drawing.Point(138, 59);
            this.CombEmployees.Name = "CombEmployees";
            this.CombEmployees.Size = new System.Drawing.Size(143, 25);
            this.CombEmployees.TabIndex = 1;
            // 
            // CombCompanies
            // 
            this.CombCompanies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombCompanies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(138, 18);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(143, 25);
            this.CombCompanies.TabIndex = 0;
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.AutoSize = true;
            this.LblEmployeeName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblEmployeeName.Location = new System.Drawing.Point(287, 64);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(55, 15);
            this.LblEmployeeName.TabIndex = 9;
            this.LblEmployeeName.Text = "الموظف :";
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(287, 23);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 8;
            this.LblCompany.Text = "الشركة :";
            // 
            // LblTaskDetails
            // 
            this.LblTaskDetails.AutoSize = true;
            this.LblTaskDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblTaskDetails.Location = new System.Drawing.Point(287, 228);
            this.LblTaskDetails.Name = "LblTaskDetails";
            this.LblTaskDetails.Size = new System.Drawing.Size(86, 15);
            this.LblTaskDetails.TabIndex = 13;
            this.LblTaskDetails.Text = "تفاصيل المهمة :";
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
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtTaskDetails
            // 
            this.TxtTaskDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtTaskDetails.Location = new System.Drawing.Point(138, 223);
            this.TxtTaskDetails.Name = "TxtTaskDetails";
            this.TxtTaskDetails.Size = new System.Drawing.Size(143, 25);
            this.TxtTaskDetails.TabIndex = 5;
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
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 366);
            this.Controls.Add(this.PnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddTask";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddTask";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.PnlContainer.ResumeLayout(false);
            this.PnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.PictureBox BtnEditCompany;
        private System.Windows.Forms.PictureBox BtnAddCompany;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblTaskDetails;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TxtTaskDetails;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.DateTimePicker DtpFromTime;
        private System.Windows.Forms.DateTimePicker DtpToTime;
        private System.Windows.Forms.PictureBox BtnEditEmployee;
        private System.Windows.Forms.PictureBox BtnAddEmployee;
        private System.Windows.Forms.ComboBox CombEmployees;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.DateTimePicker DtpDate;
    }
}