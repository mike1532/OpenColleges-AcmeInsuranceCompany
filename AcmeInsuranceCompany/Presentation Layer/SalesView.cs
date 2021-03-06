﻿/*
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
    public partial class frmSalesView : Form
    {
        public frmSalesView()
        {
            InitializeComponent();
        }

        //events
        private void frmSalesView_Load(object sender, EventArgs e)
        {
            DisplaySales();
        }

        private void frmSalesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmSalesView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalVariable.selectedSaleID = 0;
            frmSalesAdd salesAdd = new frmSalesAdd();
            salesAdd.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
            Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*
            * Prompts user for selection if nothing has been selected. Assigns SaleID to 
            * selectedSaleID variable. Loads edit screen with selected sale's information
            */

            if (lvSales.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a sale to update", "Update Sale Details",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GlobalVariable.selectedSaleID = int.Parse(lvSales.SelectedItems[0].SubItems[1].Text);
            frmSalesAdd editForm = new frmSalesAdd();
            editForm.ChangeAddToEdit("Edit Sale Details", " Edit Sale Details", "Update");            
            editForm.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*
              * Checks that user has selected a sale to delete. Confirms that the user wants to continue
              * with the deletion. Connects to DB, runs Stored Proc, Displays updated list.
             */
             if (lvSales.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a sale to delete.", "Delete Sale",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this record?",
                                           "Delete Sale Record?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            GlobalVariable.selectedSaleID = int.Parse(lvSales.SelectedItems[0].SubItems[1].Text);
            string deleteQuery = "sp_Sales_DeleteSale";
            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlCommand command = new SqlCommand(deleteQuery, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SaleID", GlobalVariable.selectedSaleID);

            connection.Open();
            command.Transaction = connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Commit();
            connection.Close();

            lvSales.Items.Clear();
            DisplaySales();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalVariable.saleSearchCriteria = "";
            frmSalesSearch salesSearch = new frmSalesSearch();
            salesSearch.ShowDialog();
            lvSales.Items.Clear();
            DisplaySales();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

        //menu options - needs to be linked up to the appropriate click event
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
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //launches tutorial pdf file stored in resources.resx file            
            String openPDFFile = "Tutorial ver2.0.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::AcmeInsuranceCompany.Properties.Resources.Tutorial_ver2_0);
            System.Diagnostics.Process.Start(openPDFFile);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        /*------------------------------------------------------------------------------------------------*/

        public void DisplaySales()
        {
            string selectQuery = "SELECT Sales.SaleID, CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName, Products.ProductName, " +
                                 "Products.YearlyPremium, Sales.Payable, Sales.StartDate " +
                                 "FROM Sales INNER JOIN Customers ON Sales.CustomerID = Customers.CustomerID " +
                                 "INNER JOIN Products ON Sales.ProductID = Products.ProductID";

            //SEARCH QUERY
            selectQuery = selectQuery + " " + GlobalVariable.saleSearchCriteria;

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                //Open DB connection, pass query to command, execute reader
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                //Define payable list items - F (Fortnight), M (Month), Y (Year)
                while (reader.Read())
                {
                    string payable = "Fortnightly";

                    if (reader["Payable"].ToString() == "M")
                    {
                        payable = "Monthly";
                    }
                    if (reader["Payable"].ToString() == "Y")
                    {
                        payable = "Yearly";
                    }
                    
                    //Calculates Premium payable based on either monthly, fortnightly or yearly payments
                    decimal amount;
                    //const double MONTH = 12;
                    //const int FORTNIGHT = 26;
                   
                    /*switch (reader["Payable"].ToString())
                    {
                        case "F":
                            amount = decimal.Parse(reader["YearlyPremium"].ToString()) / FORTNIGHT;
                            break;
                        case "M":
                            amount = decimal.Parse(reader["YearlyPremium"].ToString()) / MONTH;
                            break;
                        default:
                            amount = decimal.Parse(reader["YearlyPremium"].ToString());
                            break;
                    }*/
                    if (reader["Payable"].ToString() == "F")
                    {
                        amount = decimal.Parse(reader["YearlyPremium"].ToString()) / 26;
                    }
                    else if (reader["Payable"].ToString() == "M")
                    {
                        amount = decimal.Parse(reader["YearlyPremium"].ToString()) / 12;
                    }
                    else
                    {
                        amount = decimal.Parse(reader["YearlyPremium"].ToString());
                    }


                    //Call constructor
                    Sale sale = new Sale(int.Parse(reader["SaleID"].ToString()), reader["CustomerName"].ToString(),
                        reader["ProductName"].ToString(), amount.ToString("C"), payable, DateTime.Parse(reader["StartDate"].ToString()));

                    //creates listview then adds items to lvCustomers
                    /*
                        Added the empty first line to allow for the extra column added at the beginning
                        of the list view. Extra column was added (width of 0) to allow for all headings to 
                        be centered, as you cannot center the first column in a list view.
                     */

                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(sale.SaleID.ToString());
                    listView.SubItems.Add(sale.CustomerName);
                    listView.SubItems.Add(sale.ProductName);                   
                    listView.SubItems.Add(sale.TotalPremium);
                    listView.SubItems.Add(sale.PremiumPaid);
                    listView.SubItems.Add(sale.StartDate.ToString("dd/MM/yyyy"));

                    lvSales.Items.Add(listView);
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
    }
}

