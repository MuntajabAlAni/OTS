using OTS.Ticketing.Win.Branches;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Companies
{
    public partial class AddCompany : Form
    {
        readonly CompanyRepository companyRepository = new CompanyRepository();
        private readonly long _id;

        public AddCompany(long id)
        {
            InitializeComponent();
            _id = id;
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
                SystemConstants.ErrorLog(ex, "BtnAddBranch_Click");
            }

        }

        private async void AddCompany_Load(object sender, EventArgs e)
        {

            try
            {

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
                SystemConstants.ErrorLog(ex, "AddCompany_Load");
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
                SystemConstants.ErrorLog(ex, "BtnEditBranch_Click");
            }
        }

        private async void FillCombBranches()
        {

            try
            {
                CombBranches.DataSource = await companyRepository.GetAllBranches();
                CombBranches.DisplayMember = "Name";
                CombBranches.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "FillCombBranches");
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtName.Text == "")
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
                }
                else
                {
                    await companyRepository.UpdateCompany(TxtName.Text,
                        TxtAddress.Text,
                        Convert.ToInt64(CombBranches.SelectedValue),
                        TxtRemarks.Text,
                        _id);
                }
                CompanyInfo lastCompany = await companyRepository.GetLastCompanyId();
                SystemConstants.SelectedCompanyId = lastCompany.Id;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "BtnAdd_Click");
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
                Application.Exit();
            }
        }
    }
}
