﻿using NLog;
using OTS.Ticketing.Win.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS.Ticketing.Win.Enums;
using System.Windows.Forms;
using OTS.Ticketing.Win.ActivityLog;

namespace OTS.Ticketing.Win.Softwares
{
    public partial class AddSoftware : Form
    {
        readonly SoftwareRepository _softwareRepository;
        readonly ActivityLogRepository _activityLogRepository;
        private SoftwareInfo _softwareInfo;
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
                    _softwareInfo = await _softwareRepository.GetById(_id);
                    TxtName.Text = _softwareInfo.Name;
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
                    long addedId = await _softwareRepository.Add(software);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.AddSoftware,
                        addedId, "إضافة برنامج"));
                }
                else
                {
                    await _softwareRepository.Update(software);
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditSoftware,
                         _id, "تعديل برنامج"));
                }
                SoftwareInfo softwareInfo = await _softwareRepository.GetByName(TxtName.Text);
                SystemConstants.selectedSoftware = softwareInfo.Id;
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

        private async void AddSoftware_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (_id != 0 & (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.DeleteSoftware))))
                {
                    if (MessageBox.Show("هل انت متأكد من الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        await _softwareRepository.Delete(_softwareInfo);
                        await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.DeleteSoftware,
                         _id, "تعديل برنامج"));
                        this.Close();
                    }
                }
            }
        }
    }
}
