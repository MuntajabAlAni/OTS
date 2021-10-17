
namespace OTS.Ticketing.Win.Tickets
{
    partial class TicketRemarks
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtRemrks = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnExit.Location = new System.Drawing.Point(8, 200);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(120, 45);
            this.BtnExit.TabIndex = 7;
            this.BtnExit.Text = "رجوع";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblName.Location = new System.Drawing.Point(410, 4);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(65, 15);
            this.LblName.TabIndex = 8;
            this.LblName.Text = "الملاحظات :";
            // 
            // TxtRemrks
            // 
            this.TxtRemrks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRemrks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TxtRemrks.Location = new System.Drawing.Point(8, 22);
            this.TxtRemrks.Multiline = true;
            this.TxtRemrks.Name = "TxtRemrks";
            this.TxtRemrks.ReadOnly = true;
            this.TxtRemrks.Size = new System.Drawing.Size(464, 172);
            this.TxtRemrks.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TxtRemrks);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.BtnExit);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 255);
            this.panel1.TabIndex = 9;
            // 
            // TicketRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 262);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TicketRemarks";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TicketRemarks";
            this.Load += new System.EventHandler(this.TicketRemarks_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TicketRemarks_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtRemrks;
        private System.Windows.Forms.Panel panel1;
    }
}