using NLog;
using OTS.Ticketing.Win.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayOldTickets : Form
    {
        private readonly TicketRepository _ticketRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly string _companyName;
        private DataTable _dt;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DisplayOldTickets(string companyName = "")
        {
            _ticketRepository = new TicketRepository();
            _companyRepository = new CompanyRepository();
            _companyName = companyName;
            InitializeComponent();
        }

        private async void DisplayOldTickets_Load(object sender, EventArgs e)
        {
            try
            {
                FillUsersComboBox();
                FillCompaniesComboBox();
                var UserInfo = await _ticketRepository.GetUserById(SystemConstants.loggedInUserId);
                if (UserInfo.UserName != "admin")
                {
                    CombUser.SelectedValue = SystemConstants.loggedInUserId;
                    CombUser.Enabled = false;
                    var result = await _companyRepository.GetCompanyByName(_companyName);
                    CompanyView company = result.FirstOrDefault();
                    CombCompanies.SelectedValue = company.Id;
                    BtnUpdate.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void GetDtgOldTickets()
        {
            if (CbUnclosed.Checked) _dt = SystemConstants.ToDataTable(await _ticketRepository.GetOldUnClosedTicketsByUserIdOrCompanyId(
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombUser.SelectedValue),
                DtpFromDate.Value,
                DtpToDate.Value));
            else _dt = SystemConstants.ToDataTable(await _ticketRepository.GetOldTicketsByUserIdOrCompanyId(
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombUser.SelectedValue),
                DtpFromDate.Value,
                DtpToDate.Value));
            DtgOldTickets.DataSource = _dt;
            DtgOldTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgOldTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgOldTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgOldTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgOldTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgOldTickets.Columns["UserName"].HeaderText = "الموظف";
            DtgOldTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgOldTickets.Columns["Problem"].HeaderText = "المشكلة";
            DtgOldTickets.Columns["State"].HeaderText = "الحالة";
            DtgOldTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
            DtgOldTickets.Columns["IsIndexed"].HeaderText = "ترتيب الملفات";
            DtgOldTickets.Columns["IsClosed"].Visible = false;
            DtgOldTickets.Columns["Remarks"].Visible = false;
        }
        private async void FillCompaniesComboBox(long userId = 0)
        {
            try
            {
                userId = userId != 0 ? Convert.ToInt64(CombUser.SelectedValue) : 0;
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                CombCompanies.DataSource = await _ticketRepository.GetCompaniesOnUserId(userId);
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillUsersComboBox()
        {
            try
            {
                CombUser.DisplayMember = "displayName";
                CombUser.ValueMember = "Id";
                CombUser.DataSource = await _ticketRepository.GetAllUsers();
                CombUser.SelectedValue = SystemConstants.SelectedUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void CbFromDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!CbFromDate.Checked)
            {
                DtpFromDate.Enabled = false;
                DtpFromDate.Value = DateTimePicker.MinimumDateTime;
            }
            else DtpFromDate.Enabled = true;

        }

        private void CbToDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!CbToDate.Checked)
            {
                DtpToDate.Enabled = false;
                DtpToDate.Value = DateTimePicker.MaximumDateTime;
            }
            else DtpToDate.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            GetDtgOldTickets();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayOldTickets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CombUser_SelectedValueChanged(object sender, EventArgs e)
        {
            FillCompaniesComboBox(Convert.ToInt64(CombUser.SelectedValue));
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            StreamWriter wr = new StreamWriter(@"G:\\Book1.xls");
            // Write Columns to excel file
            for (int i = 0; i < _dt.Columns.Count; i++)
            {
                wr.Write(_dt.Columns[i].ToString().ToUpper() + "\t");
            }
            wr.WriteLine();
            //write rows to excel file
            for (int i = 0; i < (_dt.Rows.Count); i++)
            {
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    if (_dt.Rows[i][j] != null)
                    {
                        wr.Write(Convert.ToString(_dt.Rows[i][j]) + "\t");
                    }
                    else
                    {
                        wr.Write("\t");
                    }
                }
                wr.WriteLine();
            }
            wr.Close();
        }
    }
}
