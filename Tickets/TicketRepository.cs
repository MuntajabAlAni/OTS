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
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public class TicketRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<List<TicketsView>> GetAllTicketsByEmployeeId(long employeeId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@employeeId", employeeId);
                string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where employeeId = @employeeId group by number) t2 on t.revision = t2.revision and t.number = t2.number
												 WHERE employeeId = @employeeId and (isClosed = 0 or isClosed is null)
                                                 ORDER BY t.number DESC,t.revision DESC";

                var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllTicketsByEmployeeId");
                return default;
            }

        }
        public async Task<string> GetLastTicketNumber()
        {
            try
            {
                string query = "SELECT TOP 1 t.number from tickets t order by t.number DESC";

                var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
                TicketsView ticketDetails = result.FirstOrDefault();
                return (ticketDetails.Number + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetLastTicketNumber");
                return default;
            }

        }
        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            try
            {
                string query = "SELECT * FROM Companies";
                var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
                var list = result.ToList();
                list.Insert(0, (new CompanyInfo { Id = 0, Name = "الإختيار عن طريق رقم الهاتف" }));
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllCompanies");
                return default;
            }

        }
        public async Task<List<SoftwareInfo>> GetAllSoftwares()
        {
            try
            {
                string query = "SELECT * FROM Softwares";
                var result = await dataAccess.QueryAsync<SoftwareInfo>(query, new DynamicParameters());
                var list = result.ToList();
                list.Insert(0, (new SoftwareInfo { Id = 0, Name = "" }));
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllSoftwares");
                return default;
            }

        }
        public async Task<List<EmployeeInfo>> GetAllEmployees()
        {
            try
            {
                string query = "SELECT * FROM Employees";
                var result = await dataAccess.QueryAsync<EmployeeInfo>(query, new DynamicParameters());
                var list = result.ToList();
                list.Insert(0, (new EmployeeInfo { Id = 0, DisplayName = "" }));
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllEmployees");
                return default;
            }

        }
        public async Task<List<StateInfo>> GetAllStates()
        {
            try
            {
                string query = "SELECT * FROM States";
                var result = await dataAccess.QueryAsync<StateInfo>(query, new DynamicParameters());
                var list = result.ToList();
                list.Insert(0, (new StateInfo { Id = 0, Name = "" }));
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllStates");
                return default;
            }

        }
        public async Task<List<PhoneNumberInfo>> GetPhoneNumbersOnSelectedCompanyId(long companyId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyId", companyId);
                string query = "SELECT * FROM PhoneNumbers WHERE IIF(@companyId = 0,0,companyId) = @companyId";
                var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
                var list = result.ToList();
                list.Insert(0, (new PhoneNumberInfo { Id = 0, PhoneNumber = "" }));
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetPhoneNumbersOnSelectedCompanyId");
                return default;
            }

        }
        public async Task<int> AddTicket(long number, int revision, long companyId, long phoneNumberId, long softwareId, long employeeId)
        {
            try
            {
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

                return await dataAccess.ExecuteAsync(command1, parameters1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddTicket");
                return default;
            }

        }
        public async Task<List<TicketsView>> GetUnclosedTicketsOnSelectedCompanyId(long companyId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@companyId", companyId);
                string query = @" SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosed FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 WHERE isClosed = 0 and t.companyId = @companyId
                                                 ORDER BY t.number,t.revision";

                var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetUnclosedTicketsOnSelectedCompanyId");
                return default;
            }

        }
        public async Task<TicketInfo> GetTicketByNumberAndRevision(long ticketNumber, long revision)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ticketNumber", ticketNumber);
                parameters.Add("@revision", revision);
                string query = "select * from tickets where number = @ticketNumber and revision = @revision";

                var result = await dataAccess.QueryAsync<TicketInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetTicketByNumberAndRevision");
                return default;
            }


        }
        public async Task<int> UpdateTicket(long number, int revision, DateTime closeDate, long stateId, string remarks, string problem, int remotely, bool arrangement, bool closed)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "UpdateTicket");
                return default;
            }

        }
        public async Task<EmployeeInfo> GetEmployeeById(long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                string query = "SELECT * FROM Employees WHERE Id = @id";
                var result = await dataAccess.QueryAsync<EmployeeInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetEmployeeById");
                return default;
            }

        }
        public async Task<TicketsView> GetTicketDetailsByByNumberAndRevision(long ticketNumber, long revision)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ticketNumber", ticketNumber);
                parameters.Add("@revision", revision);
                string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName, t.problem, st.name state, t.revision, t.Remarks,
												 Case when t.arrangement = 1 then 'مرتبة'
												 when t.arrangement = 0 then 'غير مرتبة'
												 end arrangement, case when t.isClosed = 1 then 'مغلقة' 
                                                 when t.isClosed = 0 then 'غير مغلقة' end isClosed
												  FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 WHERE  t.number = @ticketNumber and t.revision = @revision
                                                 ORDER BY t.number DESC,t.revision DESC";

                var result = await dataAccess.QueryAsync<TicketsView>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetTicketDetailsByByNumberAndRevision");
                return default;
            }

        }
    }
}
