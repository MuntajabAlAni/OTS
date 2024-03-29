﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.DatabaseConnection
{
    public static class ConnectionTools
    {
        public static string ConnectionValue(bool init = false, string ServerIp = "")
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder
            {
                DataSource = ServerIp == "" ? SystemConstants.serverIp : ServerIp,
                InitialCatalog = init == false ? SystemConstants.database : "master",
                UserID = "sa",
                Password = "vULiwCss0SrBrLJ"
            };

            bool devTest = false;                    //todo: SET FALSE WHEN RELEASE A NEW VERSION
            str.IntegratedSecurity = devTest;
            if (!devTest)
                str["Server"] = str.DataSource + @"\FOTSQLSERVER";

            return str.ConnectionString;
        }
    }
}
