using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Employees
{
    public partial class AddEmployee : Form
    {
        private readonly EmployeeRepository employeeRepository = new EmployeeRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;
        public AddEmployee(long id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void AddEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    EmployeeInfo employeeInfo = await employeeRepository.GetEmployeeById(_id);
                    TxtDisplayName.Text = employeeInfo.DisplayName;
                    TxtUserName.Text = employeeInfo.UserName;
                    TxtPassword.Text = employeeInfo.Password;
                    TxtIp.Text = employeeInfo.Ip;
                    TxtRemarks.Text = employeeInfo.Remarks;
                    CbState.Checked = employeeInfo.State;
                    BtnAdd.Text = "تعديل";
                }
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

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    await employeeRepository.AddEmployee(TxtDisplayName.Text, TxtUserName.Text, TxtPassword.Text,
                        CbState.Checked, TxtIp.Text, TxtRemarks.Text);
                }
                else
                {
                    await employeeRepository.UpdateEmployee(_id, TxtDisplayName.Text, TxtUserName.Text, TxtPassword.Text,
                        CbState.Checked, TxtIp.Text, TxtRemarks.Text);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
