using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Users
{
    public class UserRepository
    {
        private readonly DataAccess dataAccess = new DataAccess();

        public async Task<int> AddUser(UserInfo user)
        {

            user.Salt = Guid.NewGuid();
            user.Password = SystemConstants.SHA512(user.Password + user.Salt.ToString().ToUpper());
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
            user.Password = SystemConstants.SHA512(user.Password + user.Salt.ToString().ToUpper());
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




        public async Task<List<UserInfo>> GetAllUsersFROMHOME()
        {
            string query = "SELECT * FROM Users where state = 1 and isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            var list = result.ToList();
            return list;
        }
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
            string passwordHash = SystemConstants.SHA512(password + userInfo.Salt.ToString().ToUpper());
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserName", username);
            dynamicParameters.Add("passwordHash", passwordHash);

            //todo: STORED PROCEDURE .. RECODE DATE DATEDIFF DateTime.Now

            string query = @"SELECT * FROM Users where username = @UserName and 
                             passwordHash = @passwordHash and State = 1 and isDeleted = 0";

            var result = await dataAccess.QueryAsync<UserInfo>(query, dynamicParameters);
            return result.FirstOrDefault();
        }

    }
}
