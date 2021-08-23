using Dapper;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.PhoneNumbers
{
    public class PhoneNumberRepository
    {
        public DataAccess dataAccess = new DataAccess();
        public async Task<int> AddPhoneNumber(string phoneNumber, string customerName, long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);
            parameters.Add("@customerName", customerName);
            parameters.Add("@companyId", companyId);

            string command = "INSERT INTO PhoneNumbers (phoneNumber, customerName, companyId) VALUES (@phoneNumber, @customerName, @companyId)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<PhoneNumberInfo> GetPhoneNumberById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM PhoneNumbers WHERE Id = @Id";

            var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<int> UpdatePhoneNumber(long id, string phoneNumber, string customerName, long companyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@phoneNumber", phoneNumber);
            parameters.Add("@customerName", customerName);
            parameters.Add("@companyId", companyId);

            string command = @"UPDATE PhoneNumbers SET 
                                phoneNumber = @phoneNumber,
                                customerName = @customerName,
                                companyId = @companyId
                               WHERE Id = @id";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            string query = "SELECT * FROM Companies";
            var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task<List<PhoneNumberView>> GetPhoneNumbersBySearch(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);

            string query = @"SELECT p.id, p.phoneNumber, p.customerName, c.name companyName
                            from phoneNumbers p
                            left join companies c on p.companyId = c.id
                            WHERE phoneNumber LIKE '%'+@phoneNumber";

            var result = await dataAccess.QueryAsync<PhoneNumberView>(query, parameters);
            return result.ToList();
        }
        public async Task<long> GetPhoneNumberIdByPhoneNumber(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);

            string query = "SELECT id from phoneNumbers WHERE PhoneNumber = @PhoneNumber";

            var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            PhoneNumberInfo phoneNumberInfo = result.FirstOrDefault();
            return phoneNumberInfo.Id;
        }
        public async Task<long> GetCompanyIdByName(string name)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", name);

            string query = "SELECT id from Companies WHERE Name = @Name";

            var result = await dataAccess.QueryAsync<CompanyInfo>(query, parameters);
            CompanyInfo companyInfo = result.FirstOrDefault();
            return companyInfo.Id;
        }
    }
}
