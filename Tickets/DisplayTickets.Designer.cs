
namespace OTS.Ticketing.Win.Tickets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayTickets));
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState13 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState14 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState15 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState16 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState17 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState18 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.DtgTickets = new System.Windows.Forms.DataGridView();
            this.LblNumberTitle = new System.Windows.Forms.Label();
            this.LblOpenDateTitle = new System.Windows.Forms.Label();
            this.LblCompanyTitle = new System.Windows.Forms.Label();
            this.LblEmployeeTitle = new System.Windows.Forms.Label();
            this.LblSoftwareTitle = new System.Windows.Forms.Label();
            this.LblRevisionTitle = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.LblRemarks = new System.Windows.Forms.Label();
            this.ToggleRemotely = new Bunifu.UI.WinForms.BunifuToggleSwitch();
            this.LblRemotely = new System.Windows.Forms.Label();
            this.LblRemote = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.CombStates = new System.Windows.Forms.ComboBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.LblPhoneNumberTitle = new System.Windows.Forms.Label();
            this.BtnAddState = new System.Windows.Forms.PictureBox();
            this.LblNumber = new System.Windows.Forms.Label();
            this.LblRevision = new System.Windows.Forms.Label();
            this.BtnEditState = new System.Windows.Forms.PictureBox();
            this.LblArrangement = new System.Windows.Forms.Label();
            this.ToggleArrangement = new Bunifu.UI.WinForms.BunifuToggleSwitch();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblPhoneNumber = new System.Windows.Forms.Label();
            this.LblSoftware = new System.Windows.Forms.Label();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.LblOpenDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditState)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnUpdate.FlatAppearance.BorderSize = 2;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(12, 212);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 45);
            this.BtnUpdate.TabIndex = 5;
            this.BtnUpdate.Text = "حفظ";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // DtgTickets
            // 
            this.DtgTickets.AllowUserToAddRows = false;
            this.DtgTickets.AllowUserToDeleteRows = false;
            this.DtgTickets.AllowUserToOrderColumns = true;
            this.DtgTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DtgTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DtgTickets.ColumnHeadersHeight = 28;
            this.DtgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgTickets.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DtgTickets.RowTemplate.Height = 26;
            this.DtgTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTickets.Size = new System.Drawing.Size(1026, 333);
            this.DtgTickets.TabIndex = 0;
            this.DtgTickets.DoubleClick += new System.EventHandler(this.DtgTickets_DoubleClick);
            // 
            // LblNumberTitle
            // 
            this.LblNumberTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumberTitle.AutoSize = true;
            this.LblNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumberTitle.Location = new System.Drawing.Point(950, 22);
            this.LblNumberTitle.Name = "LblNumberTitle";
            this.LblNumberTitle.Size = new System.Drawing.Size(69, 15);
            this.LblNumberTitle.TabIndex = 7;
            this.LblNumberTitle.Text = "رقم البطاقة :";
            // 
            // LblOpenDateTitle
            // 
            this.LblOpenDateTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOpenDateTitle.AutoSize = true;
            this.LblOpenDateTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblOpenDateTitle.Location = new System.Drawing.Point(642, 22);
            this.LblOpenDateTitle.Name = "LblOpenDateTitle";
            this.LblOpenDateTitle.Size = new System.Drawing.Size(96, 15);
            this.LblOpenDateTitle.TabIndex = 7;
            this.LblOpenDateTitle.Text = "تاريخ فتح البطاقة :";
            // 
            // LblCompanyTitle
            // 
            this.LblCompanyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompanyTitle.AutoSize = true;
            this.LblCompanyTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompanyTitle.Location = new System.Drawing.Point(950, 94);
            this.LblCompanyTitle.Name = "LblCompanyTitle";
            this.LblCompanyTitle.Size = new System.Drawing.Size(45, 15);
            this.LblCompanyTitle.TabIndex = 7;
            this.LblCompanyTitle.Text = "الشركة :";
            // 
            // LblEmployeeTitle
            // 
            this.LblEmployeeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEmployeeTitle.AutoSize = true;
            this.LblEmployeeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblEmployeeTitle.Location = new System.Drawing.Point(950, 202);
            this.LblEmployeeTitle.Name = "LblEmployeeTitle";
            this.LblEmployeeTitle.Size = new System.Drawing.Size(55, 15);
            this.LblEmployeeTitle.TabIndex = 7;
            this.LblEmployeeTitle.Text = "الموظف :";
            // 
            // LblSoftwareTitle
            // 
            this.LblSoftwareTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSoftwareTitle.AutoSize = true;
            this.LblSoftwareTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblSoftwareTitle.Location = new System.Drawing.Point(950, 166);
            this.LblSoftwareTitle.Name = "LblSoftwareTitle";
            this.LblSoftwareTitle.Size = new System.Drawing.Size(49, 15);
            this.LblSoftwareTitle.TabIndex = 7;
            this.LblSoftwareTitle.Text = "البرنامج :";
            // 
            // LblRevisionTitle
            // 
            this.LblRevisionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevisionTitle.AutoSize = true;
            this.LblRevisionTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRevisionTitle.Location = new System.Drawing.Point(950, 58);
            this.LblRevisionTitle.Name = "LblRevisionTitle";
            this.LblRevisionTitle.Size = new System.Drawing.Size(74, 15);
            this.LblRevisionTitle.TabIndex = 7;
            this.LblRevisionTitle.Text = "رقم المراجعة :";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(138, 136);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(498, 121);
            this.TxtRemarks.TabIndex = 2;
            // 
            // LblRemarks
            // 
            this.LblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemarks.Location = new System.Drawing.Point(642, 141);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(58, 15);
            this.LblRemarks.TabIndex = 7;
            this.LblRemarks.Text = "ملاحظات :";
            // 
            // ToggleRemotely
            // 
            this.ToggleRemotely.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleRemotely.Animation = 5;
            this.ToggleRemotely.BackColor = System.Drawing.Color.Transparent;
            this.ToggleRemotely.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleRemotely.BackgroundImage")));
            this.ToggleRemotely.Checked = false;
            this.ToggleRemotely.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleRemotely.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToggleRemotely.InnerCirclePadding = 3;
            this.ToggleRemotely.Location = new System.Drawing.Point(326, 93);
            this.ToggleRemotely.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleRemotely.Name = "ToggleRemotely";
            this.ToggleRemotely.Size = new System.Drawing.Size(51, 26);
            this.ToggleRemotely.TabIndex = 4;
            this.ToggleRemotely.ThumbMargin = 3;
            toggleState13.BackColor = System.Drawing.Color.DarkGray;
            toggleState13.BackColorInner = System.Drawing.Color.White;
            toggleState13.BorderColor = System.Drawing.Color.DarkGray;
            toggleState13.BorderColorInner = System.Drawing.Color.White;
            toggleState13.BorderRadius = 25;
            toggleState13.BorderRadiusInner = 17;
            toggleState13.BorderThickness = 1;
            toggleState13.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateDisabled = toggleState13;
            toggleState14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState14.BackColorInner = System.Drawing.Color.White;
            toggleState14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState14.BorderColorInner = System.Drawing.Color.White;
            toggleState14.BorderRadius = 25;
            toggleState14.BorderRadiusInner = 17;
            toggleState14.BorderThickness = 1;
            toggleState14.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateOff = toggleState14;
            toggleState15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState15.BackColorInner = System.Drawing.Color.White;
            toggleState15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState15.BorderColorInner = System.Drawing.Color.White;
            toggleState15.BorderRadius = 25;
            toggleState15.BorderRadiusInner = 17;
            toggleState15.BorderThickness = 1;
            toggleState15.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateOn = toggleState15;
            this.ToggleRemotely.Value = false;
            this.ToggleRemotely.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // LblRemotely
            // 
            this.LblRemotely.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemotely.AutoSize = true;
            this.LblRemotely.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemotely.Location = new System.Drawing.Point(383, 99);
            this.LblRemotely.Name = "LblRemotely";
            this.LblRemotely.Size = new System.Drawing.Size(70, 15);
            this.LblRemotely.TabIndex = 7;
            this.LblRemotely.Text = "طريقة الحل :";
            // 
            // LblRemote
            // 
            this.LblRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemote.AutoSize = true;
            this.LblRemote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemote.Location = new System.Drawing.Point(221, 99);
            this.LblRemote.Name = "LblRemote";
            this.LblRemote.Size = new System.Drawing.Size(66, 15);
            this.LblRemote.TabIndex = 7;
            this.LblRemote.Text = "بإتصال فقط";
            // 
            // LblState
            // 
            this.LblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblState.Location = new System.Drawing.Point(642, 99);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(40, 15);
            this.LblState.TabIndex = 7;
            this.LblState.Text = "الحالة :";
            // 
            // CombStates
            // 
            this.CombStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombStates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombStates.FormattingEnabled = true;
            this.CombStates.Location = new System.Drawing.Point(515, 94);
            this.CombStates.Name = "CombStates";
            this.CombStates.Size = new System.Drawing.Size(121, 25);
            this.CombStates.TabIndex = 1;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRefresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnRefresh.FlatAppearance.BorderSize = 2;
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnRefresh.Location = new System.Drawing.Point(12, 158);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(120, 45);
            this.BtnRefresh.TabIndex = 6;
            this.BtnRefresh.Text = "تحديث";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // LblPhoneNumberTitle
            // 
            this.LblPhoneNumberTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPhoneNumberTitle.AutoSize = true;
            this.LblPhoneNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPhoneNumberTitle.Location = new System.Drawing.Point(950, 130);
            this.LblPhoneNumberTitle.Name = "LblPhoneNumberTitle";
            this.LblPhoneNumberTitle.Size = new System.Drawing.Size(65, 15);
            this.LblPhoneNumberTitle.TabIndex = 7;
            this.LblPhoneNumberTitle.Text = "رقم الهاتف :";
            // 
            // BtnAddState
            // 
            this.BtnAddState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddState.BackColor = System.Drawing.Color.White;
            this.BtnAddState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddState.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddState.ErrorImage")));
            this.BtnAddState.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddState.Image")));
            this.BtnAddState.Location = new System.Drawing.Point(490, 94);
            this.BtnAddState.Name = "BtnAddState";
            this.BtnAddState.Size = new System.Drawing.Size(25, 25);
            this.BtnAddState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddState.TabIndex = 23;
            this.BtnAddState.TabStop = false;
            this.BtnAddState.Click += new System.EventHandler(this.BtnAddState_Click);
            // 
            // LblNumber
            // 
            this.LblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumber.AutoSize = true;
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblNumber.Location = new System.Drawing.Point(916, 17);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(0, 25);
            this.LblNumber.TabIndex = 24;
            // 
            // LblRevision
            // 
            this.LblRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevision.AutoSize = true;
            this.LblRevision.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblRevision.Location = new System.Drawing.Point(916, 53);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.Size = new System.Drawing.Size(0, 25);
            this.LblRevision.TabIndex = 24;
            // 
            // BtnEditState
            // 
            this.BtnEditState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEditState.BackColor = System.Drawing.Color.White;
            this.BtnEditState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditState.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditState.ErrorImage")));
            this.BtnEditState.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditState.Image")));
            this.BtnEditState.Location = new System.Drawing.Point(465, 94);
            this.BtnEditState.Name = "BtnEditState";
            this.BtnEditState.Size = new System.Drawing.Size(25, 25);
            this.BtnEditState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditState.TabIndex = 25;
            this.BtnEditState.TabStop = false;
            this.BtnEditState.Click += new System.EventHandler(this.BtnEditState_Click);
            // 
            // LblArrangement
            // 
            this.LblArrangement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblArrangement.AutoSize = true;
            this.LblArrangement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblArrangement.Location = new System.Drawing.Point(383, 53);
            this.LblArrangement.Name = "LblArrangement";
            this.LblArrangement.Size = new System.Drawing.Size(81, 15);
            this.LblArrangement.TabIndex = 7;
            this.LblArrangement.Text = "ترتيب الملفات :";
            // 
            // ToggleArrangement
            // 
            this.ToggleArrangement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleArrangement.Animation = 5;
            this.ToggleArrangement.BackColor = System.Drawing.Color.Transparent;
            this.ToggleArrangement.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleArrangement.BackgroundImage")));
            this.ToggleArrangement.Checked = false;
            this.ToggleArrangement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleArrangement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToggleArrangement.InnerCirclePadding = 3;
            this.ToggleArrangement.Location = new System.Drawing.Point(326, 47);
            this.ToggleArrangement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleArrangement.Name = "ToggleArrangement";
            this.ToggleArrangement.Size = new System.Drawing.Size(51, 26);
            this.ToggleArrangement.TabIndex = 3;
            this.ToggleArrangement.ThumbMargin = 3;
            toggleState16.BackColor = System.Drawing.Color.DarkGray;
            toggleState16.BackColorInner = System.Drawing.Color.White;
            toggleState16.BorderColor = System.Drawing.Color.DarkGray;
            toggleState16.BorderColorInner = System.Drawing.Color.White;
            toggleState16.BorderRadius = 25;
            toggleState16.BorderRadiusInner = 17;
            toggleState16.BorderThickness = 1;
            toggleState16.BorderThicknessInner = 1;
            this.ToggleArrangement.ToggleStateDisabled = toggleState16;
            toggleState17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState17.BackColorInner = System.Drawing.Color.White;
            toggleState17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState17.BorderColorInner = System.Drawing.Color.White;
            toggleState17.BorderRadius = 25;
            toggleState17.BorderRadiusInner = 17;
            toggleState17.BorderThickness = 1;
            toggleState17.BorderThicknessInner = 1;
            this.ToggleArrangement.ToggleStateOff = toggleState17;
            toggleState18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState18.BackColorInner = System.Drawing.Color.White;
            toggleState18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState18.BorderColorInner = System.Drawing.Color.White;
            toggleState18.BorderRadius = 25;
            toggleState18.BorderRadiusInner = 17;
            toggleState18.BorderThickness = 1;
            toggleState18.BorderThicknessInner = 1;
            this.ToggleArrangement.ToggleStateOn = toggleState18;
            this.ToggleArrangement.Value = false;
            this.ToggleArrangement.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblCompany.Location = new System.Drawing.Point(787, 86);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(0, 20);
            this.LblCompany.TabIndex = 24;
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPhoneNumber.AutoSize = true;
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblPhoneNumber.Location = new System.Drawing.Point(787, 122);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(0, 20);
            this.LblPhoneNumber.TabIndex = 24;
            // 
            // LblSoftware
            // 
            this.LblSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSoftware.AutoSize = true;
            this.LblSoftware.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblSoftware.Location = new System.Drawing.Point(787, 158);
            this.LblSoftware.Name = "LblSoftware";
            this.LblSoftware.Size = new System.Drawing.Size(0, 20);
            this.LblSoftware.TabIndex = 24;
            // 
            // LblEmployee
            // 
            this.LblEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblEmployee.Location = new System.Drawing.Point(787, 194);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(0, 20);
            this.LblEmployee.TabIndex = 24;
            // 
            // LblOpenDate
            // 
            this.LblOpenDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOpenDate.AutoSize = true;
            this.LblOpenDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblOpenDate.Location = new System.Drawing.Point(436, 18);
            this.LblOpenDate.Name = "LblOpenDate";
            this.LblOpenDate.Size = new System.Drawing.Size(0, 20);
            this.LblOpenDate.TabIndex = 24;
            // 
            // DisplayTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.BtnEditState);
            this.Controls.Add(this.LblEmployee);
            this.Controls.Add(this.LblSoftware);
            this.Controls.Add(this.LblPhoneNumber);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblRevision);
            this.Controls.Add(this.LblOpenDate);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.BtnAddState);
            this.Controls.Add(this.ToggleArrangement);
            this.Controls.Add(this.ToggleRemotely);
            this.Controls.Add(this.CombStates);
            this.Controls.Add(this.LblSoftwareTitle);
            this.Controls.Add(this.LblEmployeeTitle);
            this.Controls.Add(this.LblPhoneNumberTitle);
            this.Controls.Add(this.LblOpenDateTitle);
            this.Controls.Add(this.LblCompanyTitle);
            this.Controls.Add(this.LblRemarks);
            this.Controls.Add(this.LblRemote);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblArrangement);
            this.Controls.Add(this.LblRemotely);
            this.Controls.Add(this.LblRevisionTitle);
            this.Controls.Add(this.LblNumberTitle);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.DtgTickets);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayTickets";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "DisplayTickets";
            this.Load += new System.EventHandler(this.DisplayTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.DataGridView DtgTickets;
        private System.Windows.Forms.Label LblNumberTitle;
        private System.Windows.Forms.Label LblOpenDateTitle;
        private System.Windows.Forms.Label LblCompanyTitle;
        private System.Windows.Forms.Label LblEmployeeTitle;
        private System.Windows.Forms.Label LblSoftwareTitle;
        private System.Windows.Forms.Label LblRevisionTitle;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Label LblRemarks;
        private Bunifu.UI.WinForms.BunifuToggleSwitch ToggleRemotely;
        private System.Windows.Forms.Label LblRemotely;
        private System.Windows.Forms.Label LblRemote;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.ComboBox CombStates;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Label LblPhoneNumberTitle;
        private System.Windows.Forms.PictureBox BtnAddState;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.Label LblRevision;
        private System.Windows.Forms.PictureBox BtnEditState;
        private System.Windows.Forms.Label LblArrangement;
        private Bunifu.UI.WinForms.BunifuToggleSwitch ToggleArrangement;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblPhoneNumber;
        private System.Windows.Forms.Label LblSoftware;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.Label LblOpenDate;
    }
}