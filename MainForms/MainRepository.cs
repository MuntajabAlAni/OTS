using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.MainForms
{
    public class MainRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<int> UpdateSessionInfoByUserId(string number, Guid sessionId, long userId, bool isOnline)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@number", number);
            parameters.Add("@sessionId", sessionId);
            parameters.Add("@userId", userId);
            parameters.Add("@isOnline", isOnline);

            string command = @"IF EXISTS (SELECT * FROM sessions WHERE userId = @userId)
                               BEGIN
                                UPDATE Sessions SET number = @number, sessionId = @sessionId, isOnline = @isOnline where userId = @userId;
                               END
                               ELSE
                               BEGIN
                                INSERT INTO sessions (userId, sessionId, number) values (@userId, @sessionId, @number);
                               END";

            return await dataAccess.ExecuteAsync(command, parameters);

        }
        public async Task<int> UpdateIsOnlineByUserId(bool isOnline, long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@isOnline", isOnline);
            parameters.Add("@id", id);

            string command = "UPDATE Sessions SET isOnline = @isOnline where userId = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> BackupDatabase(string path)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@path", path);

            string command = " BACKUP DATABASE OTS_Ticketing_Software TO DISK= @path ";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> RestoreDatabase(string path)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@path", path);

            string command = @" USE master;
                                ALTER DATABASE OTS_Ticketing_Software SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                RESTORE DATABASE OTS_Ticketing_Software FROM DISK= @path with REPLACE, RECOVERY, STATS = 10;
                                ALTER DATABASE OTS_Ticketing_Software SET MULTI_USER;";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> UpdateSessionByUserId(long id, int eventType, string computerName, Guid sessionId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userId", id);
            parameters.Add("@eventType", eventType);
            parameters.Add("@computerName", computerName);
            parameters.Add("@sessionId", sessionId);

            string command = @"IF EXISTS (SELECT * FROM sessions WHERE userId = @userId)
                                BEGIN
                                 UPDATE sessions SET 
                                 lastEvent = @eventType,
                                 computerName = @computerName,
			   	                 lastUpdateDate = SYSDATETIME(),
                                 isOnline = @isOnline,
                                 number = @number,
                                 sessionId = @sessionId
					             WHERE userId = @userId and sessionId = @sessionId;
                                END
                               ELSE
                                BEGIN
                                 INSERT INTO sessions (userId, sessionId, number) values (@userId, @sessionId, @number);
                                END";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<SessionView>> GetSessions()
        {
            string query = @"SELECT s.id, s.userId ,u.displayName ,e.eventName ,s.computerName ,s.lastUpdateDate ,s.isOnline ,s.number
                             FROM Sessions s 
                             join users u on u.id = s.userId
                             left join events e on e.id = s.lastEvent
                             Where u.userName not in ('admin','Noor')";
            var result = await dataAccess.QueryAsync<SessionView>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<SettingsInfo> GetSettings()
        {
            string query = @"SELECT * FROM Settings";
            var result = await dataAccess.QueryAsync<SettingsInfo>(query, new DynamicParameters());
            return result.FirstOrDefault();
        }
    }
}
