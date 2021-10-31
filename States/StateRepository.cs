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
        public DataAccess _dataAccess = new DataAccess();

        public async Task<long> Add(StateInfo state)
        {
            var parameters = new DynamicParameters(state);

            string command = @"INSERT INTO States (name) VALUES (@name);
			                   SELECT SCOPE_IDENTITY();";

            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<StateInfo> GetById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM States WHERE Id = @id";
            var result = await _dataAccess.QueryAsync<StateInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task Update(StateInfo state)
        {
            var parameters = new DynamicParameters(state);

            string command = @"UPDATE States SET 
                                Name = @name
                               WHERE Id = @id";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<StateInfo>> GetAll()
        {
            string query = "SELECT * FROM states WHERE isDeleted = 0";
            var result = await _dataAccess.QueryAsync<StateInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task Delete(StateInfo state)
        {
            var parameters = new DynamicParameters(state);
            string command = @"UPDATE States SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
