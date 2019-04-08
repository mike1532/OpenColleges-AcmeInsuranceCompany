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
//ADDED
using System.Data.SqlClient;
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmProductTypesAdd : Form
    {
        public frmProductTypesAdd()
        {
            InitializeComponent();
        }

        //events 
        private void frmProductTypesAdd_Load(object sender, EventArgs e)
        {
            //Populate edit from with selected information
            if (GlobalVariable.selectedProductTypeID > 0)
            {
                string selectQuery = "SELECT * FROM ProductTypes WHERE ProductTypeID = " + GlobalVariable.selectedProductTypeID.ToString();
                SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                SqlDataReader reader1 = null;

                try
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(selectQuery, connection1);
                    reader1 = command1.ExecuteReader();
                    reader1.Read();

                    txtProductTypeID.Text = reader1["ProductTypeID"].ToString();
                    txtProductType.Text = reader1["ProductType"].ToString();

                    reader1.Close();
                    connection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful " + ex);
                }
            }
        }

        private void frmProductTypesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProductTypesView productTypesView = new frmProductTypesView();
            productTypesView.Show();
            Hide();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validates input data, if data is valid -> create productType object
            if (CheckInput() == true)
                return;

            ProductType productType = new ProductType(GlobalVariable.selectedProductTypeID, txtProductType.Text);

            /*
             * Calls Add/Update product type stored proc
             * Sets values into SP
             * Open DB, commit to DB, Close DB             
             */
            string addQuery;
           

            if (GlobalVariable.selectedProductTypeID == 0)
            {
                addQuery = "sp_ProductTypes_CreateProductType";
            }
            else
            {
                addQuery = "sp_ProductTypes_UpdateProductType";
            }

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlCommand command = new SqlCommand(addQuery, connection);

            command.CommandType = CommandType.StoredProcedure;
            if (GlobalVariable.selectedProductTypeID != 0)
                command.Parameters.AddWithValue("@ProductTypeID", productType.ProductTypeID);
            command.Parameters.AddWithValue("@ProductType", productType.ProductName);
            
            if (GlobalVariable.selectedProductTypeID == 0)
            {
                command.Parameters.AddWithValue("@NewProductTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
        /*----------------------------------------------------------------------------------------------------*/
       
        //change to edit screen
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;            
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }

        private void ClearInfo()
        {
            txtProductTypeID.Clear();
            txtProductType.Clear();
        }

        private bool CheckInput()
        {
            if (String.IsNullOrEmpty(txtProductType.Text))
            {
                MessageBox.Show("Please enter the product type", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        
    }
}
