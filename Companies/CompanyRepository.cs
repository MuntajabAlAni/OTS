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
        public DataAccess _dataAccess = new DataAccess();
        public async Task<long> Add(CompanyInfo company)
        {
            var parameters = new DynamicParameters(company);
            string command = "INSERT INTO Companies (Name, Address, BranchId, Remarks) VALUES (@Name, @Address, @BranchId, @Remarks)";
            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<CompanyInfo> GetInfoById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Companies WHERE Id = @id";
            var result = await _dataAccess.QueryAsync<CompanyInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task Update(CompanyInfo company)
        {
            var parameters = new DynamicParameters(company);


            string command = @"UPDATE Companies SET 
                             Name = @Name,
                             Address = @Address,
                             BranchId =  @BranchId,
                             Remarks = @Remarks
                             WHERE Id = @id";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<CompanyView>> GetByName(string companyName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyName", companyName);

            string query = @"SELECT c.id, c.name, c.address, c.remarks, b.name branchName
                            from companies c
                            left join branches b on c.branchId = b.id
                            WHERE c.name LIKE '%' + @companyName + '%'
                            AND c.isDeleted = 0";

            var result = await _dataAccess.QueryAsync<CompanyView>(query, parameters);
            return result.ToList();
        }
        public async Task<List<CompanyInfo>> GetAll()
        {
            string query = "SELECT * FROM Companies where isDeleted = 0";
            var result = await _dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task Delete(CompanyInfo company)
        {
            var parameters = new DynamicParameters(company);
            string command = @"UPDATE Companies SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
