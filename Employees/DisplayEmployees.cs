using NLog;
using OTS.Ticketing.Win.Employees;
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

namespace OTS.Ticketing.Win.Tasks
{
    public partial class DisplayEmployees : Form
    {
        readonly EmployeeRepository _employeeRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DisplayEmployees()
        {
            _employeeRepository = new EmployeeRepository();
            InitializeComponent();
        }

        private void DisplayEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.AddEmployee)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAdd.Visible = false;
                GetDtgEmployeesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private async void GetDtgEmployeesData()
        {
            try
            {
                DtgEmployees.DataSource = SystemConstants.ToDataTable(await _employeeRepository.GetAllEmployees(false));
                DtgEmployees.Columns["State"].HeaderText = "الحالة";
                DtgEmployees.Columns["employeeName"].HeaderText = "اسم الموظف";
                DtgEmployees.Columns["Remarks"].Visible = false;
                DtgEmployees.Columns["Id"].Visible = false;
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

        private void DisplayEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(0);
            addEmployee.ShowDialog();
            GetDtgEmployeesData();
        }

        private void DtgEmployees_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!SystemConstants.userRoles.Contains(((long)RoleType.EditEmployee)) &
                    !SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    return;
                long id = Convert.ToInt64(DtgEmployees.SelectedRows[0].Cells["Id"].Value.ToString());
                AddEmployee editEmployee = new AddEmployee(id);
                editEmployee.ShowDialog();
                GetDtgEmployeesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
