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
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to update", "Update Product",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GlobalVariable.selectedProductID = int.Parse(lvProducts.SelectedItems[0].SubItems[1].Text);
            frmProductsAdd editForm = new frmProductsAdd();
            editForm.ChangeAddToEdit("Edit Product Details", " Edit Product Details", "Update");
            editForm.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Prompts user to select a product if one has not been selected
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to delete", "Delete Product",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Declares variables then checks if AllowDelete stored proc comes back true
            int recordCount = 0;
            GlobalVariable.selectedProductID = int.Parse(lvProducts.SelectedItems[0].SubItems[1].Text);
            string allowDelete = "sp_Products_AllowDeleteProduct";

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlCommand command = new SqlCommand(allowDelete, connection);

            //Add values to stored proc
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductID", GlobalVariable.selectedProductID);
            SqlParameter returnValue = new SqlParameter("@RecordCount", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.Output;
            command.Parameters.Add(returnValue);

            //Opens DB. Executes stored proc. Assigns @RecordCount output to recordCount variable. Closes DB
            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            recordCount = (int)command.Parameters["@RecordCount"].Value;
            connection.Close();

            //If category is being used, prompt user 
            if (recordCount > 0)
            {
                MessageBox.Show("Product is unable to be deleted. Product data is being used.", "Delete Product",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    //If category is unused. Ask for user to confirm deletion of product. Delclare variables. Set SP
                    //Open DB -> Execute Stored Proc -> Commit -> Refresh listview
                    DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                                    "Delete Product?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;

                    GlobalVariable.selectedProductID = int.Parse(lvProducts.SelectedItems[0].SubItems[1].Text);
                    string deleteQuery = "sp_Products_DeleteProduct";
                    SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                    SqlCommand command1 = new SqlCommand(deleteQuery, connection1);

                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@ProductID", GlobalVariable.selectedProductID);

                    connection1.Open();
                    command1.Transaction = connection1.BeginTransaction();
                    command1.ExecuteNonQuery();
                    command1.Transaction.Commit();
                    connection1.Close();

                    lvProducts.Items.Clear();
                    DisplayProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsucessful" + ex);
                }
            }              
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalVariable.productSearchCriteria = "";
            frmProductsSearch productsSearch = new frmProductsSearch();
            productsSearch.ShowDialog();
            lvProducts.Items.Clear();
            DisplayProducts();
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
                                 "FROM Products INNER JOIN ProductTypes ON Products.ProductTypeID = ProductTypes.ProductTypeID ";

            //Search criteria
            selectQuery = selectQuery + GlobalVariable.productSearchCriteria;

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
