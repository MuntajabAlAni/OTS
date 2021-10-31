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
        public DataAccess _dataAccess = new DataAccess();
        public async Task<List<TicketsView>> GetAllByUserId(long UserId)
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
												 WHERE t.UserId = @UserId and t.isClosed is null and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<string> GetLastNumber()
        {
            string query = "SELECT TOP 1 t.number from tickets t order by t.number DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            TicketsView ticketDetails = result.FirstOrDefault();
            if (ticketDetails == null) return "1";
            return (ticketDetails.Number + 1).ToString();
        }
// USERS WHERE STATE =1 and isDELETED = 0  Without admin and noor and batool
//todo: add id = 0 to all users.. companies.. states.. etc.
        public async Task<long> AddTicket(TicketInfo ticket)
        {
            var parameters = new DynamicParameters(ticket);
            string command = @"INSERT INTO tickets
           (number, phoneNumberId, softwareId, UserId, companyId, revision)
               VALUES
           (@number,
            @phoneNumberId,
            @softwareId,
            @UserId,
            @companyId,
            @revision);
			SELECT SCOPE_IDENTITY();";

            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<List<TicketsView>> GetUnclosedByCompanyId(long companyId)
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
												 WHERE isClosed = 0 and t.companyId = @companyId and t.isDeleted = 0
                                                 ORDER BY t.number,t.revision";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<TicketInfo> GetByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = "select * from tickets where number = @ticketNumber and revision = @revision and isDeleted = 0";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<TicketsView> GetDetailsByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = @"select t.id, t.number, t.revision, t.OpenDate, c.name CompanyName, pn.phoneNumber PhoneNumber,
                            s.name SoftwareName, u.displayName UserName, st.name State, t.problem, t.remarks, 
                            t.remotely remotelyView, t.isIndexed isIndexedView, t.isClosed isClosedView, ut.displayName TransferedTo
                             from tickets t
                             join companies c on c.id = t.companyId
                             join softwares s on s.id = t.softwareId
                             join users u on u.id = t.userId
                             left join states st on st.id = t.stateId
                             left join users ut on ut.id = t.transferedTo
                             join phoneNumbers pn on pn.id = t.phoneNumberId
                              where t.number = @ticketNumber and t.revision = @revision and t.isDeleted = 0";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> Update(long number, int revision, DateTime closeDate, long stateId, string remarks, string problem, int remotely, bool IsIndexed, bool closed, long transferedTo)
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

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<UserInfo> GetUserById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Users WHERE Id = @id AND isDeleted = 0";
            var result = await _dataAccess.QueryAsync<UserInfo>(query, parameters);
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
												 WHERE  t.number = @ticketNumber and t.revision = @revision and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<List<TicketsView>> GetOldUnClosedTicketsByUserIdOrCompanyId(
            long companyId, long userId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            parameters.Add("@fromDate", fromDate.ToString("yyyy-MM-dd 00:00:00.000"));
            parameters.Add("@userId", userId);
            parameters.Add("@toDate", toDate.ToString("yyyy-MM-dd 23:59:59.000"));

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, pn.CustomerName CustomerName,
                                                 s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, b.name as BranchName, t.problem, st.name state, t.remarks, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id
                                                 inner join branches b on c.branchId = b.id
												 inner join (select number,max(revision) revision from tickets group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 left join states st on t.stateId = st.id
												 WHERE IIF(@companyId = 0,0,t.CompanyId) = @companyId
												 and IIF(@userId = 0,0,t.UserId) = @userId
												 and t.openDate between @fromDate and @toDate
												 and (t.isClosed = 0 or t.isClosed is null)
                                                 and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<List<TicketsView>> GetOldTicketsByUserIdOrCompanyId(
            long companyId, long userId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            parameters.Add("@fromDate", fromDate.ToString("yyyy-MM-dd 00:00:00.000"));
            parameters.Add("@userId", userId);
            parameters.Add("@toDate", toDate.ToString("yyyy-MM-dd 23:59:59.000"));

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber,pn.CustomerName CustomerName,
                                                 s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, b.name as BranchName, t.problem, st.name state, t.remarks, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed, u.displayName as TransferedTo FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id
                                                 inner join branches b on c.branchId = b.id
												 left join states st on t.stateId = st.id
                                                 left join Users u on t.transferedTo = u.id
												 WHERE  IIF(@companyId = 0,0,t.CompanyId) = @companyId
												 and IIF(@userId = 0,0,t.UserId) = @userId
												 and t.openDate between @fromDate and @toDate
												 and t.isClosed = 1
                                                 and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task<List<TicketsView>> GetAllOldTicketsByUserIdOrCompanyId(
    long companyId, long userId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            parameters.Add("@fromDate", fromDate.ToString("yyyy-MM-dd 00:00:00.000"));
            parameters.Add("@userId", userId);
            parameters.Add("@toDate", toDate.ToString("yyyy-MM-dd 23:59:59.000"));

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber,pn.CustomerName CustomerName,
                                                 s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, b.name as BranchName, t.problem, st.name state, t.remarks, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexed,  u.displayName as TransferedTo FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id
                                                 inner join branches b on c.branchId = b.id
												 left join states st on t.stateId = st.id
                                                 left join Users u on t.transferedTo = u.id
												 WHERE  IIF(@companyId = 0,0,t.CompanyId) = @companyId
												 and IIF(@userId = 0,0,t.UserId) = @userId
												 and t.openDate between @fromDate and @toDate
                                                 and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, parameters);
            return result.ToList();
        }
        public async Task UpdateInsertTicket(TicketInfo ticket)
        {
            var updateParameters = new DynamicParameters();
            updateParameters.Add("@number", ticket.Number);
            updateParameters.Add("@revision", ticket.Revision);
            updateParameters.Add("@closeDate", ticket.CloseDate);
            updateParameters.Add("@stateId", ticket.StateId);
            updateParameters.Add("@remarks", ticket.Remarks);
            updateParameters.Add("@problem", ticket.Problem);
            updateParameters.Add("@remotely", ticket.Remotely);
            updateParameters.Add("@IsIndexed", ticket.IsIndexed);
            updateParameters.Add("@closed", ticket.IsClosed);
            updateParameters.Add("@transferedTo", ticket.TransferedTo);

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
                await connection.OpenAsync();
                using (var trans = connection.BeginTransaction())
                {
                    int recordsUpdated = await connection.ExecuteAsync(updateCommand, updateParameters, trans);

                    var insertParameters = new DynamicParameters();
                    insertParameters.Add("@number", ticket.Number);
                    insertParameters.Add("@revision", ticket.Revision + 1);
                    insertParameters.Add("@companyId", ticket.CompanyId);
                    insertParameters.Add("@phoneNumberId", ticket.PhoneNumberId);
                    insertParameters.Add("@softwareId", ticket.SoftwareId);
                    insertParameters.Add("@UserId", ticket.TransferedTo);

                    string insertCommand = @"INSERT INTO tickets
                            (number, phoneNumberId, softwareId, UserId, companyId, revision)
                              VALUES
                           (@number,
                            @phoneNumberId,
                            @softwareId,
                            @UserId,
                            @companyId,
                            @revision)";

                    try
                    {

                        await connection.ExecuteAsync(insertCommand, insertParameters, transaction: trans);
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
            string problem, int remotely, bool IsIndexed, bool closed, long transferedTo, long phoneNumberId, long softwareId, long userId)
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
            parameters.Add("@phoneNumberId", phoneNumberId);
            parameters.Add("@softwareId", softwareId);
            parameters.Add("@userId", userId);

            string command = @"UPDATE tickets
                             SET phoneNumberId = @phoneNumberId
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

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task Delete(TicketInfo ticket)
        {
            var parameters = new DynamicParameters(ticket);
            string command = @"UPDATE Tickets SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }

        public async Task<List<TicketsView>> GetTodaysTickets()
        {

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                c.name as CompanyName, t.problem, st.name state, t.revision, 
												Case t.IsIndexed when 1 then 'مرتبة'
												 else 'غير مرتبة'
												 end IsIndexed,
												 case t.isClosed when 1 then 'مغلقة' 
                                                 else 'غير مغلقة' end isClosed, u.displayName as TransferedTo
												 FROM tickets t
                                                 left join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 left join softwares s on t.softwareId = s.id
                                                 left join Users e on t.UserId = e.id
                                                 left join companies c on t.companyId = c.id
												 left join Users u on t.transferedTo = u.id
                                                 left join states st on t.stateId = st.id 
												 WHERE openDate between CAST( GETDATE() AS Date )  and CAST( GETDATE() AS DateTime )
                                                 and t.isDeleted = 0
												 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            return result.ToList();
        }

    }
}