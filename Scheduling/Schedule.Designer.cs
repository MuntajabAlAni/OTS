
namespace OTS.Ticketing.Win.Scheduling
{
    partial class Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlLoad = new System.Windows.Forms.Panel();
            this.PbLoading = new System.Windows.Forms.PictureBox();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.DtgSchedule = new System.Windows.Forms.DataGridView();
            this.DtgTasks = new System.Windows.Forms.DataGridView();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnAddTask = new System.Windows.Forms.Button();
            this.BtnEditTask = new System.Windows.Forms.Button();
            this.LblDate = new System.Windows.Forms.Label();
            this.BtnToday = new System.Windows.Forms.Button();
            this.PnlLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlLoad
            // 
            this.PnlLoad.Controls.Add(this.PbLoading);
            this.PnlLoad.Location = new System.Drawing.Point(412, 204);
            this.PnlLoad.Name = "PnlLoad";
            this.PnlLoad.Size = new System.Drawing.Size(200, 100);
            this.PnlLoad.TabIndex = 9;
            // 
            // PbLoading
            // 
            this.PbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbLoading.Image = ((System.Drawing.Image)(resources.GetObject("PbLoading.Image")));
            this.PbLoading.Location = new System.Drawing.Point(-129, -150);
            this.PbLoading.Name = "PbLoading";
            this.PbLoading.Size = new System.Drawing.Size(458, 400);
            this.PbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLoading.TabIndex = 0;
            this.PbLoading.TabStop = false;
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblEmployeeName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblEmployeeName.Location = new System.Drawing.Point(67, 478);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(271, 47);
            this.LblEmployeeName.TabIndex = 7;
            this.LblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DtgSchedule
            // 
            this.DtgSchedule.AllowUserToAddRows = false;
            this.DtgSchedule.AllowUserToDeleteRows = false;
            this.DtgSchedule.AllowUserToResizeColumns = false;
            this.DtgSchedule.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgSchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DtgSchedule.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgSchedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgSchedule.ColumnHeadersHeight = 45;
            this.DtgSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgSchedule.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgSchedule.EnableHeadersVisualStyles = false;
            this.DtgSchedule.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgSchedule.Location = new System.Drawing.Point(12, 60);
            this.DtgSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgSchedule.MultiSelect = false;
            this.DtgSchedule.Name = "DtgSchedule";
            this.DtgSchedule.ReadOnly = true;
            this.DtgSchedule.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgSchedule.RowHeadersVisible = false;
            this.DtgSchedule.RowHeadersWidth = 65;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.DtgSchedule.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DtgSchedule.RowTemplate.Height = 26;
            this.DtgSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgSchedule.Size = new System.Drawing.Size(1026, 348);
            this.DtgSchedule.TabIndex = 3;
            this.DtgSchedule.Click += new System.EventHandler(this.DtgSchedule_Click);
            // 
            // DtgTasks
            // 
            this.DtgTasks.AllowUserToAddRows = false;
            this.DtgTasks.AllowUserToDeleteRows = false;
            this.DtgTasks.AllowUserToOrderColumns = true;
            this.DtgTasks.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DtgTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgTasks.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DtgTasks.ColumnHeadersHeight = 28;
            this.DtgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgTasks.DefaultCellStyle = dataGridViewCellStyle8;
            this.DtgTasks.EnableHeadersVisualStyles = false;
            this.DtgTasks.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTasks.Location = new System.Drawing.Point(412, 412);
            this.DtgTasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgTasks.MultiSelect = false;
            this.DtgTasks.Name = "DtgTasks";
            this.DtgTasks.ReadOnly = true;
            this.DtgTasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgTasks.RowHeadersVisible = false;
            this.DtgTasks.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.DtgTasks.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DtgTasks.RowTemplate.Height = 26;
            this.DtgTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTasks.Size = new System.Drawing.Size(626, 256);
            this.DtgTasks.TabIndex = 4;
            this.DtgTasks.DoubleClick += new System.EventHandler(this.DtgTasks_DoubleClick);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnPrevious.FlatAppearance.BorderSize = 2;
            this.BtnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnPrevious.ForeColor = System.Drawing.Color.White;
            this.BtnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevious.Image")));
            this.BtnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrevious.Location = new System.Drawing.Point(199, 10);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(115, 45);
            this.BtnPrevious.TabIndex = 0;
            this.BtnPrevious.Text = "السابق";
            this.BtnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrevious.UseVisualStyleBackColor = false;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnNext.FlatAppearance.BorderSize = 2;
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnNext.ForeColor = System.Drawing.Color.White;
            this.BtnNext.Image = ((System.Drawing.Image)(resources.GetObject("BtnNext.Image")));
            this.BtnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNext.Location = new System.Drawing.Point(12, 10);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(115, 45);
            this.BtnNext.TabIndex = 2;
            this.BtnNext.Text = "التالي";
            this.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnAddTask
            // 
            this.BtnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAddTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAddTask.FlatAppearance.BorderSize = 2;
            this.BtnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddTask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAddTask.Location = new System.Drawing.Point(214, 610);
            this.BtnAddTask.Name = "BtnAddTask";
            this.BtnAddTask.Size = new System.Drawing.Size(120, 45);
            this.BtnAddTask.TabIndex = 5;
            this.BtnAddTask.Text = "إضافة مهمة";
            this.BtnAddTask.UseVisualStyleBackColor = false;
            this.BtnAddTask.Click += new System.EventHandler(this.BtnAddTask_Click);
            // 
            // BtnEditTask
            // 
            this.BtnEditTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnEditTask.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnEditTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnEditTask.FlatAppearance.BorderSize = 2;
            this.BtnEditTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditTask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnEditTask.Location = new System.Drawing.Point(67, 610);
            this.BtnEditTask.Name = "BtnEditTask";
            this.BtnEditTask.Size = new System.Drawing.Size(120, 45);
            this.BtnEditTask.TabIndex = 6;
            this.BtnEditTask.Text = "تعديل مهمة";
            this.BtnEditTask.UseVisualStyleBackColor = false;
            this.BtnEditTask.Click += new System.EventHandler(this.BtnEditTask_Click);
            // 
            // LblDate
            // 
            this.LblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblDate.Location = new System.Drawing.Point(67, 534);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(271, 73);
            this.LblDate.TabIndex = 8;
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnToday
            // 
            this.BtnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnToday.FlatAppearance.BorderSize = 2;
            this.BtnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnToday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnToday.ForeColor = System.Drawing.Color.White;
            this.BtnToday.Image = ((System.Drawing.Image)(resources.GetObject("BtnToday.Image")));
            this.BtnToday.Location = new System.Drawing.Point(133, 10);
            this.BtnToday.Name = "BtnToday";
            this.BtnToday.Size = new System.Drawing.Size(60, 45);
            this.BtnToday.TabIndex = 1;
            this.BtnToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnToday.UseVisualStyleBackColor = false;
            this.BtnToday.Click += new System.EventHandler(this.BtnToday_Click);
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 680);
            this.Controls.Add(this.BtnEditTask);
            this.Controls.Add(this.BtnAddTask);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnToday);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.DtgTasks);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblEmployeeName);
            this.Controls.Add(this.PnlLoad);
            this.Controls.Add(this.DtgSchedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Schedule";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            this.PnlLoad.ResumeLayout(false);
            this.PnlLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlLoad;
        private System.Windows.Forms.PictureBox PbLoading;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.DataGridView DtgSchedule;
        private System.Windows.Forms.DataGridView DtgTasks;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnAddTask;
        private System.Windows.Forms.Button BtnEditTask;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Button BtnToday;
    }
}