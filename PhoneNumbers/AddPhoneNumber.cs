﻿using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Enums;
using System;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.PhoneNumbers
{
    public partial class AddPhoneNumber : Form
    {
        private readonly PhoneNumberRepository _phoneNumberRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private readonly CompanyRepository _companyRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly long _id;
        private readonly string _phoneNumber;

        public AddPhoneNumber(long id, string phoneNumber = "")
        {
            _phoneNumberRepository = new PhoneNumberRepository();
            _activityLogRepository = new ActivityLogRepository();
            _companyRepository = new CompanyRepository();
            InitializeComponent();
            _id = id;
            _phoneNumber = phoneNumber;
        }
        private async void AddPhoneNumber_Load(object sender, EventArgs e)
        {
            try
            {
                if (_phoneNumber != "")
                {
                    TxtPhoneNumber.Text = _phoneNumber;
                }
                FillCompaniesComboBox();
                if (_id != 0)
                {
                    PhoneNumberInfo phoneNumberInfo = await _phoneNumberRepository.GetPhoneNumberById(_id);
                    TxtPhoneNumber.Text = phoneNumberInfo.PhoneNumber;
                    TxtCustomerName.Text = phoneNumberInfo.CustomerName;
                    CombCompanies.SelectedValue = phoneNumberInfo.CompanyId;
                    BtnAdd.Text = "تعديل";
                }
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
                CombCompanies.DataSource = await _companyRepository.GetAllCompanies();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPhoneNumber.Text == "" | CombCompanies.SelectedValue == DBNull.Value | Convert.ToInt64(CombCompanies.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PhoneNumberInfo phoneNumber = GetFormData();
                if (_id == 0)
                {
                    long addedId = await _phoneNumberRepository.AddPhoneNumber(phoneNumber);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddPhoneNumber,
                        addedId, "إضافة رقم هاتف"));
                }
                else
                {
                    await _phoneNumberRepository.UpdatePhoneNumber(phoneNumber);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditPhoneNumber,
                         _id, "تعديل رقم هاتف"));

                }
                SystemConstants.SelectedCompanyId = Convert.ToInt64(CombCompanies.SelectedValue);
                SystemConstants.SelectedPhoneNumberId = await _phoneNumberRepository.GetPhoneNumberIdByPhoneNumber(TxtPhoneNumber.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private PhoneNumberInfo GetFormData()
        {
            return new PhoneNumberInfo
            {
                Id = _id,
                PhoneNumber = TxtPhoneNumber.Text,
                CustomerName = TxtCustomerName.Text,
                CompanyId = Convert.ToInt64(CombCompanies.SelectedValue)
            };
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                AddCompany addCompany = new AddCompany(0, CombCompanies.Text);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private void AddPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void TxtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (!(TxtPhoneNumber.Text == "") & TxtPhoneNumber.Text.Length < 11)
            {
                MessageBox.Show("يرجى ادخال الرقم كاملاً");
                TxtPhoneNumber.Focus();
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

        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
