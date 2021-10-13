using System.Data.SqlClient;

namespace OTS.Ticketing.Win.DatabaseConnection
{
    public static class ConnectionTools
    {
        public static string ConnectionValue(bool init = false, string ServerIp = "")
        {
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder
            {
                DataSource = ServerIp == "" ? SystemConstants.ServerIp : ServerIp,
                InitialCatalog = init == false ? SystemConstants.Database : "master",
                UserID = "sa",
                Password = "vULiwCss0SrBrLJ"
            };

            bool devTest = true;                    //todo: SET FALSE WHEN RELEASE A NEW VERSION
            str.IntegratedSecurity = devTest;
            if (!devTest)
                str["Server"] = str.DataSource + @"\FOTSQLSERVER";

            return str.ConnectionString;
        }
    }
}
