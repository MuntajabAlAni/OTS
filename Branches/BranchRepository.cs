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

        public async Task<long> AddBranch(BranchInfo branch)
        {
            var parameters = new DynamicParameters(branch);
            string command = "INSERT INTO Branches (Name) VALUES (@name)";
            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<BranchInfo> GetBranchById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Branches WHERE Id = @Id";

            var result = await _dataAccess.QueryAsync<BranchInfo>(query, parameters);
            return result.FirstOrDefault();

        }
        public async Task UpdateBranch(BranchInfo branch)
        {
            var parameters = new DynamicParameters(branch);
            string command = @"UPDATE Branches SET 
                                Name = @name
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
