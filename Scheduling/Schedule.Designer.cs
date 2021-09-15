
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
            this.DtgSchedule = new System.Windows.Forms.DataGridView();
            this.PnlLoad = new System.Windows.Forms.Panel();
            this.PbLoading = new System.Windows.Forms.PictureBox();
            this.DtgTasks = new System.Windows.Forms.DataGridView();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgSchedule)).BeginInit();
            this.PnlLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgSchedule
            // 
            this.DtgSchedule.AllowUserToAddRows = false;
            this.DtgSchedule.AllowUserToDeleteRows = false;
            this.DtgSchedule.AllowUserToResizeColumns = false;
            this.DtgSchedule.AllowUserToResizeRows = false;
            this.DtgSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgSchedule.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgSchedule.Location = new System.Drawing.Point(12, 39);
            this.DtgSchedule.MultiSelect = false;
            this.DtgSchedule.Name = "DtgSchedule";
            this.DtgSchedule.ReadOnly = true;
            this.DtgSchedule.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgSchedule.RowHeadersVisible = false;
            this.DtgSchedule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DtgSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgSchedule.Size = new System.Drawing.Size(1001, 323);
            this.DtgSchedule.TabIndex = 0;
            this.DtgSchedule.Click += new System.EventHandler(this.DtgSchedule_Click);
            // 
            // PnlLoad
            // 
            this.PnlLoad.Controls.Add(this.PbLoading);
            this.PnlLoad.Location = new System.Drawing.Point(412, 204);
            this.PnlLoad.Name = "PnlLoad";
            this.PnlLoad.Size = new System.Drawing.Size(200, 100);
            this.PnlLoad.TabIndex = 29;
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
            // DtgTasks
            // 
            this.DtgTasks.AllowUserToAddRows = false;
            this.DtgTasks.AllowUserToDeleteRows = false;
            this.DtgTasks.AllowUserToResizeColumns = false;
            this.DtgTasks.AllowUserToResizeRows = false;
            this.DtgTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTasks.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTasks.Location = new System.Drawing.Point(412, 368);
            this.DtgTasks.MultiSelect = false;
            this.DtgTasks.Name = "DtgTasks";
            this.DtgTasks.ReadOnly = true;
            this.DtgTasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgTasks.RowHeadersVisible = false;
            this.DtgTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DtgTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgTasks.Size = new System.Drawing.Size(601, 210);
            this.DtgTasks.TabIndex = 30;
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEmployeeName.AutoSize = true;
            this.LblEmployeeName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LblEmployeeName.Location = new System.Drawing.Point(68, 398);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(52, 21);
            this.LblEmployeeName.TabIndex = 31;
            this.LblEmployeeName.Text = "label1";
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.Location = new System.Drawing.Point(938, 10);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(75, 23);
            this.BtnPrevious.TabIndex = 32;
            this.BtnPrevious.Text = "Previous";
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(12, 10);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 32;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 590);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.LblEmployeeName);
            this.Controls.Add(this.PnlLoad);
            this.Controls.Add(this.DtgSchedule);
            this.Controls.Add(this.DtgTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Schedule";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgSchedule)).EndInit();
            this.PnlLoad.ResumeLayout(false);
            this.PnlLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgSchedule;
        private System.Windows.Forms.Panel PnlLoad;
        private System.Windows.Forms.PictureBox PbLoading;
        private System.Windows.Forms.DataGridView DtgTasks;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
    }
}