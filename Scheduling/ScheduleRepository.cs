using Dapper;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Scheduling
{
    public class ScheduleRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<IEnumerable<dynamic>> GetEmployeesTasks(DateTime selectedDate, int period = 8)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@selectedDate", selectedDate);
            parameters.Add("@selectedPeriod", period);

            string query = @"EXEC  GetSchedule
		                    @fromdate = @selectedDate,
		                    @period = @selectedPeriod,
		                    @sql = NULL,
		                    @toDate = NULL";

            var result = await dataAccess.QueryAsync<dynamic>(query, parameters);
            return result;
        }
        public async Task<List<TaskView>> GetDayTasksByEmployeeNameAndDate(string employeeName, string date)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeName", employeeName);
            parameters.Add("@date", date);

            string query = @"select t.id, c.name CompanyName, t.taskDetails, t.taskStart, t.taskEnd, t.taskState from tasks t
							inner join employees e on e.EmployeeName = @employeeName and t.employeeId = e.id
							inner join companies c on c.id = t.companyId
                            where t.taskDate between CAST( @date AS Date )  and CAST( @date AS DateTime )
                            and t.isDeleted = 0";

            var result = await dataAccess.QueryAsync<TaskView>(query, parameters);
            return result.ToList();
        }
        public async Task<TaskInfo> GetTaskById(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"select * from Tasks WHERE id = @id and isDeleted = 0";

            var result = await dataAccess.QueryAsync<TaskInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            string query = "SELECT * FROM Companies WHERE isDeleted = 0";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new CompanyInfo { Id = 0, Name = "يرجى إختيار شركة" }));
            return list;
        }
        public async Task<List<EmployeeInfo>> GetAllEmployees(bool onlyStateOn)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@onlyStateOn", onlyStateOn);
            string query = "SELECT * FROM Employees where IIF(@onlyStateOn = 0,0,state) = @onlyStateOn";
            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var list = result.ToList();
            list.Insert(0, (new EmployeeInfo { Id = 0, EmployeeName = "يرجى إختيار موظف" }));
            return list;
        }
        public async Task<long> GetEmployeeIdByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string query = "SELECT * from Employees where EmployeeName = @name";

            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var employeeInfo = result.FirstOrDefault();
            return employeeInfo.Id;
        }
        public async Task<int> AddTask(TaskInfo taskInfo)
        {
            var parameters = new DynamicParameters(taskInfo);

            string command = @"INSERT INTO Tasks 
                                (EmployeeId, CompanyId, TaskDate, TaskStart, TaskEnd, TaskState, TaskDetails) 
                                Values 
                                (@EmployeeId, @CompanyId, @TaskDate, @TaskStart, @TaskEnd, @TaskState, @TaskDetails)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> UpdateTask(TaskInfo taskInfo)
        {
            var parameters = new DynamicParameters(taskInfo);

            string command = @"UPDATE Tasks SET 
                               EmployeeId = @EmployeeId,
                               CompanyId = @CompanyId,
                               TaskDate = @TaskDate,
                               TaskStart = @TaskStart,
                               TaskEnd = @TaskEnd,
                               TaskState = @TaskState,
                               TaskDetails = @TaskDetails
                               WHERE id = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<EmployeeInfo> GetEmployeeById(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"select * from Employees WHERE id = @id";

            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdateEmployee(EmployeeInfo employeeInfo)
        {
            var parameters = new DynamicParameters(employeeInfo);

            string command = @"UPDATE Employees SET 
                               EmployeeName = @EmployeeName,
                               Remarks = @Remarks,
                               State = @State
                               WHERE id = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> AddEmployee(EmployeeInfo employeeInfo)
        {
            var parameters = new DynamicParameters(employeeInfo);

            string command = @"INSERT INTO Employees 
                                (EmployeeName, Remarks, State) 
                                Values 
                                (@EmployeeName, @Remarks, @State)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
