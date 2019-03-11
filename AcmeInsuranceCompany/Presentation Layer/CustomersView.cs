using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//access DB/Folders
using System.Data.SqlClient;
using AcmeInsuranceCompany.Data_Access_Layer;
using AcmeInsuranceCompany.Business_Logic_Layer;

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
            DisplayCustomers();
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
            GlobalVariable.selectedCustomerID = 0;
            frmCustomersAdd customersAdd = new frmCustomersAdd();
            customersAdd.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*
             * Prompts user for selection if nothing has been selected. Assigns CustomerID to 
             * selectedCustomerID variable. Loads edit screen with selected customers information
             */

            if(lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to update");
                return;
            }

            GlobalVariable.selectedCustomerID = int.Parse(lvCustomers.SelectedItems[0].SubItems[1].Text);
            frmCustomersAdd editForm = new frmCustomersAdd();
            editForm.ChangeAddToEdit("Edit Customer Details", " Edit Customer Details", "Update");            
            editForm.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*
             * Checks that user has selected a customer to delete. Confirms that the user wants to continue
             * with the deletion. Connects to DB, runs Stored Proc, Displays updated list.
            */
            if(lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }
            
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                            "Delete Customer Record?", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.No)
                return;

            GlobalVariable.selectedCustomerID = int.Parse(lvCustomers.SelectedItems[0].SubItems[1].Text);
            string deleteQuery = "sp_Customers_DeleteCustomer";
            SqlConnection connection = ConnectionManager.DatabaseConnection();            
            SqlCommand command = new SqlCommand(deleteQuery, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerID", GlobalVariable.selectedCustomerID);

            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Commit();
            connection.Close();

            lvCustomers.Items.Clear();
            DisplayCustomers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalVariable.customerSearchCriteria = "";
            frmCustomersSearch customersSearch = new frmCustomersSearch();
            customersSearch.ShowDialog();
            lvCustomers.Items.Clear();
            DisplayCustomers();
                            
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
            //launches tutorial pdf file stored in resources.resx file            
            String openPDFFile = "Tutorial ver2.0.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::AcmeInsuranceCompany.Properties.Resources.Tutorial_ver2_0);
            System.Diagnostics.Process.Start(openPDFFile);
        }
        /*-----------------------------------------------------------------------------------------------*/

        //displays customers to View Customers screen
        public void DisplayCustomers()
        {
            string selectQuery = "SELECT Customers.CustomerID, Categories.Category, Customers.FirstName, " +
                "Customers.LastName, Customers.Address, Customers.Suburb, Customers.State, Customers.Postcode," +
                " Customers.Gender, Customers.BirthDate FROM Customers INNER JOIN Categories " +
                "ON Customers.CategoryID = Categories.CategoryID";

            //search criteria
            selectQuery = selectQuery + " " + GlobalVariable.customerSearchCriteria;

            //Connects to DB and instantiates DataReaderObject
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                //opens connection, passes query to command, executes query through DataReaderObject
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                //define variable list items (Gender - defaults to Male, sets to Female if F)
                while (reader.Read())
                {
                    string gender = "Male";
                    if (reader["Gender"].ToString() == "F")
                    {
                        gender = "Female";
                    }
                    //call contructor
                    Customer customer = new Customer(int.Parse(reader["CustomerID"].ToString()), reader["Category"].ToString(), reader["FirstName"].ToString(),
                                        reader["LastName"].ToString(), reader["Address"].ToString(), reader["Suburb"].ToString(),
                                        reader["State"].ToString(), int.Parse(reader["Postcode"].ToString()), gender,
                                        reader["BirthDate"].ToString());

                    //creates listview then adds items to lvCustomers
                    /*
                        Added the empty first line to allow for the extra column added at the beginning
                        of the list view. Extra column was added (width of 0) to allow for all headings to 
                        be centered, as you cannot center the first column in a list view.
                     */

                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(customer.CustomerID.ToString());
                    listView.SubItems.Add(customer.Category);
                    listView.SubItems.Add(customer.FirstName);
                    listView.SubItems.Add(customer.LastName);
                    listView.SubItems.Add(customer.Address);
                    listView.SubItems.Add(customer.Suburb);
                    listView.SubItems.Add(customer.State);
                    listView.SubItems.Add(customer.Postcode.ToString());
                    listView.SubItems.Add(customer.Gender);
                    DateTime bday = DateTime.Parse(customer.BirthDate);
                    listView.SubItems.Add(bday.ToString("dd/MM/yyyy"));

                    lvCustomers.Items.Add(listView);
                }
                //if null, close reader and connection
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
