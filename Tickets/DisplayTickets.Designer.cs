﻿
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayTickets));
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState1 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState2 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState3 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState4 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState5 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState6 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState7 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState8 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState toggleState9 = new Bunifu.UI.WinForms.BunifuToggleSwitch.ToggleState();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.DtgTickets = new System.Windows.Forms.DataGridView();
            this.LblNumberTitle = new System.Windows.Forms.Label();
            this.LblOpenDateTitle = new System.Windows.Forms.Label();
            this.LblCompanyTitle = new System.Windows.Forms.Label();
            this.LblUserTitle = new System.Windows.Forms.Label();
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
            this.LblIsIndexed = new System.Windows.Forms.Label();
            this.ToggleIsIndexed = new Bunifu.UI.WinForms.BunifuToggleSwitch();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblPhoneNumber = new System.Windows.Forms.Label();
            this.LblSoftware = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.LblOpenDate = new System.Windows.Forms.Label();
            this.TxtProblem = new System.Windows.Forms.TextBox();
            this.LblProblem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToggleClosed = new Bunifu.UI.WinForms.BunifuToggleSwitch();
            this.BtnOldTickets = new System.Windows.Forms.Button();
            this.CombTransferedTo = new System.Windows.Forms.ComboBox();
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
            this.BtnUpdate.TabIndex = 7;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTickets.ColumnHeadersHeight = 34;
            this.DtgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgTickets.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTickets.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgTickets.RowTemplate.Height = 26;
            this.DtgTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTickets.Size = new System.Drawing.Size(1026, 333);
            this.DtgTickets.TabIndex = 31;
            this.DtgTickets.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgTickets_CellContentDoubleClick);
            // 
            // LblNumberTitle
            // 
            this.LblNumberTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumberTitle.AutoSize = true;
            this.LblNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumberTitle.Location = new System.Drawing.Point(950, 25);
            this.LblNumberTitle.Name = "LblNumberTitle";
            this.LblNumberTitle.Size = new System.Drawing.Size(69, 15);
            this.LblNumberTitle.TabIndex = 10;
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
            this.LblOpenDateTitle.TabIndex = 25;
            this.LblOpenDateTitle.Text = "تاريخ فتح البطاقة :";
            // 
            // LblCompanyTitle
            // 
            this.LblCompanyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompanyTitle.AutoSize = true;
            this.LblCompanyTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompanyTitle.Location = new System.Drawing.Point(950, 99);
            this.LblCompanyTitle.Name = "LblCompanyTitle";
            this.LblCompanyTitle.Size = new System.Drawing.Size(45, 15);
            this.LblCompanyTitle.TabIndex = 12;
            this.LblCompanyTitle.Text = "الشركة :";
            // 
            // LblUserTitle
            // 
            this.LblUserTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUserTitle.AutoSize = true;
            this.LblUserTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblUserTitle.Location = new System.Drawing.Point(950, 227);
            this.LblUserTitle.Name = "LblUserTitle";
            this.LblUserTitle.Size = new System.Drawing.Size(55, 15);
            this.LblUserTitle.TabIndex = 15;
            this.LblUserTitle.Text = "الموظف :";
            // 
            // LblSoftwareTitle
            // 
            this.LblSoftwareTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSoftwareTitle.AutoSize = true;
            this.LblSoftwareTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblSoftwareTitle.Location = new System.Drawing.Point(950, 184);
            this.LblSoftwareTitle.Name = "LblSoftwareTitle";
            this.LblSoftwareTitle.Size = new System.Drawing.Size(49, 15);
            this.LblSoftwareTitle.TabIndex = 14;
            this.LblSoftwareTitle.Text = "البرنامج :";
            // 
            // LblRevisionTitle
            // 
            this.LblRevisionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevisionTitle.AutoSize = true;
            this.LblRevisionTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRevisionTitle.Location = new System.Drawing.Point(950, 63);
            this.LblRevisionTitle.Name = "LblRevisionTitle";
            this.LblRevisionTitle.Size = new System.Drawing.Size(74, 15);
            this.LblRevisionTitle.TabIndex = 11;
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
            this.TxtRemarks.TabIndex = 3;
            // 
            // LblRemarks
            // 
            this.LblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemarks.Location = new System.Drawing.Point(642, 141);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(58, 15);
            this.LblRemarks.TabIndex = 22;
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
            this.ToggleRemotely.Location = new System.Drawing.Point(308, 55);
            this.ToggleRemotely.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleRemotely.Name = "ToggleRemotely";
            this.ToggleRemotely.Size = new System.Drawing.Size(51, 26);
            this.ToggleRemotely.TabIndex = 5;
            this.ToggleRemotely.ThumbMargin = 3;
            toggleState1.BackColor = System.Drawing.Color.DarkGray;
            toggleState1.BackColorInner = System.Drawing.Color.White;
            toggleState1.BorderColor = System.Drawing.Color.DarkGray;
            toggleState1.BorderColorInner = System.Drawing.Color.White;
            toggleState1.BorderRadius = 25;
            toggleState1.BorderRadiusInner = 17;
            toggleState1.BorderThickness = 1;
            toggleState1.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateDisabled = toggleState1;
            toggleState2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState2.BackColorInner = System.Drawing.Color.White;
            toggleState2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState2.BorderColorInner = System.Drawing.Color.White;
            toggleState2.BorderRadius = 25;
            toggleState2.BorderRadiusInner = 17;
            toggleState2.BorderThickness = 1;
            toggleState2.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateOff = toggleState2;
            toggleState3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState3.BackColorInner = System.Drawing.Color.White;
            toggleState3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState3.BorderColorInner = System.Drawing.Color.White;
            toggleState3.BorderRadius = 25;
            toggleState3.BorderRadiusInner = 17;
            toggleState3.BorderThickness = 1;
            toggleState3.BorderThicknessInner = 1;
            this.ToggleRemotely.ToggleStateOn = toggleState3;
            this.ToggleRemotely.Value = false;
            this.ToggleRemotely.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // LblRemotely
            // 
            this.LblRemotely.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemotely.AutoSize = true;
            this.LblRemotely.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemotely.Location = new System.Drawing.Point(365, 61);
            this.LblRemotely.Name = "LblRemotely";
            this.LblRemotely.Size = new System.Drawing.Size(70, 15);
            this.LblRemotely.TabIndex = 28;
            this.LblRemotely.Text = "طريقة الحل :";
            // 
            // LblRemote
            // 
            this.LblRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRemote.AutoSize = true;
            this.LblRemote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemote.Location = new System.Drawing.Point(206, 61);
            this.LblRemote.Name = "LblRemote";
            this.LblRemote.Size = new System.Drawing.Size(66, 15);
            this.LblRemote.TabIndex = 29;
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
            this.LblState.TabIndex = 23;
            this.LblState.Text = "الحالة :";
            // 
            // CombStates
            // 
            this.CombStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombStates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombStates.FormattingEnabled = true;
            this.CombStates.Location = new System.Drawing.Point(465, 94);
            this.CombStates.Name = "CombStates";
            this.CombStates.Size = new System.Drawing.Size(171, 25);
            this.CombStates.TabIndex = 1;
            this.CombStates.SelectedValueChanged += new System.EventHandler(this.CombStates_SelectedValueChanged);
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
            this.BtnRefresh.TabIndex = 8;
            this.BtnRefresh.Text = "تحديث";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // LblPhoneNumberTitle
            // 
            this.LblPhoneNumberTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPhoneNumberTitle.AutoSize = true;
            this.LblPhoneNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPhoneNumberTitle.Location = new System.Drawing.Point(950, 141);
            this.LblPhoneNumberTitle.Name = "LblPhoneNumberTitle";
            this.LblPhoneNumberTitle.Size = new System.Drawing.Size(65, 15);
            this.LblPhoneNumberTitle.TabIndex = 13;
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
            this.BtnAddState.Location = new System.Drawing.Point(440, 94);
            this.BtnAddState.Name = "BtnAddState";
            this.BtnAddState.Size = new System.Drawing.Size(25, 25);
            this.BtnAddState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddState.TabIndex = 23;
            this.BtnAddState.TabStop = false;
            this.BtnAddState.Visible = false;
            this.BtnAddState.Click += new System.EventHandler(this.BtnAddState_Click);
            // 
            // LblNumber
            // 
            this.LblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblNumber.Location = new System.Drawing.Point(753, 18);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(191, 25);
            this.LblNumber.TabIndex = 17;
            // 
            // LblRevision
            // 
            this.LblRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRevision.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LblRevision.Location = new System.Drawing.Point(753, 56);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.Size = new System.Drawing.Size(191, 25);
            this.LblRevision.TabIndex = 16;
            // 
            // BtnEditState
            // 
            this.BtnEditState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEditState.BackColor = System.Drawing.Color.White;
            this.BtnEditState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditState.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditState.ErrorImage")));
            this.BtnEditState.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditState.Image")));
            this.BtnEditState.Location = new System.Drawing.Point(415, 94);
            this.BtnEditState.Name = "BtnEditState";
            this.BtnEditState.Size = new System.Drawing.Size(25, 25);
            this.BtnEditState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditState.TabIndex = 25;
            this.BtnEditState.TabStop = false;
            this.BtnEditState.Visible = false;
            this.BtnEditState.Click += new System.EventHandler(this.BtnEditState_Click);
            // 
            // LblIsIndexed
            // 
            this.LblIsIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIsIndexed.AutoSize = true;
            this.LblIsIndexed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblIsIndexed.Location = new System.Drawing.Point(365, 23);
            this.LblIsIndexed.Name = "LblIsIndexed";
            this.LblIsIndexed.Size = new System.Drawing.Size(81, 15);
            this.LblIsIndexed.TabIndex = 27;
            this.LblIsIndexed.Text = "ترتيب الملفات :";
            // 
            // ToggleIsIndexed
            // 
            this.ToggleIsIndexed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleIsIndexed.Animation = 5;
            this.ToggleIsIndexed.BackColor = System.Drawing.Color.Transparent;
            this.ToggleIsIndexed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleIsIndexed.BackgroundImage")));
            this.ToggleIsIndexed.Checked = false;
            this.ToggleIsIndexed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleIsIndexed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToggleIsIndexed.InnerCirclePadding = 3;
            this.ToggleIsIndexed.Location = new System.Drawing.Point(308, 17);
            this.ToggleIsIndexed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleIsIndexed.Name = "ToggleIsIndexed";
            this.ToggleIsIndexed.Size = new System.Drawing.Size(51, 26);
            this.ToggleIsIndexed.TabIndex = 4;
            this.ToggleIsIndexed.ThumbMargin = 3;
            toggleState4.BackColor = System.Drawing.Color.DarkGray;
            toggleState4.BackColorInner = System.Drawing.Color.White;
            toggleState4.BorderColor = System.Drawing.Color.DarkGray;
            toggleState4.BorderColorInner = System.Drawing.Color.White;
            toggleState4.BorderRadius = 25;
            toggleState4.BorderRadiusInner = 17;
            toggleState4.BorderThickness = 1;
            toggleState4.BorderThicknessInner = 1;
            this.ToggleIsIndexed.ToggleStateDisabled = toggleState4;
            toggleState5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState5.BackColorInner = System.Drawing.Color.White;
            toggleState5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState5.BorderColorInner = System.Drawing.Color.White;
            toggleState5.BorderRadius = 25;
            toggleState5.BorderRadiusInner = 17;
            toggleState5.BorderThickness = 1;
            toggleState5.BorderThicknessInner = 1;
            this.ToggleIsIndexed.ToggleStateOff = toggleState5;
            toggleState6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState6.BackColorInner = System.Drawing.Color.White;
            toggleState6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            toggleState6.BorderColorInner = System.Drawing.Color.White;
            toggleState6.BorderRadius = 25;
            toggleState6.BorderRadiusInner = 17;
            toggleState6.BorderThickness = 1;
            toggleState6.BorderThicknessInner = 1;
            this.ToggleIsIndexed.ToggleStateOn = toggleState6;
            this.ToggleIsIndexed.Value = false;
            this.ToggleIsIndexed.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblCompany.Location = new System.Drawing.Point(753, 94);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(191, 25);
            this.LblCompany.TabIndex = 18;
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblPhoneNumber.Location = new System.Drawing.Point(753, 133);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(191, 25);
            this.LblPhoneNumber.TabIndex = 19;
            // 
            // LblSoftware
            // 
            this.LblSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSoftware.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblSoftware.Location = new System.Drawing.Point(753, 180);
            this.LblSoftware.Name = "LblSoftware";
            this.LblSoftware.Size = new System.Drawing.Size(191, 25);
            this.LblSoftware.TabIndex = 20;
            // 
            // LblUser
            // 
            this.LblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblUser.Location = new System.Drawing.Point(753, 223);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(191, 25);
            this.LblUser.TabIndex = 21;
            // 
            // LblOpenDate
            // 
            this.LblOpenDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOpenDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LblOpenDate.Location = new System.Drawing.Point(445, 17);
            this.LblOpenDate.Name = "LblOpenDate";
            this.LblOpenDate.Size = new System.Drawing.Size(191, 25);
            this.LblOpenDate.TabIndex = 26;
            // 
            // TxtProblem
            // 
            this.TxtProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProblem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtProblem.Location = new System.Drawing.Point(465, 56);
            this.TxtProblem.Name = "TxtProblem";
            this.TxtProblem.Size = new System.Drawing.Size(171, 25);
            this.TxtProblem.TabIndex = 0;
            // 
            // LblProblem
            // 
            this.LblProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblProblem.AutoSize = true;
            this.LblProblem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblProblem.Location = new System.Drawing.Point(642, 61);
            this.LblProblem.Name = "LblProblem";
            this.LblProblem.Size = new System.Drawing.Size(73, 15);
            this.LblProblem.TabIndex = 24;
            this.LblProblem.Text = "نوع المشكلة :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(36, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "إغلاق البطاقة";
            // 
            // ToggleClosed
            // 
            this.ToggleClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleClosed.Animation = 5;
            this.ToggleClosed.BackColor = System.Drawing.Color.Transparent;
            this.ToggleClosed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleClosed.BackgroundImage")));
            this.ToggleClosed.Checked = false;
            this.ToggleClosed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleClosed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToggleClosed.InnerCirclePadding = 3;
            this.ToggleClosed.Location = new System.Drawing.Point(45, 74);
            this.ToggleClosed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleClosed.Name = "ToggleClosed";
            this.ToggleClosed.Size = new System.Drawing.Size(51, 26);
            this.ToggleClosed.TabIndex = 6;
            this.ToggleClosed.ThumbMargin = 3;
            toggleState7.BackColor = System.Drawing.Color.DarkGray;
            toggleState7.BackColorInner = System.Drawing.Color.White;
            toggleState7.BorderColor = System.Drawing.Color.DarkGray;
            toggleState7.BorderColorInner = System.Drawing.Color.White;
            toggleState7.BorderRadius = 25;
            toggleState7.BorderRadiusInner = 17;
            toggleState7.BorderThickness = 1;
            toggleState7.BorderThicknessInner = 1;
            this.ToggleClosed.ToggleStateDisabled = toggleState7;
            toggleState8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState8.BackColorInner = System.Drawing.Color.White;
            toggleState8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            toggleState8.BorderColorInner = System.Drawing.Color.White;
            toggleState8.BorderRadius = 25;
            toggleState8.BorderRadiusInner = 17;
            toggleState8.BorderThickness = 1;
            toggleState8.BorderThicknessInner = 1;
            this.ToggleClosed.ToggleStateOff = toggleState8;
            toggleState9.BackColor = System.Drawing.Color.Crimson;
            toggleState9.BackColorInner = System.Drawing.Color.White;
            toggleState9.BorderColor = System.Drawing.Color.Crimson;
            toggleState9.BorderColorInner = System.Drawing.Color.White;
            toggleState9.BorderRadius = 25;
            toggleState9.BorderRadiusInner = 17;
            toggleState9.BorderThickness = 1;
            toggleState9.BorderThicknessInner = 1;
            this.ToggleClosed.ToggleStateOn = toggleState9;
            this.ToggleClosed.Value = false;
            this.ToggleClosed.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // BtnOldTickets
            // 
            this.BtnOldTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOldTickets.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnOldTickets.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnOldTickets.FlatAppearance.BorderSize = 2;
            this.BtnOldTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOldTickets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnOldTickets.Location = new System.Drawing.Point(12, 107);
            this.BtnOldTickets.Name = "BtnOldTickets";
            this.BtnOldTickets.Size = new System.Drawing.Size(120, 45);
            this.BtnOldTickets.TabIndex = 9;
            this.BtnOldTickets.Text = "عرض البطاقات السابقة";
            this.BtnOldTickets.UseVisualStyleBackColor = false;
            this.BtnOldTickets.Click += new System.EventHandler(this.BtnOldTickets_Click);
            // 
            // CombTransferedTo
            // 
            this.CombTransferedTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombTransferedTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombTransferedTo.FormattingEnabled = true;
            this.CombTransferedTo.Location = new System.Drawing.Point(282, 94);
            this.CombTransferedTo.Name = "CombTransferedTo";
            this.CombTransferedTo.Size = new System.Drawing.Size(127, 25);
            this.CombTransferedTo.TabIndex = 2;
            this.CombTransferedTo.Visible = false;
            // 
            // DisplayTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.BtnEditState);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.LblSoftware);
            this.Controls.Add(this.LblPhoneNumber);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblRevision);
            this.Controls.Add(this.LblOpenDate);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.BtnAddState);
            this.Controls.Add(this.ToggleClosed);
            this.Controls.Add(this.ToggleIsIndexed);
            this.Controls.Add(this.ToggleRemotely);
            this.Controls.Add(this.CombTransferedTo);
            this.Controls.Add(this.CombStates);
            this.Controls.Add(this.LblSoftwareTitle);
            this.Controls.Add(this.LblUserTitle);
            this.Controls.Add(this.LblPhoneNumberTitle);
            this.Controls.Add(this.LblOpenDateTitle);
            this.Controls.Add(this.LblCompanyTitle);
            this.Controls.Add(this.LblProblem);
            this.Controls.Add(this.LblRemarks);
            this.Controls.Add(this.LblRemote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblIsIndexed);
            this.Controls.Add(this.LblRemotely);
            this.Controls.Add(this.LblRevisionTitle);
            this.Controls.Add(this.LblNumberTitle);
            this.Controls.Add(this.TxtProblem);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.DtgTickets);
            this.Controls.Add(this.BtnOldTickets);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayTickets";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label LblUserTitle;
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
        private System.Windows.Forms.Label LblIsIndexed;
        private Bunifu.UI.WinForms.BunifuToggleSwitch ToggleIsIndexed;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblPhoneNumber;
        private System.Windows.Forms.Label LblSoftware;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblOpenDate;
        private System.Windows.Forms.TextBox TxtProblem;
        private System.Windows.Forms.Label LblProblem;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuToggleSwitch ToggleClosed;
        private System.Windows.Forms.Button BtnOldTickets;
        private System.Windows.Forms.ComboBox CombTransferedTo;
    }
}