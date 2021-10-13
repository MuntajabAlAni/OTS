using NLog;
using OTS.Ticketing.Win.Companies;
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

namespace OTS.Ticketing.Win.Tickets
{
    public partial class EditTicket : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly TicketRepository _ticketRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private readonly long _number;
        private readonly long _revision;
        public EditTicket(long number, long revision)
        {
            InitializeComponent();
            _ticketRepository = new TicketRepository();
            _activityLogRepository = new ActivityLogRepository();
            _number = number;
            _revision = revision;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void EditTicket_Load(object sender, EventArgs e)
        {

            FillTransferedToComboBox();
            FillStatesComboBox();

            TicketInfo ticketInfo = await _ticketRepository.GetTicketByNumberAndRevision(_number, _revision);
            LblNumber.Text = ticketInfo.Number.ToString();
            LblRevision.Text = ticketInfo.Revision.ToString();
            SystemConstants.SelectedCompanyId = ticketInfo.CompanyId;
            CompanyInfo companyInfo = await _ticketRepository.GetCompanyById(ticketInfo.CompanyId);
            LblCompanyName.Text = companyInfo.Name;
            SystemConstants.SelectedPhoneNumberId = ticketInfo.PhoneNumberId;
            SystemConstants.SelectedSoftware = ticketInfo.SoftwareId;
            SystemConstants.SelectedUser = ticketInfo.UserId;
            LblOpenDate.Text = ticketInfo.OpenDate.ToString();
            TxtProblem.Text = ticketInfo.Problem != null ? ticketInfo.Problem.ToString() : "";
            CombStates.SelectedValue = ticketInfo.StateId;
            CombTransferedTo.SelectedValue = ticketInfo.TransferedTo;
            TxtRemarks.Text = ticketInfo.Remarks != null ? ticketInfo.Remarks.ToString() : "";
            ToggleClosed.Checked = ticketInfo.IsClosed;
            ToggleIsIndexed.Checked = ticketInfo.IsIndexed;
            ToggleRemotely.Checked = ticketInfo.Remotely;

            FillSoftwaresComboBox();
            FillUsersComboBox();
            FillPhoneNumbersComboBox(ticketInfo.CompanyId);
        }

        private async void FillSoftwaresComboBox()
        {
            try
            {
                CombSoftwares.DisplayMember = "Name";
                CombSoftwares.ValueMember = "Id";
                CombSoftwares.DataSource = await _ticketRepository.GetAllSoftwares();
                CombSoftwares.SelectedValue = SystemConstants.SelectedSoftware;
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
                CombUsers.DisplayMember = "displayName";
                CombUsers.ValueMember = "Id";
                CombUsers.DataSource = await _ticketRepository.GetAllUsers();
                CombUsers.SelectedValue = SystemConstants.SelectedUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillPhoneNumbersComboBox(long companyId)
        {
            try
            {
                //companyId = CombCompanies.SelectedValue != null ? Convert.ToInt64(CombCompanies.SelectedValue) : 0;
                var result = await _ticketRepository.GetPhoneNumbersOnSelectedCompanyId(companyId);
                if (result.Count != 0)
                {
                    CombPhoneNumbers.DisplayMember = "phoneNumber";
                    CombPhoneNumbers.ValueMember = "Id";
                    CombPhoneNumbers.DataSource = result;
                    CombPhoneNumbers.SelectedValue = SystemConstants.SelectedPhoneNumberId;
                }
                else CombPhoneNumbers.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }
        private async void FillTransferedToComboBox()
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
                    DialogResult dr;
                    dr = MessageBox.Show("إغلاق البطاقة ؟؟", "إغلاق", MessageBoxButtons.YesNo);
                    ToggleClosed.Checked = dr == DialogResult.Yes;
                }
                DialogResult dr2;
                dr2 = MessageBox.Show("هل انت متأكد من الإضافة ؟", "تأكيد", MessageBoxButtons.YesNo);
                if (dr2 == DialogResult.Yes)
                {
                    await _ticketRepository.UpdateEntireTicket(Convert.ToInt64(LblNumber.Text),
               Convert.ToInt32(LblRevision.Text),
               DateTime.Now,
               Convert.ToInt64(CombStates.SelectedValue),
               TxtRemarks.Text,
               TxtProblem.Text,
               Convert.ToInt32(ToggleRemotely.Checked),
               ToggleIsIndexed.Checked,
               ToggleClosed.Checked,
               Convert.ToInt64(CombTransferedTo.SelectedValue),
               Convert.ToInt64(CombPhoneNumbers.SelectedValue),
               Convert.ToInt64(CombSoftwares.SelectedValue),
               Convert.ToInt64(CombUsers.SelectedValue));
                    TicketInfo updatedTicket = await _ticketRepository.GetTicketByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
        Convert.ToInt64(LblRevision.Text));
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo( ActivityType.EditTicket,
                         updatedTicket.Id, "تعديل بطاقة"));
                    //todo: update model !! activityLog Affected ID
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }
        }
    }
}
