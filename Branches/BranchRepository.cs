using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Branches
{
    public class BranchRepository
    {
        public DataAccess _dataAccess = new DataAccess();

        public async Task<long> Add(BranchInfo branch)
        {
            var parameters = new DynamicParameters(branch);
            string command = @"INSERT INTO Branches (Name) VALUES (@name);
                               SELECT SCOPE_IDENTITY();";
            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<BranchInfo> GetById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Branches WHERE Id = @Id";

            var result = await _dataAccess.QueryAsync<BranchInfo>(query, parameters);
            return result.FirstOrDefault();

        }
        public async Task Update(BranchInfo branch)
        {
            var parameters = new DynamicParameters(branch);
            string command = @"UPDATE Branches SET 
                                Name = @name
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<BranchInfo>> GetAll()
        {
            string query = "SELECT * FROM Branches Where isDeleted = 0";
            var result = await _dataAccess.QueryAsync<BranchInfo>(query, new DynamicParameters());
            var list = result.ToList();
            return list;
        }
        public async Task Delete(BranchInfo branch)
        {
            var parameters = new DynamicParameters(branch);
            string command = @"UPDATE Branches SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
