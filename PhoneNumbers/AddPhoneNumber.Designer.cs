
namespace OTS.Ticketing.Win.PhoneNumbers
{
    partial class AddPhoneNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhoneNumber));
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblPhoneNumber = new System.Windows.Forms.Label();
            this.TxtPhoneNumber = new System.Windows.Forms.TextBox();
            this.TxtCustomerName = new System.Windows.Forms.TextBox();
            this.LblCustomerName = new System.Windows.Forms.Label();
            this.BtnEditCompany = new System.Windows.Forms.PictureBox();
            this.BtnAddCompany = new System.Windows.Forms.PictureBox();
            this.CombCompanies = new System.Windows.Forms.ComboBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSearchCompany = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(30, 257);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "تراجع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnAdd.Location = new System.Drawing.Point(214, 257);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(120, 45);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "إضافة";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.AutoSize = true;
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblPhoneNumber.Location = new System.Drawing.Point(278, 42);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(65, 15);
            this.LblPhoneNumber.TabIndex = 5;
            this.LblPhoneNumber.Text = "رقم الهاتف :";
            // 
            // TxtPhoneNumber
            // 
            this.TxtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtPhoneNumber.Location = new System.Drawing.Point(92, 37);
            this.TxtPhoneNumber.MaxLength = 11;
            this.TxtPhoneNumber.Name = "TxtPhoneNumber";
            this.TxtPhoneNumber.Size = new System.Drawing.Size(180, 25);
            this.TxtPhoneNumber.TabIndex = 0;
            this.TxtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPhoneNumber_KeyPress);
            this.TxtPhoneNumber.Leave += new System.EventHandler(this.TxtPhoneNumber_Leave);
            // 
            // TxtCustomerName
            // 
            this.TxtCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtCustomerName.Location = new System.Drawing.Point(92, 97);
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.Size = new System.Drawing.Size(180, 25);
            this.TxtCustomerName.TabIndex = 1;
            // 
            // LblCustomerName
            // 
            this.LblCustomerName.AutoSize = true;
            this.LblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCustomerName.Location = new System.Drawing.Point(278, 102);
            this.LblCustomerName.Name = "LblCustomerName";
            this.LblCustomerName.Size = new System.Drawing.Size(69, 15);
            this.LblCustomerName.TabIndex = 6;
            this.LblCustomerName.Text = "اسم العميل :";
            // 
            // BtnEditCompany
            // 
            this.BtnEditCompany.BackColor = System.Drawing.Color.White;
            this.BtnEditCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnEditCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.ErrorImage")));
            this.BtnEditCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.Image")));
            this.BtnEditCompany.Location = new System.Drawing.Point(42, 157);
            this.BtnEditCompany.Name = "BtnEditCompany";
            this.BtnEditCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnEditCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnEditCompany.TabIndex = 41;
            this.BtnEditCompany.TabStop = false;
            this.BtnEditCompany.Click += new System.EventHandler(this.BtnEditCompany_Click);
            // 
            // BtnAddCompany
            // 
            this.BtnAddCompany.BackColor = System.Drawing.Color.White;
            this.BtnAddCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnAddCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.ErrorImage")));
            this.BtnAddCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.Image")));
            this.BtnAddCompany.Location = new System.Drawing.Point(67, 157);
            this.BtnAddCompany.Name = "BtnAddCompany";
            this.BtnAddCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnAddCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddCompany.TabIndex = 42;
            this.BtnAddCompany.TabStop = false;
            this.BtnAddCompany.Click += new System.EventHandler(this.BtnAddCompany_Click);
            // 
            // CombCompanies
            // 
            this.CombCompanies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CombCompanies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CombCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombCompanies.FormattingEnabled = true;
            this.CombCompanies.Location = new System.Drawing.Point(92, 157);
            this.CombCompanies.Name = "CombCompanies";
            this.CombCompanies.Size = new System.Drawing.Size(180, 25);
            this.CombCompanies.TabIndex = 2;
            this.CombCompanies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CombCompanies_KeyDown);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblCompany.Location = new System.Drawing.Point(278, 162);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(45, 15);
            this.LblCompany.TabIndex = 7;
            this.LblCompany.Text = "الشركة :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnSearchCompany);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 315);
            this.panel1.TabIndex = 8;
            // 
            // BtnSearchCompany
            // 
            this.BtnSearchCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearchCompany.BackColor = System.Drawing.Color.White;
            this.BtnSearchCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtnSearchCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearchCompany.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BtnSearchCompany.ErrorImage")));
            this.BtnSearchCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCompany.Image")));
            this.BtnSearchCompany.Location = new System.Drawing.Point(13, 151);
            this.BtnSearchCompany.Name = "BtnSearchCompany";
            this.BtnSearchCompany.Size = new System.Drawing.Size(25, 25);
            this.BtnSearchCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnSearchCompany.TabIndex = 44;
            this.BtnSearchCompany.TabStop = false;
            this.BtnSearchCompany.Click += new System.EventHandler(this.BtnSearchCompany_Click);
            // 
            // AddPhoneNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 325);
            this.Controls.Add(this.BtnEditCompany);
            this.Controls.Add(this.BtnAddCompany);
            this.Controls.Add(this.CombCompanies);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblCustomerName);
            this.Controls.Add(this.TxtCustomerName);
            this.Controls.Add(this.LblPhoneNumber);
            this.Controls.Add(this.TxtPhoneNumber);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AddPhoneNumber";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddPhoneNumber";
            this.Load += new System.EventHandler(this.AddPhoneNumber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPhoneNumber_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BtnEditCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddCompany)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearchCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblPhoneNumber;
        private System.Windows.Forms.TextBox TxtPhoneNumber;
        private System.Windows.Forms.TextBox TxtCustomerName;
        private System.Windows.Forms.Label LblCustomerName;
        private System.Windows.Forms.PictureBox BtnEditCompany;
        private System.Windows.Forms.PictureBox BtnAddCompany;
        private System.Windows.Forms.ComboBox CombCompanies;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BtnSearchCompany;
    }
}