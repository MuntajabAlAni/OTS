using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Users
{
    public class UserRepository
    {
        private readonly DataAccess dataAccess = new DataAccess();

        public async Task<int> AddUser(UserInfo user)
        {

            user.Salt = Guid.NewGuid();
            user.PasswordHash = SystemConstants.SHA512(user.PasswordHash + user.Salt.ToString().ToUpper());
            var parameters = new DynamicParameters(user);

            string command = @"INSERT INTO Users (DisplayName, UserName, passwordHash, State, Ip, Remarks, Salt)
                                VALUES (@displayName,
                                        @userName,
                                        @passwordHash,
                                        @state,
                                        @ip,
                                        @remarks,
                                        @Salt)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<UserInfo> GetUserById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = @"SELECT * FROM Users WHERE ID = @ID";
            var result = await dataAccess.QueryAsync<UserInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<List<UserInfo>> GetAllUsers()
        {
            string query = "select id, displayName from users WHERE isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<int> UpdateUser(UserInfo user)
        {
            user.Salt = Guid.NewGuid();
            user.PasswordHash = SystemConstants.SHA512(user.PasswordHash + user.Salt.ToString().ToUpper());
            var parameters = new DynamicParameters(user);

            string command = @"UPDATE Users SET 
                                displayName = @displayName,
                                userName = @userName,
                                passwordHash = @PasswordHash,
                                state = @state,
                                ip = @ip,
                                remarks = @remarks,
                                salt = @Salt
                               WHERE Id = @id";
            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<long> GetLastAddedUserId()
        {
            string query = "SELECT TOP 1 id FROM Users Order by id DESC";

            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            UserInfo userInfo = result.FirstOrDefault();
            return userInfo.Id;

        }
        public async Task<UserInfo> GetUserByUserName(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userName", userName);

            string query = @"SELECT * FROM Users WHERE userName = @userName and isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<UserInfo> CheckUserNameAndPasswordAsync(UserInfo user)
        {
            UserInfo userInfo = await GetUserByUserName(user.UserName);
            if (userInfo is null) return null;

            user.PasswordHash = SystemConstants.SHA512(user.PasswordHash + userInfo.Salt.ToString().ToUpper());

            var dynamicParameters = new DynamicParameters(user);
            dynamicParameters.Add("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            string query = @"IF ABS(DATEDIFF(MINUTE, @date, GETDATE())) > 5
                             THROW 15101998,
                            '15101998 Check the Date difference between this pc and The server.',1;

                             ELSE
                             SELECT * FROM Users where username = @UserName and 
                             passwordHash = @passwordHash and State = 1 and isDeleted = 0
                             and ABS(DATEDIFF(MINUTE, @date, GETDATE())) < 5";

            var result = await dataAccess.QueryAsync<UserInfo>(query, dynamicParameters);
            return result.FirstOrDefault();
        }

    }
}
