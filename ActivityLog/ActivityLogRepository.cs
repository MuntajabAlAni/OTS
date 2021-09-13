using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using OTS.Ticketing.Win.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.ActivityLog
{
    public class ActivityLogRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<List<UserInfo>> GetAllUsers()
        {
            string query = "SELECT * FROM Users where isDeleted = 0";
            var result = await dataAccess.QueryAsync<UserInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new UserInfo { Id = 0, DisplayName = "" }));
            return list;
        }
        public async Task<List<ActivityInfo>> GetAllActivities()
        {
            string query = "SELECT * FROM activities";
            var result = await dataAccess.QueryAsync<ActivityInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new ActivityInfo { Id = 0, ActivityName = "" }));
            return list;
        }
        public async Task<List<ActivityView>> GetActivityLog(long userId, long activityId, DateTime fromDate, DateTime toDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            parameters.Add("@activityId", activityId);
            parameters.Add("@fromDate", fromDate.ToString("yyyy-MM-dd 00:00:00.000"));
            parameters.Add("@toDate", toDate.ToString("yyyy-MM-dd 23:59:59.000"));

            string query = @"select al.id, u.displayName username, al.activityDate, a.activityName activityType, al.computerName,
                             al.details, al.affectedId 
                             from activityLog al
                             inner join users u on u.id = al.userId
                             inner join activities a on a.Id = al.activityType
                             WHERE IIF(@userId = 0,0,u.Id) = @userId
                             AND IIF(@activityId = 0,0,a.Id) = @activityId
                             AND al.activityDate between @fromDate and @toDate";

            var result = await dataAccess.QueryAsync<ActivityView>(query, parameters);

            return result.ToList();

        }
        //public async Task<ActivityView> GetActivityInfoById(long id)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@Id", id);

        //    string query = @"select al.id, u.displayName username, al.activityDate, a.activityName activityType, al.computerName, al.details, al.affectedId 
        //                     from activityLog al
        //                     inner join users u on u.id = al.userId
        //                     inner join activities a on a.Id = al.activityType
        //                     WHERE al.id = @Id";

        //    var result = await dataAccess.QueryAsync<ActivityView>(query, parameters);
        //    return result.FirstOrDefault();
        //}
    }
}
