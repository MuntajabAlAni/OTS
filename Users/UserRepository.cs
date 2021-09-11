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

        public async Task<int> AddUser(string displayName, string userName, string password, bool state, string ip, string remarks)
        {
            DynamicParameters parameters = new DynamicParameters();
            Guid salt = Guid.NewGuid();
            Byte[] passwordHash = SystemConstants.SHA512(password + salt.ToString().ToUpper());
            parameters.Add("@displayName", displayName);
            parameters.Add("@userName", userName);
            parameters.Add("@password", passwordHash);
            parameters.Add("@state", state);
            parameters.Add("@ip", ip);
            parameters.Add("@remarks", remarks);
            parameters.Add("@Salt", salt);

            string command = @"INSERT INTO Users (DisplayName, UserName, Password, State, Ip, Remarks, Salt)
                                VALUES (@displayName,
                                        @userName,
                                        @password,
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
            string query = "select id, displayName from users";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<int> UpdateUser(long id, string displayName, string userName, string password, bool state, string ip, string remarks)
        {

            DynamicParameters parameters = new DynamicParameters();
            Guid salt = Guid.NewGuid();
            Byte[] passwordHash = SystemConstants.SHA512(password + salt.ToString().ToUpper());
            parameters.Add("@id", id);
            parameters.Add("@displayName", displayName);
            parameters.Add("@userName", userName);
            parameters.Add("@passwordHash", passwordHash);
            parameters.Add("@state", state);
            parameters.Add("@ip", ip);
            parameters.Add("@remarks", remarks);
            parameters.Add("@Salt", salt);


            string command = @"UPDATE Users SET 
                                displayName = @displayName,
                                userName = @userName,
                                password = @PasswordHash,
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
    }
}
