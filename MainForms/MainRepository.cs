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
        public async Task<UserInfo> GetUserByUserName(string userName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userName", userName);

            string query = @"SELECT * FROM Users WHERE userName = @userName and isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<UserInfo> CheckUserNameAndPasswordAsync(string username, string password)
        {
            UserInfo userInfo = await GetUserByUserName(username);
            if (userInfo is null) return null;
            Byte[] passwordHash = SystemConstants.SHA512(password + userInfo.Salt.ToString().ToUpper());
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", username);
            dynamicParameters.Add("Password", passwordHash);

            string query = @"SELECT * FROM Users where username = @UserName and 
                             password = @password and State = 1 and isDeleted = 0";

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
                                                 else 'غير مغلقة' end isClosed, k.displayName TransferedTo
												 FROM tickets t
                                                 left join phoneNumbers pn on t.phoneNumberId = pn.id
                                                 left join softwares s on t.softwareId = s.id
                                                 left join Users e on t.UserId = e.id
                                                 left join companies c on t.companyId = c.id
												 left join (select u.id, u.displayName from users u inner join tickets t on t.transferedTo = u.id) k on t.transferedTo = k.id
                                                 left join states st on t.stateId = st.id 
												 WHERE openDate between CAST( GETDATE() AS Date )  and CAST( GETDATE() AS DateTime )
                                                 and t.isDeleted = 0
												 ORDER BY t.number DESC,t.revision DESC";

            var result = await dataAccess.QueryAsync<TicketsView>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            string query = "SELECT * FROM Users where state = 1 and isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            var list = result.ToList();
            return list;
        }
        public async Task<int> UpdateUserNumberByUserName(string number, string userName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@userName", userName);

            string command = "UPDATE Users SET number = @number, isOnline = 1 where userName = @userName";

            return await dataAccess.ExecuteAsync(command, parameters);

        }
        public async Task<int> UpdateIsOnlineByUserId(bool isOnline, long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@isOnline", isOnline);
            parameters.Add("@id", id);

            string command = "UPDATE Users SET isOnline = @isOnline where id = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
