﻿using NLog;
using OTS.Ticketing.Win.ActivityLog;
using OTS.Ticketing.Win.Enums;
using System;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Softwares
{
    public partial class AddSoftware : Form
    {
        readonly SoftwareRepository _softwareRepository;
        readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly long _id;


        public AddSoftware(long id)
        {
            _activityLogRepository = new ActivityLogRepository();
            _softwareRepository = new SoftwareRepository();
            _id = id;
            InitializeComponent();
        }

        private async void AddSoftware_Load(object sender, EventArgs e)
        {
            try
            {
                if (_id != 0)
                {
                    SoftwareInfo softwareInfo = await _softwareRepository.GetSoftwareById(_id);
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
                SoftwareInfo software = GetFormData();
                if (_id == 0)
                {
                    long addedId = await _softwareRepository.AddSoftware(software);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddSoftware,
                        addedId, "إضافة برنامج"));
                }
                else
                {
                    await _softwareRepository.UpdateSoftware(software);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditSoftware,
                         _id, "تعديل برنامج"));
                }
                SoftwareInfo softwareInfo = await _softwareRepository.GetSoftwareByName(TxtName.Text);
                SystemConstants.SelectedSoftware = softwareInfo.Id;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private SoftwareInfo GetFormData()
        {
            return new SoftwareInfo
            {
                Id = _id,
                Name = TxtName.Text
            };
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
