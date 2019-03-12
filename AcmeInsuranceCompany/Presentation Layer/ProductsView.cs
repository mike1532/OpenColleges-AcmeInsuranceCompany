using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Added
using System.Data.SqlClient;
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmProductsView : Form
    {
        public frmProductsView()
        {
            InitializeComponent();
        }

        //events
        private void frmProducts_Load(object sender, EventArgs e)
        {            
            DisplayProducts();
        }

        private void frmProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalVariable.selectedProductID = 0;
            frmProductsAdd productsAdd = new frmProductsAdd();
            productsAdd.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProductsAdd editForm = new frmProductsAdd();
            editForm.ChangeAddToEdit("Edit Product Details", " Edit Product Details", "Update");
            editForm.ShowDialog();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO - code to delete selected Product

            //message to show if category is able to be deleted
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this product?",
                                            "Delete Product?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            //add code to check to see if Product is being used in a sale. if being used tell user that it is
            //unable to be deleted. Try/Catch block?
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmProductsSearch productsSearch = new frmProductsSearch();
            productsSearch.ShowDialog();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

        //menu options - needs to be linked up to the appropriate click event
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
            //launches tutorial pdf file stored in resources.resx file            
            String openPDFFile = "Tutorial ver2.0.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::AcmeInsuranceCompany.Properties.Resources.Tutorial_ver2_0);
            System.Diagnostics.Process.Start(openPDFFile);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        /*-----------------------------------------------------------------------------------------------*/

        public void DisplayProducts()
        {
            string selectQuery = "SELECT Products.ProductID, ProductTypes.ProductTypeID, Products.ProductName, Products.YearlyPremium " +
                                 "FROM Products INNER JOIN ProductTypes ON Products.ProductTypeID = ProductTypes.ProductTypeID";

            //TODO ADD SEARCH CRITERIA STRING

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            //Connect to DB. Load info into constructor. Create listview -> add items to lvCategory -> Close connection.
            /*
             * Create listview -> add items to lvCategory -> Close connection. Added the empty 
             * first line to allow for the extra column added at the beginning of the list view. 
             * 
             ***Extra column was added (width of 0) to allow for all headings to be centered, as you cannot 
             *  center the first column in a list view***
             */

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product(int.Parse(reader["ProductID"].ToString()), reader["ProductTypeID"].ToString(),
                                                  reader["ProductName"].ToString(), decimal.Parse(reader["YearlyPremium"].ToString()));

                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(product.ProductID.ToString());
                    listView.SubItems.Add(product.ProductType);
                    listView.SubItems.Add(product.ProductName);
                    listView.SubItems.Add(product.YearlyPremium.ToString("00.00"));

                    lvProducts.Items.Add(listView);
                }
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful" + ex);
            }


        }
    }
}
