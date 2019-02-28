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
using AcmeInsuranceCompany.Business_Logic_Layer;
using AcmeInsuranceCompany.Data_Access_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCustomersAdd : Form
    {
        public frmCustomersAdd()
        {
            InitializeComponent();
        }
               
        //button click events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Edit checks to validate user input. Then creates customer object to add to DB
            if(String.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the customer's first name");
                return;
            }
            if (String.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please enter the customer's last name.");
                return;
            }
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please select a gender.");
                return;
            }
            if (String.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Please select a category.");
                return;
            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address");
                return;
            }
            if (String.IsNullOrEmpty(txtSuburb.Text))
            {
                MessageBox.Show("Please enter a suburb.");
                return;
            }
            if (String.IsNullOrEmpty(cbState.Text))
            {
                MessageBox.Show("Please select a state.");
                return;
            }
            if (String.IsNullOrEmpty(txtPostcode.Text))
            {
                MessageBox.Show("Please enter a postcode.");
                return;
            }
                if (!int.TryParse(txtPostcode.Text, out int parsedValue))
                    {
                        MessageBox.Show("Postcode must be a number.");
                        return;
                    }

            string gender = "M";
            if(rbFemale.Checked)
            {
                gender = "F";
            }

            Customer customer = new Customer(GlobalVariable.selectedCustomerID, lbCategory.Items[cbCategory.SelectedIndex].ToString(),
                                            txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtSuburb.Text, cbState.Text,
                                            int.Parse(txtPostcode.Text), gender, dateTimePickerDOB.Value);
            
            /*Calls create customer stored procedure, sets values into SP, commit to DB, close connection.
             TODO - code to edit
             */
            string addQuery = "sp_Customers_CreateCustomer ";         
                        
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(addQuery, connection);

            command.CommandType = CommandType.StoredProcedure;           
            command.Parameters.AddWithValue("@CategoryID", customer.Category);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@Suburb", customer.Suburb);
            command.Parameters.AddWithValue("@State", customer.State);
            command.Parameters.AddWithValue("@Postcode", customer.Postcode);
            command.Parameters.AddWithValue("@Gender", customer.Gender);
            command.Parameters.AddWithValue("@BirthDate", customer.BirthDate);

            if(GlobalVariable.selectedCustomerID == 0)
            {
                command.Parameters.AddWithValue("@NewCustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }

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

        //load/close events        
        private void frmCustomersAdd_Load(object sender, EventArgs e)
        {
            //Pre loads categories into form
            
            string selectQuery = "SELECT * FROM Categories";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            //Opens connection, loads info into category combo box, closes connection.
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
                MessageBox.Show("Unsuccessful " + ex);
            }

            //TODO - code to update row 

        }
        private void frmCustomersAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }

        /*-----------------------------------------------------------------------------------------*/

        //change from add to edit form
        public void ChangeAddToEdit (string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }

        //clears entered text
        public void ClearInfo()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cbCategory.SelectedIndex = -1;
            txtAddress.Clear();
            txtSuburb.Clear();
            cbState.SelectedIndex = -1;
            txtPostcode.Clear();
            txtCustomerID.Clear();
            dateTimePickerDOB = null;
        }
        
    }
}
