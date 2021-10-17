using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.UsersRoles
{
    public class RoleRepository
    {
        public DataAccess _dataAccess = new DataAccess();
        public async Task<List<RoleInfo>> GetRoles(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            string query = @"SELECT ur.UserId, ur.RoleId, r.RoleName
                             FROM UsersRoles ur
                             join Roles r on ur.RoleId = r.Id
                             Where ur.UserId = @id";
            var result = await _dataAccess.QueryAsync<RoleInfo>(query, parameters);
            return result.ToList();
        }
        public async Task UpdateRoles(long id, List<RoleInfo> roles)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string deleteCommand = @"DELETE FROM UsersRoles Where UserId = @id;";

            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                await connection.OpenAsync();
                using (var trans = connection.BeginTransaction())
                {
                    int recordsDeleted = await connection.ExecuteAsync(deleteCommand, parameters, trans);

                    string insertCommand = @"INSERT INTO UsersRoles (UserId, RoleId) VALUES ";
                    foreach (RoleInfo role in roles)
                    {
                        insertCommand += $"(@id, {role.RoleId}),";
                    }
                    insertCommand = insertCommand.Remove(insertCommand.Length - 1, 1);
                    try
                    {
                        await connection.ExecuteAsync(insertCommand, parameters, transaction: trans);
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }

        }
    }
}
