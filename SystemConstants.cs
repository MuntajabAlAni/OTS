﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win
{
    public class SystemConstants
    {
        public static long loggedInUserId = 0;
        public static long SelectedPhoneNumberId = 0;
        public static long SelectedCompanyId = 0;
        public static long SelectedSoftware = 0;
        public static long SelectedUser = 0;
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
