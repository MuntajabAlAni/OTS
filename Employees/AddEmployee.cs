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
    public partial class AddEmployee : Form
    {
        private readonly long _id;
        private readonly EmployeeRepository _employeeRepository;
        private EmployeeInfo _employeeInfo;
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
                _employeeInfo = await _employeeRepository.GetById(_id);
                if (!(_employeeInfo is null))
                {
                    TxtName.Text = _employeeInfo.EmployeeName;
                    TxtRemarks.Text = _employeeInfo.Remarks;
                    CbState.Checked = _employeeInfo.State;
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

        private async void AddEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (_id != 0 & (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.DeleteEmployee))))
                {
                    if (MessageBox.Show("هل انت متأكد من الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        await _employeeRepository.Delete(_employeeInfo);
                        this.Close();
                    }
                }
            }
        }
    }
}
