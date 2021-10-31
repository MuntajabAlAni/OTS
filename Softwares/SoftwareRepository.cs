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
        public DataAccess _dataAccess = new DataAccess();

        public async Task<long> Add(SoftwareInfo software)
        {
            var parameters = new DynamicParameters(software);

            string command = @"INSERT INTO Softwares (Name) VALUES (@name);
			                   SELECT SCOPE_IDENTITY();";

            return await _dataAccess.ExecuteScalarAsync<long>(command, parameters);
        }
        public async Task<SoftwareInfo> GetById(long id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);

            string query = "SELECT * FROM Softwares WHERE Id = @Id";

            var result = await _dataAccess.QueryAsync<SoftwareInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task Update(SoftwareInfo software)
        {
            var parameters = new DynamicParameters(software);
            string command = @"UPDATE Softwares SET 
                                Name = @name
                               WHERE Id = @id";

             await _dataAccess.ExecuteAsync(command, parameters);
        }
        public async Task<SoftwareInfo> GetByName(string name)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string query = "SELECT * FROM Softwares WHERE name = @name AND isDeleted = 0";
            var result = await _dataAccess.QueryAsync<SoftwareInfo>(query, parameters);
            return result.FirstOrDefault();
        }
        public async Task<List<SoftwareInfo>> GetAll()
        {
            string query = "SELECT * FROM softwares WHERE isDeleted = 0";
            var result = await _dataAccess.QueryAsync<SoftwareInfo>(query, new DynamicParameters());
            return result.ToList();
        }
        public async Task Delete(SoftwareInfo software)
        {
            var parameters = new DynamicParameters(software);
            string command = @"UPDATE Softwares SET 
                                isDeleted = 1
                               WHERE Id = @id";
            await _dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
