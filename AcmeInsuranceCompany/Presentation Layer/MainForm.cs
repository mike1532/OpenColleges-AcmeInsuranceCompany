using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//allows access to the presentation layer
//using AcmeInsuranceCompany.Presentation_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        //menu options
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }

        //buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
