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
using OTS.Ticketing.Win.Enums;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.Softwares;
using NLog;
using OTS.Ticketing.Win.Utils;
using OTS.Ticketing.Win.ActivityLog;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class DisplayTickets : Form
    {
        readonly TicketRepository _ticketRepository;
        readonly MainRepository _mainRepository;
        readonly ActivityLogRepository _activityLogRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DisplayTickets()
        {
            _mainRepository = new MainRepository();
            _ticketRepository = new TicketRepository();
            _activityLogRepository = new ActivityLogRepository();
            InitializeComponent();
            CombStates.DropDownStyle = ComboBoxStyle.DropDownList;
            CombTransferedTo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DisplayTickets_Load(object sender, EventArgs e)
        {
            try
            {
                if (SystemConstants.userRoles.Contains(((long)RoleType.AddState)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnAddState.Visible = true;

                if (SystemConstants.userRoles.Contains(((long)RoleType.EditState)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.Admin)))
                    BtnEditState.Visible = true;

                GetDtgTicketsData();
                FillUsersComboBox();
                FillStatesComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillUsersComboBox()
        {
            try
            {
                CombTransferedTo.DisplayMember = "displayName";
                CombTransferedTo.ValueMember = "Id";
                CombTransferedTo.DataSource = await _ticketRepository.GetAllUsers();
                CombTransferedTo.SelectedValue = 0;
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
                CombStates.DataSource = await _ticketRepository.GetAllStates();
                CombStates.SelectedValue = 0;
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
                DataTable dt = SystemConstants.ToDataTable(
                    await _ticketRepository.GetAllByUserId(SystemConstants.loggedInUser.Id));
                DataColumn dc = new DataColumn("ت", typeof(int));
                dt.Columns.Add(dc);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dr["ت"] = i + 1;
                    i++;
                }
                DtgTickets.DataSource = dt;
                DtgTickets.Columns["ت"].DisplayIndex = 0;
                DtgTickets.Columns["Number"].HeaderText = "رقم البطاقة";
                DtgTickets.Columns["OpenDate"].HeaderText = "تاريخ فتح البطاقة";
                DtgTickets.Columns["CloseDate"].HeaderText = "تاريخ إغلاق البطاقة";
                DtgTickets.Columns["PhoneNumber"].HeaderText = "رقم الهاتف";
                DtgTickets.Columns["SoftwareName"].HeaderText = "البرنامج";
                DtgTickets.Columns["UserName"].HeaderText = "الموظف";
                DtgTickets.Columns["CompanyName"].HeaderText = "اسم الشركة";
                DtgTickets.Columns["BranchName"].HeaderText = "الفرع";
                DtgTickets.Columns["Problem"].HeaderText = "المشكلة";
                DtgTickets.Columns["State"].HeaderText = "الحالة";
                DtgTickets.Columns["Revision"].HeaderText = "مراجعة البطاقة";
                DtgTickets.Columns["IsIndexed"].HeaderText = "ترتيب الملفات";
                DtgTickets.Columns["IsClosed"].HeaderText = "الإغلاق";
                DtgTickets.HideUntranslatedColumns();

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

                await _mainRepository.UpdateSession(new SessionInfo(EventType.TicketInProgress));

                long selectedNumber = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Number"].Value.ToString());
                long selectedRevision = Convert.ToInt64(DtgTickets.SelectedRows[0].Cells["Revision"].Value.ToString());
                TicketsView selectedTicket = await _ticketRepository.GetTicketDetailsByByNumberAndRevision(selectedNumber, selectedRevision);
                LblNumber.Text = selectedTicket.Number.ToString();
                LblRevision.Text = selectedTicket.Revision.ToString();
                LblCompany.Text = selectedTicket.CompanyName.ToString();
                LblUser.Text = selectedTicket.UserName.ToString();
                LblPhoneNumber.Text = selectedTicket.PhoneNumber.ToString();
                LblSoftware.Text = selectedTicket.SoftwareName.ToString();
                LblOpenDate.Text = selectedTicket.OpenDate.ToString("yyyy-MM-dd hh:mm tt dddd");
                if (selectedTicket.State != null)
                {
                    TxtProblem.Text = selectedTicket.Problem;
                    TxtRemarks.Text = selectedTicket.Remarks;
                    CombStates.Text = selectedTicket.State;
                    ToggleIsIndexed.Checked = selectedTicket.IsIndexed == "مرتبة";
                    ToggleClosed.Checked = selectedTicket.IsClosed == "مغلقة";
                }
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
                if (Convert.ToInt64(CombTransferedTo.SelectedValue) == SystemConstants.loggedInUser.Id)
                {
                    MessageBox.Show(" !!! لا يمكن تحويل بطاقة لنفس المستخدم الحالي", "محاولة ادخال خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt64(CombTransferedTo.SelectedValue) == 0 & Convert.ToInt64(CombStates.SelectedValue) == 4)
                {
                    MessageBox.Show("! يجب إختيار اسم المستخدم عند تحويل البطاقة", "محاولة ادخال خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt64(CombTransferedTo.SelectedValue) == 0)
                {
                    if (!ToggleClosed.Checked)
                    {
                        DialogResult dr;
                        dr = MessageBox.Show("إغلاق البطاقة ؟؟", "إغلاق", MessageBoxButtons.YesNo);
                        ToggleClosed.Checked = dr == DialogResult.Yes;
                    }
                }
                DialogResult dr2;
                dr2 = MessageBox.Show("هل انت متأكد من الإضافة ؟", "تأكيد", MessageBoxButtons.YesNo);
                if (dr2 == DialogResult.Yes)
                {
                    if (Convert.ToInt64(CombTransferedTo.SelectedValue) == 0 & Convert.ToInt64(CombStates.SelectedValue) != 4)
                    {
                        await _ticketRepository.Update(Convert.ToInt64(LblNumber.Text),
                    Convert.ToInt32(LblRevision.Text),
                    DateTime.Now,
                    Convert.ToInt64(CombStates.SelectedValue),
                    TxtRemarks.Text,
                    TxtProblem.Text,
                    Convert.ToInt32(ToggleRemotely.Checked),
                    ToggleIsIndexed.Checked,
                    ToggleClosed.Checked,
                    Convert.ToInt64(CombTransferedTo.SelectedValue));

                        TicketInfo updatedTicket = await _ticketRepository.GetByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
        Convert.ToInt64(LblRevision.Text));
                        await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.UpdateTicket,
                             updatedTicket.Id, "الرد على بطاقة"));
                    }
                    else if (Convert.ToInt64(CombTransferedTo.SelectedValue) != 0 & Convert.ToInt64(CombStates.SelectedValue) == 4)
                    {
                        TicketInfo ticket = await _ticketRepository.GetByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
                            Convert.ToInt64(LblRevision.Text));
                        ticket.CloseDate = DateTime.Now;
                        ticket.Problem = TxtProblem.Text;
                        ticket.StateId = Convert.ToInt64(CombStates.SelectedValue);
                        ticket.TransferedTo = Convert.ToInt64(CombTransferedTo.SelectedValue);
                        ticket.Remarks = TxtRemarks.Text;
                        ticket.IsIndexed = ToggleIsIndexed.Checked;
                        ticket.Remotely = ToggleRemotely.Checked;
                        ticket.IsClosed = true;

                        await _ticketRepository.UpdateInsertTicket(ticket);
                        TicketInfo updatedTicket = await _ticketRepository.GetByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
        Convert.ToInt64(LblRevision.Text) + 1);
                        await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.UpdateTicket,
                             updatedTicket.Id, "الرد على بطاقة"));

                    }
                    //if (CombStates.Text == "تحويل الى الدعم الفني")
                    //{
                    //    this.Close();
                    //    SystemConstants.TechnicalSupportTask = true;
                    //}
                    await _mainRepository.UpdateSession(new SessionInfo(EventType.DisplayTickets));
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
                CombStates.SelectedValue = 0;
                CombTransferedTo.SelectedValue = 0;
                ToggleIsIndexed.Checked = false;
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

        private void BtnOldTickets_Click(object sender, EventArgs e)
        {
            if (LblCompany.Text == "")
            {
                MessageBox.Show("! يرجى إختيار بطاقة اولاً");
                return;
            }
            DisplayOldTickets displayOldTickets = new DisplayOldTickets(LblCompany.Text);
            displayOldTickets.ShowDialog();
        }

        private void CombStates_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CombStates.SelectedValue) == 4) CombTransferedTo.Visible = true;
            else
            {
                CombTransferedTo.Visible = false;
                FillUsersComboBox();
            }
        }
    }
}
