using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Employees
{
    public class EmployeeRepository
    {
        private readonly DataAccess dataAccess = new DataAccess();

        public async Task<int> AddEmployee(string displayName, string userName, string password, bool state, string ip, string remarks)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@displayName", displayName);
            parameters.Add("@userName", userName);
            parameters.Add("@password", password);
            parameters.Add("@state", state);
            parameters.Add("@ip", ip);
            parameters.Add("@remarks", remarks);

            string command = @"INSERT INTO Employees (DisplayName, UserName, Password, State, Ip, Remarks)
                                VALUES (@displayName,
                                        @userName,
                                        @password,
                                        @state,
                                        @ip,
                                        @remarks)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<EmployeeInfo> GetEmployeeById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"SELECT * FROM EMPLOYEES WHERE ID = @ID";
            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdateEmployee(long id, string displayName, string userName, string password, bool state, string ip, string remarks)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@displayName", displayName);
            parameters.Add("@userName", userName);
            parameters.Add("@password", password);
            parameters.Add("@state", state);
            parameters.Add("@ip", ip);
            parameters.Add("@remarks", remarks);

            string command = @"UPDATE Employees SET 
                                displayName = @displayName,
                                userName = @userName,
                                password = @password,
                                state = @state,
                                ip = @ip,
                                remarks = @remarks
                               WHERE Id = @id";
            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
