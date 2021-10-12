﻿using NLog;
using OTS.Ticketing.Win.Branches;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Ticketing.Win.Enums;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Companies
{
    public partial class AddCompany : Form
    {
        readonly CompanyRepository companyRepository = new CompanyRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        private readonly string _name;

        public AddCompany(long id, string name = "")
        {
            InitializeComponent();
            _id = id;
            _name = name;
        }

        private void BtnAddBranch_Click(object sender, EventArgs e)
        {
            try
            {
                long selectedBranch = 0;
                AddBranch aeForm = new AddBranch(selectedBranch);
                aeForm.ShowDialog();
                FillCombBranches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void AddCompany_Load(object sender, EventArgs e)
        {

            try
            {
                TxtName.Text = _name;
                FillCombBranches();
                if (_id != 0)
                {
                    CompanyInfo companyInfo = await companyRepository.GetCompanyInfoById(_id);
                    TxtName.Text = companyInfo.Name;
                    TxtAddress.Text = companyInfo.Address;
                    CombBranches.SelectedValue = companyInfo.BranchId;
                    TxtRemarks.Text = companyInfo.Remarks;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnEditBranch_Click(object sender, EventArgs e)
        {

            try
            {
                long selectedBranch = Convert.ToInt64(CombBranches.SelectedValue);
                AddBranch aeForm = new AddBranch(selectedBranch);
                aeForm.ShowDialog();
                FillCombBranches();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private async void FillCombBranches()
        {

            try
            {
                CombBranches.DisplayMember = "Name";
                CombBranches.ValueMember = "Id";
                CombBranches.DataSource = await companyRepository.GetAllBranches();
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
                if (TxtName.Text == "" | Convert.ToInt64(CombBranches.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_id == 0)
                {
                    await companyRepository.AddCompany(TxtName.Text,
                        TxtAddress.Text,
                        Convert.ToInt64(CombBranches.SelectedValue),
                        TxtRemarks.Text);
                    await ActivityLogUtility.AddActivityLog(ActivityType.AddCompany, "إضافة شركة", await companyRepository.GetLastCompanyId());
                }
                else
                {
                    await companyRepository.UpdateCompany(TxtName.Text,
                        TxtAddress.Text,
                        Convert.ToInt64(CombBranches.SelectedValue),
                        TxtRemarks.Text,
                        _id);
                    await ActivityLogUtility.AddActivityLog(ActivityType.EditCompany, "تعديل شركة", _id);

                }
                List<CompanyView> companies = await companyRepository.GetCompanyByName(TxtName.Text);
                CompanyView selectedCompany = companies.FirstOrDefault();
                SystemConstants.SelectedCompanyId = selectedCompany.Id;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
