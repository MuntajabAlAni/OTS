using Dapper;
using OTS.Ticketing.Win.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.States
{
    public class StateRepository
    {
        public DataAccess dataAccess = new DataAccess();

        public async Task<int> AddState(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", name);

            string command = "INSERT INTO States (name) VALUES (@name)";

            return await dataAccess.ExecuteAsync(command, parameters);
        }
    }
}
