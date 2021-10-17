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
        public DataAccess _dataAccess = new DataAccess();
        public async Task<long> Add(PhoneNumberInfo phoneNumber)
        {
            var parameters = new DynamicParameters(phoneNumber);
            string command = @"INSERT INTO PhoneNumbers (phoneNumber, customerName, companyId)
                               VALUES (@phoneNumber, @customerName, @companyId)";

            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<PhoneNumberInfo> GetById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM PhoneNumbers WHERE Id = @Id";

            var result = await _dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task Update(PhoneNumberInfo phoneNumber)
        {
            var parameters = new DynamicParameters(phoneNumber);

            string command = @"UPDATE PhoneNumbers SET 
                                phoneNumber = @phoneNumber,
                                customerName = @customerName,
                                companyId = @companyId
                               WHERE Id = @id";

            await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<List<PhoneNumberView>> GetBySearch(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);

            string query = @"SELECT p.id, p.phoneNumber, p.customerName, c.name companyName
                            from phoneNumbers p
                            left join companies c on p.companyId = c.id
                            WHERE phoneNumber LIKE '%'+@phoneNumber
                            AND p.isDeleted = 0";

            var result = await _dataAccess.QueryAsync<PhoneNumberView>(query, parameters);
            return result.ToList();
        }
        public async Task<long> GetIdBy(string phoneNumber)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@phoneNumber", phoneNumber);

            string query = "SELECT id from phoneNumbers WHERE PhoneNumber = @PhoneNumber And isDeleted = 0";

            var result = await _dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
            PhoneNumberInfo phoneNumberInfo = result.FirstOrDefault();
            return phoneNumberInfo.Id;
        }
        public async Task Delete(PhoneNumberInfo phoneNumber)
        {
            var parameters = new DynamicParameters(phoneNumber);
            string command = @"UPDATE PhoneNumbers SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
