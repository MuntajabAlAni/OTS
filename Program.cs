﻿using NLog;
using NLog.Config;
using OTS.Ticketing.Win.MainForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = new Mutex(true, "OTS.Ticketing.Win", out bool createdNew);

            if (!createdNew)
            {
                MessageBox.Show("لا يمكن تشغيل البرنامج أكثر من مرة !!");
                return;
            }
            var config = new XmlLoggingConfiguration("NLog.config");
            LogManager.Configuration = config;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
