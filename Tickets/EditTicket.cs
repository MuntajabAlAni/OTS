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
using OTS.Ticketing.Win.Softwares;
using OTS.Ticketing.Win.Users;
using OTS.Ticketing.Win.PhoneNumbers;
using OTS.Ticketing.Win.States;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class EditTicket : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly TicketRepository _ticketRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly ActivityLogRepository _activityLogRepository;
        private readonly SoftwareRepository _softwareRepository;
        private readonly PhoneNumberRepository _phoneNumberRepository;
        private readonly StateRepository _stateRepository;
        private readonly UserRepository _userRepository;
        private TicketInfo _ticketInfo;
        private readonly long _number;
        private readonly long _revision;
        public EditTicket(long number, long revision)
        {
            InitializeComponent();
            _ticketRepository = new TicketRepository();
            _stateRepository = new StateRepository();
            _userRepository = new UserRepository();
            _companyRepository = new CompanyRepository();
            _phoneNumberRepository = new PhoneNumberRepository();
            _softwareRepository = new SoftwareRepository();
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

            _ticketInfo = await _ticketRepository.GetByNumberAndRevision(_number, _revision);
            LblNumber.Text = _ticketInfo.Number.ToString();
            LblRevision.Text = _ticketInfo.Revision.ToString();
            SystemConstants.SelectedCompanyId = _ticketInfo.CompanyId;
            CompanyInfo companyInfo = await _companyRepository.GetById(_ticketInfo.CompanyId);
            LblCompanyName.Text = companyInfo.Name;
            SystemConstants.SelectedPhoneNumberId = _ticketInfo.PhoneNumberId;
            SystemConstants.SelectedSoftware = _ticketInfo.SoftwareId;
            SystemConstants.SelectedUser = _ticketInfo.UserId;
            LblOpenDate.Text = _ticketInfo.OpenDate.ToString();
            TxtProblem.Text = _ticketInfo.Problem != null ? _ticketInfo.Problem.ToString() : "";
            CombStates.SelectedValue = _ticketInfo.StateId;
            CombTransferedTo.SelectedValue = _ticketInfo.TransferedTo;
            TxtRemarks.Text = _ticketInfo.Remarks != null ? _ticketInfo.Remarks.ToString() : "";
            ToggleClosed.Checked = _ticketInfo.IsClosed;
            ToggleIsIndexed.Checked = _ticketInfo.IsIndexed;
            ToggleRemotely.Checked = _ticketInfo.Remotely;

            FillSoftwaresComboBox();
            FillUsersComboBox();
            FillPhoneNumbersComboBox(_ticketInfo.CompanyId);
        }

        private async void FillSoftwaresComboBox()
        {
            try
            {
                CombSoftwares.DisplayMember = "Name";
                CombSoftwares.ValueMember = "Id";
                CombSoftwares.DataSource = await _softwareRepository.GetAll();
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
                CombUsers.DataSource = await _userRepository.GetAll();
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
                var result = await _phoneNumberRepository.GetByCompanyId(companyId);
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
                CombTransferedTo.DataSource = await _userRepository.GetAll();
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
                CombStates.DataSource = await _stateRepository.GetAll();
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
                    TicketInfo ticket = new TicketInfo()
                    {
                        Number = Convert.ToInt64(LblNumber.Text),
                        Revision = Convert.ToInt32(LblRevision.Text),
                        CloseDate = DateTime.Now,
                        StateId = Convert.ToInt64(CombStates.SelectedValue),
                        Remarks = TxtRemarks.Text,
                        Problem = TxtProblem.Text,
                        Remotely = ToggleRemotely.Checked,
                        IsIndexed = ToggleIsIndexed.Checked,
                        IsClosed = ToggleClosed.Checked,
                        TransferedTo = Convert.ToInt64(CombTransferedTo.SelectedValue),
                        PhoneNumberId = Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                        SoftwareId = Convert.ToInt64(CombSoftwares.SelectedValue),
                        UserId = Convert.ToInt64(CombUsers.SelectedValue)
                    };
                    await _ticketRepository.Update(ticket);
                    TicketInfo updatedTicket = await _ticketRepository.GetByNumberAndRevision(Convert.ToInt64(LblNumber.Text),
        Convert.ToInt64(LblRevision.Text));
                    await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.EditTicket,
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

        private async void EditTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (SystemConstants.userRoles.Contains(((long)RoleType.Admin)) |
                    SystemConstants.userRoles.Contains(((long)RoleType.DeleteTicket)))
                {
                    if (MessageBox.Show("هل انت متأكد من الحذف ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        await _ticketRepository.Delete(_ticketInfo);
                        await _activityLogRepository.AddActivityLog(new ActivityLogInfo(ActivityType.DeleteTicket,
                         _ticketInfo.Id, "حذف بطاقة"));
                        this.Close();
                    }
                }
            }
        }
    }
}
