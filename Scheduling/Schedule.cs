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
    public partial class Schedule : Form
    {
        private readonly ScheduleRepository _scheduleRepository;
        public Schedule()
        {
            _scheduleRepository = new ScheduleRepository();
            InitializeComponent();
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            GetDtgScheduleData();
        }

        int sumOfPeriods = 0;

        private async void GetDtgScheduleData(int period = 0)
        {
            PnlLoad.Visible = true;
            var employeesList = await _scheduleRepository.GetAllEmployees();
            var employeesDt = SystemConstants.ToDataTable(employeesList);
            employeesDt.Columns.Remove("Id");
            employeesDt.Columns.Remove("State");
            employeesDt.Columns.Remove("Remarks");

            sumOfPeriods += period;

            DateTime selectedDate = DateTime.Now.AddDays(sumOfPeriods);
            for (DateTime nowDate = DateTime.Now.AddDays(sumOfPeriods);
                nowDate < selectedDate.AddDays(8);
                nowDate = nowDate.AddDays(1))
            {
                int day = nowDate.Day;
                employeesDt.Columns.Add($"{day}", typeof(int));
            }

            DtgSchedule.DataSource = employeesDt;
            PnlLoad.Visible = false;
        }

        private async void DtgSchedule_Click(object sender, EventArgs e)
        {
            int row = DtgSchedule.SelectedCells[0].RowIndex;
            int col = DtgSchedule.SelectedCells[0].ColumnIndex;
            if (!int.TryParse(DtgSchedule.Columns[col].HeaderText, out int result))
            {
                DtgTasks.DataSource = null;
                LblEmployeeName.Text = "";
                return;
            }

            string employeeName = DtgSchedule.Rows[row].Cells["EmployeeName"].Value.ToString();
            LblEmployeeName.Text = employeeName;


            string selectedDate = DateTime.Now.AddDays(result - DateTime.Now.Day).ToString("yyyy-MM-dd");

            var tasksList = await _scheduleRepository.GetTasksByEmployeeNameAndDate(employeeName, selectedDate);
            DtgTasks.DataSource = tasksList;
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            GetDtgScheduleData(-8);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            GetDtgScheduleData(8);
        }
    }
}
