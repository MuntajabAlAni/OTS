using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.States;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Employees;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayTickets : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        public DisplayTickets()
        {
            InitializeComponent();
        }

        private async void DisplayTickets_Load(object sender, EventArgs e)
        {
            try
            {
                var employeeInfo = await ticketRepository.GetEmployeeById(SystemConstants.loggedInEmployeeId);
                if (employeeInfo.UserName != "admin")
                {
                    BtnAddState.Visible = false;
                    BtnEditState.Visible = false;
                }
                GetDtgTicketsData();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "DisplayTickets_Load");
            }

        }

        private async void FillStatesComboBox()
        {
            try
            {
                CombStates.DataSource = await ticketRepository.GetAllStates();
                CombStates.DisplayMember = "Name";
                CombStates.ValueMember = "Id";
                CombStates.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillStatesComboBox");
            }

        }
        private async void GetDtgTicketsData()
        {
            try
            {
                DtgTickets.DataSource = await ticketRepository.GetAllTicketsByEmployeeId(SystemConstants.loggedInEmployeeId);
                DtgTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                DtgTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                DtgTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                DtgTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                DtgTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                DtgTickets.Columns["EmployeeName"].HeaderText = "الموظف";
                DtgTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                DtgTickets.Columns["State"].HeaderText = "الحالة";
                DtgTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                DtgTickets.Columns["Arrangement"].HeaderText = "ترتيب الملفات";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetDtgTicketsData");
            }

        }

        private void ToggleRemotely_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (ToggleRemotely.Checked) LblRemote.Text = "بإستخدام Anydesk";
            else LblRemote.Text = "بإتصال فقط";
        }

        private async void DtgTickets_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DtgTickets.Rows.Count == 0) return;
                long selectedNumber = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketsView selectedTicket = await ticketRepository.GetTicketDetailsByByNumberAndRevision(selectedNumber, selectedRevision);
                LblNumber.Text = selectedTicket.Number.ToString();
                LblRevision.Text = selectedTicket.Revision.ToString();
                LblCompany.Text = selectedTicket.CompanyName.ToString();
                LblEmployee.Text = selectedTicket.EmployeeName.ToString();
                LblPhoneNumber.Text = selectedTicket.PhoneNumber.ToString();
                LblSoftware.Text = selectedTicket.SoftwareName.ToString();
                LblOpenDate.Text = selectedTicket.OpenDate.ToString("yyyy-MM-dd hh:mm tt dddd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "DtgTickets_DoubleClick");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetDtgTicketsData();
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblNumber.Text == "")
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await ticketRepository.UpdateTicket(Convert.ToInt64(LblNumber.Text),
                 Convert.ToInt32(LblRevision.Text),
                 DateTime.Now,
                 Convert.ToInt64(CombStates.SelectedValue),
                 TxtRemarks.Text,
                 Convert.ToInt32(ToggleRemotely.Checked),
                 ToggleArrangement.Checked);
                GetDtgTicketsData();
                LblNumber.Text = "";
                LblRevision.Text = "";
                LblCompany.Text = "";
                LblEmployee.Text = "";
                LblPhoneNumber.Text = "";
                LblSoftware.Text = "";
                LblOpenDate.Text = "";
                ToggleArrangement.Checked = false;
                ToggleRemotely.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnUpdate_Click");
            }
        }

        private void BtnAddState_Click(object sender, EventArgs e)
        {
            try
            {
                AddState addState = new AddState(0);
                addState.ShowDialog();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAddState_Click");
            }

        }

        private void BtnEditState_Click(object sender, EventArgs e)
        {
            try
            {
                AddState addState = new AddState(Convert.ToInt64(CombStates.SelectedValue));
                addState.ShowDialog();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnEditState_Click");
            }
        }
    }
}
