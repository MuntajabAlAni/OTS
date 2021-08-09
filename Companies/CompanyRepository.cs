using Dapper;
using OTS.Ticketing.Win.Branches;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Companies
{
    public class CompanyRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<int> AddCompany(string name, string address, long branchId, string remarks)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", name);
                parameters.Add("@Address", address);
                parameters.Add("@BranchId", branchId);
                parameters.Add("@Remarks", remarks);

                string command = "INSERT INTO Companies (Name, Address, BranchId, Remarks) VALUES (@Name, @Address, @BranchId, @Remarks)";
                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddCompany");
                return default;
            }

        }
        public async Task<CompanyInfo> GetCompanyInfoById(long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                string query = "SELECT * FROM Companies WHERE Id = @id";
                var result = await dataAccess.QueryAsync<CompanyInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetCompanyInfoById");
                return default;
            }

        }
        public async Task<int> UpdateCompany(string name, string address, long branchId, string remarks, long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", name);
                parameters.Add("@Address", address);
                parameters.Add("@BranchId", branchId);
                parameters.Add("@Remarks", remarks);
                parameters.Add("@Id", id);

                string command = @"UPDATE Companies SET 
                             Name = @Name,
                             Address = @Address,
                             BranchId =  @BranchId,
                             Remarks = @Remarks
                             WHERE Id = @id";
                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "UpdateCompany");
                return default;
            }

        }
        public async Task<List<BranchInfo>> GetAllBranches()
        {
            try
            {
                string query = "SELECT * FROM Branches";
                var result = await dataAccess.QueryAsync<BranchInfo>(query, new DynamicParameters());
                return result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllBranches");
                return default;
            }

        }
    }
}
