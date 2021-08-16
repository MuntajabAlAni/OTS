using Dapper;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Users;
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
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<List<TicketsView>> GetAllTicketsByUserId(long UserId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", UserId);
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where UserId = @UserId group by number) t2 on t.revision = t2.revision and t.number = t2.number
												 WHERE UserId = @UserId and (isClosed = 0 or isClosed is null)
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<string> GetLastTicketNumber()
        {
            string query = "SELECT TOP 1 t.number from tickets t order by t.number DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            TicketsView ticketDetails = result.FirstOrDefault();
            if (ticketDetails == null) return "1";
            return (ticketDetails.Number + 1).ToString();
        }
        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            string query = "SELECT * FROM Companies";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new CompanyInfo { Id = 0, Name = "الإختيار عن طريق رقم الهاتف" }));
            return list;
        }
        public async Task<List<SoftwareInfo>> GetAllSoftwares()
        {
            string query = "SELECT * FROM Softwares";
            var result = await dataAccess.QueryAsync<SoftwareInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new SoftwareInfo { Id = 0, Name = "" }));
            return list;
        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            string query = "SELECT * FROM Users where username not in ('admin','Noor') and state = 1";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new UserInfo { Id = 0, DisplayName = "" }));
            return list;
        }
        public async Task<List<StateInfo>> GetAllStates()
        {
            string query = "SELECT * FROM States";
            var result = await dataAccess.QueryAsync<StateInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new StateInfo { Id = 0, Name = "" }));
            return list;
        }
        public async Task<List<PhoneNumberInfo>> GetPhoneNumbersOnSelectedCompanyId(long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = "SELECT * FROM PhoneNumbers WHERE IIF(@companyId = 0,0,companyId) = @companyId";
            var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            var list = result.ToList();
            list.Insert(0, (new PhoneNumberInfo { Id = 0, PhoneNumber = "" }));
            return list;
        }
        public async Task<int> AddTicket(long number, int revision, long companyId, long phoneNumberId, long softwareId, long UserId)
        {
            DynamicParameters parameters1 = new DynamicParameters();
            parameters1.Add("@number", number);
            parameters1.Add("@revision", revision);
            parameters1.Add("@companyId", companyId);
            parameters1.Add("@phoneNumberId", phoneNumberId);
            parameters1.Add("@softwareId", softwareId);
            parameters1.Add("@UserId", UserId);

            string command1 = @"INSERT INTO tickets
           (number, phoneNumberId, softwareId, UserId, companyId, revision)
               VALUES
           (@number,
            @phoneNumberId,
            @softwareId,
            @UserId,
            @companyId,
            @revision)";

            return await dataAccess.ExecuteAsync(command1, parameters1);
        }
        public async Task<List<TicketsView>> GetUnclosedTicketsOnSelectedCompanyId(long companyId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = @" SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 WHERE isClosed = 0 and t.companyId = @companyId
                                                 ORDER BY t.number,t.revision";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<TicketInfo> GetTicketByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = "select * from tickets where number = @ticketNumber and revision = @revision";

            var result = await dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdateTicket(long number, int revision, DateTime closeDate, long stateId, string remarks, string problem, int remotely, bool arrangement, bool closed)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@closeDate", closeDate);
            parameters.Add("@stateId", stateId);
            parameters.Add("@remarks", remarks);
            parameters.Add("@problem", problem);
            parameters.Add("@remotely", remotely);
            parameters.Add("@arrangement", arrangement);
            parameters.Add("@closed", closed);

            string command = @"UPDATE tickets
                             SET closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,arrangement = @arrangement
                           ,isClosed = @closed
                            WHERE number = @number and revision = @revision";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<UserInfo> GetUserById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Users WHERE Id = @id";
            var result = await dataAccess.QueryAsync<UserInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<TicketsView> GetTicketDetailsByByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, t.Remarks,
												 Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosed
												  FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 WHERE  t.number = @ticketNumber and t.revision = @revision
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.FirstOrDefault();
        }
    }
}
