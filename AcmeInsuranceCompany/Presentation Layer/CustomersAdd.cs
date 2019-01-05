using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCustomersAdd : Form
    {
        public frmCustomersAdd()
        {
            InitializeComponent();
        }
               
        //button click events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //code to add customer
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //code to clear entered data
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //load/close events
        private void frmCustomersAdd_Load(object sender, EventArgs e)
        {
            //TODO - load event
        }
        private void frmCustomersAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }

        //change from add to edit
        public void ChangeAddToEdit (string form, string title, string button)
        {
            this.Text = form;
            lblCustomersAddTitle.Text = title;
            btnAdd.Text = button;
        }
        
    }
}
