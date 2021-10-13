using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Utils;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayOldTickets : Form
    {
        private readonly TicketRepository _ticketRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly string _companyName;
        private System.Data.DataTable _dt;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DisplayOldTickets(string companyName = "")
        {
            _ticketRepository = new TicketRepository();
            _companyRepository = new CompanyRepository();
            _companyName = companyName;
            InitializeComponent();
            CombUser.DropDownStyle = ComboBoxStyle.DropDownList;
            CombCompanies.DropDownStyle = ComboBoxStyle.DropDownList;
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }

        private async void DisplayOldTickets_Load(object sender, EventArgs e)
        {
            try
            {
                DtpToDate.Value = DateTime.Today;
                FillUsersComboBox();
                FillCompaniesComboBox(SystemConstants.loggedInUser.Id);
                //if (SystemConstants.loggedInUserId == 1)
                //{
                BtnEdit.Visible = true;
                BtnExcel.Visible = true;
                CombUser.Visible = true;
                LblUser.Visible = true;
                //    return;
                //}
                var result = await _companyRepository.GetCompanyByName(_companyName);
                CompanyView company = result.FirstOrDefault();
                CombCompanies.SelectedValue = company.Id;
                CombUser.SelectedValue = 0;
                BtnUpdate.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void GetDtgOldTickets()
        {
            if (CbUnclosed.Checked & !CbClosed.Checked) _dt =
                    SystemConstants.ToDataTable(await _ticketRepository.GetOldUnClosedTicketsByUserIdOrCompanyId(
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombUser.SelectedValue),
                DtpFromDate.Value,
                DtpToDate.Value));
            else if (!CbUnclosed.Checked & CbClosed.Checked) _dt =
                    SystemConstants.ToDataTable(await _ticketRepository.GetOldTicketsByUserIdOrCompanyId(
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombUser.SelectedValue),
                DtpFromDate.Value,
                DtpToDate.Value));
            else if (CbUnclosed.Checked & CbClosed.Checked) _dt =
                    SystemConstants.ToDataTable(await _ticketRepository.GetAllOldTicketsByUserIdOrCompanyId(
                 Convert.ToInt64(CombCompanies.SelectedValue),
                 Convert.ToInt64(CombUser.SelectedValue),
                 DtpFromDate.Value,
                 DtpToDate.Value));
            else if (!CbUnclosed.Checked & !CbClosed.Checked)
            {
                MessageBox.Show("يرجى إختيار نوع إغلاق البطاقة !");
                return;
            }

            _dt.Columns["Number"].ColumnName = "رقم البطاقة";
            _dt.Columns["OpenDate"].ColumnName = "تاريخ فتح البطاقة";
            _dt.Columns["CloseDate"].ColumnName = "تاريخ إغلاق البطاقة";
            _dt.Columns["PhoneNumber"].ColumnName = "رقم الهاتف";
            _dt.Columns["SoftwareName"].ColumnName = "البرنامج";
            _dt.Columns["UserName"].ColumnName = "الموظف";
            _dt.Columns["CompanyName"].ColumnName = "اسم الشركة";
            _dt.Columns["BranchName"].ColumnName = "الفرع";
            _dt.Columns["Problem"].ColumnName = "المشكلة";
            _dt.Columns["State"].ColumnName = "الحالة";
            _dt.Columns["Revision"].ColumnName = "مراجعة البطاقة";
            _dt.Columns["IsIndexed"].ColumnName = "ترتيب الملفات";
            _dt.Columns["TransferedTo"].ColumnName = "تم التحويل الى";
            _dt.Columns["Remarks"].ColumnName = "الملاحظات";
            _dt.Columns.Remove("IsClosed");
            _dt.Columns.Remove("IsDeleted");

            DtgOldTickets.DataSource = _dt;

            DtgOldTickets.Columns["الملاحظات"].Visible = false;
        }
        private async void FillCompaniesComboBox(long userId)
        {
            try
            {
                userId = userId == 1 ? 0 : userId;
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                var list = await _ticketRepository.GetCompaniesByUserId(userId);
                if (SystemConstants.loggedInUser.Id == 1)
                {
                    list.Insert(0, (new CompanyInfo { Id = 0, Name = "الكل" }));
                }
                CombCompanies.DataSource = list;
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

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            PnlLoad.Visible = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Execl files (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                RestoreDirectory = true,
                CreatePrompt = false,
                FileName = "البطاقات السابقة حتى " + DateTime.Now.ToString("yyyy-MM-dd"),
                Title = "أختيار مكان حفظ الملف"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    if (Convert.ToDateTime(row["تاريخ إغلاق البطاقة"]) == DateTime.MinValue)
                        row["تاريخ إغلاق البطاقة"] = DBNull.Value;
                }
                ExcelUtility.ExportExcelFile(_dt, saveFileDialog.FileName);
            }
            PnlLoad.Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            long selectedNumber = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["رقم البطاقة"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["مراجعة البطاقة"].Value.ToString());
            EditTicket editTicket = new EditTicket(selectedNumber, selectedRevision);
            editTicket.ShowDialog();
        }

        private void CombUser_SelectedValueChanged(object sender, EventArgs e)
        {
            FillCompaniesComboBox(Convert.ToInt64(CombUser.SelectedValue));
        }

        private async void DtgOldTickets_DoubleClick(object sender, EventArgs e)
        {
            if (DtgOldTickets.Rows.Count == 0) return;
            long selectedNumber = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["رقم البطاقة"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["مراجعة البطاقة"].Value.ToString());
            TicketsView selectedTicket = await _ticketRepository.GetTicketDetailsByByNumberAndRevision(selectedNumber, selectedRevision);
            TicketRemarks remarks = new TicketRemarks(selectedTicket);
            remarks.ShowDialog();
        }

        private void PnlLoad_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = !PnlLoad.Visible;
            }
        }
    }
}
