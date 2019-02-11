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

        //events
        private void frmCustomersView_Load(object sender, EventArgs e)
        {
            //code to load customers data
        }
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

        //File menu options - needs to be linked up to the appropriate click event
        private void mainScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriesView categoriesView = new frmCategoriesView();
            categoriesView.Show();
            Hide();
        }
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductsView productsView = new frmProductsView();
            productsView.Show();
            Hide();
        }
        private void productTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductTypesView productTypesView = new frmProductTypesView();
            productTypesView.Show();
            Hide();
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

        //Help menu options
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }              
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTutorialScreen tutorial = new frmTutorialScreen();
            tutorial.ShowDialog();
        }


    }
}
