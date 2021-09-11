using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.Utils
{
    public static class ActivityLogUtility
    {
        private static readonly DataAccess _dataAccess = new DataAccess();

        public static async Task<int> ActivityLog(Enums.Activities activityType, string details, long affectedId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", SystemConstants.loggedInUserId);
            parameters.Add("@date", DateTime.Now);
            parameters.Add("@type", (int)activityType);
            parameters.Add("@computerName", Environment.MachineName);
            parameters.Add("@details", details);
            parameters.Add("@affectedId", affectedId);

            string command = @"INSERT INTO ActivityLog (userId, activityDate, activityType, computerName, details, affectedId)
                                VALUES (@userId,
                                        @date,
                                        @type,
                                        @computerName,
                                        @details,
                                        @affectedId)";

            return await _dataAccess.ExecuteAsync(command, parameters);
        }

        public static async Task<List<ActivityInfo>> GetAllLog()
        {
            string query = @"SELECT u.displayName
                                    , al.activityDate
                                    , a.activityName
                                    ,al.computerName
                                    ,al.details
                                    ,al.affectedId
                                    FROM ActivityLog al
                                    inner join Users u on al.userId = u.id
                                    inner join Activities a on al.activityType = a.Id";

            var result = await _dataAccess.QueryAsync<ActivityInfo>(query, new DynamicParameters());
            var list = result.ToList();

            return list;
        }

    }
}
