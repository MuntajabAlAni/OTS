﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win.DatabaseConnection
{
    public class DataAccess
    {
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters parameters,bool init = false,string ServerIp = "")
        {
            using (IDbConnection connection = new SqlConnection(ConnectionTools.ConnectionValue(init,ServerIp)))
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<int> ExecuteAsync(string sql, DynamicParameters parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                return await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}

