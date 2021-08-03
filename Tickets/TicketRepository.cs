using Dapper;
using OTS.Ticketing.Software.DatabaseConnection;
using OTS.Ticketing.Software.Models;
using System;
using System.Collections.Generic;
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
                                                c.name as CompanyName, 
                                                case when t.state = 0 then 'لم يتم الحل'
                                                when t.state = 1 then 'تم الحل'
                                                when t.state = 2 then 'مؤجلة'
                                                when t.state = 3 then 'تم التحويل'
                                                end state, t.revision FROM tickets t
                                                 inner join phoneNumbers pn on t.number = pn.id
                                                 inner join softwares s on t.softwareId = s.id
                                                 inner join employees e on t.employeeId = e.id
                                                 inner join companies c on t.companyId = c.id ORDER BY t.number", new DynamicParameters()).ToList();
        }
    }
}
