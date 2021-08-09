using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Softwares
{
    public class SoftwareRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<int> AddSoftware(string name)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", name);

                string command = "INSERT INTO Softwares (Name) VALUES (@name)";

                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "AddSoftware");
                return default;
            }

        }

        public async Task<SoftwareInfo> GetSoftwareById(long id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                string query = "SELECT * FROM Softwares WHERE Id = @Id";

                var result = await dataAccess.QueryAsync<SoftwareInfo>(query, parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "GetSoftwareById");
                return default;
            }


        }

        public async Task<int> UpdateSoftware(long id, string name)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@name", name);
                string command = @"UPDATE Softwares SET 
                                Name = @name
                               WHERE Id = @id";

                return await dataAccess.ExecuteAsync(command, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemConstants.ErrorLog(ex, "UpdateSoftware");
                return default;
            }

        }
    }
}
