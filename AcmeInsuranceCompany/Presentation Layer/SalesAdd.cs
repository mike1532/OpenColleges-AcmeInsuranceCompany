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
            LoadInfo();
           // ProductPremiumLink();
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

                command.Parameters.Add("@MYVALUE", SqlDbType.Int).Value = cbProduct.SelectedIndex + 1;
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
            frmCustomersAdd frmCustomers = new frmCustomersAdd();
            frmCustomers.ShowDialog();
            //Refreshes combo boxes with updated customer list (if new customer button is used in the new sales screen
            LoadInfo();            
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

            if (String.IsNullOrEmpty(txtYearlyPremium.Text))
            {
                MessageBox.Show("Please enter the product's yearly premium", "Add New Product", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            else if(!double.TryParse(txtYearlyPremium.Text,NumberStyles.Currency, null, out double value))
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
        
        private void LoadInfo()
        {
            cbCustomer.Items.Clear();
            cbProduct.Items.Clear();

            //TODO - Load Customers/Products/into form
            string customerQuery = "SELECT Customers.CustomerID, CONCAT(Customers.FirstName,' ',Customers.LastName) AS CustomerName FROM Customers";
            string productQuery = "SELECT Products.ProductID, Products.ProductName FROM Products";

            SqlConnection customerConnection = ConnectionManager.DatabaseConnection();
            SqlConnection productConnection = ConnectionManager.DatabaseConnection();

            SqlDataReader customerReader = null;
            SqlDataReader productReader = null;

            //Opens connection, loads in customers, products into category boxes.
            try
            {
                //Loads Customers
                customerConnection.Open();
                SqlCommand customerCommand = new SqlCommand(customerQuery, customerConnection);
                customerReader = customerCommand.ExecuteReader();

                while (customerReader.Read())
                {
                    lbCustomer.Items.Add(customerReader["CustomerID"].ToString());
                    cbCustomer.Items.Add(customerReader["CustomerName"].ToString());
                }
                if (customerReader != null)
                    customerReader.Close();
                customerConnection.Close();

                //Loads Products
                productConnection.Open();
                SqlCommand productCommand = new SqlCommand(productQuery, productConnection);
                productReader = productCommand.ExecuteReader();

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
