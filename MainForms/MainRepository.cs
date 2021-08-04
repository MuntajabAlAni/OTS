﻿using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Employees;
using OTS.Ticketing.Win.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.MainForms
{
    public class MainRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<bool> CheckUserNameAndPasswordAsync(string username, string password)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", username);
            dynamicParameters.Add("Password", password);
            string query = "SELECT * FROM employees where username like @UserName and password = @Password and State = 1";

            var result =  await dataAccess.QueryAsync<EmployeeInfo>(query, dynamicParameters);
            List<EmployeeInfo> employeesInfo = result.ToList();
            return employeesInfo.Count > 0;
        }

        public async Task<List<TicketsView>> GetLastCalls()
        {
            string query = @"SELECT TOP 5 t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                c.name as CompanyName, st.name state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.number = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id
                                                 inner join states st on t.stateId = st.id ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            return result.ToList();
        }
    }
}
