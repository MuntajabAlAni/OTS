﻿using Dapper;
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
            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName, st.name state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
												 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where employeeId = @employeeId group by number) t2 on t.revision = t2.revision and t.number = t2.number
												 WHERE employeeId = @employeeId and closeDate is null
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
        public async Task<int> AddTicket(long number, int revision, long companyId, long phoneNumberId, long softwareId, long employeeId)
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
        public async Task<List<TicketsView>> GetUnclosedTicketsOnSelectedCompanyId(long companyId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            string query = @" SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                 c.name as CompanyName,st.name state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 left join states st on t.stateId = st.id
												 inner join (select number,max(revision) revision from tickets where employeeId = 6 group by number) t2 on t.revision = t2.revision and t.number = t2.number 
												 WHERE closeDate is null and t.companyId = @companyId
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
