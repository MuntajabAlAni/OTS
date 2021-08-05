using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS.Ticketing.Win.States
{
    public partial class AddState : Form
    {
        readonly StateRepository stateRepository = new StateRepository();
        public AddState()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            await stateRepository.AddState(TxtName.Text);
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
