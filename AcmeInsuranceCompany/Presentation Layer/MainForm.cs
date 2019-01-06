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
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void productTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesView salesView = new frmSalesView();
            salesView.Show();
            Hide();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
