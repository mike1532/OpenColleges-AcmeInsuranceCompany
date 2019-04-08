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
using System.Data.SqlClient;
using AcmeInsuranceCompany.Data_Access_Layer;
using AcmeInsuranceCompany.Presentation_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCustomersSearch : Form
    {
        public frmCustomersSearch()
        {
            InitializeComponent();
        }

        //set visibility on selected option
        private void rbListAll_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbCategory.Visible = false;
        }

        private void rbLastName_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            cbCategory.Visible = false;
        }

        private void rbCategory_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbCategory.Visible = true;
            cbCategory.SelectedIndex = -1;
            cbCategory.Top = txtSearch.Top;
            cbCategory.Left = txtSearch.Left;
        }

        private void rbPostcode_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            cbCategory.Visible = false;
        }

        //load/close events
        private void frmCustomersSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            cbCategory.Visible = false;

            string selectQuery = "SELECT * FROM Categories";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    lbCategory.Items.Add(reader["CategoryID"].ToString());
                    cbCategory.Items.Add(reader["Category"].ToString());
                }
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unsucessful" + ex);
            }
            
        }

        //buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Code to search databse
            if (rbListAll.Checked == true)
                GlobalVariable.customerSearchCriteria = "";
            if(rbLastName.Checked == true)
                GlobalVariable.customerSearchCriteria = "WHERE LastName = '" + txtSearch.Text + "'";
            if (rbCategory.Checked == true)
                GlobalVariable.customerSearchCriteria = "WHERE Customers.CategoryID = '" + lbCategory.Items[cbCategory.SelectedIndex].ToString() + "'";
            if (rbPostcode.Checked == true)
                GlobalVariable.customerSearchCriteria = "WHERE Postcode = '" + txtSearch.Text + "'";
            Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
