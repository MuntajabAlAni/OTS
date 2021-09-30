using NLog;
using OTS.Ticketing.Win.Companies;
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
    public partial class AddTask : Form
    {
        private readonly long _employeeId;
        private readonly long _id;
        private readonly ScheduleRepository _scheduleRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AddTask(long id, DateTime selectedDate, long employeeId)
        {
            _employeeId = employeeId;
            _id = id;
            _scheduleRepository = new ScheduleRepository();
            InitializeComponent();
            DtpDate.Value = selectedDate;
        }

        private async void AddTask_Load(object sender, EventArgs e)
        {
            FillCompaniesComboBox();
            FillEmployeesComboBox();
            if (_id != 0)
            {
                var task = await _scheduleRepository.GetTaskById(_id);
                if (!(task is null))
                {
                    CombCompanies.SelectedValue = task.CompanyId;
                    CombEmployees.SelectedValue = task.EmployeeId;
                    DtpFromTime.Value = Convert.ToDateTime(task.TaskStart);
                    DtpToTime.Value = Convert.ToDateTime(task.TaskEnd);
                    TxtTaskDetails.Text = task.TaskDetails;
                    BtnAdd.Text = "تعديل";
                }
            }
        }

        private async void FillCompaniesComboBox()
        {
            try
            {
                CombCompanies.DisplayMember = "Name";
                CombCompanies.ValueMember = "Id";
                CombCompanies.DataSource = await _scheduleRepository.GetAllCompanies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private async void FillEmployeesComboBox()
        {
            try
            {
                CombEmployees.DisplayMember = "EmployeeName";
                CombEmployees.ValueMember = "Id";
                CombEmployees.DataSource = await _scheduleRepository.GetAllEmployees(true);
                CombEmployees.SelectedValue = _employeeId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            TaskInfo taskInfo;

            if (Convert.ToInt64(CombCompanies.SelectedValue) == 0)
            {
                MessageBox.Show("! يرجى إختيار شركة");
                return;
            }
            if (Convert.ToInt64(CombEmployees.SelectedValue) == 0)
            {
                MessageBox.Show("! يرجى إختيار موظف");
                return;
            }
            if (_id != 0)
            {
                taskInfo = new TaskInfo
                {
                    Id = _id,
                    CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                    EmployeeId = Convert.ToInt64(CombEmployees.SelectedValue),
                    TaskDate = DtpDate.Value,
                    TaskStart = DtpFromTime.Value.ToString("HH:mm"),
                    TaskEnd = DtpToTime.Value.ToString("HH:mm"),
                    TaskDetails = TxtTaskDetails.Text,
                    TaskState = false
                };

                await _scheduleRepository.UpdateTask(taskInfo);
                this.DialogResult = DialogResult.Yes;
                return;
            }



            taskInfo = new TaskInfo
            {
                CompanyId = Convert.ToInt64(CombCompanies.SelectedValue),
                EmployeeId = Convert.ToInt64(CombEmployees.SelectedValue),
                TaskDate = DtpDate.Value,
                TaskStart = DtpFromTime.Value.ToString("HH:mm"),
                TaskEnd = DtpToTime.Value.ToString("HH:mm"),
                TaskDetails = TxtTaskDetails.Text,
                TaskState = false
            };

            await _scheduleRepository.AddTask(taskInfo);
            this.DialogResult = DialogResult.Yes;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                var addCompany = new AddCompany(0);
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
                if ((long)CombCompanies.SelectedValue == 0)
                {
                    MessageBox.Show("! يرجى إختيار شركة");
                    return;
                }
                var editCompany = new AddCompany(Convert.ToInt64(CombCompanies.SelectedValue));
                editCompany.ShowDialog();
                FillCompaniesComboBox();
                CombCompanies.SelectedValue = SystemConstants.SelectedCompanyId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var addEmployee = new AddEmployee(0);
                addEmployee.ShowDialog();
                FillEmployeesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if ((long)CombEmployees.SelectedValue == 0)
                {
                    MessageBox.Show("! يرجى إختيار موظف");
                    return;
                }
                var editEmployee = new AddEmployee(Convert.ToInt64(CombEmployees.SelectedValue));
                editEmployee.ShowDialog();
                FillEmployeesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
