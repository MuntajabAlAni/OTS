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

namespace OTS.Ticketing.Win.Scheduling
{
    public partial class AddEmployee : Form
    {
        private readonly long _id;
        private readonly ScheduleRepository _scheduleRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AddEmployee(long id)
        {
            _id = id;
            _scheduleRepository = new ScheduleRepository();
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
                var employee = await _scheduleRepository.GetEmployeeById(_id);
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

                    await _scheduleRepository.UpdateEmployee(employeeInfo);
                    this.DialogResult = DialogResult.Yes;
                    return;
                }



                employeeInfo = new EmployeeInfo
                {
                    EmployeeName = TxtName.Text,
                    Remarks = TxtRemarks.Text,
                    State = CbState.Checked
                };

                await _scheduleRepository.AddEmployee(employeeInfo);
                this.DialogResult = DialogResult.Yes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
