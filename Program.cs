using NLog;
using NLog.Config;
using OTS.Ticketing.Win.MainForms;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            CultureInfo ci = new CultureInfo("ar");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat = new CultureInfo("en-GB").DateTimeFormat;


            _ = new Mutex(true, "OTS.Ticketing.Win", out bool createdNew);

            if (!createdNew)
            {
                MessageBox.Show(LocalizationMessages.GetMessage("OneTimeProgramRunning"));
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
