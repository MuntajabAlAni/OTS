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
using OTS.Ticketing.Win.Enums;
using OTS.Ticketing.Win.Utils;
using OTS.Ticketing.Win.ActivityLog;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class AddTicket : Form
    {
        readonly TicketRepository _ticketRepository;
        readonly CompanyRepository _companyRepository;
        readonly SoftwareRepository _softwareRepository;
        readonly UserRepository _userRepository;
        readonly PhoneNumberRepository _phoneNumberRepository;
        readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public AddTicket()
        {
            _ticketRepository = new TicketRepository();
            _companyRepository = new CompanyRepository();
            _softwareRepository = new SoftwareRepository();
            _userRepository = new UserRepository();
            _phoneNumberRepository = new PhoneNumberRepository();
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
        }
        private async void AddTicket_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddCompany)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAddCompany.Visible = false;
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditCompany)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEditCompany.Visible = false;

                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddPhoneNumber)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAddPhoneNumber.Visible = false;
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditPhoneNumber)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEditPhoneNumber.Visible = false;

                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddUser)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAddUser.Visible = false;

                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditUser)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEditUser.Visible = false;

                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddSoftware)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAddSoftware.Visible = false;

                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditSoftware)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEditSoftware.Visible = false;

                ToolTip.SetToolTip(BtnAddCompany, "إضافة شركة");
                ToolTip.SetToolTip(BtnEditCompany, "تعديل شركة");
                ToolTip.SetToolTip(BtnSearchCompany, "البحث عن شركة");
                ToolTip.SetToolTip(BtnAddPhoneNumber, "إضافة رقم هاتف");
                ToolTip.SetToolTip(BtnEditPhoneNumber, "تعديل رقم هاتف");
                ToolTip.SetToolTip(BtnSearchPhoneNumber, "البحث عن رقم هاتف");
                ToolTip.SetToolTip(BtnAddUser, "إضافة مستخدم");
                ToolTip.SetToolTip(BtnEditUser, "تعديل مستخدم");
                ToolTip.SetToolTip(BtnAddSoftware, "إضافة برنامج");
                ToolTip.SetToolTip(BtnEditSoftware, "تعديل برنامج");

                LblNumber.Text = await _ticketRepository.GetLastNumber();
                LblRevision.Text = "0";
                FillCompaniesComboBox();
                FillSoftwaresComboBox();
                //FillUsersComboBox();
                FillPhoneNumbersComboBox();
                SystemConstants.selectedCompanyId = 0;
                SystemConstants.selectedPhoneNumberId = 0;
                SystemConstants.selectedSoftware = 0;
                SystemConstants.selectedUser = 0;
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
                CombCompanies.DataSource = await _companyRepository.GetAll();
                CombCompanies.SelectedValue = SystemConstants.selectedCompanyId;
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
                CombSoftware.DataSource = await _softwareRepository.GetAll();
                CombSoftware.SelectedValue = SystemConstants.selectedSoftware;
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
                CombUser.DataSource = await _userRepository.GetOnlineOTS();
                CombUser.SelectedValue = SystemConstants.selectedUser;
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
                var result = await _phoneNumberRepository.GetByCompanyId(Convert.ToInt64(CombCompanies.SelectedValue));
                if (result.Count != 0)
                {
                    CombPhoneNumbers.DisplayMember = "phoneNumber";
                    CombPhoneNumbers.ValueMember = "Id";
                    CombPhoneNumbers.DataSource = result;
                    CombPhoneNumbers.SelectedValue = SystemConstants.selectedPhoneNumberId;
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
            DtgUnclosedTickets.DataSource = await _ticketRepository.GetUnclosedByCompanyId(companyId);
            DtgUnclosedTickets.Columns["Number"].HeaderText = "رقم البطاقة";
            DtgUnclosedTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
            DtgUnclosedTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
            DtgUnclosedTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
            DtgUnclosedTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
            DtgUnclosedTickets.Columns["UserName"].HeaderText = "الموظف";
            DtgUnclosedTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgUnclosedTickets.Columns["BranchName"].HeaderText = "الفرع";
            DtgUnclosedTickets.Columns["Problem"].HeaderText = "المشكلة";
            DtgUnclosedTickets.Columns["StateName"].HeaderText = "الحالة";
            DtgUnclosedTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
            DtgUnclosedTickets.Columns["IsIndexedView"].HeaderText = "ترتيب الملفات";
            DtgUnclosedTickets.Columns["IsClosedView"].HeaderText = "الإغلاق";
            DtgUnclosedTickets.HideUntranslatedColumns();

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
                    TicketInfo ticket = new TicketInfo()
                    {
                        Number = Convert.ToInt64(LblNumber.Text),
                        Revision = Convert.ToInt32(LblRevision.Text),
                        CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                        PhoneNumberId = Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                        SoftwareId = Convert.ToInt64(CombSoftware.SelectedValue),
                        UserId = Convert.ToInt64(CombUser.SelectedValue)
                    };

                    await _ticketRepository.Add(ticket);

                    SystemConstants.selectedCompanyId = 0;
                    SystemConstants.selectedPhoneNumberId = 0;
                    SystemConstants.selectedSoftware = 0;
                    SystemConstants.selectedUser = 0;

                    TicketInfo addedTicket = await _ticketRepository.GetByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
                        Convert.ToInt32(LblRevision.Text));

                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddTicket,
                         addedTicket.Id, "إضافة بطاقة"));
                    this.Close();
                }

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
                CombCompanies.SelectedValue = SystemConstants.selectedCompanyId;
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
                CombCompanies.SelectedValue = SystemConstants.selectedCompanyId;
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
                SystemConstants.selectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
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
                SystemConstants.selectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
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
                SystemConstants.selectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
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
                CombCompanies.SelectedValue = SystemConstants.selectedCompanyId;
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
                CombSoftware.SelectedValue = SystemConstants.selectedSoftware;
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
                CombSoftware.SelectedValue = SystemConstants.selectedSoftware;
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

        private async void DtgUnclosedTickets_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DtgUnclosedTickets.RowCount == 0) return;
                long selectedNumber = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgUnclosedTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketInfo selectedTicket = await _ticketRepository.GetByNumberAndRevision(selectedNumber, selectedRevision);
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

        private void CombUser_Enter(object sender, EventArgs e)
        {
            FillUsersComboBox();
        }
    }
}
