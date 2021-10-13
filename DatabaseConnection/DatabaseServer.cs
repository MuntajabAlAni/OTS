using Dapper;
using NLog;
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
        private readonly DataAccess _dataAccess;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IniFile _iniFile;

        public DatabaseServer()
        {
            _dataAccess = new DataAccess();
            _iniFile = new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));
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
            try
            {
                _iniFile.IniWriteValue("Connection", "Database", CombDatabases.SelectedValue.ToString());
                SystemConstants.Database = CombDatabases.SelectedValue.ToString();
                _iniFile.IniWriteValue("Connection", "ServerIp", TxtServerIp.Text);
                SystemConstants.ServerIp = TxtServerIp.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImbTryConnect_Click(object sender, EventArgs e)
        {
            //todo: TRY CONNECT
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
            try
            {
                string query = "select name, name as value from sys.databases where name not in ('master','tempdb','model','msdb');";
                var result = await _dataAccess.QueryAsync<DatabaseInfo>(query, new DynamicParameters(), true, TxtServerIp.Text);
                List<DatabaseInfo> databaseInfo = result.ToList();
                CombDatabases.DataSource = databaseInfo;
                CombDatabases.DisplayMember = "Name";
                CombDatabases.ValueMember = "Value";
                CombDatabases.SelectedValue = _iniFile.IniReadValue("Connection", "Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void DatabaseServer_Load(object sender, EventArgs e)
        {
            TxtServerIp.Text = _iniFile.IniReadValue("Connection", "ServerIp");
            ImbRefresh_Click(sender, e);
        }
    }
}
