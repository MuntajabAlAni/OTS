using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.DatabaseConnection
{
    public partial class DatabaseServer : Form
    {
        readonly DataAccess dataAccess = new DataAccess();
        readonly IniFile iniFile = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));

        public DatabaseServer()
        {
            InitializeComponent();
        }

        private void DatabaseServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            iniFile.IniWriteValue("Connection", "Database", CombDatabases.SelectedValue.ToString());
            SystemConstants.Database = CombDatabases.SelectedValue.ToString();
            iniFile.IniWriteValue("Connection", "ServerIp", TxtServerIp.Text);
            SystemConstants.ServerIp = TxtServerIp.Text;
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  void ImbTryConnect_Click(object sender, EventArgs e)
        {
            //using (var connection = new SqlConnection(ConnectionTools.ConnectionValue(false, TxtServerIp.Text)))
            //{
            //    try
            //    {
            //        connection.Open();
            //        this.Invoke(new Action(() => MessageBox.Show("تم الاتصال بنجاح")));
            //    }
            //    catch (Exception)
            //    {
            //        this.Invoke(new Action(() => MessageBox.Show("فشل الإتصال .. يرجى التأكد من كل الإعدادات")));

            //    }
            //}
        }

        private async void ImbRefresh_Click(object sender, EventArgs e)
        {
            string query = "select name, name as value from sys.databases where name not in ('master','tempdb','model','msdb');";
            var result = await dataAccess.QueryAsync<DatabaseInfo>(query, new DynamicParameters(), true, TxtServerIp.Text);
            List<DatabaseInfo> databaseInfo = result.ToList();
            CombDatabases.DataSource = databaseInfo;
            CombDatabases.DisplayMember = "Name";
            CombDatabases.ValueMember = "Value";
            CombDatabases.SelectedValue = iniFile.IniReadValue("Connection", "Database");
        }

        private void DatabaseServer_Load(object sender, EventArgs e)
        {
            TxtServerIp.Text = iniFile.IniReadValue("Connection", "ServerIp");
            ImbRefresh_Click(sender, e);
        }
    }
}
