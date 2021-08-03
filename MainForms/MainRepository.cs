﻿using Dapper;
using OTS.Ticketing.Software.DatabaseConnection;
using OTS.Ticketing.Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Software.MainForms
{
    public class MainRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public bool CheckUserNameAndPassword(string username, string password)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", username);
            dynamicParameters.Add("Password", password);
            List<EmployeeInfo> employeesInfo = dataAccess.Query<EmployeeInfo>("SELECT * FROM employees where username like @UserName and password = @Password and State = 1", dynamicParameters).ToList();
            return employeesInfo.Count > 0;
        }

        public List<TicketDetails> GetLastCalls()
        {
            return dataAccess.Query<TicketDetails>(@"SELECT TOP 5 t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                c.name as CompanyName, 
                                                case when t.state = 0 then 'لم يتم الحل'
                                                when t.state = 1 then 'تم الحل'
                                                when t.state = 2 then 'مؤجلة'
                                                when t.state = 3 then 'تم التحويل'
                                                end state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.number = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id ORDER BY t.Id DESC", new DynamicParameters()).ToList();
        }
    }
}