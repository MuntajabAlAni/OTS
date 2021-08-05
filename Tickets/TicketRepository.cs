using Dapper;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Employees;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using OTS.Ticketing.Win.States;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<List<TicketsView>> GetAllTicketsByEmployeeId(long employeeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", employeeId);
            string query = @"SELECT TOP 5 t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName,st.name state, t.revision FROM tickets t
                                                 left join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 left join softwares s on t.softwareId = s.id
                                                 left join employees e on t.employeeId = e.id
                                                 left join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id
												 WHERE employeeId = @employeeId and closeDate is null and childId =0
                                                 ORDER BY t.number,t.revision";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
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
            var result = await dataAccess.QueryAsync<StateInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<PhoneNumberInfo>> GetPhoneNumbersOnSelectedCompanyId(long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = "SELECT * FROM PhoneNumbers WHERE IIF(@companyId = 0,0,companyId) = @companyId";
            var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            return result.ToList();
        }
        public async void AddTicket(long number, int revision, long companyId, long phoneNumberId, long softwareId, long employeeId)
        {
            //using (IDbConnection connection = new SqlConnection(ConnectionTools.ConnectionValue("OTS_Ticketing_SoftwareDB")))
            //{
                DynamicParameters parameters1 = new DynamicParameters();
                parameters1.Add("@number", number);
                parameters1.Add("@revision", revision);
                parameters1.Add("@companyId", companyId);
                parameters1.Add("@phoneNumberId", phoneNumberId);
                parameters1.Add("@softwareId", softwareId);
                parameters1.Add("@employeeId", employeeId);

                string command1 = @"INSERT INTO tickets
           (number, phoneNumberId, softwareId, employeeId, companyId, revision)
               VALUES
           (@number,
            @phoneNumberId,
            @softwareId,
            @employeeId,
            @companyId,
            @revision)";

            await dataAccess.ExecuteAsync(command1, parameters1);

            //connection.Open();
            //using (var trans = connection.BeginTransaction())
            //{
            //int recordsUpdated = await connection.ExecuteAsync(command1, parameters1, trans);
            //    try
            //    {
            //        var parameters2 = new DynamicParameters();
            //        parameters2.Add("@number", number);
            //        parameters2.Add("@revision", revision);

            //        string command2 = "UPDATE Tickets SET childId = (select max(id) from tickets where number = @number) Where number = @number and revision < @revision";
            //        int recordsUpdated2 = await connection.ExecuteAsync(command2, parameters2, transaction: trans);
            //        trans.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //    }
            //}
            //}
        }
        public async Task<List<TicketsView>> GetUnclosedTicketsOnSelectedCompanyId(long companyId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName,st.name state, t.revision FROM tickets t
                                                 left join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 left join softwares s on t.softwareId = s.id
                                                 left join employees e on t.employeeId = e.id
                                                 left join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id 
												 WHERE closeDate is null and t.companyId = @companyId and childId =0
                                                 ORDER BY t.number,t.revision";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<TicketInfo> GetTicketsByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = "select * from tickets where number = @ticketNumber and revision = @revision";

            var result = await dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.FirstOrDefault();

        }
        public async Task<int> UpdateTicket(long number, int revision, DateTime closeDate, long stateId, string remarks, bool remotely)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@closeDate", closeDate);
            parameters.Add("@stateId", stateId);
            parameters.Add("@remarks", remarks);
            parameters.Add("@remotely", remotely);

            string command = @"UPDATE tickets
                             SET closeDate = @closeDate
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,remotely = @remotely
                            WHERE number = @number and revision = @revision";

            return await dataAccess.ExecuteAsync(command, parameters);
        }

    }
}
