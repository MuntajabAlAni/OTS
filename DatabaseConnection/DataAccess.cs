using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Software.DatabaseConnection
{
    public class DataAccess
    {
        public IEnumerable<T> Query<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionTools.ConnectionValue("OTS_Ticketing_SoftwareDB")))
            {
                return connection.Query<T>(sql, parameters);
            }
        }

        public int Execute(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionTools.ConnectionValue("OTS_Ticketing_SoftwareDB")))
            {
                return connection.Execute(sql, parameters);
            }
        }
    }
}

