using Dapper;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Employees;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using OTS.Ticketing.Win.States;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<List<TicketsView>> GetAllTickets()
        {
            string query = @"SELECT TOP 5 t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName,st.name state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.number = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 inner join states st on t.stateId = st.id 
                                                 ORDER BY t.number,t.revision";

            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            return result.ToList();
        }

        public async Task<string> GetLastTicketNumber()
        {
            string query = "SELECT TOP 1 t.number from tickets t order by t.number DESC";
            
            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            TicketsView ticketDetails = result.FirstOrDefault();
                return (ticketDetails.Number + 1).ToString();
        }

        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            string query = "SELECT * FROM Companies";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            return result.ToList();
        }

        public async Task<List<SoftwareInfo>> GetAllSoftwares()
        {
            string query = "SELECT * FROM Softwares";
            var result = await dataAccess.QueryAsync<SoftwareInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<EmployeeInfo>> GetAllEmployees()
        {
            string query = "SELECT * FROM Employees";
            var result = await dataAccess.QueryAsync<EmployeeInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<StateInfo>> GetAllStates()
        {
            string query = "SELECT * FROM States";
            var result = await dataAccess.Query<StateInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<PhoneNumberInfo>> GetPhoneNumberOnSelectedCompanyId(long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = "SELECT * FROM PhoneNumbers WHERE companyId = @companyId";
            var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            return result.ToList();
        }

        public async Task<int> AddTicket(long number,int revision,long companyId, long phoneNumberId, long softwareId, long employeeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@companyId", companyId);
            parameters.Add("@phoneNumberId", phoneNumberId);
            parameters.Add("@softwareId", softwareId);
            parameters.Add("@employeeId", employeeId);

            string command = @"INSERT INTO tickets
           (number, phoneNumberId, softwareId, employeeId, companyId, revision)
               VALUES
           (@number,
            @phoneNumberId,
            @softwareId,
            @employeeId,
            @companyId,
            @revision)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }

    }
}
