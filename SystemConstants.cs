using OTS.Ticketing.Win.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win
{
    public class SystemConstants
    {
        public static UserInfo loggedInUser = null;
        public static Guid loggedInUserSessionId = Guid.Empty;
        public static long SelectedPhoneNumberId = 0;
        public static long SelectedCompanyId = 0;
        public static long SelectedSoftware = 0;
        public static long SelectedUser = 0;
        public static string Database;
        public static string ServerIp;
        //public static bool TechnicalSupportTask = false;

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
            loggedInUser = null;
            SelectedPhoneNumberId = 0;
            SelectedCompanyId = 0;
            SelectedSoftware = 0;
            SelectedUser = 0;
        }

        public static byte[] SHA512(string plaintext)
        {
            ASCIIEncoding AE = new ASCIIEncoding();
            byte[] passBuff = AE.GetBytes(plaintext);

            SHA512Managed hashVal = new SHA512Managed();
            byte[] passHash = hashVal.ComputeHash(passBuff);

            return passHash;
        }

        public static DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }


    }

    public static class ControlExtensions
    {
        public static void Invoke(this Control Control, Action Action)
        {
            if (Control.InvokeRequired && !Control.IsDisposed)
            {
                Control.Invoke(Action);
            }
            else if (!Control.IsDisposed)
            {
                Action();
            }
            else
            {
            }
        }
    }
}
