using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Branches;
using OTS.Ticketing.Win.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Companies
{
    public partial class AddCompany : Form
    {
        private readonly CompanyRepository _companyRepository;
        private readonly BranchRepository _branchRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private CompanyInfo _companyInfo;
        private readonly long _id;
        private readonly string _name;

        public AddCompany(long id, string name = "")
        {
            _companyRepository = new CompanyRepository();
            _activityLogRepository = new ActivityLogRepository();
            _branchRepository = new BranchRepository();
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
                    _companyInfo = await _companyRepository.GetCompanyInfoById(_id);
                    TxtName.Text = _companyInfo.Name;
                    TxtAddress.Text = _companyInfo.Address;
                    CombBranches.SelectedValue = _companyInfo.BranchId;
                    TxtRemarks.Text = _companyInfo.Remarks;
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
                CombBranches.DataSource = await _branchRepository.GetAllBranches();
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
                CompanyInfo company = GetFormData();
                if (_id == 0)
                {
                    long addedId = await _companyRepository.AddCompany(company);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddCompany,
                        addedId, "إضافة شركة"));
                }
                else
                {
                    await _companyRepository.UpdateCompany(company);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditCompany,
                         _id, "تعديل شركة"));

                }
                List<CompanyView> companies = await _companyRepository.GetCompanyByName(TxtName.Text);
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

        private CompanyInfo GetFormData()
        {
            return new CompanyInfo
            {
                Id = _id,
                Name = TxtName.Text,
                Address = TxtAddress.Text,
                BranchId = Convert.ToInt64(CombBranches.SelectedValue),
                Remarks = TxtRemarks.Text
            };
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
