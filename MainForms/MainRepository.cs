using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.UsersRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.MainForms
{
    public class MainRepository
    {
        public DataAccess _dataAccess = new DataAccess();
        public async Task InitializeUserSession(SessionInfo session)
        {
            var parameters = new DynamicParameters(session);

            string command = @"IF EXISTS (SELECT * FROM sessions WHERE userId = @userId)
                               BEGIN
                                UPDATE Sessions SET number = @number, sessionId = @sessionId, isOnline = @isOnline where userId = @userId;
                               END
                               ELSE
                               BEGIN
                                INSERT INTO sessions (userId, sessionId, number, IsOnline)
                                values (@userId, @sessionId, @number, @isOnline);
                               END";

            await _dataAccess.ExecuteAsync(command, parameters);

        }
        public async Task UpdateIsOnlineByUserId(SessionInfo session)
        {
            var parameters = new DynamicParameters(session);

            string command = "UPDATE Sessions SET isOnline = @isOnline where userId = @userId";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> BackupDatabase(string path)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@path", path);

            string command = " BACKUP DATABASE OTS_Ticketing_Software TO DISK= @path ";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> RestoreDatabase(string path)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@path", path);

            string command = @" USE master;
                                ALTER DATABASE OTS_Ticketing_Software SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                RESTORE DATABASE OTS_Ticketing_Software FROM DISK= @path with REPLACE, RECOVERY, STATS = 10;
                                ALTER DATABASE OTS_Ticketing_Software SET MULTI_USER;";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<int> UpdateSession(SessionInfo session)
        {
            var parameters = new DynamicParameters(session);

            string command = @"UPDATE sessions SET 
                                 lastEvent = @lastEvent,
                                 computerName = @computerName,
			   	                 lastUpdateDate = SYSDATETIME()
					             WHERE userId = @userId and sessionId = @sessionId;

                              UPDATE Sessions SET 
                              lastEvent = 14,
                              isOnline = 0,
                              Number = ''
                              WHERE
                              ABS(DATEDIFF(MINUTE,SYSDATETIME(),(lastUpdateDate))) > 4";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<SessionView>> GetSessions()
        {
            string query = @"SELECT s.id, s.userId ,u.displayName ,e.eventName ,s.computerName ,s.lastUpdateDate ,s.isOnline ,s.number
                             FROM Sessions s with (nolock)
                             join users u on u.id = s.userId
                             left join events e on e.id = s.lastEvent
                             Where u.userName not in ('admin','Noor','Batool')";
            var result = await _dataAccess.QueryAsync<SessionView>(query);
            return result.ToList();
        }
        public async Task<SettingsInfo> GetSettings()
        {
            string query = @"SELECT * FROM Settings";
            var result = await _dataAccess.QueryAsync<SettingsInfo>(query);
            return result.FirstOrDefault();
        }
        public async Task<List<RoleInfo>> GetUserRoles(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT UserId, RoleId FROM UsersRoles WHERE UserId = @id";
            var result = await _dataAccess.QueryAsync<RoleInfo>(query, parameters);

            return result.ToList();
        }
    }
}
