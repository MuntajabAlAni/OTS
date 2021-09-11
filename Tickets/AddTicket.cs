﻿using NLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OTS.Ticketing.Win.Utils;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class AddTicket : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public AddTicket()
        {
            InitializeComponent();
        }
        private async void AddTicket_Load(object sender, EventArgs e)
        {
            try
            {
                var UserInfo = await ticketRepository.GetUserById(SystemConstants.loggedInUserId);
                if (UserInfo.UserName != "admin")
                {
                    BtnAddUser.Visible = false;
                    BtnEditUser.Visible = false;
                    BtnAddSoftware.Visible = false;
                    BtnEditSoftware.Visible = false;
                }
                LblNumber.Text = await ticketRepository.GetLastTicketNumber();
                LblRevision.Text = "0";
                FillCompaniesComboBox();
                FillSoftwaresComboBox();
                FillUsersComboBox();
                FillPhoneNumbersComboBox();
                SystemConstants.SelectedCompanyId = 0;
                SystemConstants.SelectedPhoneNumberId = 0;
                SystemConstants.SelectedSoftware = 0;
                SystemConstants.SelectedUser = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                CombCompanies.DataSource = await ticketRepository.GetAllCompanies();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillSoftwaresComboBox()
        {
            try
            {
                CombSoftware.DisplayMember = "Name";
                CombSoftware.ValueMember = "Id";
                CombSoftware.DataSource = await ticketRepository.GetAllSoftwares();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
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
                CombUser.DataSource = await ticketRepository.GetAllUsers();
                CombUser.SelectedValue = SystemConstants.SelectedUser;
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
                //companyId = CombCompanies.SelectedValue != null ? Convert.ToInt64(CombCompanies.SelectedValue) : 0;
                var result = await ticketRepository.GetPhoneNumbersOnSelectedCompanyId(Convert.ToInt64(CombCompanies.SelectedValue));
                if (result.Count != 0)
                {
                    CombPhoneNumbers.DisplayMember = "phoneNumber";
                    CombPhoneNumbers.ValueMember = "Id";
                    CombPhoneNumbers.DataSource = result;
                    CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
                }
                else CombPhoneNumbers.DataSource = null;
                FillDtgUnclosedTickets(Convert.ToInt64(CombCompanies.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillDtgUnclosedTickets(long companyId)
        {
            DtgUnclosedTickets.DataSource = await ticketRepository.GetUnclosedTicketsOnSelectedCompanyId(companyId);
            DtgUnclosedTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgUnclosedTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgUnclosedTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgUnclosedTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgUnclosedTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgUnclosedTickets.Columns["UserName"].HeaderText = "الموظف";
            DtgUnclosedTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgUnclosedTickets.Columns["BranchName"].HeaderText = "الفرع";
            DtgUnclosedTickets.Columns["Problem"].HeaderText = "المشكلة";
            DtgUnclosedTickets.Columns["State"].HeaderText = "الحالة";
            DtgUnclosedTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
            DtgUnclosedTickets.Columns["IsIndexed"].HeaderText = "ترتيب الملفات";
            DtgUnclosedTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
            DtgUnclosedTickets.Columns["Remarks"].Visible = false;
            DtgUnclosedTickets.Columns["TransferedTo"].Visible = false;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt64(CombPhoneNumbers.SelectedValue) == 0
                    | Convert.ToInt64(CombCompanies.SelectedValue) == 0
                    | Convert.ToInt64(CombUser.SelectedValue) == 0
                    | Convert.ToInt64(CombSoftware.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr;
                dr = MessageBox.Show("هل انت متأكد من الإضافة ؟", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    await ticketRepository.AddTicket(Convert.ToInt64(LblNumber.Text),
                Convert.ToInt32(LblRevision.Text),
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                Convert.ToInt64(CombSoftware.SelectedValue),
                Convert.ToInt64(CombUser.SelectedValue));
                    SystemConstants.SelectedCompanyId = 0;
                    SystemConstants.SelectedPhoneNumberId = 0;
                    SystemConstants.SelectedSoftware = 0;
                    SystemConstants.SelectedUser = 0;
                    TicketInfo addedTicket = await ticketRepository.GetTicketByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
                        Convert.ToInt32(LblRevision.Text));
                    await ActivityLogUtility.ActivityLog(Enums.Activities.AddTicket, "إضافة بطاقة", addedTicket.Id);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void DtgUnclosedTickets_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DtgUnclosedTickets.RowCount == 0) return;
                long selectedNumber = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketInfo selectedTicket = await ticketRepository.GetTicketByNumberAndRevision(selectedNumber, selectedRevision);
                LblNumber.Text = selectedTicket.Number.ToString();
                LblRevision.Text = (selectedTicket.Revision + 1).ToString();
                CombCompanies.SelectedValue = selectedTicket.CompanyId;
                CombUser.SelectedValue = selectedTicket.UserId;
                CombPhoneNumbers.SelectedValue = selectedTicket.PhoneNumberId;
                CombSoftware.SelectedValue = selectedTicket.SoftwareId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(0);
                addCompany.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(Convert.ToInt64(CombCompanies.SelectedValue));
                addCompany.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0, CombPhoneNumbers.Text);
                addPhoneNumber.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                AddPhoneNumber addPhoneNumber = new AddPhoneNumber(Convert.ToInt64(CombPhoneNumbers.SelectedValue), CombPhoneNumbers.Text);
                addPhoneNumber.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void BtnSearchPhoneNumber_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                DisplayPhoneNumbers displayPhoneNumbers = new DisplayPhoneNumbers(true, CombPhoneNumbers.Text);
                displayPhoneNumbers.ShowDialog();
                FillCompaniesComboBox();
                FillPhoneNumbersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombPhoneNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!(CombPhoneNumbers.Text == "") & CombPhoneNumbers.Text.Length < 11)
                {
                    MessageBox.Show("يرجى ادخال الرقم كاملاً");
                    CombPhoneNumbers.Focus();
                    return;
                }
                BtnSearchPhoneNumber_Click(sender, e);
            }
        }
        private void CombPhoneNumbers_Leave(object sender, EventArgs e)
        {
            if (!(CombPhoneNumbers.Text == "") & CombPhoneNumbers.Text.Length < 11)
            {
                MessageBox.Show("يرجى ادخال الرقم كاملاً");
                CombPhoneNumbers.Focus();
            }
        }
        private void BtnSearchCompany_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayCompanies displayCompanies = new DisplayCompanies(true, CombCompanies.Text);
                displayCompanies.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                BtnSearchCompany_Click(sender, e);
            }
        }
        private void BtnAddSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                AddSoftware addSoftware = new AddSoftware(0);
                addSoftware.ShowDialog();
                FillSoftwaresComboBox();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                AddSoftware addSoftware = new AddSoftware(Convert.ToInt64(CombSoftware.SelectedValue));
                addSoftware.ShowDialog();
                FillSoftwaresComboBox();
                CombSoftware.SelectedValue = SystemConstants.SelectedSoftware;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                AddUser addUser = new AddUser(0);
                addUser.ShowDialog();
                FillUsersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                AddUser addUser = new AddUser(Convert.ToInt64(CombUser.SelectedValue));
                addUser.ShowDialog();
                FillUsersComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void CombCompanies_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CombCompanies.SelectedValue != null)
                {
                    FillPhoneNumbersComboBox();
                    FillDtgUnclosedTickets(Convert.ToInt64(CombCompanies.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void CombPhoneNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
