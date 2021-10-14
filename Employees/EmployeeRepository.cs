﻿using Dapper;
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

        public async Task<EmployeeInfo> GetEmployeeById(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"select * from Employees WHERE id = @id";

            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
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

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> AddEmployee(EmployeeInfo employeeInfo)
        {
            var parameters = new DynamicParameters(employeeInfo);

            string command = @"INSERT INTO Employees 
                                (EmployeeName, Remarks, State) 
                                Values 
                                (@EmployeeName, @Remarks, @State)";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<EmployeeInfo>> GetAllEmployees(bool onlyStateOn)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@onlyStateOn", onlyStateOn);
            string query = "SELECT * FROM Employees where IIF(@onlyStateOn = 0,0,state) = @onlyStateOn";
            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var list = result.ToList();
            list.Insert(0, (new EmployeeInfo { Id = 0, EmployeeName = "يرجى إختيار موظف" }));
            return list;
        }
        public async Task<long> GetEmployeeIdByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string query = "SELECT * from Employees where EmployeeName = @name";

            var result = await _dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
            var employeeInfo = result.FirstOrDefault();
            return employeeInfo.Id;
        }

    }
}