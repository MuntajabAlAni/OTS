using Dapper;
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
    }
}
