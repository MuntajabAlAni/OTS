using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.MainForms
{
    public class MainRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<UserInfo> CheckUserNameAndPasswordAsync(string username, string password)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", username);
            dynamicParameters.Add("Password", password);
            string query = "SELECT * FROM Users where username like @UserName and password = @Password and State = 1";

            var result = await dataAccess.QueryAsync<UserInfo>(query, dynamicParameters);
            return result.FirstOrDefault();
        }
        public async Task<List<TicketsView>> GetTodaysTickets()
        {

            string query = @"SELECT t.number, t.openDate, t.closeDate, pn.phoneNumber, s.name as SoftwareName, e.displayName as UserName,
                                                c.name as CompanyName, t.problem, st.name state, t.revision, 
												Case t.IsIndexed when 1 then 'مرتبة'
												 else 'غير مرتبة'
												 end IsIndexed,
												 case t.isClosed when 1 then 'مغلقة' 
                                                 else 'غير مغلقة' end isClosed
												 FROM tickets t
                                                 left join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 left join softwares s on t.softwareId = s.id
                                                 left join Users e on t.UserId = e.id
                                                 left join companies c on t.companyId = c.id
                                                 left join states st on t.stateId = st.id 
												 WHERE CAST( openDate AS Date )  = CAST( GETDATE() AS Date )
												 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            return result.ToList();
        }
    }
}
