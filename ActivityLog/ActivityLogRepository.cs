using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.ActivityLog
{
    public class ActivityLogRepository
    {
        private readonly DataAccess _dataAccess;

        public ActivityLogRepository()
        {
            _dataAccess = new DataAccess();
        }

        public async Task<List<ActivityInfo>> GetAllActivities()
        {
            string query = "SELECT Id, ActivityName FROM activities";
            var result = await _dataAccess.QueryAsync<ActivityInfo>(query);
            var list = result.ToList();

            return list;
        }
        public async Task<List<ActivityView>> GetActivityLog(ActivityLogReportInfo logReportInfo)
        {
            logReportInfo.FromDate.ToString("yyyy-MM-dd 00:00:00.000");
            logReportInfo.ToDate.ToString("yyyy-MM-dd 23:59:59.000");

            var parameters = new DynamicParameters(logReportInfo);

            string query = @"select al.id, u.displayName username, al.activityDate, a.activityName activityType, al.computerName,
                             al.details, al.affectedId 
                             from activityLog al
                             join users u on u.id = al.userId
                             join activities a on a.Id = al.activityType
                             WHERE IIF(@userId = 0,0,u.Id) = @userId
                             AND IIF(@activityId = 0,0,a.Id) = @activityId
                             AND al.activityDate between @fromDate and @toDate";

            var result = await _dataAccess.QueryAsync<ActivityView>(query, parameters);

            return result.ToList();

        }
        public async Task AddActivityLog(ActivityLogInfo activityLog)
        {
            var parameters = new DynamicParameters(activityLog);

            string command = @"INSERT INTO ActivityLog (userId, activityDate, activityType, computerName,
                                                        details, affectedId)
                                VALUES (@userId,
                                        GETDATE(),
                                        @activityType,
                                        @computerName,
                                        @details,
                                        @affectedId)";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
