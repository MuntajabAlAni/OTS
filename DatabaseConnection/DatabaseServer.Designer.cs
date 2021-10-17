
namespace OTS.Ticketing.Win.DatabaseConnection
{
    partial class DatabaseServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseServer));
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblServerIp = new System.Windows.Forms.Label();
            this.TxtServerIp = new System.Windows.Forms.TextBox();
            this.PnlContainer = new System.Windows.Forms.Panel();
            this.ImbRefresh = new System.Windows.Forms.PictureBox();
            this.ImbTryConnect = new System.Windows.Forms.PictureBox();
            this.CombDatabases = new System.Windows.Forms.ComboBox();
            this.LblDatabases = new System.Windows.Forms.Label();
            this.PnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImbTryConnect)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(62, 169);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "إلغاء الأمر";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnSave.FlatAppearance.BorderSize = 2;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnSave.Location = new System.Drawing.Point(241, 169);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 45);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "تخزين";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblServerIp
            // 
            this.LblServerIp.AutoSize = true;
            this.LblServerIp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblServerIp.Location = new System.Drawing.Point(264, 39);
            this.LblServerIp.Name = "LblServerIp";
            this.LblServerIp.Size = new System.Drawing.Size(51, 15);
            this.LblServerIp.TabIndex = 4;
            this.LblServerIp.Text = "عنوان IP:";
            // 
            // TxtServerIp
            // 
            this.TxtServerIp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtServerIp.Location = new System.Drawing.Point(108, 34);
            this.TxtServerIp.Name = "TxtServerIp";
            this.TxtServerIp.Size = new System.Drawing.Size(150, 25);
            this.TxtServerIp.TabIndex = 0;
            // 
            // PnlContainer
            // 
            this.PnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlContainer.Controls.Add(this.ImbRefresh);
            this.PnlContainer.Controls.Add(this.ImbTryConnect);
            this.PnlContainer.Controls.Add(this.CombDatabases);
            this.PnlContainer.Controls.Add(this.LblDatabases);
            this.PnlContainer.Controls.Add(this.LblServerIp);
            this.PnlContainer.Controls.Add(this.BtnSave);
            this.PnlContainer.Controls.Add(this.TxtServerIp);
            this.PnlContainer.Controls.Add(this.BtnExit);
            this.PnlContainer.Location = new System.Drawing.Point(12, 12);
            this.PnlContainer.Name = "PnlContainer";
            this.PnlContainer.Size = new System.Drawing.Size(425, 231);
            this.PnlContainer.TabIndex = 0;
            // 
            // ImbRefresh
            // 
            this.ImbRefresh.BackColor = System.Drawing.Color.White;
            this.ImbRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImbRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImbRefresh.ErrorImage = null;
            this.ImbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ImbRefresh.Image")));
            this.ImbRefresh.Location = new System.Drawing.Point(58, 34);
            this.ImbRefresh.Name = "ImbRefresh";
            this.ImbRefresh.Size = new System.Drawing.Size(25, 25);
            this.ImbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImbRefresh.TabIndex = 42;
            this.ImbRefresh.TabStop = false;
            this.ImbRefresh.Click += new System.EventHandler(this.ImbRefresh_Click);
            // 
            // ImbTryConnect
            // 
            this.ImbTryConnect.BackColor = System.Drawing.Color.White;
            this.ImbTryConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImbTryConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImbTryConnect.ErrorImage = null;
            this.ImbTryConnect.Image = ((System.Drawing.Image)(resources.GetObject("ImbTryConnect.Image")));
            this.ImbTryConnect.Location = new System.Drawing.Point(83, 34);
            this.ImbTryConnect.Name = "ImbTryConnect";
            this.ImbTryConnect.Size = new System.Drawing.Size(25, 25);
            this.ImbTryConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImbTryConnect.TabIndex = 42;
            this.ImbTryConnect.TabStop = false;
            this.ImbTryConnect.Click += new System.EventHandler(this.ImbTryConnect_Click);
            // 
            // CombDatabases
            // 
            this.CombDatabases.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombDatabases.FormattingEnabled = true;
            this.CombDatabases.Location = new System.Drawing.Point(108, 80);
            this.CombDatabases.Name = "CombDatabases";
            this.CombDatabases.Size = new System.Drawing.Size(150, 25);
            this.CombDatabases.TabIndex = 1;
            // 
            // LblDatabases
            // 
            this.LblDatabases.AutoSize = true;
            this.LblDatabases.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblDatabases.Location = new System.Drawing.Point(264, 85);
            this.LblDatabases.Name = "LblDatabases";
            this.LblDatabases.Size = new System.Drawing.Size(80, 15);
            this.LblDatabases.TabIndex = 5;
            this.LblDatabases.Text = "قاعدة البيانات :";
            // 
            // DatabaseServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 255);
            this.Controls.Add(this.PnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "DatabaseServer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DatabaseServer";
            this.Load += new System.EventHandler(this.DatabaseServer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabaseServer_KeyDown);
            this.PnlContainer.ResumeLayout(false);
            this.PnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImbTryConnect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblServerIp;
        private System.Windows.Forms.TextBox TxtServerIp;
        private System.Windows.Forms.Panel PnlContainer;
        private System.Windows.Forms.ComboBox CombDatabases;
        private System.Windows.Forms.Label LblDatabases;
        private System.Windows.Forms.PictureBox ImbRefresh;
        private System.Windows.Forms.PictureBox ImbTryConnect;
    }
}