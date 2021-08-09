using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win
{
    public class SystemConstants
    {
        public static long loggedInEmployeeId;
        public static long SelectedPhoneNumberId;
        public static long SelectedCompanyId;
        public static string Database;
        public static string ServerIp;

        public static void ErrorLog(Exception ex, string methodName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.AppendAllText(Path.Combine(path, "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), methodName + Environment.NewLine);
            File.AppendAllText(Path.Combine(path, "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), ex.Message + Environment.NewLine);
            File.AppendAllText(Path.Combine(path, "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), "=========================================================" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
        }
    }
}
