using NLog;
using OTS.Ticketing.Win.Employees;
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
    public partial class AddEmployee : Form
    {
        private readonly long _id;
        private readonly EmployeeRepository _employeeRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AddEmployee(long id)
        {
            _id = id;
            _employeeRepository = new EmployeeRepository();
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddEmployee_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                var employee = await _employeeRepository.GetById(_id);
                if (!(employee is null))
                {
                    TxtName.Text = employee.EmployeeName;
                    TxtRemarks.Text = employee.Remarks;
                    CbState.Checked = employee.State;
                    BtnAdd.Text = "تعديل";
                }
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeInfo employeeInfo;

                if (string.IsNullOrWhiteSpace(TxtName.Text))
                {
                    MessageBox.Show("! يرجى إضافة اسم الموظف");
                    return;
                }
                if (_id != 0)
                {
                    employeeInfo = new EmployeeInfo
                    {
                        Id = _id,
                        EmployeeName = TxtName.Text,
                        Remarks = TxtRemarks.Text,
                        State = CbState.Checked
                    };

                    await _employeeRepository.Update(employeeInfo);
                    this.DialogResult = DialogResult.Yes;
                    return;
                }



                employeeInfo = new EmployeeInfo
                {
                    EmployeeName = TxtName.Text,
                    Remarks = TxtRemarks.Text,
                    State = CbState.Checked
                };

                await _employeeRepository.Add(employeeInfo);
                this.DialogResult = DialogResult.Yes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void AddEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
