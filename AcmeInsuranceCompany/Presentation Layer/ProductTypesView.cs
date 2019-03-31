using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//ADDED
using System.Data.SqlClient;
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;

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
            DisplayProductTypes();
        }

        private void frmProductTypesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalVariable.selectedProductTypeID = 0;
            frmProductTypesAdd productTypesAdd = new frmProductTypesAdd();
            productTypesAdd.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
            Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*
            * Prompts user for selection if nothing has been selected. Assigns ProductTypeID to 
            * selectedProductTypeID variable. Loads edit screen with selected product type's information
            */

            if (lvProductTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product type to update", "Update Product Type",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GlobalVariable.selectedProductTypeID = int.Parse(lvProductTypes.SelectedItems[0].SubItems[1].Text);
            frmProductTypesAdd editProductTypes = new frmProductTypesAdd();
            editProductTypes.ChangeAddToEdit("Edit Product Type", " Edit Product Type Details", "Update");
            editProductTypes.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Prompts user to select a product type if one has not been selected
            if (lvProductTypes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product type to delete", "Delete Product Type",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Declares variables and checks if AllowDelete stored proc comes back true
            int recordCount = 0;
            GlobalVariable.selectedProductTypeID = int.Parse(lvProductTypes.SelectedItems[0].SubItems[1].Text);
            string allowDelete = "sp_ProductTypes_AllowDeleteProductType";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlCommand command = new SqlCommand(allowDelete, connection);

            //Add values to stored proc
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductTypeID", GlobalVariable.selectedProductTypeID);
            SqlParameter returnValue = new SqlParameter("@RecordCount", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.Output;
            command.Parameters.Add(returnValue);

            //Opens DB. Executes stored proc. Assigns @RecordCount output to recordCount variable. Closes DB
            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Commit();
            recordCount = (int)command.Parameters["@RecordCount"].Value;
            connection.Close();

            //If category is being used, prompt user
            if (recordCount > 0)
            {
                MessageBox.Show("Product type is unable to be deleted. Product type data is being used.", "Delete Product Type",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //If category is unused. Ask for user to confirm deletion of product. Delclare variables. Set SP
                    //Open DB -> Execute Stored Proc -> Commit -> Refresh listview
                    DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                                    "Delete Product Type?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;

                    GlobalVariable.selectedProductTypeID = int.Parse(lvProductTypes.SelectedItems[0].SubItems[1].Text);
                    string deleteQuery = "sp_ProductTypes_DeleteProductType";
                    SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                    SqlCommand command1 = new SqlCommand(deleteQuery, connection1);

                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@ProductTypeID", GlobalVariable.selectedProductTypeID);

                    connection1.Open();
                    command1.Transaction = connection1.BeginTransaction();
                    command1.ExecuteNonQuery();
                    command1.Transaction.Commit();
                    connection1.Close();

                    lvProductTypes.Items.Clear();
                    DisplayProductTypes();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalVariable.productTypeSearchCriteria = "";
            frmProductTypesSearch productTypesSearch = new frmProductTypesSearch();
            productTypesSearch.ShowDialog();
            lvProductTypes.Items.Clear();
            DisplayProductTypes();
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

        /*----------------------------------------------------------------------------------------------------*/

        public void DisplayProductTypes()
        {
            string selectQuery = "SELECT ProductTypes.ProductTypeID, ProductTypes.ProductType FROM ProductTypes ";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            //SEARCH CRITERIA
            selectQuery = selectQuery + GlobalVariable.productTypeSearchCriteria;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Call constructor
                    ProductType productType = new ProductType(int.Parse(reader["ProductTypeID"].ToString()), reader["ProductType"].ToString());

                    //Creates listView then adds items to lvProductTypes
                    /*
                       Added the empty first line to allow for the extra column added at the beginning
                       of the list view. Extra column was added (width of 0) to allow for all headings to 
                       be centered, as you cannot center the first column in a list view.
                    */

                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(productType.ProductTypeID.ToString());
                    listView.SubItems.Add(productType.ProductName);

                    lvProductTypes.Items.Add(listView);
                }

                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unsucessful " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
