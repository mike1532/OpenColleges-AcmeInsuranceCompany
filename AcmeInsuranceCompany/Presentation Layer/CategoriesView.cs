using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//added
using System.Data.SqlClient;
using AcmeInsuranceCompany.Data_Access_Layer;
using AcmeInsuranceCompany.Business_Logic_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCategoriesView : Form
    {
        public frmCategoriesView()
        {
            InitializeComponent();
        }

        //events
        private void frmCategoriesView_Load(object sender, EventArgs e)
        {
            DisplayCategories();
        }

        private void frmCategoriesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalVariable.selectedCategoryID = 0;
            frmCategoriesAdd categoriesAdd = new frmCategoriesAdd();
            categoriesAdd.ShowDialog();
            lvCategories.Items.Clear();
            DisplayCategories();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*
             * Prompts user for selection if nothing has been selected. Assigns CategoryID to 
             * selectedCategoryID variable. Loads edit screen with selected category information
             */
             if (lvCategories.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please choose a category to update");
                return;
            }

            GlobalVariable.selectedCategoryID = int.Parse(lvCategories.SelectedItems[0].SubItems[1].Text);
            frmCategoriesAdd editForm = new frmCategoriesAdd();
            editForm.ChangeAddToEdit("Edit Category", " Edit Category Details", "Update");
            editForm.ShowDialog();
            lvCategories.Items.Clear();
            DisplayCategories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Prompts user to select category if one has not been selected
            if (lvCategories.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a category to delete");
            }

            //declare variables
            int recordCount = 0;
            GlobalVariable.selectedCategoryID = int.Parse(lvCategories.SelectedItems[0].SubItems[1].Text);
            string allowDelete = "sp_Categories_AllowDeleteCategory";

            SqlConnection connection = ConnectionManager.DatabaseConnection();                       
            SqlCommand command = new SqlCommand(allowDelete, connection);

            //adds values to AllowDelete stored proc
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CategoryID", GlobalVariable.selectedCategoryID);
            SqlParameter ReturnValue = new SqlParameter("@RecordCount", SqlDbType.Int);
            ReturnValue.Direction = ParameterDirection.Output;
            command.Parameters.Add(ReturnValue);

            //Opens DB. Executes stored proc. Assigns @RecordCount output to recordCount variable. Closes DB
            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            recordCount = (int)command.Parameters["@RecordCount"].Value;
            connection.Close();

            //If category is being used, prompt user 
            if (recordCount > 0)
            {
                MessageBox.Show("Category is unable to be deleted. Category is being used.");
            }
            //TODO DELETE

            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            //message to show if category is able to be deleted
           /* DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this category?",
                                            "Delete Category?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;
            //add code to check to see if category is being used. if being used tell user that it is
            //unable to be deleted. Try/Catch block?*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmCategoriesSearch categoriesSearch = new frmCategoriesSearch();
            categoriesSearch.ShowDialog();
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

        /*-------------------------------------------------------------------------------------------*/

        public void DisplayCategories()
        {
            string selectQuery = "SELECT Categories.CategoryID, Categories.Category FROM Categories";
            //TODO - SEARCH CRITERIA

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                //Connect to DB
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Call constructor
                    Category category = new Category(int.Parse(reader["CategoryID"].ToString()), reader["Category"].ToString());

                    /*
                     * Create listview -> add items to lvCategory -> Close connection. Added the empty 
                     * first line to allow for the extra column added at the beginning of the list view. 
                     * 
                     ***Extra column was added (width of 0) to allow for all headings to be centered, as you cannot 
                     *  center the first column in a list view***
                     */

                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(category.CategoryID.ToString());
                    listView.SubItems.Add(category.CategoryType.ToString());

                    lvCategories.Items.Add(listView);
                }

                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
                Application.Exit();
            }
        }
    }
}

