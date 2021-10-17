using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Employees
{
    public class EmployeeRepository
    {
        public DataAccess _dataAccess = new DataAccess();

        public async Task<EmployeeInfo> GetById(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"select * from Employees WHERE id = @id AND isDeleted = 0";

            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> Update(EmployeeInfo employeeInfo)
        {
            var parameters = new DynamicParameters(employeeInfo);

            string command = @"UPDATE Employees SET 
                               EmployeeName = @EmployeeName,
                               Remarks = @Remarks,
                               State = @State
                               WHERE id = @id";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> Add(EmployeeInfo employeeInfo)
        {
            var parameters = new DynamicParameters(employeeInfo);

            string command = @"INSERT INTO Employees 
                                (EmployeeName, Remarks, State) 
                                Values 
                                (@EmployeeName, @Remarks, @State)";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<EmployeeInfo>> GetAll(bool onlyStateOn)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@onlyStateOn", onlyStateOn);
            string query = "SELECT * FROM Employees where IIF(@onlyStateOn = 0,0,state) = @onlyStateOn AND isDeleted = 0";
            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var list = result.ToList();
            return list;
        }
        public async Task<long> GetIdByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string query = "SELECT * from Employees where EmployeeName = @name AND isDeleted = 0";

            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var employeeInfo = result.FirstOrDefault();
            return employeeInfo.Id;
        }

        public async Task Delete(EmployeeInfo employee)
        {
            var parameters = new DynamicParameters(employee);
            string command = @"UPDATE Employees SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
