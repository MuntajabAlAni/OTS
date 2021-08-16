
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgLastTickets = new System.Windows.Forms.DataGridView();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LblDataGridTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLastTickets)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.DtgLastTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.DtgLastTickets.ColumnHeadersHeight = 34;
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
            this.DtgLastTickets.Location = new System.Drawing.Point(27, 349);
            this.DtgLastTickets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgLastTickets.MultiSelect = false;
            this.DtgLastTickets.Name = "DtgLastTickets";
            this.DtgLastTickets.ReadOnly = true;
            this.DtgLastTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgLastTickets.RowHeadersVisible = false;
            this.DtgLastTickets.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgLastTickets.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgLastTickets.RowTemplate.Height = 26;
            this.DtgLastTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgLastTickets.Size = new System.Drawing.Size(997, 218);
            this.DtgLastTickets.TabIndex = 2;
            // 
            // LblTime
            // 
            this.LblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("Segoe UI", 50F);
            this.LblTime.Location = new System.Drawing.Point(6, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(284, 89);
            this.LblTime.TabIndex = 3;
            this.LblTime.Text = "00:00:00";
            // 
            // LblDate
            // 
            this.LblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.LblDate.Location = new System.Drawing.Point(50, 89);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(196, 31);
            this.LblDate.TabIndex = 3;
            this.LblDate.Text = "00-00-0000 السبت";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 900;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LblDataGridTitle
            // 
            this.LblDataGridTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblDataGridTitle.AutoSize = true;
            this.LblDataGridTitle.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.LblDataGridTitle.Location = new System.Drawing.Point(871, 314);
            this.LblDataGridTitle.Name = "LblDataGridTitle";
            this.LblDataGridTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblDataGridTitle.Size = new System.Drawing.Size(150, 31);
            this.LblDataGridTitle.TabIndex = 3;
            this.LblDataGridTitle.Text = "بطاقات اليوم :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblTime);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Location = new System.Drawing.Point(727, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 137);
            this.panel1.TabIndex = 4;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 606);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblDataGridTitle);
            this.Controls.Add(this.DtgLastTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLastTickets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}