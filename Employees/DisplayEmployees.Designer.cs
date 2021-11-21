
namespace OTS.Ticketing.Win.Tasks
{
    partial class DisplayEmployees
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DtgEmployees = new System.Windows.Forms.DataGridView();
            this.BtnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(313, 394);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DtgEmployees
            // 
            this.DtgEmployees.AllowUserToAddRows = false;
            this.DtgEmployees.AllowUserToDeleteRows = false;
            this.DtgEmployees.AllowUserToOrderColumns = true;
            this.DtgEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DtgEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtgEmployees.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.DtgEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DtgEmployees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgEmployees.ColumnHeadersHeight = 28;
            this.DtgEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgEmployees.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtgEmployees.EnableHeadersVisualStyles = false;
            this.DtgEmployees.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DtgEmployees.Location = new System.Drawing.Point(12, 12);
            this.DtgEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtgEmployees.MultiSelect = false;
            this.DtgEmployees.Name = "DtgEmployees";
            this.DtgEmployees.ReadOnly = true;
            this.DtgEmployees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgEmployees.RowHeadersVisible = false;
            this.DtgEmployees.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DtgEmployees.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgEmployees.RowTemplate.Height = 26;
            this.DtgEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgEmployees.Size = new System.Drawing.Size(421, 377);
            this.DtgEmployees.TabIndex = 0;
            this.DtgEmployees.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEmployees_CellContentDoubleClick);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(12, 394);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "إلغاء الأمر";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // DisplayEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 450);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.DtgEmployees);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DisplayEmployees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "DisplayEmployees";
            this.Load += new System.EventHandler(this.DisplayEmployees_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayEmployees_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView DtgEmployees;
        private System.Windows.Forms.Button BtnExit;
    }
}