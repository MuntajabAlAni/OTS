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
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where UserId = @UserId group by number) t2 on t.revision = t2.revision and t.number = t2.number
												 WHERE UserId = @UserId and isClosed is null
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
            list.Insert(0, (new CompanyInfo { Id = 0, Name = "إختيار عن طريق رقم الهاتف" }));
            return list;
        }
        public async Task<List<SoftwareInfo>> GetAllSoftwares()
        {
            string query = "SELECT * FROM Softwares";
            var result = await dataAccess.QueryAsync<SoftwareInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new SoftwareInfo { Id = 0, Name = "الكل" }));
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
        public async Task<int> AddTicket(long number, int revision, long companyId, long phoneNumberId, long softwareId, long userId)
        {
            DynamicParameters parameters1 = new DynamicParameters();
            parameters1.Add("@number", number);
            parameters1.Add("@revision", revision);
            parameters1.Add("@companyId", companyId);
            parameters1.Add("@phoneNumberId", phoneNumberId);
            parameters1.Add("@softwareId", softwareId);
            parameters1.Add("@userId", userId);

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
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed, case when t.isClosed = 1 then 'مغلقة' 
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
        public async Task<int> UpdateTicket(long number, int revision, DateTime closeDate, long stateId, string remarks, string problem, int remotely, bool IsIndexed, bool closed, long transferedTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@closeDate", closeDate);
            parameters.Add("@stateId", stateId);
            parameters.Add("@remarks", remarks);
            parameters.Add("@problem", problem);
            parameters.Add("@remotely", remotely);
            parameters.Add("@IsIndexed", IsIndexed);
            parameters.Add("@closed", closed);
            parameters.Add("@transferedTo", transferedTo);

            string command = @"UPDATE tickets
                             SET closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,IsIndexed = @IsIndexed
                           ,isClosed = @closed
                           ,transferedTo = @transferedTo
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
												 Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed, case when t.isClosed = 1 then 'مغلقة' 
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
        public async Task<List<TicketsView>> GetOldUnClosedTicketsByUserIdOrCompanyId(
            long companyId, long userId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            parameters.Add("@userId", userId);
            parameters.Add("@fromDate", fromDate);
            parameters.Add("@toDate", toDate);

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 inner join (select number,max(revision) revision from tickets group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 left join states st on t.stateId = st.id
												 WHERE IIF(@userId = 0,0,t.UserId) = @userId 
												 and IIF(@companyId = 0,0,t.CompanyId) = @companyId
												 and t.openDate between @fromDate and @toDate
												 and (isClosed = 0 or isClosed is null)
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<List<TicketsView>> GetOldTicketsByUserIdOrCompanyId(
            long companyId, long userId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            parameters.Add("@userId", userId);
            parameters.Add("@fromDate", fromDate);
            parameters.Add("@toDate", toDate);

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 WHERE IIF(@userId = 0,0,t.UserId) = @userId 
												 and IIF(@companyId = 0,0,t.CompanyId) = @companyId
												 and t.openDate between @fromDate and @toDate
												 and isClosed = 1
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<List<CompanyView>> GetCompaniesOnUserId(long userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);

            string query = @"Select distinct c.id, c.name 
                           from companies c
                           left join tickets t on t.companyId = c.id
                           where IIF(@userId = 0,0,t.userId) = @userId";

            var result = await dataAccess.QueryAsync<CompanyView>(query, parameters);
            return result.ToList();
        }
        public async void UpdateInsertTicket(long number, int revision, DateTime closeDate, long stateId, string remarks, string problem, int remotely, bool IsIndexed, bool closed, long transferedTo)
        {
            var updateParameters = new DynamicParameters();
            updateParameters.Add("@number", number);
            updateParameters.Add("@revision", revision);
            updateParameters.Add("@closeDate", closeDate);
            updateParameters.Add("@stateId", stateId);
            updateParameters.Add("@remarks", remarks);
            updateParameters.Add("@problem", problem);
            updateParameters.Add("@remotely", remotely);
            updateParameters.Add("@IsIndexed", IsIndexed);
            updateParameters.Add("@closed", closed);
            updateParameters.Add("@transferedTo", transferedTo);

            string updateCommand = @"UPDATE tickets
                             SET closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,IsIndexed = @IsIndexed
                           ,isClosed = @closed
                           ,transferedTo = @transferedTo
                            WHERE number = @number and revision = @revision";

            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    int recordsUpdated = await connection.ExecuteAsync(updateCommand, updateParameters, trans);
                    try
                    {
                        TicketInfo ticketInfo = await GetTicketByNumberAndRevision(number, revision);

                        var insertParameters = new DynamicParameters();
                        insertParameters.Add("@number", number);
                        insertParameters.Add("@revision", revision + 1);
                        insertParameters.Add("@companyId", ticketInfo.CompanyId);
                        insertParameters.Add("@phoneNumberId", ticketInfo.PhoneNumberId);
                        insertParameters.Add("@softwareId", ticketInfo.SoftwareId);
                        insertParameters.Add("@UserId", ticketInfo.TransferedTo);

                        string insertCommand = @"INSERT INTO tickets
                            (number, phoneNumberId, softwareId, UserId, companyId, revision)
                              VALUES
                           (@number,
                            @phoneNumberId,
                            @softwareId,
                            @UserId,
                            @companyId,
                            @revision)";

                        await connection.ExecuteAsync(insertCommand, insertParameters , transaction: trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        trans.Rollback();
                    }
                }
            }
        }
        public async Task<int> UpdateEntireTicket(long number, int revision, DateTime closeDate, long stateId, string remarks,
            string problem, int remotely, bool IsIndexed, bool closed, long transferedTo, long companyId, long phoneNumberId, long softwareId, long userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@closeDate", closeDate);
            parameters.Add("@stateId", stateId);
            parameters.Add("@remarks", remarks);
            parameters.Add("@problem", problem);
            parameters.Add("@remotely", remotely);
            parameters.Add("@IsIndexed", IsIndexed);
            parameters.Add("@closed", closed);
            parameters.Add("@transferedTo", transferedTo);
            parameters.Add("@companyId", companyId);
            parameters.Add("@phoneNumberId", phoneNumberId);
            parameters.Add("@softwareId", softwareId);
            parameters.Add("@userId", userId);

            string command = @"UPDATE tickets
                             SET companyId = @companyId
                           ,phoneNumberId = @phoneNumberId
                           ,softwareId = @softwareId
                           ,userId = @userId
                           ,closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,IsIndexed = @IsIndexed
                           ,isClosed = @closed
                           ,transferedTo = @transferedTo
                            WHERE number = @number and revision = @revision";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
