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
    public partial class frmSalesAdd : Form
    {
        public frmSalesAdd()
        {
            InitializeComponent();
        }

        //load/close events
        private void frmSalesAdd_Load(object sender, EventArgs e)
        {
            //TODO - Load event
        }
        private void frmSalesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesView salesView = new frmSalesView();
            salesView.Show();
            Hide();
        }
        
        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO - code to add sale
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO - Code to clear entered data
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //change from add to edit form
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            btnClear.Visible = false;
            txtYearlyPremium.Enabled = true;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }
    }
}
