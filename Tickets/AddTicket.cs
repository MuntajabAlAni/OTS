using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.Tickets
{
    public partial class AddTicket : Form
    {
        public TicketRepository ticketRepository = new TicketRepository();

        public AddTicket()
        {
            InitializeComponent();
        }

        private void AddTicket_Load(object sender, EventArgs e)
        {
            TxtNumber.Text = ticketRepository.GetLastTicketNumber();
            FillCompaniesComboBox();
            FillSoftwaresComboBox();
            FillEmployeesComboBox();
            FillPhoneNumbersComboBox();
        }
        private void FillCompaniesComboBox()
        {
            CombCompanies.DataSource = ticketRepository.GetAllCompanies();
            CombCompanies.DisplayMember = "Name";
            CombCompanies.ValueMember = "Id";
        }
        private void FillSoftwaresComboBox()
        {
            CombSoftware.DataSource = ticketRepository.GetAllSoftwares();
            CombSoftware.DisplayMember = "Name";
            CombSoftware.ValueMember = "Id";
        }
        private void FillEmployeesComboBox()
        {
            CombEmployee.DataSource = ticketRepository.GetAllEmployees();
            CombEmployee.DisplayMember = "displayName";
            CombEmployee.ValueMember = "Id";
        }
        private void FillPhoneNumbersComboBox()
        {
            CombPhoneNumbers.DataSource = ticketRepository.GetPhoneNumberOnSelectedCompanyId(Convert.ToInt64(CombCompanies.SelectedValue));
            CombPhoneNumbers.DisplayMember = "phoneNumber";
            CombPhoneNumbers.ValueMember = "Id";
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ticketRepository.AddTicket(Convert.ToInt64(TxtNumber.Text),
                Convert.ToInt32(TxtRevision.Text),
                Convert.ToInt64(CombCompanies.SelectedValue),
                Convert.ToInt64(CombPhoneNumbers.SelectedValue),
                Convert.ToInt64(CombSoftware.SelectedValue),
                Convert.ToInt64(CombEmployee.SelectedValue));
            this.Close();
        }
    }
}
