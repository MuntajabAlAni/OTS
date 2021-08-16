﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OTS.Ticketing.Win.MainForms;
using OTS.Ticketing.Win.States;
using OTS.Ticketing.Win.Companies;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using NLog;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayTickets : Form
    {
        readonly TicketRepository ticketRepository = new TicketRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DisplayTickets()
        {
            InitializeComponent();
        }

        private async void DisplayTickets_Load(object sender, EventArgs e)
        {
            try
            {
                var UserInfo = await ticketRepository.GetUserById(SystemConstants.loggedInUserId);
                if (UserInfo.UserName != "admin")
                {
                    BtnAddState.Visible = false;
                    BtnEditState.Visible = false;
                }
                GetDtgTicketsData();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void FillStatesComboBox()
        {
            try
            {
                CombStates.DisplayMember = "Name";
                CombStates.ValueMember = "Id";
                CombStates.DataSource = await ticketRepository.GetAllStates();
                CombStates.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void GetDtgTicketsData()
        {
            try
            {
                DtgTickets.DataSource = SystemConstants.ToDataTable(
                    await ticketRepository.GetAllTicketsByUserId(SystemConstants.loggedInUserId));
                DtgTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                DtgTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                DtgTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                DtgTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                DtgTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                DtgTickets.Columns["UserName"].HeaderText = "الموظف";
                DtgTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                DtgTickets.Columns["Problem"].HeaderText = "المشكلة";
                DtgTickets.Columns["State"].HeaderText = "الحالة";
                DtgTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                DtgTickets.Columns["Arrangement"].HeaderText = "ترتيب الملفات";
                DtgTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
                DtgTickets.Columns["Remarks"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private void ToggleRemotely_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (ToggleRemotely.Checked) LblRemote.Text = "بإستخدام Anydesk";
            else LblRemote.Text = "بإتصال فقط";
        }

        private async void DtgTickets_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (DtgTickets.Rows.Count == 0) return;
                long selectedNumber = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketsView selectedTicket = await ticketRepository.GetTicketDetailsByByNumberAndRevision(selectedNumber, selectedRevision);
                LblNumber.Text = selectedTicket.Number.ToString();
                LblRevision.Text = selectedTicket.Revision.ToString();
                LblCompany.Text = selectedTicket.CompanyName.ToString();
                LblUser.Text = selectedTicket.UserName.ToString();
                LblPhoneNumber.Text = selectedTicket.PhoneNumber.ToString();
                LblSoftware.Text = selectedTicket.SoftwareName.ToString();
                LblOpenDate.Text = selectedTicket.OpenDate.ToString("yyyy-MM-dd hh:mm tt dddd");
                TxtProblem.Text = selectedTicket.Problem;
                TxtRemarks.Text = selectedTicket.Remarks;
                CombStates.Text = selectedTicket.State;
                ToggleArrangement.Checked = selectedTicket.Arrangement == "مرتبة";
                ToggleClosed.Checked = selectedTicket.IsClosed == "مغلقة";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetDtgTicketsData();
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblNumber.Text == "" | Convert.ToInt64(CombStates.SelectedValue) == 0)
                {
                    MessageBox.Show("يرجى ادخال المعلومات بشكل صحيح", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr;
                dr = MessageBox.Show("إغلاق البطاقة ؟؟", "إغلاق", MessageBoxButtons.YesNo);
                ToggleClosed.Checked = dr == DialogResult.Yes;
                DialogResult dr2;
                dr2 = MessageBox.Show("هل انت متأكد من الإضافة ؟", "Confirm", MessageBoxButtons.YesNo);
                if (dr2 == DialogResult.Yes)
                {
                    await ticketRepository.UpdateTicket(Convert.ToInt64(LblNumber.Text),
                  Convert.ToInt32(LblRevision.Text),
                  DateTime.Now,
                  Convert.ToInt64(CombStates.SelectedValue),
                  TxtRemarks.Text,
                  TxtProblem.Text,
                  Convert.ToInt32(ToggleRemotely.Checked),
                  ToggleArrangement.Checked,
                  ToggleClosed.Checked);
                    GetDtgTicketsData();
                    RefreshAllData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void RefreshAllData()
        {
            try
            {
                LblNumber.Text = "";
                LblRevision.Text = "";
                LblCompany.Text = "";
                LblUser.Text = "";
                LblPhoneNumber.Text = "";
                LblSoftware.Text = "";
                LblOpenDate.Text = "";
                TxtProblem.Text = "";
                TxtRemarks.Text = "";
                CombStates.SelectedIndex = 0;
                ToggleArrangement.Checked = false;
                ToggleRemotely.Checked = false;
                ToggleClosed.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
        private void BtnAddState_Click(object sender, EventArgs e)
        {
            try
            {
                AddState addState = new AddState(0);
                addState.ShowDialog();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private void BtnEditState_Click(object sender, EventArgs e)
        {
            try
            {
                AddState addState = new AddState(Convert.ToInt64(CombStates.SelectedValue));
                addState.ShowDialog();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
    }
}
