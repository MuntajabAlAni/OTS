
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.BtnRefresh = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            this.DtgLastTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            resources.ApplyResources(this.DtgLastTickets, "DtgLastTickets");
            this.DtgLastTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgLastTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgLastTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgLastTickets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgLastTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgLastTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DtgLastTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgLastTickets.DefaultCellStyle = dataGridViewCellStyle21;
            this.DtgLastTickets.EnableHeadersVisualStyles = false;
            this.DtgLastTickets.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgLastTickets.MultiSelect = false;
            this.DtgLastTickets.Name = "DtgLastTickets";
            this.DtgLastTickets.ReadOnly = true;
            this.DtgLastTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgLastTickets.RowHeadersVisible = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            this.DtgLastTickets.RowsDefaultCellStyle = dataGridViewCellStyle22;
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
            this.DtgUsers.AllowUserToAddRows = false;
            this.DtgUsers.AllowUserToDeleteRows = false;
            this.DtgUsers.AllowUserToResizeColumns = false;
            this.DtgUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
            this.DtgUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgUsers.BackgroundColor = System.Drawing.Color.White;
            this.DtgUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            resources.ApplyResources(this.DtgUsers, "DtgUsers");
            this.DtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgUsers.DefaultCellStyle = dataGridViewCellStyle25;
            this.DtgUsers.EnableHeadersVisualStyles = false;
            this.DtgUsers.GridColor = System.Drawing.Color.White;
            this.DtgUsers.MultiSelect = false;
            this.DtgUsers.Name = "DtgUsers";
            this.DtgUsers.ReadOnly = true;
            this.DtgUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.DtgUsers.RowHeadersVisible = false;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            this.DtgUsers.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.DtgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgUsers.ShowCellErrors = false;
            this.DtgUsers.ShowCellToolTips = false;
            this.DtgUsers.ShowEditingIcon = false;
            this.DtgUsers.ShowRowErrors = false;
            this.DtgUsers.SelectionChanged += new System.EventHandler(this.DtgUsers_SelectionChanged);
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
            this.BtnOnlineState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnOnlineState.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnOnlineState.FlatAppearance.BorderSize = 2;
            resources.ApplyResources(this.BtnOnlineState, "BtnOnlineState");
            this.BtnOnlineState.Name = "BtnOnlineState";
            this.BtnOnlineState.UseVisualStyleBackColor = false;
            this.BtnOnlineState.Click += new System.EventHandler(this.BtnOnlineState_Click);
            // 
            // BtnRefresh
            // 
            resources.ApplyResources(this.BtnRefresh, "BtnRefresh");
            this.BtnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnRefresh.FlatAppearance.BorderSize = 2;
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnRefresh);
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
        private System.Windows.Forms.Button BtnRefresh;
    }
}