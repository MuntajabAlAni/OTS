
namespace OTS.Ticketing.Win.MainForms
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgLastTickets = new System.Windows.Forms.DataGridView();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblDataGridTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RtbNotes = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblNotes = new System.Windows.Forms.Label();
            this.DtgUsers = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblUsers = new System.Windows.Forms.Label();
            this.BtnOnlineState = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLastTickets)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsers)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgLastTickets
            // 
            this.DtgLastTickets.AllowUserToAddRows = false;
            this.DtgLastTickets.AllowUserToDeleteRows = false;
            this.DtgLastTickets.AllowUserToOrderColumns = true;
            this.DtgLastTickets.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgLastTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.DtgLastTickets, "DtgLastTickets");
            this.DtgLastTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgLastTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgLastTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgLastTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgLastTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgLastTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgLastTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgLastTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgLastTickets.EnableHeadersVisualStyles = false;
            this.DtgLastTickets.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgLastTickets.MultiSelect = false;
            this.DtgLastTickets.Name = "DtgLastTickets";
            this.DtgLastTickets.ReadOnly = true;
            this.DtgLastTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgLastTickets.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgLastTickets.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgLastTickets.RowTemplate.Height = 26;
            this.DtgLastTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // LblTime
            // 
            resources.ApplyResources(this.LblTime, "LblTime");
            this.LblTime.Name = "LblTime";
            // 
            // LblDate
            // 
            resources.ApplyResources(this.LblDate, "LblDate");
            this.LblDate.Name = "LblDate";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 900;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LblDataGridTitle
            // 
            resources.ApplyResources(this.LblDataGridTitle, "LblDataGridTitle");
            this.LblDataGridTitle.Name = "LblDataGridTitle";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.LblTime);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Name = "panel1";
            // 
            // RtbNotes
            // 
            this.RtbNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.RtbNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.RtbNotes, "RtbNotes");
            this.RtbNotes.ForeColor = System.Drawing.Color.White;
            this.RtbNotes.Name = "RtbNotes";
            this.RtbNotes.Leave += new System.EventHandler(this.RtbNotes_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.LblNotes);
            this.panel2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // LblNotes
            // 
            resources.ApplyResources(this.LblNotes, "LblNotes");
            this.LblNotes.Name = "LblNotes";
            // 
            // DtgUsers
            // 
            this.DtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DtgUsers, "DtgUsers");
            this.DtgUsers.Name = "DtgUsers";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.LblUsers);
            this.panel3.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // LblUsers
            // 
            resources.ApplyResources(this.LblUsers, "LblUsers");
            this.LblUsers.Name = "LblUsers";
            // 
            // BtnOnlineState
            // 
            resources.ApplyResources(this.BtnOnlineState, "BtnOnlineState");
            this.BtnOnlineState.Name = "BtnOnlineState";
            this.BtnOnlineState.UseVisualStyleBackColor = true;
            this.BtnOnlineState.Click += new System.EventHandler(this.BtnOnlineState_Click);
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnOnlineState);
            this.Controls.Add(this.DtgUsers);
            this.Controls.Add(this.RtbNotes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblDataGridTitle);
            this.Controls.Add(this.DtgLastTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLastTickets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsers)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgLastTickets;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LblDataGridTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox RtbNotes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblNotes;
        private System.Windows.Forms.DataGridView DtgUsers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblUsers;
        private System.Windows.Forms.Button BtnOnlineState;
    }
}