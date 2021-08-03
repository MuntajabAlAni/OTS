using Dapper;
using OTS.Ticketing.Software.DatabaseConnection;
using OTS.Ticketing.Software.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Software.Tickets
{
    public class TicketRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public List<TicketDetails> GetAllTickets()
        {
            return dataAccess.Query<TicketDetails>(@"SELECT TOP 5 t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as EmployeeName,
                                                c.name as CompanyName,st.name state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.number = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id 
                                                 inner join states st on t.stateId = st.id ORDER BY t.number,t.revision", new DynamicParameters()).ToList();
        }

        public string GetLastTicketNumber()
        {
            List<TicketDetails> ticketDetails = dataAccess.Query<TicketDetails>("SELECT TOP 1 t.number from tickets t order by t.number DESC", new DynamicParameters()).ToList();
            foreach (TicketDetails item in ticketDetails)
            {
                return (item.Number + 1).ToString();
            }
            return "0";
        }

        public List<CompanyInfo> GetAllCompanies()
        {
            return dataAccess.Query<CompanyInfo>("SELECT * FROM Companies", new DynamicParameters()).ToList();
        }

        public List<SoftwareInfo> GetAllSoftwares()
        {
            return dataAccess.Query<SoftwareInfo>("SELECT * FROM Softwares", new DynamicParameters()).ToList();
        }
        public List<EmployeeInfo> GetAllEmployees()
        {
            return dataAccess.Query<EmployeeInfo>("SELECT * FROM Employees", new DynamicParameters()).ToList();
        }
        public List<StateInfo> GetAllStates()
        {
            return dataAccess.Query<StateInfo>("SELECT * FROM States", new DynamicParameters()).ToList();
        }
        public List<PhoneNumberInfo> GetPhoneNumberOnSelectedCompanyId(long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyId", companyId);
            return dataAccess.Query<PhoneNumberInfo>("SELECT * FROM PhoneNumbers WHERE companyId = @companyId", parameters).ToList();
        }

        public int AddTicket(long number,int revision,long companyId, long phoneNumberId, long softwareId, long employeeId)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@revision", revision);
            parameters.Add("@companyId", companyId);
            parameters.Add("@phoneNumberId", phoneNumberId);
            parameters.Add("@softwareId", softwareId);
            parameters.Add("@employeeId", employeeId);
            return dataAccess.Execute($@"INSERT INTO tickets
           (number, openDate, closeDate, phoneNumberId, softwareId, employeeId, companyId, stateId, remarks, revision, remotely)
     VALUES
           (@number,
            '{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}',
            '{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}',
            @phoneNumberId,
            @softwareId,
            @employeeId,
            @companyId,
            {1},
            null,
            @revision,
            {1})", parameters);
        }

    }
}
