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
using System.Globalization;
using System.Text.RegularExpressions;
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
        
        //load/close events        
        private void frmCustomersAdd_Load(object sender, EventArgs e)
        {
            SetLengthDOB();

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

                while (reader.Read())
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

            //Populates the edit form with selected information
            if(GlobalVariable.selectedCustomerID > 0)
            {
                selectQuery = "SELECT * FROM Customers WHERE CustomerID = " + GlobalVariable.selectedCustomerID.ToString();
                SqlConnection connection1 = ConnectionManager.DatabaseConnection();
                SqlDataReader reader1 = null;

                try
                {
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand(selectQuery, connection1);
                    reader1 = command1.ExecuteReader();
                    reader1.Read();

                    txtCustomerID.Text = reader1["CustomerID"].ToString();
                    cbCategory.SelectedIndex = int.Parse(reader1["CategoryID"].ToString()) - 1;
                    txtFirstName.Text = reader1["FirstName"].ToString();
                    txtLastName.Text = reader1["LastName"].ToString();
                    txtAddress.Text = reader1["Address"].ToString();
                    txtSuburb.Text = reader1["Suburb"].ToString();
                    cbState.Text = reader1["State"].ToString();
                    txtPostcode.Text = reader1["Postcode"].ToString();
                    if (reader1["Gender"].ToString() == "M")
                        rbMale.Checked = true;
                    else
                        rbFemale.Checked = true;
                    
                    //takes birthdate from DB and places it into appropriate sections (dd MMMM yyyy)
                    string dob = reader1["BirthDate"].ToString();
                    DateTime birthday = DateTime.Parse(dob);                   
                    txtBirthDay.Text = birthday.Day.ToString();
                    cbBirthMonth.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(birthday.Month);
                    txtBirthYear.Text = birthday.Year.ToString();
                    
                    reader1.Close();
                    connection1.Close();                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unsucessful " + ex);                    
                }
            }          
        }

        private void frmCustomersAdd_FormClosed(object sender, FormClosedEventArgs e)
        {            
            frmCustomersView customersView = new frmCustomersView();
            customersView.Show();
            Hide();
        }               

        //button click events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validates input data, if data is valid -> create customer object
            if (ConfirmInput() == true)
                return;
            if (ConfirmDateOfBirthInput() == true)
                return;

            Customer customer = new Customer(GlobalVariable.selectedCustomerID, lbCategory.Items[cbCategory.SelectedIndex].ToString(),
                                            txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtSuburb.Text, cbState.Text,
                                            int.Parse(txtPostcode.Text), Gender(), DateTime.Parse(txtBirthDay.Text + "/" + cbBirthMonth.Text +
                                            "/" + txtBirthYear.Text));

            /*Calls create/update customer stored procedure 
             * sets values into SP
             * commit to DB then close connection             
             */
            string addQuery;            

            if (GlobalVariable.selectedCustomerID == 0)
            {
                addQuery = "sp_Customers_CreateCustomer";
            }
            else
            {
                addQuery = "sp_Customers_UpdateCustomer";
            }


            SqlConnection connection = ConnectionManager.DatabaseConnection();            
            SqlCommand command = new SqlCommand(addQuery, connection);

            command.CommandType = CommandType.StoredProcedure;
            if (GlobalVariable.selectedCustomerID != 0)
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            command.Parameters.AddWithValue("@CategoryID", customer.Category);
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@Suburb", customer.Suburb);
            command.Parameters.AddWithValue("@State", customer.State);
            command.Parameters.AddWithValue("@Postcode", customer.Postcode);
            command.Parameters.AddWithValue("@Gender", customer.Gender);       
            command.Parameters.AddWithValue("@BirthDate", customer.BirthDate.ToString("dd/MMMM/yyyy"));            

            if (GlobalVariable.selectedCustomerID == 0)
            {
                command.Parameters.AddWithValue("@NewCustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
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
        private void ClearInfo()
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
            txtBirthDay.Clear();
            cbBirthMonth.SelectedIndex = -1;
            txtBirthYear.Clear();
        }

       private bool ConfirmDateOfBirthInput()
        {
            Regex DateInput = new Regex(@"^([1-9]|[12][0-9]|3[01])$");
            Regex YearInput = new Regex(@"^[1-2][0-9]{3}$");

            if(!DateInput.IsMatch(txtBirthDay.Text))
            {
                MessageBox.Show("Please check your Date of Birth\nDay must be in a number format\nbetween 1 and 31 (dd)",
                    "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if(cbBirthMonth.Text == String.Empty)
            {
                MessageBox.Show("Please check your Date of Birth\nNo month has been selected", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if(!YearInput.IsMatch(txtBirthYear.Text))
            {
                MessageBox.Show("Please check your Date of Birth\nYear must be in number format (yyyy)", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private bool ConfirmInput()
        {
            
            //Checks all info is entered. Then creates customer object to add to DB
            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please enter the customer's first name", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please enter the customer's last name.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Please select a gender.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Please select a category.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(txtSuburb.Text))
            {
                MessageBox.Show("Please enter a suburb.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(cbState.Text))
            {
                MessageBox.Show("Please select a state.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (String.IsNullOrEmpty(txtPostcode.Text))
            {
                MessageBox.Show("Please enter a postcode.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            if (!int.TryParse(txtPostcode.Text, out int parsedValue))
            {
                MessageBox.Show("Postcode must be a number.", "Add New Customer", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return true;
            }
            return false;                      
        }

        private string Gender()
        {
            string gender = "M";
            if (rbFemale.Checked)
            {
                gender = "F";
            }

            return gender;
        }

        private void SetLengthDOB()
        {
            //sets length of date of birth boxes
            txtBirthDay.MaxLength = 2;
            txtBirthYear.MaxLength = 4;
        }        
        
    }
}
