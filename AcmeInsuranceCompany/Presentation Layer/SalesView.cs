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
    public partial class frmSalesView : Form
    {
        public frmSalesView()
        {
            InitializeComponent();
        }
        //load/closing events
        private void frmSalesView_Load(object sender, EventArgs e)
        {
            //code to load sales data
        }
        private void frmSalesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void frmSalesView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSalesAdd salesAdd = new frmSalesAdd();
            salesAdd.ShowDialog();
            Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmSalesAdd editForm = new frmSalesAdd();
            editForm.ChangeAddToEdit("Edit Sale Details", " Edit Sale Details", "Update");            
            editForm.ShowDialog();
            Hide();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                           "Delete Sale Record?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSalesSearch salesSearch = new frmSalesSearch();
            salesSearch.ShowDialog();            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }


    }
}
