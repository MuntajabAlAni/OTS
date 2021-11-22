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
        public async Task<List<TicketInfo>> GetUnClosedByUserId(long UserId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", UserId);
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name stateName, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexedView FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where UserId = @UserId group by number) t2 on t.revision = t2.revision and t.number = t2.number
												 WHERE t.UserId = @UserId and t.isClosed = 0 and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.ToList();
        }
        public async Task<string> GetLastNumber()
        {
            string query = "SELECT TOP 1 t.number from tickets t order by t.number DESC";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, new DynamicParameters());
            TicketInfo ticketDetails = result.FirstOrDefault();
            if (ticketDetails == null) return "1";
            return (ticketDetails.Number + 1).ToString();
        }
        // USERS WHERE STATE =1 and isDELETED = 0  Without admin and noor and batool
        //todo: add id = 0 to all users.. companies.. states.. etc.
        public async Task<long> Add(TicketInfo ticket)
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
        public async Task<List<TicketInfo>> GetUnclosedByCompanyId(long companyId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = @" SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name stateName, t.revision, Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexedView, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosedView FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 WHERE isClosed = 0 and t.companyId = @companyId and t.isDeleted = 0
                                                 ORDER BY t.number,t.revision";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
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
        public async Task<TicketInfo> GetViewByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Number", ticketNumber);
            parameters.Add("@revision", revision);
            string query = @"select t.id, t.number, t.revision, t.OpenDate, c.name CompanyName, pn.phoneNumber PhoneNumber,
                            s.name SoftwareName, u.displayName UserName, st.name StateName, t.problem, t.remarks, 
                            t.remotely remotely, t.isIndexed isIndexed, t.isClosed isClosed, ut.displayName TransferedToName
                             from tickets t
                             join companies c on c.id = t.companyId
                             join softwares s on s.id = t.softwareId
                             join users u on u.id = t.userId
                             left join states st on st.id = t.stateId
                             left join users ut on ut.id = t.transferedTo
                             join phoneNumbers pn on pn.id = t.phoneNumberId
                              where t.number = @Number and t.revision = @revision and t.isDeleted = 0";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task Answer(TicketInfo ticket)
        {
            var parameters = new DynamicParameters(ticket);

            string command = @"UPDATE tickets
                             SET closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,IsIndexed = @IsIndexed
                           ,isClosed = @isClosed
                           ,transferedTo = @transferedTo
                            WHERE number = @Number and revision = @revision";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<TicketInfo> GetDetailsByNumberAndRevision(long ticketNumber, long revision)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ticketNumber", ticketNumber);
            parameters.Add("@revision", revision);
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                 c.name as CompanyName, t.problem, st.name stateName, t.revision, t.Remarks,
												 Case when t.IsIndexed = 1 then 'مرتبة'
												 when t.IsIndexed = 0 then 'غير مرتبة'
												 end IsIndexedView, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosedView
												  FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join Users e on t.UserId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 WHERE  t.number = @ticketNumber and t.revision = @revision and t.isDeleted = 0
                                                 ORDER BY t.number DESC,t.revision DESC";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<List<TicketInfo>> GetByRequest(OldTicketRequest request)
        {
            request.ToDate = request.ToDate.AddDays(1);
            var parameters = new DynamicParameters(request);

            string query = @"EXEC  DisplayTicketsReport
		                    @fromdate = @FromDate,
		                    @toDate = @ToDate,
		                    @companyId = @CompanyId,
		                    @userId = @UserId,
		                    @isClosed = @IsClosed";

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, parameters);
            return result.ToList();
        }
        public async Task UpdateInsertTicket(TicketInfo ticket)
        {
            var updateParameters = new DynamicParameters(ticket);
            string updateCommand = @"UPDATE tickets
                             SET closeDate = CASE WHEN closeDate is null then @closeDate else closeDate end
                           ,stateId = @stateId
                           ,remarks = @remarks
                           ,problem = @problem
                           ,remotely = @remotely
                           ,IsIndexed = @IsIndexed
                           ,isClosed = @isClosed
                           ,transferedTo = @transferedTo
                            WHERE number = @number and revision = @revision";

            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                await connection.OpenAsync();
                using (var trans = connection.BeginTransaction())
                {
                    int recordsUpdated = await connection.ExecuteAsync(updateCommand, updateParameters, trans);
                    ticket.Revision += 1;
                    var insertParameters = new DynamicParameters(ticket);

                    string insertCommand = @"INSERT INTO tickets
                            (number, phoneNumberId, softwareId, UserId, companyId, revision)
                              VALUES
                           (@number,
                            @phoneNumberId,
                            @softwareId,
                            @TransferedTo,
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
        public async Task<int> Update(TicketInfo ticket)
        {
            var parameters = new DynamicParameters(ticket);
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
                           ,isClosed = @isClosed
                           ,transferedTo = @transferedTo
                            WHERE number = @Number and revision = @revision";

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
        public async Task<List<TicketInfo>> GetTodaysTickets()
        {
            string query = @"SELECT t.number, t.openDate, t.closeDate, t.companyId, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                c.name as CompanyName, t.problem, st.name stateName, t.revision, 
												Case t.IsIndexed when 1 then 'مرتبة'
												 else 'غير مرتبة'
												 end IsIndexedView,
												 case t.isClosed when 1 then 'مغلقة' 
                                                 else 'غير مغلقة' end isClosedView, u.displayName as TransferedToName
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

            var result = await _dataAccess.QueryAsync<TicketInfo>(query, new DynamicParameters());
            return result.ToList();
        }
    }
}