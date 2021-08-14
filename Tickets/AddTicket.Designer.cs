
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAddCompany = new System.Windows.Forms.PictureBox();
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
            this.BtnSearchPhoneNumber = new System.Windows.Forms.PictureBox();
            this.BtnSearchCompany = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddPhoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUnclosedTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditPhoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchPhoneNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAddCompany
            // 
            this.BtnAddCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BtnAddCompany.Click += new System.EventHandler(this.BtnAddCompany_Click);
            // 
            // CombSoftware
            // 
            this.CombSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombSoftware.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombSoftware.FormattingEnabled = true;
            this.CombSoftware.Location = new System.Drawing.Point(232, 36);
            this.CombSoftware.Name = "CombSoftware";
            this.CombSoftware.Size = new System.Drawing.Size(180, 25);
            this.CombSoftware.TabIndex = 2;
            // 
            // CombEmployee
            // 
            this.CombEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombEmployee.FormattingEnabled = true;
            this.CombEmployee.Location = new System.Drawing.Point(232, 85);
            this.CombEmployee.Name = "CombEmployee";
            this.CombEmployee.Size = new System.Drawing.Size(180, 25);
            this.CombEmployee.TabIndex = 3;
            // 
            // CombCompanies
            // 
            this.CombCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombCompanies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombCompanies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(556, 36);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(180, 25);
            this.CombCompanies.TabIndex = 0;
            this.CombCompanies.SelectedValueChanged += new System.EventHandler(this.CombCompanies_SelectedValueChanged);
            this.CombCompanies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CombCompanies_KeyDown);
            // 
            // LblSoftware
            // 
            this.LblSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.LblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.LblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(742, 41);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 12;
            this.LblCompany.Text = "الشركة :";
            // 
            // LblRevisionTitle
            // 
            this.LblRevisionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevisionTitle.AutoSize = true;
            this.LblRevisionTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRevisionTitle.Location = new System.Drawing.Point(907, 90);
            this.LblRevisionTitle.Name = "LblRevisionTitle";
            this.LblRevisionTitle.Size = new System.Drawing.Size(74, 15);
            this.LblRevisionTitle.TabIndex = 9;
            this.LblRevisionTitle.Text = "رقم المراجعة :";
            // 
            // LblNumberTitle
            // 
            this.LblNumberTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumberTitle.AutoSize = true;
            this.LblNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumberTitle.Location = new System.Drawing.Point(907, 41);
            this.LblNumberTitle.Name = "LblNumberTitle";
            this.LblNumberTitle.Size = new System.Drawing.Size(69, 15);
            this.LblNumberTitle.TabIndex = 7;
            this.LblNumberTitle.Text = "رقم البطاقة :";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(22, 75);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(22, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // CombPhoneNumbers
            // 
            this.CombPhoneNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombPhoneNumbers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombPhoneNumbers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombPhoneNumbers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombPhoneNumbers.FormattingEnabled = true;
            this.CombPhoneNumbers.Location = new System.Drawing.Point(556, 85);
            this.CombPhoneNumbers.MaxLength = 11;
            this.CombPhoneNumbers.Name = "CombPhoneNumbers";
            this.CombPhoneNumbers.Size = new System.Drawing.Size(180, 25);
            this.CombPhoneNumbers.TabIndex = 1;
            this.CombPhoneNumbers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CombPhoneNumbers_KeyDown);
            this.CombPhoneNumbers.Leave += new System.EventHandler(this.CombPhoneNumbers_Leave);
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPhoneNumber.AutoSize = true;
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPhoneNumber.Location = new System.Drawing.Point(742, 90);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(65, 15);
            this.LblPhoneNumber.TabIndex = 13;
            this.LblPhoneNumber.Text = "رقم الهاتف :";
            // 
            // BtnAddPhoneNumber
            // 
            this.BtnAddPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BtnAddPhoneNumber.Click += new System.EventHandler(this.BtnAddPhoneNumber_Click);
            // 
            // DtgUnclosedTickets
            // 
            this.DtgUnclosedTickets.AllowUserToAddRows = false;
            this.DtgUnclosedTickets.AllowUserToDeleteRows = false;
            this.DtgUnclosedTickets.AllowUserToOrderColumns = true;
            this.DtgUnclosedTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUnclosedTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DtgUnclosedTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgUnclosedTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgUnclosedTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgUnclosedTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgUnclosedTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgUnclosedTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgUnclosedTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DtgUnclosedTickets.ColumnHeadersHeight = 34;
            this.DtgUnclosedTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgUnclosedTickets.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUnclosedTickets.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DtgUnclosedTickets.RowTemplate.Height = 26;
            this.DtgUnclosedTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgUnclosedTickets.Size = new System.Drawing.Size(1026, 427);
            this.DtgUnclosedTickets.TabIndex = 6;
            this.DtgUnclosedTickets.DoubleClick += new System.EventHandler(this.DtgUnclosedTickets_DoubleClick);
            // 
            // LblUnclosedTickets
            // 
            this.LblUnclosedTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUnclosedTickets.AutoSize = true;
            this.LblUnclosedTickets.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.LblUnclosedTickets.Location = new System.Drawing.Point(809, 133);
            this.LblUnclosedTickets.Name = "LblUnclosedTickets";
            this.LblUnclosedTickets.Size = new System.Drawing.Size(226, 31);
            this.LblUnclosedTickets.TabIndex = 11;
            this.LblUnclosedTickets.Text = "البطاقات الغير مغلقة :";
            // 
            // LblNumber
            // 
            this.LblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumber.AutoSize = true;
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblNumber.Location = new System.Drawing.Point(873, 36);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblNumber.Size = new System.Drawing.Size(34, 25);
            this.LblNumber.TabIndex = 8;
            this.LblNumber.Text = "99";
            // 
            // LblRevision
            // 
            this.LblRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevision.AutoSize = true;
            this.LblRevision.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblRevision.Location = new System.Drawing.Point(873, 85);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRevision.Size = new System.Drawing.Size(34, 25);
            this.LblRevision.TabIndex = 10;
            this.LblRevision.Text = "99";
            // 
            // BtnEditCompany
            // 
            this.BtnEditCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BtnEditCompany.Click += new System.EventHandler(this.BtnEditCompany_Click);
            // 
            // BtnEditPhoneNumber
            // 
            this.BtnEditPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BtnEditPhoneNumber.Click += new System.EventHandler(this.BtnEditPhoneNumber_Click);
            // 
            // BtnSearchPhoneNumber
            // 
            this.BtnSearchPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchPhoneNumber.BackColor = System.Drawing.Color.White;
            this.BtnSearchPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnSearchPhoneNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearchPhoneNumber.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnSearchPhoneNumber.ErrorImage")));
            this.BtnSearchPhoneNumber.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchPhoneNumber.Image")));
            this.BtnSearchPhoneNumber.Location = new System.Drawing.Point(481, 85);
            this.BtnSearchPhoneNumber.Name = "BtnSearchPhoneNumber";
            this.BtnSearchPhoneNumber.Size = new System.Drawing.Size(25, 25);
            this.BtnSearchPhoneNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnSearchPhoneNumber.TabIndex = 22;
            this.BtnSearchPhoneNumber.TabStop = false;
            this.BtnSearchPhoneNumber.Click += new System.EventHandler(this.BtnSearchPhoneNumber_Click);
            // 
            // BtnSearchCompany
            // 
            this.BtnSearchCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchCompany.BackColor = System.Drawing.Color.White;
            this.BtnSearchCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnSearchCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearchCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnSearchCompany.ErrorImage")));
            this.BtnSearchCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCompany.Image")));
            this.BtnSearchCompany.Location = new System.Drawing.Point(481, 36);
            this.BtnSearchCompany.Name = "BtnSearchCompany";
            this.BtnSearchCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnSearchCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnSearchCompany.TabIndex = 22;
            this.BtnSearchCompany.TabStop = false;
            this.BtnSearchCompany.Click += new System.EventHandler(this.BtnSearchCompany_Click);
            // 
            // AddTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.DtgUnclosedTickets);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnSearchCompany);
            this.Controls.Add(this.BtnSearchPhoneNumber);
            this.Controls.Add(this.BtnEditPhoneNumber);
            this.Controls.Add(this.BtnAddPhoneNumber);
            this.Controls.Add(this.BtnEditCompany);
            this.Controls.Add(this.BtnAddCompany);
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
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddPhoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUnclosedTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditPhoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchPhoneNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BtnAddCompany;
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
        private System.Windows.Forms.PictureBox BtnSearchPhoneNumber;
        private System.Windows.Forms.PictureBox BtnSearchCompany;
    }
}