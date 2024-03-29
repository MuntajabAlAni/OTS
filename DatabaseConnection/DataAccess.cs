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
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters parameters = null, bool init = false, string ServerIp = "",
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue(init, ServerIp)))
            {
                return await connection.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
            }
        }

        public async Task<int> ExecuteAsync(string sql, DynamicParameters parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteAsync(sql, parameters, trans, commandTimeout, commandType);
                    trans.Commit();
                    return result;
                }
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, DynamicParameters parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionTools.ConnectionValue()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteScalarAsync<T>(sql, parameters, trans);
                    trans.Commit();
                    return result;
                }
            }
        }
    }
}

