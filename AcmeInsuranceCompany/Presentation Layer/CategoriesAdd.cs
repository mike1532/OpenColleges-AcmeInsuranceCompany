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
//added
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;


namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCategoriesAdd : Form
    {
        public frmCategoriesAdd()
        {
            InitializeComponent();
        }

        //load/close events
        private void frmCategoriesAdd_Load(object sender, EventArgs e)
        {
            string selectQuery;
            //Preloads selected category information into the edit category form
            if (GlobalVariable.selectedCategoryID > 0)
            {
                selectQuery = "SELECT * FROM Categories WHERE CategoryID = " + GlobalVariable.selectedCategoryID.ToString();
                SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                SqlDataReader reader1 = null;

                try
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(selectQuery, connection1);
                    reader1 = command1.ExecuteReader();
                    reader1.Read();

                    txtCategory.Text = reader1["Category"].ToString();

                    reader1.Close();
                    connection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsuccessful" + ex);
                }
            }
        }

        private void frmCategoriesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCategoriesView categoriesView = new frmCategoriesView();
            categoriesView.Show();
            Hide();
        }

        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checks input -> creates category object
            if (CheckInput() == true)
                return;

            Category category = new Category(GlobalVariable.selectedCategoryID, txtCategory.Text);

            /*Calls create/update category stored procedure 
             * sets values into SP
             * commit to DB then close connection             
             */
            string addQuery;

            if (GlobalVariable.selectedCategoryID == 0)
            {
                addQuery = "sp_Categories_CreateCategory";
            }
            else
            {
                addQuery = "sp_Categories_UpdateCategory";
            }

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(addQuery, connection);

            command.CommandType = CommandType.StoredProcedure;
            if (GlobalVariable.selectedCategoryID != 0)
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            command.Parameters.AddWithValue("@Category", category.CategoryType);

            if (GlobalVariable.selectedCategoryID == 0)
                command.Parameters.AddWithValue("@NewCategoryID", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Commit();

            connection.Close();
            Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears all input
            txtCategory.Clear();
            txtCategoryID.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*-----------------------------------------------------------------------------------------------*/
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            lblCategory.Text = "Category:";
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }

        private bool CheckInput()
        {                        
            if(String.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Please enter a category", "Add New Category", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
                return false;              
        }
    }
}
