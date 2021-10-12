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
            string query = "SELECT * FROM Branches Where isDeleted = 0";
            var result = await dataAccess.QueryAsync<BranchInfo>(query, new DynamicParameters());
            var list = result.ToList();
            list.Insert(0, (new BranchInfo { Id = 0, Name = "" }));
            return list;
        } // تم
        public async Task<long> GetLastCompanyId()
        {
            string query = "SELECT TOP 1 Id FROM Companies Order by Id DESC";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            CompanyInfo companyInfo = result.FirstOrDefault();
            return companyInfo.Id;
        }
        public async Task<List<CompanyView>> GetCompanyByName(string companyName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyName", companyName);

            string query = @"SELECT c.id, c.name, c.address, c.remarks, b.name branchName
                            from companies c
                            left join branches b on c.branchId = b.id
                            WHERE c.name LIKE '%' + @companyName + '%'
                            AND c.isDeleted = 0";

            var result = await dataAccess.QueryAsync<CompanyView>(query, parameters);
            return result.ToList();
        }
    }
}
