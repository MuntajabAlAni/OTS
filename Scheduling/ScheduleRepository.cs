using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Scheduling
{
    public class ScheduleRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<List<EmployeeInfo>> GetAllEmployees()
        {
            string query = "Select * from Employees";

            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, new DynamicParameters());
            var list = result.ToList();

            return list;
        }
        public async Task<List<TaskInfo>> GetTasksByEmployeeNameAndDate(string employeeName,string date)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeName", employeeName);
            parameters.Add("@date", date);

            string query = @"select t.taskDetails,t.taskStart, t.taskEnd, t.taskState from tasks t
							inner join employees e on e.EmployeeName = @employeeName and t.employeeId = e.id
                            where t.taskDate between CAST( @date AS Date )  and CAST( @date AS DateTime )
                            and t.isDeleted = 0";

            var result = await dataAccess.QueryAsync<TaskInfo>(query, parameters);
            return result.ToList();
        }
    }
}
