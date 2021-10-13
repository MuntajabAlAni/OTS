using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Scheduling
{
    public partial class Schedule : Form
    {
        private readonly ScheduleRepository _scheduleRepository;
        private DateTime _selectedDate;
        public Schedule()
        {
            _scheduleRepository = new ScheduleRepository();
            _selectedDate = DateTime.Now;
            InitializeComponent();
            PnlLoad.Dock = DockStyle.Fill;
            PnlLoad.BringToFront();
            PnlLoad.Visible = false;
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            GetDtgScheduleData();
        }


        private async void GetDtgScheduleData()
        {
            PnlLoad.Visible = true;
            DtgSchedule.DataSource = SystemConstants.ToDataTable(await _scheduleRepository.GetEmployeesTasks(_selectedDate, 8));
            if (DtgSchedule.DataSource is null)
            {
                MessageBox.Show("!! لا يوجد موظفين .. او كلهم معطلين");
                return;
            }
            await Task.Delay(500);
            foreach (DataGridViewRow row in DtgSchedule.Rows)
            {
                foreach (DataGridViewColumn col in DtgSchedule.Columns)
                {
                    if (int.TryParse(DtgSchedule.Rows[row.Index].Cells[col.Index].Value.ToString(), out int result))
                    {
                        if (result > 5)
                        {
                            DtgSchedule.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.Brown;
                            continue;
                        }
                        DtgSchedule.Rows[row.Index].Cells[col.Index].Style.BackColor =
                            Color.FromArgb(255, 255 - (result * 50), 255 - (result * 50));
                    }
                }
            }
            foreach (DataGridViewColumn col in DtgSchedule.Columns)
            {
                DtgSchedule.Columns[col.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DtgSchedule.Columns[0].HeaderText = "اسم الموظف";
            PnlLoad.Visible = false;
        }

        private async void GetDtgTasksData()
        {
            int row = DtgSchedule.SelectedCells[0].RowIndex;
            int col = DtgSchedule.SelectedCells[0].ColumnIndex;
            if (DtgSchedule.Columns[col].HeaderText == "اسم الموظف")
            {
                DtgTasks.DataSource = null;
                LblEmployeeName.Text = "";
                return;
            }

            DateTime selectedDate = Convert.ToDateTime(Regex.Replace(DtgSchedule.Columns[col].HeaderText, "[^0-9-]", ""));
            LblDate.Text = selectedDate.ToString("yyyy-MM-dd dddd");
            string employeeName = DtgSchedule.Rows[row].Cells["EmployeeName"].Value.ToString();
            LblEmployeeName.Text = employeeName;


            DtgTasks.DataSource = await _scheduleRepository.
                GetDayTasksByEmployeeNameAndDate(employeeName, selectedDate.ToString("yyyy-MM-dd"));
            DtgTasks.Columns["Id"].Visible = false;
            DtgTasks.Columns["CompanyName"].HeaderText = "اسم الشركة";
            DtgTasks.Columns["TaskDetails"].HeaderText = "التفاصيل";
            DtgTasks.Columns["TaskStart"].HeaderText = "من";
            DtgTasks.Columns["TaskEnd"].HeaderText = "الى";
            DtgTasks.Columns["TaskState"].HeaderText = "الحالة";

        }

        private void DtgSchedule_Click(object sender, EventArgs e)
        {
            GetDtgTasksData();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            _selectedDate = _selectedDate.AddDays(-8);
            GetDtgScheduleData();
            DtgTasks.DataSource = null;
            LblEmployeeName.Text = "";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            _selectedDate = _selectedDate.AddDays(8);
            GetDtgScheduleData();
            DtgTasks.DataSource = null;
            LblEmployeeName.Text = "";
        }

        private async void BtnAddTask_Click(object sender, EventArgs e)
        {
            int row = DtgSchedule.SelectedCells[0].RowIndex;
            int col = DtgSchedule.SelectedCells[0].ColumnIndex;
            if (DateTime.TryParse(Regex.Replace(DtgSchedule.Columns[col].HeaderText, "[^0-9-]", ""), out DateTime selectedDate))
            {
                string employeeName = DtgSchedule.Rows[row].Cells["EmployeeName"].Value.ToString();
                long employeeId = await _scheduleRepository.GetEmployeeIdByName(employeeName);
                var addTask = new AddTask(0, selectedDate, employeeId);
                addTask.ShowDialog();
                if (addTask.DialogResult == DialogResult.Yes)
                {
                    GetDtgScheduleData();
                    GetDtgTasksData();
                }
            }
        }


        private async void BtnEditTask_Click(object sender, EventArgs e)
        {
            int row = DtgSchedule.SelectedCells[0].RowIndex;
            int col = DtgSchedule.SelectedCells[0].ColumnIndex;
            if (DateTime.TryParse(Regex.Replace(DtgSchedule.Columns[col].HeaderText, "[^0-9-]", ""), out DateTime selectedDate))
            {
                string employeeName = DtgSchedule.Rows[row].Cells["EmployeeName"].Value.ToString();
                if (DtgTasks.SelectedRows.Count < 1) return;
                long selectedTaskId = Convert.ToInt64(DtgTasks.SelectedRows[0].Cells["Id"].Value);
                long employeeId = await _scheduleRepository.GetEmployeeIdByName(employeeName);
                var addTask = new AddTask(selectedTaskId, selectedDate, employeeId);
                addTask.ShowDialog();
                if (addTask.DialogResult == DialogResult.Yes)
                {
                    GetDtgScheduleData();
                    GetDtgTasksData();
                }
            }
        }

        private async void DtgTasks_DoubleClick(object sender, EventArgs e)
        {
            if (DtgTasks.SelectedRows.Count < 1) return;
            long selectedTaskId = Convert.ToInt64(DtgTasks.SelectedRows[0].Cells["Id"].Value);
            var selectedTask = await _scheduleRepository.GetTaskById(selectedTaskId);
            selectedTask.TaskState = !selectedTask.TaskState;
            await _scheduleRepository.UpdateTask(selectedTask);
            GetDtgTasksData();
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            if (_selectedDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")) return;
            _selectedDate = DateTime.Now;
            GetDtgScheduleData();
            DtgTasks.DataSource = null;
            LblEmployeeName.Text = "";
        }
    }
}
