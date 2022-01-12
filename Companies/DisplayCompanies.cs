using NLog;
using OTS.Ticketing.Win.Enums;
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
    public partial class DisplayCompanies : Form
    {
        readonly CompanyRepository companyRepository = new CompanyRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        readonly string _companyName;
        readonly bool _search;
        private DataTable _companies;

        public DisplayCompanies(bool serach, string companyName = "")
        {
            InitializeComponent();
            _companyName = companyName;
            _search = serach;
        }

        private async void DisplayCompanies_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddCompany)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = false;

                _companies = SystemConstants.ToDataTable(await companyRepository.GetByName(_companyName));
                GetDtgCompaniesData(_companies);

                if (_search)
                {
                    BtnAdd.Visible = false;
                    if (DtgCompanies.Rows.Count == 1)
                    {
                        long id = Convert.ToInt64(DtgCompanies.Rows[0].Cells["Id"].Value.ToString());
                        CompanyInfo selectedCompany = await companyRepository.GetById(id);
                        SystemConstants.selectedCompanyId = selectedCompany.Id;
                        this.Close();
                    }
                    if (DtgCompanies.Rows.Count == 0)
                    {
                        MessageBox.Show("عذراً.. هذه الشركة غير معرفة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        AddCompany addCompany = new AddCompany(0, _companyName);
                        addCompany.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void GetDtgCompaniesData(DataTable data)
        {
            if (!data.Columns.Contains("ت"))
            {
                DataColumn dc = new DataColumn("ت", typeof(int));
                data.Columns.Add(dc);
                int i = 0;
                foreach (DataRow dr in data.Rows)
                {
                    dr["ت"] = i + 1;
                    i++;
                }
            }
            DtgCompanies.DataSource = data;
            DtgCompanies.Columns["ت"].DisplayIndex = 0;
            DtgCompanies.Columns["Id"].Visible = false;
            DtgCompanies.Columns["Name"].HeaderText = "اسم الشركة";
            DtgCompanies.Columns["Address"].HeaderText = "العنوان";
            DtgCompanies.Columns["BranchName"].HeaderText = "الفرع";
            DtgCompanies.Columns["Remarks"].Visible = false;
            DtgCompanies.Columns["IsDeleted"].Visible = false;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            AddCompany addCompany = new AddCompany(0);
            addCompany.ShowDialog();

            _companies = SystemConstants.ToDataTable(await companyRepository.GetByName(_companyName));
            GetDtgCompaniesData(_companies);
        }

        private async void DtgCompanies_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_search)
                {
                    long id = Convert.ToInt64(DtgCompanies.SelectedRows[0].Cells["Id"].Value.ToString());
                    CompanyInfo selectedCompany = await companyRepository.GetById(id);
                    SystemConstants.selectedCompanyId = selectedCompany.Id;
                    this.Close();
                }
                else
                {
                    if (!SystemConstants.userRoles.Contains(((long)RoleType.EditCompany)) &
                        !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                        return;
                    long id = Convert.ToInt64(DtgCompanies.SelectedRows[0].Cells["Id"].Value.ToString());
                    AddCompany addCompany = new AddCompany(id);
                    addCompany.ShowDialog();

                    _companies = SystemConstants.ToDataTable(await companyRepository.GetByName(_companyName));
                    GetDtgCompaniesData(_companies);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void TxtCompany_TextChanged(object sender, EventArgs e)
        {
            if (TxtCompany.Text != string.Empty)
            {
                var rows = _companies.Select($"Name Like '%{ TxtCompany.Text }%'");
                if (rows.Count() > 0)
                {
                    GetDtgCompaniesData(rows.CopyToDataTable());
                    return;
                }
            }

            GetDtgCompaniesData(_companies);
        }
    }
}
