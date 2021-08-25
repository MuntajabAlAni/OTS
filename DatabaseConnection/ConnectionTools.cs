using System;
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
        public static string ConnectionValue(bool init = false,string ServerIp = "")
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder
            {
                DataSource = ServerIp==""? SystemConstants.ServerIp:ServerIp,
                InitialCatalog = init==false? SystemConstants.Database:"master",
                UserID = "sa",
                Password = "vULiwCss0SrBrLJ",
                IntegratedSecurity = true,
            };
            //str["Server"] = str.DataSource + @"\FOTSQLSERVER";
            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return str.ConnectionString;
        }
    }
}
