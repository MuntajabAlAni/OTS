
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
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.DtgTickets = new System.Windows.Forms.DataGridView();
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.LblNumber = new System.Windows.Forms.Label();
            this.DtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.LblOpenDate = new System.Windows.Forms.Label();
            this.LblCloseDate = new System.Windows.Forms.Label();
            this.DtpCloseDate = new System.Windows.Forms.DateTimePicker();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.CombEmployee = new System.Windows.Forms.ComboBox();
            this.LblSoftware = new System.Windows.Forms.Label();
            this.CombSoftware = new System.Windows.Forms.ComboBox();
            this.TxtRevision = new System.Windows.Forms.TextBox();
            this.LblRevision = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.LblRemarks = new System.Windows.Forms.Label();
            this.ToggleRemotely = new Bunifu.UI.WinForms.BunifuToggleSwitch();
            this.LblRemotely = new System.Windows.Forms.Label();
            this.LblRemote = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.CombState = new System.Windows.Forms.ComboBox();
            this.BtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnUpdate.FlatAppearance.BorderSize = 2;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(12, 212);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 45);
            this.BtnUpdate.TabIndex = 4;
            this.BtnUpdate.Text = "حفظ";
            this.BtnUpdate.UseVisualStyleBackColor = false;
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
            this.DtgTickets.ColumnHeadersHeight = 28;
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
            this.DtgTickets.TabIndex = 5;
            // 
            // TxtNumber
            // 
            this.TxtNumber.Enabled = false;
            this.TxtNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtNumber.Location = new System.Drawing.Point(790, 12);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Size = new System.Drawing.Size(100, 25);
            this.TxtNumber.TabIndex = 6;
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblNumber.Location = new System.Drawing.Point(896, 17);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(69, 15);
            this.LblNumber.TabIndex = 7;
            this.LblNumber.Text = "رقم البطاقة :";
            // 
            // DtpStartDate
            // 
            this.DtpStartDate.CustomFormat = "dddd dd-MM-yyyy mm:HH";
            this.DtpStartDate.Enabled = false;
            this.DtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartDate.Location = new System.Drawing.Point(436, 12);
            this.DtpStartDate.Name = "DtpStartDate";
            this.DtpStartDate.RightToLeftLayout = true;
            this.DtpStartDate.Size = new System.Drawing.Size(200, 25);
            this.DtpStartDate.TabIndex = 8;
            // 
            // LblOpenDate
            // 
            this.LblOpenDate.AutoSize = true;
            this.LblOpenDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblOpenDate.Location = new System.Drawing.Point(642, 17);
            this.LblOpenDate.Name = "LblOpenDate";
            this.LblOpenDate.Size = new System.Drawing.Size(96, 15);
            this.LblOpenDate.TabIndex = 7;
            this.LblOpenDate.Text = "تاريخ فتح البطاقة :";
            // 
            // LblCloseDate
            // 
            this.LblCloseDate.AutoSize = true;
            this.LblCloseDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCloseDate.Location = new System.Drawing.Point(291, 17);
            this.LblCloseDate.Name = "LblCloseDate";
            this.LblCloseDate.Size = new System.Drawing.Size(105, 15);
            this.LblCloseDate.TabIndex = 7;
            this.LblCloseDate.Text = "تاريخ إغلاق البطاقة :";
            // 
            // DtpCloseDate
            // 
            this.DtpCloseDate.CustomFormat = "dddd dd-MM-yyyy mm:HH";
            this.DtpCloseDate.Enabled = false;
            this.DtpCloseDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpCloseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCloseDate.Location = new System.Drawing.Point(85, 12);
            this.DtpCloseDate.Name = "DtpCloseDate";
            this.DtpCloseDate.RightToLeftLayout = true;
            this.DtpCloseDate.Size = new System.Drawing.Size(200, 25);
            this.DtpCloseDate.TabIndex = 8;
            // 
            // CombCompanies
            // 
            this.CombCompanies.Enabled = false;
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(764, 74);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(180, 25);
            this.CombCompanies.TabIndex = 9;
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(950, 79);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 7;
            this.LblCompany.Text = "الشركة :";
            // 
            // LblEmployee
            // 
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblEmployee.Location = new System.Drawing.Point(950, 203);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(55, 15);
            this.LblEmployee.TabIndex = 7;
            this.LblEmployee.Text = "الموظف :";
            // 
            // CombEmployee
            // 
            this.CombEmployee.Enabled = false;
            this.CombEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombEmployee.FormattingEnabled = true;
            this.CombEmployee.Location = new System.Drawing.Point(764, 198);
            this.CombEmployee.Name = "CombEmployee";
            this.CombEmployee.Size = new System.Drawing.Size(180, 25);
            this.CombEmployee.TabIndex = 9;
            // 
            // LblSoftware
            // 
            this.LblSoftware.AutoSize = true;
            this.LblSoftware.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblSoftware.Location = new System.Drawing.Point(950, 141);
            this.LblSoftware.Name = "LblSoftware";
            this.LblSoftware.Size = new System.Drawing.Size(49, 15);
            this.LblSoftware.TabIndex = 7;
            this.LblSoftware.Text = "البرنامج :";
            // 
            // CombSoftware
            // 
            this.CombSoftware.Enabled = false;
            this.CombSoftware.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombSoftware.FormattingEnabled = true;
            this.CombSoftware.Location = new System.Drawing.Point(764, 136);
            this.CombSoftware.Name = "CombSoftware";
            this.CombSoftware.Size = new System.Drawing.Size(180, 25);
            this.CombSoftware.TabIndex = 9;
            // 
            // TxtRevision
            // 
            this.TxtRevision.Enabled = false;
            this.TxtRevision.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRevision.Location = new System.Drawing.Point(536, 74);
            this.TxtRevision.Name = "TxtRevision";
            this.TxtRevision.Size = new System.Drawing.Size(100, 25);
            this.TxtRevision.TabIndex = 6;
            // 
            // LblRevision
            // 
            this.LblRevision.AutoSize = true;
            this.LblRevision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRevision.Location = new System.Drawing.Point(642, 79);
            this.LblRevision.Name = "LblRevision";
            this.LblRevision.Size = new System.Drawing.Size(74, 15);
            this.LblRevision.TabIndex = 7;
            this.LblRevision.Text = "رقم المراجعة :";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(438, 136);
            this.TxtRemarks.Multiline = true;
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(198, 87);
            this.TxtRemarks.TabIndex = 6;
            // 
            // LblRemarks
            // 
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
            this.ToggleRemotely.Animation = 5;
            this.ToggleRemotely.BackColor = System.Drawing.Color.Transparent;
            this.ToggleRemotely.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ToggleRemotely.BackgroundImage")));
            this.ToggleRemotely.Checked = true;
            this.ToggleRemotely.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToggleRemotely.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToggleRemotely.InnerCirclePadding = 3;
            this.ToggleRemotely.Location = new System.Drawing.Point(234, 135);
            this.ToggleRemotely.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToggleRemotely.Name = "ToggleRemotely";
            this.ToggleRemotely.Size = new System.Drawing.Size(51, 26);
            this.ToggleRemotely.TabIndex = 10;
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
            toggleState2.BackColor = System.Drawing.Color.Empty;
            toggleState2.BackColorInner = System.Drawing.Color.Empty;
            toggleState2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState2.BorderColorInner = System.Drawing.Color.Empty;
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
            this.ToggleRemotely.Value = true;
            this.ToggleRemotely.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs>(this.ToggleRemotely_CheckedChanged);
            // 
            // LblRemotely
            // 
            this.LblRemotely.AutoSize = true;
            this.LblRemotely.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemotely.Location = new System.Drawing.Point(291, 141);
            this.LblRemotely.Name = "LblRemotely";
            this.LblRemotely.Size = new System.Drawing.Size(70, 15);
            this.LblRemotely.TabIndex = 7;
            this.LblRemotely.Text = "طريقة الحل :";
            // 
            // LblRemote
            // 
            this.LblRemote.AutoSize = true;
            this.LblRemote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblRemote.Location = new System.Drawing.Point(129, 141);
            this.LblRemote.Name = "LblRemote";
            this.LblRemote.Size = new System.Drawing.Size(99, 15);
            this.LblRemote.TabIndex = 7;
            this.LblRemote.Text = "بإستخدام Anydesk";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblState.Location = new System.Drawing.Point(291, 79);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(40, 15);
            this.LblState.TabIndex = 7;
            this.LblState.Text = "الحالة :";
            // 
            // CombState
            // 
            this.CombState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombState.FormattingEnabled = true;
            this.CombState.Location = new System.Drawing.Point(164, 74);
            this.CombState.Name = "CombState";
            this.CombState.Size = new System.Drawing.Size(121, 25);
            this.CombState.TabIndex = 9;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Crimson;
            this.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnClose.FlatAppearance.BorderSize = 2;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnClose.Location = new System.Drawing.Point(12, 161);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(120, 45);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "إغلاق";
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // DisplayTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.ToggleRemotely);
            this.Controls.Add(this.CombSoftware);
            this.Controls.Add(this.CombEmployee);
            this.Controls.Add(this.CombState);
            this.Controls.Add(this.CombCompanies);
            this.Controls.Add(this.LblCloseDate);
            this.Controls.Add(this.DtpCloseDate);
            this.Controls.Add(this.LblSoftware);
            this.Controls.Add(this.DtpStartDate);
            this.Controls.Add(this.LblEmployee);
            this.Controls.Add(this.LblOpenDate);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.LblRemarks);
            this.Controls.Add(this.LblRemote);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblRemotely);
            this.Controls.Add(this.LblRevision);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.TxtRevision);
            this.Controls.Add(this.TxtNumber);
            this.Controls.Add(this.DtgTickets);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnUpdate);
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
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.DataGridView DtgTickets;
        private System.Windows.Forms.TextBox TxtNumber;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.DateTimePicker DtpStartDate;
        private System.Windows.Forms.Label LblOpenDate;
        private System.Windows.Forms.Label LblCloseDate;
        private System.Windows.Forms.DateTimePicker DtpCloseDate;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.ComboBox CombEmployee;
        private System.Windows.Forms.Label LblSoftware;
        private System.Windows.Forms.ComboBox CombSoftware;
        private System.Windows.Forms.TextBox TxtRevision;
        private System.Windows.Forms.Label LblRevision;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Label LblRemarks;
        private Bunifu.UI.WinForms.BunifuToggleSwitch ToggleRemotely;
        private System.Windows.Forms.Label LblRemotely;
        private System.Windows.Forms.Label LblRemote;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.ComboBox CombState;
        private System.Windows.Forms.Button BtnClose;
    }
}