
namespace OTS.Ticketing.Win.ActivityLog
{
    partial class DisplayActivities
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
            this.LblTo = new System.Windows.Forms.Label();
            this.LblFrom = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.CombUser = new System.Windows.Forms.ComboBox();
            this.DtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.DtpToDate = new System.Windows.Forms.DateTimePicker();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.DtgActivityLog = new System.Windows.Forms.DataGridView();
            this.CombActivities = new System.Windows.Forms.ComboBox();
            this.LblActivities = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgActivityLog)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTo
            // 
            this.LblTo.AutoSize = true;
            this.LblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblTo.Location = new System.Drawing.Point(392, 26);
            this.LblTo.Name = "LblTo";
            this.LblTo.Size = new System.Drawing.Size(30, 15);
            this.LblTo.TabIndex = 34;
            this.LblTo.Text = "الى :";
            // 
            // LblFrom
            // 
            this.LblFrom.AutoSize = true;
            this.LblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblFrom.Location = new System.Drawing.Point(562, 26);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(28, 15);
            this.LblFrom.TabIndex = 35;
            this.LblFrom.Text = "من :";
            // 
            // LblUser
            // 
            this.LblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUser.AutoSize = true;
            this.LblUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblUser.Location = new System.Drawing.Point(956, 26);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(55, 15);
            this.LblUser.TabIndex = 36;
            this.LblUser.Text = "الموظف :";
            // 
            // CombUser
            // 
            this.CombUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombUser.FormattingEnabled = true;
            this.CombUser.Location = new System.Drawing.Point(824, 21);
            this.CombUser.Name = "CombUser";
            this.CombUser.Size = new System.Drawing.Size(126, 25);
            this.CombUser.TabIndex = 28;
            // 
            // DtpFromDate
            // 
            this.DtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpFromDate.CustomFormat = "";
            this.DtpFromDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFromDate.Location = new System.Drawing.Point(452, 21);
            this.DtpFromDate.Name = "DtpFromDate";
            this.DtpFromDate.Size = new System.Drawing.Size(104, 25);
            this.DtpFromDate.TabIndex = 29;
            this.DtpFromDate.Value = new System.DateTime(2021, 8, 4, 0, 0, 0, 0);
            // 
            // DtpToDate
            // 
            this.DtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.DtpToDate.CustomFormat = "";
            this.DtpToDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpToDate.Location = new System.Drawing.Point(280, 21);
            this.DtpToDate.Name = "DtpToDate";
            this.DtpToDate.Size = new System.Drawing.Size(106, 25);
            this.DtpToDate.TabIndex = 30;
            this.DtpToDate.Value = new System.DateTime(2021, 9, 12, 0, 0, 0, 0);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnUpdate.FlatAppearance.BorderSize = 2;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnUpdate.Location = new System.Drawing.Point(12, 11);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(120, 45);
            this.BtnUpdate.TabIndex = 31;
            this.BtnUpdate.Text = "تحديث";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(12, 452);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 32;
            this.BtnExit.Text = "رجوع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // DtgActivityLog
            // 
            this.DtgActivityLog.AllowUserToAddRows = false;
            this.DtgActivityLog.AllowUserToDeleteRows = false;
            this.DtgActivityLog.AllowUserToOrderColumns = true;
            this.DtgActivityLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgActivityLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgActivityLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgActivityLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgActivityLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgActivityLog.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgActivityLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgActivityLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgActivityLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgActivityLog.ColumnHeadersHeight = 34;
            this.DtgActivityLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgActivityLog.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgActivityLog.EnableHeadersVisualStyles = false;
            this.DtgActivityLog.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgActivityLog.Location = new System.Drawing.Point(12, 61);
            this.DtgActivityLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgActivityLog.MultiSelect = false;
            this.DtgActivityLog.Name = "DtgActivityLog";
            this.DtgActivityLog.ReadOnly = true;
            this.DtgActivityLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgActivityLog.RowHeadersVisible = false;
            this.DtgActivityLog.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgActivityLog.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgActivityLog.RowTemplate.Height = 26;
            this.DtgActivityLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgActivityLog.Size = new System.Drawing.Size(1001, 386);
            this.DtgActivityLog.TabIndex = 33;
            this.DtgActivityLog.DoubleClick += new System.EventHandler(this.DtgActivityLog_DoubleClick);
            // 
            // CombActivities
            // 
            this.CombActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CombActivities.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombActivities.FormattingEnabled = true;
            this.CombActivities.Location = new System.Drawing.Point(617, 21);
            this.CombActivities.Name = "CombActivities";
            this.CombActivities.Size = new System.Drawing.Size(126, 25);
            this.CombActivities.TabIndex = 28;
            // 
            // LblActivities
            // 
            this.LblActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblActivities.AutoSize = true;
            this.LblActivities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblActivities.Location = new System.Drawing.Point(749, 26);
            this.LblActivities.Name = "LblActivities";
            this.LblActivities.Size = new System.Drawing.Size(63, 15);
            this.LblActivities.TabIndex = 36;
            this.LblActivities.Text = "نوع الحركة :";
            // 
            // DisplayActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 509);
            this.Controls.Add(this.LblTo);
            this.Controls.Add(this.LblFrom);
            this.Controls.Add(this.LblActivities);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.CombActivities);
            this.Controls.Add(this.CombUser);
            this.Controls.Add(this.DtpFromDate);
            this.Controls.Add(this.DtpToDate);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.DtgActivityLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DisplayActivities";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DisplayActivities";
            this.Load += new System.EventHandler(this.DisplayActivities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgActivityLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTo;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.ComboBox CombUser;
        private System.Windows.Forms.DateTimePicker DtpFromDate;
        private System.Windows.Forms.DateTimePicker DtpToDate;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridView DtgActivityLog;
        private System.Windows.Forms.ComboBox CombActivities;
        private System.Windows.Forms.Label LblActivities;
    }
}