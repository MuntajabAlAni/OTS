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
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@phoneNumber", phoneNumber);
                parameters.Add("@customerName", customerName);
                parameters.Add("@companyId", companyId);

                string command = "INSERT INTO PhoneNumbers (phoneNumber, customerName, companyId) VALUES (@phoneNumber, @customerName, @companyId)";

                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddPhoneNumber");
                return default;
            }

        }
        public async Task<PhoneNumberInfo> GetPhoneNumberById(long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                string query = "SELECT * FROM PhoneNumbers WHERE Id = @Id";

                var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetPhoneNumberById");
                return default;
            }


        }
        public async Task<int> UpdatePhoneNumber(long id, string phoneNumber, string customerName, long companyId)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "UpdatePhoneNumber");
                return default;
            }

        }
        public async Task<List<CompanyInfo>> GetAllCompanies()
        {
            try
            {
                string query = "SELECT * FROM Companies";
                var result = await dataAccess.QueryAsync<CompanyInfo>(query, new DynamicParameters());
                return result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetAllCompanies");
                return default;
            }

        }
        public async Task<List<PhoneNumberInfo>> GetPhoneNumbersBySearch(string phoneNumber)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@phoneNumber", phoneNumber);

                string query = "SELECT * from phoneNumbers WHERE phoneNumber LIKE '%'+@phoneNumber";
                var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query, parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetPhoneNumbersBySearch");
                return default;
            }

        }

        public async Task<long> GetPhoneNumberIdByPhoneNumber(string phoneNumber)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@phoneNumber", phoneNumber);

                string query = "SELECT id from phoneNumbers WHERE PhoneNumber = @PhoneNumber";

                var result = await dataAccess.QueryAsync<PhoneNumberInfo>(query,parameters);
                PhoneNumberInfo phoneNumberInfo = result.FirstOrDefault();
                return phoneNumberInfo.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetLastPhoneNumberId");
                return default;
            }
        }
    }
}
