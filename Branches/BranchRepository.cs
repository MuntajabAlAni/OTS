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
        public DataAccess dataAccess = new DataAccess();

        public async Task<int> AddBranch(string name)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);

                string command = "INSERT INTO Branches (Name) VALUES (@name)";

                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddBranch");
                return default;
            }

        }

        public async Task<BranchInfo> GetBranchById(long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                string query = "SELECT * FROM Branches WHERE Id = @Id";

                var result = await dataAccess.QueryAsync<BranchInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetBranchById");
                return default;
            }

        }

        public async Task<int> UpdateBranch(long id, string name)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@name", name);
                string command = @"UPDATE Branches SET 
                                Name = @name
                               WHERE Id = @id";

                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "UpdateBranch");
                return default;
            }

        }
    }
}
