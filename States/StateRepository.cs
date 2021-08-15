using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.States
{
    public class StateRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<int> AddState(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string command = "INSERT INTO States (name) VALUES (@name)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<StateInfo> GetStateById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM States WHERE Id = @id";
            var result = await dataAccess.QueryAsync<StateInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdateState(long id, string name)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@name", name);
            string command = @"UPDATE States SET 
                                Name = @name
                               WHERE Id = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
