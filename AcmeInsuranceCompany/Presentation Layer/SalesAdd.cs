/*
 * Open Colleges - Module 9 Part B Assessment - Database Program for Acme Insurance Company
 * Author - Mike Ormond
 * 
 * The following source code can be used as a learning tool. Please do not submit as your own work.
 * 
 * ©2019
 */

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
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmSalesAdd : Form
    {
        public frmSalesAdd()
        {
            InitializeComponent();
        }

        //form events
        private void frmSalesAdd_Load(object sender, EventArgs e)
        {            
            LoadCustomerInfo();
            LoadProductInfo();

            //Populates the edit form with selected information
            if (GlobalVariable.selectedSaleID > 0)
            {
                string selectQuery = "SELECT Sales.SaleID, CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName, " +
                                      "Products.ProductName, Sales.Payable, Products.YearlyPremium, Sales.StartDate FROM Sales " +
                                      "INNER JOIN Customers on Sales.CustomerID = Customers.CustomerID " +
                                      "INNER JOIN Products on Sales.ProductID = Products.ProductID " +
                                      "WHERE SaleID = " + GlobalVariable.selectedSaleID.ToString();
                SqlConnection connection = ConnectionManager.DatabaseConnection();

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(selectQuery, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    txtSaleID.Text = reader["SaleID"].ToString();

                    //Takes the customers name, finds the index of the name in the combo box list and then sets 
                    //to selected index of combo box. 
                    string customer = reader["CustomerName"].ToString();
                    int customerIndex = cbCustomer.Items.IndexOf(customer);
                    cbCustomer.SelectedIndex = customerIndex;

                    //Then does the same for the product name
                    string product = reader["ProductName"].ToString();
                    int productIndex = cbProduct.Items.IndexOf(product);
                    cbProduct.SelectedIndex = productIndex;

                    //Defines payable list options
                    switch (reader["Payable"].ToString())
                    {
                        case "F":
                            cbPremiumPaid.Text = "Fortnightly";
                            break;
                        case "M":
                            cbPremiumPaid.Text = "Monthly";
                            break;
                        default:
                            cbPremiumPaid.Text = "Yearly";
                            break;
                    }

                    dateTimePickerPremiumStartDate.Text = reader["StartDate"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }
        }

        private void frmSalesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSalesView salesView = new frmSalesView();
            salesView.Show();
            Hide();
        }
        
        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectQuery = "SELECT Products.YearlyPremium FROM Products WHERE ProductID = @MYVALUE";
            SqlConnection connection = ConnectionManager.DatabaseConnection();

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.Add("@MYVALUE", SqlDbType.Int).Value = int.Parse(lbProduct.Items[cbProduct.SelectedIndex].ToString());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string yearlyPremium = reader["YearlyPremium"].ToString();
                    decimal.TryParse(yearlyPremium, out decimal output);
                    txtYearlyPremium.Text = output.ToString("C");
                }
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }           
        }

        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validates input -> if data is valid, create sale object. If not, shows applicable message.
            if (CheckInput() == true)
               return;
                        
            cbCustomer.SelectedIndex = cbCustomer.FindStringExact(cbCustomer.Text);

            Sale sale = new Sale(GlobalVariable.selectedSaleID, lbCustomer.Items[cbCustomer.SelectedIndex].ToString(), lbProduct.Items[cbProduct.SelectedIndex].ToString(),
                                txtYearlyPremium.Text, cbPremiumPaid.Text, DateTime.Parse(dateTimePickerPremiumStartDate.Text));

            /*
             * Calls create/update sales stored proc
             * Sets values into SP
             * Commit to DB -> Close connection
             */

            string addquery;

            if (GlobalVariable.selectedSaleID == 0)
            {
                addquery = "sp_Sales_CreateSale";
            }
            else
            {
                addquery = "sp_Sales_UpdateSale";
            }

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlCommand command = new SqlCommand(addquery, connection);
            command.CommandType = CommandType.StoredProcedure;

            if (GlobalVariable.selectedSaleID != 0)
                command.Parameters.AddWithValue("@SaleID", sale.SaleID);
            command.Parameters.AddWithValue("@CustomerID", sale.CustomerName);
            command.Parameters.AddWithValue("@ProductID", sale.ProductName);
            command.Parameters.AddWithValue("@Payable", sale.PremiumPaid);
            command.Parameters.AddWithValue("@StartDate", sale.StartDate.ToString("dd/MMM/yyyy"));

            if (GlobalVariable.selectedSaleID == 0)
            {
                command.Parameters.AddWithValue("@NewSaleID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }

            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Commit();
            connection.Close();
            Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {

            GlobalVariable.selectedCustomerID = 0;

            frmCustomersAdd customersAdd = new frmCustomersAdd();
            customersAdd.ShowDialog();

            //Refreshes combo boxes with updated customer list (if new customer button is used in the new sales screen
            LoadCustomerInfo();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {

            GlobalVariable.selectedProductID = 0;

            frmProductsAdd productsAdd = new frmProductsAdd();
            productsAdd.ShowDialog();

            //Refreshes combo boxes with updated product list (if new customer button is used in the new sales screen
            LoadProductInfo();
        }

        /*-------------------------------------------------------------------------------------------------*/
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

            btnNewCustomer.Visible = false;
            btnNewProduct.Visible = false;
        }

        private void ClearInfo()
        {
            txtSaleID.Clear();
            cbCustomer.SelectedIndex = -1;
            cbProduct.SelectedIndex = -1;
            txtYearlyPremium.Clear();
            cbPremiumPaid.SelectedIndex = -1;
            dateTimePickerPremiumStartDate.ResetText();
        }

        private bool CheckInput()
        {
            if (String.IsNullOrEmpty(cbCustomer.Text))
            {
                MessageBox.Show("Please select a customer", "Add New Sale", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }

            if (String.IsNullOrEmpty(cbProduct.Text))
            {
                MessageBox.Show("Please select a product", "Add New Sale", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return true;
            }

            //Checks if empty. Then checks if the number can be parsed to currency value.
            if (String.IsNullOrEmpty(txtYearlyPremium.Text))
            {
                MessageBox.Show("Please enter the product's yearly premium", "Add New Product", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            else if (!double.TryParse(txtYearlyPremium.Text, NumberStyles.Currency, null, out double value))
            {
                MessageBox.Show("Yearly Premium must be a numerical value.", "Add New Product", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return true;
            }
            else
            {
                txtYearlyPremium.Text = value.ToString();
            }

            if (String.IsNullOrEmpty(cbPremiumPaid.Text))
            {
                MessageBox.Show("Please select when the premium is to be paid", "Add New Sale", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return true;
            }

            if (String.IsNullOrEmpty(dateTimePickerPremiumStartDate.Text))
            {
                MessageBox.Show("Please choose a start date", "Add New Sale", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return true;
            }

            return false;
        }      

        private void LoadCustomerInfo()
        {
            cbCustomer.Items.Clear();
            lbCustomer.Items.Clear();

            //Load Customers Info into form
            string customerQuery = "SELECT Customers.CustomerID, CONCAT(Customers.FirstName,' ',Customers.LastName) AS CustomerName FROM Customers";
            SqlConnection customerConnection = ConnectionManager.DatabaseConnection();

            //Opens connection, loads in customers into category boxes.
            try
            {
                //Loads Customers
                customerConnection.Open();
                SqlCommand customerCommand = new SqlCommand(customerQuery, customerConnection);
                SqlDataReader customerReader = customerCommand.ExecuteReader();

                while (customerReader.Read())
                {
                    lbCustomer.Items.Add(customerReader["CustomerID"].ToString());
                    cbCustomer.Items.Add(customerReader["CustomerName"].ToString());
                }
                if (customerReader != null)
                    customerReader.Close();
                customerConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }
        }

        private void LoadProductInfo()
        {
            cbProduct.Items.Clear();
            lbProduct.Items.Clear();

            string productQuery = "SELECT Products.ProductID, Products.ProductName FROM Products";                        
            SqlConnection productConnection = ConnectionManager.DatabaseConnection();

            try
            {
                //Loads Products
                productConnection.Open();
                SqlCommand productCommand = new SqlCommand(productQuery, productConnection);
                SqlDataReader productReader = productCommand.ExecuteReader();

                while (productReader.Read())
                {
                    lbProduct.Items.Add(productReader["ProductID"].ToString());
                    cbProduct.Items.Add(productReader["ProductName"].ToString());
                }
                if (productReader != null)
                    productReader.Close();
                productConnection.Close();
            }        
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }
        }
    }
}
