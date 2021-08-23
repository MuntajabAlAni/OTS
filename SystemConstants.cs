using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        //public static void Notes(string notes)
        //{
        //    //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        //    //if (!Directory.Exists(path))
        //    //{
        //    //    Directory.CreateDirectory(path);
        //    //}

        //    File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notes.txt"), notes);
        //    //File.AppendAllText(Path.Combine(path, "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), ex.Message + Environment.NewLine);
        //    //File.AppendAllText(Path.Combine(path, "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), "=========================================================" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine);
        //}
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static void Initialize()
        {
            loggedInUserId = 0;
            SelectedPhoneNumberId = 0;
            SelectedCompanyId = 0;
            SelectedSoftware = 0;
            SelectedUser = 0;
        }
    }
}
