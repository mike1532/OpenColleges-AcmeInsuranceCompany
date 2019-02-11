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
    public partial class frmProductTypesView : Form
    {
        public frmProductTypesView()
        {
            InitializeComponent();
        }

        //events
        private void frmProductTypesView_Load(object sender, EventArgs e)
        {
            //TODO - code to load product types
        }
        private void frmProductTypesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductTypesAdd productTypesAdd = new frmProductTypesAdd();
            productTypesAdd.ShowDialog();
            Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProductTypesAdd editProductTypes = new frmProductTypesAdd();
            editProductTypes.ChangeAddToEdit("Edit Product Type", " Edit Product Type Details", "Update");
            editProductTypes.ShowDialog();
            Hide();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO - code to delete selected category

            //message to show if category is able to be deleted
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this product type?",
                                            "Delete Product Type?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            //add code to check to see if category is being used. if being used tell user that it is
            //unable to be deleted. Try/Catch block?
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmProductTypesSearch productTypesSearch = new frmProductTypesSearch();
            productTypesSearch.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

        //menu to be linked up to the appropriate click event
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
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTutorialScreen tutorial = new frmTutorialScreen();
            tutorial.ShowDialog();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
    }
}
