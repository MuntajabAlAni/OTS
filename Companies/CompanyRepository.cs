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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", name);
            parameters.Add("@Address", address);
            parameters.Add("@BranchId", branchId);
            parameters.Add("@Remarks", remarks);

            string command = "INSERT INTO Companies (Name, Address, BranchId, Remarks) VALUES (@Name, @Address, @BranchId, @Remarks)";
            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<CompanyInfo> GetCompanyInfoById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Companies WHERE Id = @id";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdateCompany(string name, string address, long branchId, string remarks, long id)
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
        public async Task<List<BranchInfo>> GetAllBranches()
        {
            string query = "SELECT * FROM Branches";
            var result = await dataAccess.QueryAsync<BranchInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<CompanyInfo> GetLastCompanyId()
        {
            string query = "SELECT TOP 1 Id FROM Companies Order by Id DESC";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            return result.FirstOrDefault();
        }
        public async Task<List<CompanyInfo>> GetCompanyByName(string companyName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyName", companyName);

            string query = "SELECT * from companies WHERE name LIKE '%'+@companyName+'%'";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, parameters);
            return result.ToList();
        }
    }
}
