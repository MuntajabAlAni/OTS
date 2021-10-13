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

namespace OTS.Ticketing.Win.Tasks
{
    public class TaskRepository
    {
        public DataAccess _dataAccess = new DataAccess();

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

            var result = await _dataAccess.QueryAsync<dynamic>(query, parameters);
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

            var result = await _dataAccess.QueryAsync<TaskView>(query, parameters);
            return result.ToList();
        }   
        public async Task<TaskInfo> GetTaskById(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"select * from Tasks WHERE id = @id and isDeleted = 0";

            var result = await _dataAccess.QueryAsync<TaskInfo>(query, parameters);
            return result.FirstOrDefault();
        }        
        public async Task<int> AddTask(TaskInfo taskInfo)
        {
            var parameters = new DynamicParameters(taskInfo);

            string command = @"INSERT INTO Tasks 
                                (EmployeeId, CompanyId, TaskDate, TaskStart, TaskEnd, TaskState, TaskDetails) 
                                Values 
                                (@EmployeeId, @CompanyId, @TaskDate, @TaskStart, @TaskEnd, @TaskState, @TaskDetails)";

            return await _dataAccess.ExecuteAsync(command, parameters);
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

            return await _dataAccess.ExecuteAsync(command, parameters);
        }        
    }
}
