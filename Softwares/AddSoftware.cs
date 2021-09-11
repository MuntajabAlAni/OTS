using NLog;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Softwares
{
    public partial class AddSoftware : Form
    {
        readonly SoftwareRepository softwareRepository = new SoftwareRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;


        public AddSoftware(long id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void AddSoftware_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    SoftwareInfo softwareInfo = await softwareRepository.GetSoftwareById(_id);
                    TxtName.Text = softwareInfo.Name;
                    BtnAdd.Text = "تعديل";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    await softwareRepository.AddSoftware(TxtName.Text);
                    await ActivityLogUtility.ActivityLog(Enums.Activities.AddSoftware, "إضافة برنامج",
                        await softwareRepository.GetLastAddedSoftwareId());
                }
                else
                {
                    await softwareRepository.UpdateSoftware(_id, TxtName.Text);
                    await ActivityLogUtility.ActivityLog(Enums.Activities.EditSoftware, "تعديل برنامج", _id);
                }
                SoftwareInfo softwareInfo = await softwareRepository.GetSoftwareByName(TxtName.Text);
                SystemConstants.SelectedSoftware = softwareInfo.Id;
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
    }
}
