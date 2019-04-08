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
using System.Data.SqlClient;
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmSalesSearch : Form
    {
        public frmSalesSearch()
        {
            InitializeComponent();
        }

        //load/close events
        private void frmSalesSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbProduct.Visible = false;

            string selectQuery = "SELECT * FROM Products";

            SqlConnection connection = ConnectionManager.DatabaseConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbProduct.Items.Add(reader["ProductID"].ToString());
                    cbProduct.Items.Add(reader["ProductName"].ToString());
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

        //set visibility on selected option
        private void rbListAll_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbProduct.Visible = false;
        }

        private void rbProduct_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbProduct.Visible = true;
            cbProduct.SelectedIndex = -1;
            cbProduct.Top = txtSearch.Top;
            cbProduct.Left = txtSearch.Left;
        }

        private void rbLastName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            cbProduct.Visible = false;
        }

        //buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Code to search sales records
            if (rbListAll.Checked == true)
                GlobalVariable.saleSearchCriteria = "";
            if (rbProduct.Checked == true)
                GlobalVariable.saleSearchCriteria = "WHERE Products.ProductName = '" + lbProduct.Items[cbProduct.SelectedIndex].ToString() + "'";
            if (rbLastName.Checked == true)
                GlobalVariable.saleSearchCriteria = "WHERE Customers.LastName = '" + txtSearch.Text + "'";
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
