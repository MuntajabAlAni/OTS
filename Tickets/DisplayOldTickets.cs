using Microsoft.Office.Interop.Excel;
using NLog;
using OTS.Ticketing.Win.Companies;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
        private readonly string _companyName;
        private System.Data.DataTable _dt;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DisplayOldTickets(string companyName = "")
        {
            _ticketRepository = new TicketRepository();
            _companyRepository = new CompanyRepository();
            _companyName = companyName;
            InitializeComponent();
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }

        private async void DisplayOldTickets_Load(object sender, EventArgs e)
        {
            try
            {
                FillUsersComboBox();
                FillCompaniesComboBox(0);
                var UserInfo = await _ticketRepository.GetUserById(SystemConstants.loggedInUserId);
                if (UserInfo.UserName != "admin")
                {
                    CombUser.Enabled = false;
                    CombUser.DropDownStyle = ComboBoxStyle.DropDownList;
                    CombUser.SelectedValue = SystemConstants.loggedInUserId;
                    var result = await _companyRepository.GetCompanyByName(_companyName);
                    CompanyView company = result.FirstOrDefault();
                    CombCompanies.SelectedValue = company.Id;
                    BtnUpdate.PerformClick();
                    BtnEdit.Visible = false;
                    BtnExcel.Visible = false;
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

            _dt.Columns["Number"].ColumnName = "رقم البطاقة";
            _dt.Columns["OpenDate"].ColumnName = "تاريخ فتح البطاقة";
            _dt.Columns["CloseDate"].ColumnName = "تاريخ إغلاق البطاقة";
            _dt.Columns["PhoneNumber"].ColumnName = "رقم الهاتف";
            _dt.Columns["SoftwareName"].ColumnName = "البرنامج";
            _dt.Columns["UserName"].ColumnName = "الموظف";
            _dt.Columns["CompanyName"].ColumnName = "اسم الشركة";
            _dt.Columns["Problem"].ColumnName = "المشكلة";
            _dt.Columns["State"].ColumnName = "الحالة";
            _dt.Columns["Revision"].ColumnName = "مراجعة البطاقة";
            _dt.Columns["IsIndexed"].ColumnName = "ترتيب الملفات";
            _dt.Columns["TransferedTo"].ColumnName = "تم التحويل الى";
            _dt.Columns["Remarks"].ColumnName = "الملاحظات";
            _dt.Columns.Remove("IsClosed");

            DtgOldTickets.DataSource = _dt;

            DtgOldTickets.Columns["الملاحظات"].Visible = false;
        }
        private async void FillCompaniesComboBox(long userId)
        {
            try
            {
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                CombCompanies.DataSource = await _ticketRepository.GetCompaniesByUserId(userId);
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

        private async void BtnExcel_Click(object sender, EventArgs e)
        {
            PnlLoad.Visible = true;
            await ExcelFile(_dt);
            PnlLoad.Visible = false;
        }
        private async Task ExcelFile(System.Data.DataTable dtTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Execl files (*.xls)|*.xls",
                FilterIndex = 0,
                RestoreDirectory = true,
                CreatePrompt = false,
                FileName = "البطاقات السابقة حتى " + DateTime.Now.ToString("yyyy-MM-dd"),
                Title = "أختيار مكان حفظ الملف"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filepath = saveFileDialog.FileName;

            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbooks wkbooks = null;
            Microsoft.Office.Interop.Excel.Workbook wkbook = null;
            Microsoft.Office.Interop.Excel.Sheets wksheets = null;
            Microsoft.Office.Interop.Excel.Worksheet wksheet = null;

            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                wkbooks = xlApp.Workbooks;
                wkbook = wkbooks.Add();
                wksheets = wkbook.Sheets;
                wksheet = wksheets.Add();

                wksheet.Name = "1";

                try
                {
                    await Task.Run(() =>
                    {
                        for (var i = 0; i < dtTable.Columns.Count; i++)
                        {
                            wksheet.Cells[1, i + 1] = dtTable.Columns[i].ColumnName;
                        }

                        for (var i = 0; i < dtTable.Rows.Count; i++)
                        {
                            for (var j = 0; j < dtTable.Columns.Count; j++)
                            {
                                wksheet.Cells[i + 2, j + 1] = dtTable.Rows[i][j];
                            }
                        }

                        wkbook.SaveAs(filepath, XlFileFormat.xlExcel8, null,
                        null, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                        wkbook.Close(false, Missing.Value, Missing.Value);
                        wkbooks.Close();
                        xlApp.Quit();
                    });
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Error(exp);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(e);
            }

            finally
            {
                if (wksheets != null) Marshal.ReleaseComObject(wksheets);
                if (wkbook != null) Marshal.ReleaseComObject(wkbook);
                if (wkbooks != null) Marshal.ReleaseComObject(wkbooks);
                if (xlApp != null) Marshal.ReleaseComObject(xlApp);
            }
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
    }
}
