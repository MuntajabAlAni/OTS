using ClosedXML.Excel;
using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Enums;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayOldTickets : Form
    {
        private readonly TicketRepository _ticketRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly PhoneNumberRepository _phoneNumberRepository;
        private readonly UserRepository _userRepository;
        private DataTable _dt;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private DateTime _prevSaturday = DateTime.Today;
        private DateTime _nextFriday = DateTime.Today;
        private readonly long _companyId;


        public DisplayOldTickets(long companyId)
        {
            _companyId = companyId;
            _ticketRepository = new TicketRepository();
            _companyRepository = new CompanyRepository();
            _phoneNumberRepository = new PhoneNumberRepository();
            _userRepository = new UserRepository();

            while (!(_prevSaturday.DayOfWeek == DayOfWeek.Saturday))
            {
                _prevSaturday = _prevSaturday.AddDays(-1);
            }

            while (!(_nextFriday.DayOfWeek == DayOfWeek.Friday))
            {
                _nextFriday = _nextFriday.AddDays(1);
            }
            InitializeComponent();
            //CombUser.DropDownStyle = ComboBoxStyle.DropDownList;
            //CombCompanies.DropDownStyle = ComboBoxStyle.DropDownList;
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }

        private void DisplayOldTickets_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditTicket)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEdit.Visible = false;

                DtpFromDate.Value = DateTime.Today.AddDays(-1);
                DtpToDate.Value = DateTime.Today;

                FillUsersComboBox();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();

                if (_companyId > 0)
                {
                    CombInterval.SelectedIndex = 0;
                }

                if (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.OTSManager)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.CallReceiver)))
                {
                    BtnExcel.Visible = true;
                    CombUser.Visible = true;
                    CombInterval.Visible = true;
                    LblInterval.Visible = true;
                    LblUser.Visible = true;
                    return;
                }

                CombCompanies.SelectedValue = 0;
                CombUser.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async Task GetDtgOldTickets()
        {
            OldTicketRequest request = default;
            if (!CbUnclosed.Checked & !CbClosed.Checked)
            {
                MessageBox.Show("يرجى إختيار نوع إغلاق البطاقة !");
                return;
            }
            else if (CbUnclosed.Checked & !CbClosed.Checked)
                request = new OldTicketRequest()
                {
                    FromDate = DtpFromDate.Value,
                    ToDate = DtpToDate.Value,
                    UserId = Convert.ToInt64(CombUser.SelectedValue),
                    CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                    PhoneNumberId = Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                    IsClosed = 0
                };
            else if (!CbUnclosed.Checked & CbClosed.Checked)
                request = new OldTicketRequest()
                {
                    FromDate = DtpFromDate.Value,
                    ToDate = DtpToDate.Value,
                    UserId = Convert.ToInt64(CombUser.SelectedValue),
                    CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                    PhoneNumberId = Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                    IsClosed = 1
                };
            else if (CbUnclosed.Checked & CbClosed.Checked)
                request = new OldTicketRequest()
                {
                    FromDate = DtpFromDate.Value,
                    ToDate = DtpToDate.Value,
                    UserId = Convert.ToInt64(CombUser.SelectedValue),
                    CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                    PhoneNumberId = Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                    IsClosed = 2
                };


            _dt =
                   SystemConstants.ToDataTable(await _ticketRepository.GetByRequest(request));
            _dt.Columns["Number"].ColumnName = "رقم البطاقة";
            _dt.Columns["OpenDate"].ColumnName = "تاريخ فتح البطاقة";
            _dt.Columns["CloseDate"].ColumnName = "تاريخ إغلاق البطاقة";
            _dt.Columns["PhoneNumber"].ColumnName = "رقم الهاتف";
            _dt.Columns["CustomerName"].ColumnName = "اسم المتصل";
            _dt.Columns["SoftwareName"].ColumnName = "البرنامج";
            _dt.Columns["UserName"].ColumnName = "الموظف";
            _dt.Columns["CompanyName"].ColumnName = "اسم الشركة";
            _dt.Columns["BranchName"].ColumnName = "الفرع";
            _dt.Columns["Problem"].ColumnName = "المشكلة";
            _dt.Columns["StateName"].ColumnName = "الحالة";
            _dt.Columns["Revision"].ColumnName = "مراجعة البطاقة";
            _dt.Columns["IsIndexedView"].ColumnName = "ترتيب الملفات";
            _dt.Columns["TransferedToName"].ColumnName = "تم التحويل الى";
            _dt.Columns["Remarks"].ColumnName = "الملاحظات";
            _dt.Columns["RemotelyView"].ColumnName = "الحل";
            _dt.Columns["IsClosedView"].ColumnName = "الإغلاق";
            _dt.Columns.Remove("Id");
            _dt.Columns.Remove("PhoneNumberId");
            _dt.Columns.Remove("SoftwareId");
            _dt.Columns.Remove("UserId");
            _dt.Columns.Remove("CompanyId");
            _dt.Columns.Remove("StateId");
            _dt.Columns.Remove("Remotely");
            _dt.Columns.Remove("IsIndexed");
            _dt.Columns.Remove("TransferedTo");
            _dt.Columns.Remove("IsClosed");
            _dt.Columns.Remove("IsDeleted");

            DataColumn dc = new DataColumn("ت", typeof(int));
            _dt.Columns.Add(dc);
            int i = 0;
            foreach (DataRow dr in _dt.Rows)
            {
                dr["ت"] = i + 1;
                i++;
            }

            DtgOldTickets.DataSource = _dt;
            DtgOldTickets.Columns["ت"].DisplayIndex = 0;
            DtgOldTickets.HideUntranslatedColumns();
        }
        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                var list = await _companyRepository.GetAll();
                list.Insert(0, (new CompanyInfo { Id = 0, Name = "الكل" }));
                CombCompanies.DataSource = list;
                CombCompanies.SelectedValue = _companyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void FillPhoneNumbersComboBox()
        {
            try
            {
                CombPhoneNumbers.DisplayMember = "PhoneNumber";
                CombPhoneNumbers.ValueMember = "Id";
                var list = await _phoneNumberRepository.GetAll();
                list.Insert(0, (new PhoneNumberInfo { Id = 0, PhoneNumber = "الكل" }));
                CombPhoneNumbers.DataSource = list;
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
                List<UserInfo> users = await _userRepository.GetOTS();
                users.Insert(0, new UserInfo { Id = 0, DisplayName = "الكل" });
                CombUser.DataSource = users;
                CombUser.SelectedValue = SystemConstants.selectedUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            PnlLoad.Visible = true;
            await GetDtgOldTickets();
            PnlLoad.Visible = false;
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
            BtnUpdate.PerformClick();
        }

        private void PnlLoad_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = !PnlLoad.Visible;
            }
        }

        private async void BtnRemarks_Click(object sender, EventArgs e)
        {
            if (DtgOldTickets.Rows.Count == 0) return;
            long selectedNumber = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["رقم البطاقة"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["مراجعة البطاقة"].Value.ToString());
            TicketInfo selectedTicket = await _ticketRepository.GetDetailsByNumberAndRevision(selectedNumber, selectedRevision);
            TicketRemarks remarks = new TicketRemarks(selectedTicket);
            remarks.ShowDialog();
        }

        private void DtgOldTickets_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtgOldTickets.Rows.Count == 0) return;
            long selectedNumber = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["رقم البطاقة"].Value.ToString());
            long selectedRevision = Convert.ToInt64(DtgOldTickets.SelectedRows[0].Cells["مراجعة البطاقة"].Value.ToString());

            ViewTicket view = new ViewTicket(selectedNumber, selectedRevision);
            view.ShowDialog();
        }

        private void DtgOldTickets_Sorted(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow r in DtgOldTickets.Rows)
            {
                r.Cells["ت"].Value = i + 1;
                i++;
            }
        }

        private void CombInterval_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (CombInterval.SelectedIndex)
            {
                case 0:
                    DtpFromDate.Value = new DateTime(2021, 08, 04);
                    DtpToDate.Value = DateTime.Today;
                    break;
                case 1:
                    DtpFromDate.Value = DateTime.Today;
                    DtpToDate.Value = DateTime.Today;
                    break;
                case 2:
                    DtpFromDate.Value = DateTime.Today.AddDays(-1);
                    DtpToDate.Value = DateTime.Today.AddDays(-1);
                    break;
                case 3:
                    DtpFromDate.Value = _prevSaturday;
                    DtpToDate.Value = _nextFriday;
                    break;
                case 4:
                    DtpFromDate.Value = _prevSaturday.AddDays(-7);
                    DtpToDate.Value = _nextFriday.AddDays(-7);
                    break;
                case 5:
                    DtpFromDate.Value = DateTime.Today.AddDays(-6);
                    DtpToDate.Value = DateTime.Today;
                    break;
                case 6:
                    DtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    DtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
                    break;
                case 7:
                    DtpFromDate.Value = DateTime.Today.Month == 1 ?

                        new DateTime(DateTime.Today.Year - 1, 12, 1):
                        new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1);
                    DtpToDate.Value = DateTime.Today.Month == 1 ?
                         new DateTime(DateTime.Today.Year - 1, 12, DateTime.DaysInMonth(DateTime.Today.Year - 1, 12)) :
                        new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month - 1));
                    break;
                case 8:
                    DtpFromDate.Value = DateTime.Today.AddDays(-30);
                    DtpToDate.Value = DateTime.Today;
                    break;

                default:
                    break;
            }
        }
    }
}
