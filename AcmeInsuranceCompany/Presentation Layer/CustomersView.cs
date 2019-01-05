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
    public partial class frmCustomersView : Form
    {
        public frmCustomersView()
        {
            InitializeComponent();
        }

        //TODO - Load/Closing events
        private void frmCustomersView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void frmCustomersView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        //TODO Click events for buttons    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomersAdd customersAdd = new frmCustomersAdd();
            customersAdd.ShowDialog();
            Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //TODO - code to update selected customer record
            frmCustomersAdd editForm = new frmCustomersAdd();
            editForm.ChangeAddToEdit("Edit Customer Details", " Edit Customer Details", "Update");            
            editForm.ShowDialog();
            Hide();            
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO - code to delete selected customer record
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                            "Delete Customer Record?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO - code to search records
            frmCustomersSearch customersSearch = new frmCustomersSearch();
            customersSearch.ShowDialog();
                            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

       
    }
}
