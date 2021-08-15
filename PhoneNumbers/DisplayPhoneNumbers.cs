using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.PhoneNumbers
{
    public partial class DisplayPhoneNumbers : Form
    {
        readonly PhoneNumberRepository phoneNumberRepository = new PhoneNumberRepository();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        readonly private string _phoneNumber;
        public DisplayPhoneNumbers(string phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
        }

        private async void DisplayPhoneNumbers_Load(object sender, EventArgs e)
        {
            try
            {
                DtgPhoneNumbers.DataSource = await phoneNumberRepository.GetPhoneNumbersBySearch(_phoneNumber);
                DtgPhoneNumbers.Columns["phoneNumber"].HeaderText = "رقم الهاتف";
                DtgPhoneNumbers.Columns["CustomerName"].HeaderText = "اسم الزبون";
                DtgPhoneNumbers.Columns["CompanyId"].HeaderText = "اسم الشركة";
                if (DtgPhoneNumbers.Rows.Count == 1)
                {
                    long id = Convert.ToInt64(DtgPhoneNumbers.Rows[0].Cells["Id"].Value.ToString());
                    PhoneNumberInfo selectedPhoneNumber = await phoneNumberRepository.GetPhoneNumberById(id);
                    SystemConstants.SelectedPhoneNumberId = selectedPhoneNumber.Id;
                    SystemConstants.SelectedCompanyId = selectedPhoneNumber.CompanyId;
                    this.Close();
                }
                if (DtgPhoneNumbers.Rows.Count == 0)
                {
                    MessageBox.Show("عذراً.. هذا الرقم غير معرف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddPhoneNumber addPhoneNumber = new AddPhoneNumber(0, _phoneNumber);
                    addPhoneNumber.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(ex);
            }

        }

        private async void DtgPhoneNumbers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(DtgPhoneNumbers.SelectedRows[0].Cells["Id"].Value.ToString());
                PhoneNumberInfo selectedPhoneNumber = await phoneNumberRepository.GetPhoneNumberById(id);
                SystemConstants.SelectedPhoneNumberId = selectedPhoneNumber.Id;
                SystemConstants.SelectedCompanyId = selectedPhoneNumber.CompanyId;
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

        private void DisplayPhoneNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
