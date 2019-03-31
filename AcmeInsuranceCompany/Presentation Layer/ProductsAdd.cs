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
using System.Globalization;
using System.Text.RegularExpressions;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmProductsAdd : Form
    {
        public frmProductsAdd()
        {
            InitializeComponent();
        }

        //RegEx to check that a number has been entered
        Regex YearlyPremium = new Regex(@"^[0-9]*$");

        //events
        private void frmProductsAdd_Load(object sender, EventArgs e)
        {
            //Preloads Product Types into form. Opens DB. Loads into Form. Closes DB
            string selectQuery = "SELECT * FROM ProductTypes";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbProductType.Items.Add(reader["ProductTypeID"].ToString());
                    cbProductType.Items.Add(reader["ProductType"].ToString());
                }
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful " + ex);
            }

            //Loads selected product into edit form
            if (GlobalVariable.selectedProductID > 0)
            {

                selectQuery = "SELECT * FROM Products WHERE ProductID = " + GlobalVariable.selectedProductID.ToString();
                SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                SqlDataReader reader1 = null;

                try
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(selectQuery, connection1);
                    reader1 = command1.ExecuteReader();
                    reader1.Read();

                    txtProductID.Text = reader1["ProductID"].ToString();
                    txtProductName.Text = reader1["ProductName"].ToString();
                    cbProductType.SelectedIndex = int.Parse(reader1["ProductTypeID"].ToString()) - 1;

                    //Makes input into txtYearlyPremium a currency value ($00.00)
                    string yearlyPremium = reader1["YearlyPremium"].ToString();
                    decimal.TryParse(yearlyPremium, out decimal output);
                    txtYearlyPremium.Text = output.ToString("C");


                    reader1.Close();
                    connection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }
        }

        private void frmProductsAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProductsView productsView = new frmProductsView();
            productsView.Show();
            Hide();
        }

        //button events
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInfo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checks Input, Creates Product Object, Adds values to Stored Proc, Connects to DB, Execute SP, 
            //Close Connection
            if (CheckInput() == true)
                return;

            Product product = new Product(GlobalVariable.selectedProductID, lbProductType.Items[cbProductType.SelectedIndex].ToString(),
                                          txtProductName.Text, txtYearlyPremium.Text);

            string addQuery;

            if (GlobalVariable.selectedProductID == 0)
            {
                addQuery = "sp_Products_CreateProduct";
            }
            else
            {
                addQuery = "sp_Products_UpdateProduct";
            }

            SqlConnection connection1 = ConnectionManager.DatabaseConnection();
            SqlCommand command1 = new SqlCommand(addQuery, connection1);
            command1.CommandType = CommandType.StoredProcedure;

            if (GlobalVariable.selectedProductID != 0)
                command1.Parameters.AddWithValue("@ProductID", product.ProductID);
            command1.Parameters.AddWithValue("@ProductTypeID", product.ProductType);
            command1.Parameters.AddWithValue("@ProductName", product.ProductName);
            command1.Parameters.AddWithValue("@YearlyPremium", product.YearlyPremium);

            if (GlobalVariable.selectedProductID == 0)
            {
                command1.Parameters.AddWithValue("@NewProductID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }

            connection1.Open();
            command1.Transaction = connection1.BeginTransaction();
            command1.ExecuteNonQuery();
            command1.Transaction.Commit();
            connection1.Close();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //txtYearlyPremium.Leave -= txtYearlyPremium_Leave; 
            Close();
        }

        /*-----------------------------------------------------------------------------------------------*/
        //change from add to edit form
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }

        public void ClearInfo()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cbProductType.SelectedIndex = -1;
            txtYearlyPremium.Clear();
        }

        public bool CheckInput()
        {
            if (String.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please enter a product name", "Add New Product", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(cbProductType.Text))
            {
                MessageBox.Show("Please enter the product type", "Add New Product", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please enter a product name", "Add New Product", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }

            if (String.IsNullOrEmpty(txtYearlyPremium.Text))
            {
                MessageBox.Show("Please enter the yearly premium", "Edit Sale Details", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            else if (!YearlyPremium.IsMatch(txtYearlyPremium.Text))
            {
                MessageBox.Show("Yearly Premium must be a numerical value.", "Edit Sale Details", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            else
            {
                double YP = double.Parse(txtYearlyPremium.Text, NumberStyles.Currency);
                txtYearlyPremium.Text = YP.ToString();
                return false;
            }

        }
    }
}


