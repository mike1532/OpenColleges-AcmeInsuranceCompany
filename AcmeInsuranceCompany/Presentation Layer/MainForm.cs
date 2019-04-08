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
using AcmeInsuranceCompany.Data_Access_Layer;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            MainDisplay();
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // File menu options       
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
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //launches tutorial pdf file stored in resources.resx file            
            String openPDFFile = "Tutorial ver2.0.pdf";
            System.IO.File.WriteAllBytes(openPDFFile, global::AcmeInsuranceCompany.Properties.Resources.Tutorial_ver2_0);
            System.Diagnostics.Process.Start(openPDFFile);

            //code sourced from stackoverflow.com/questions/8609476/how-to-open-a-pdf-file-that-is-also-a-project-resource
        }

        //button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*----------------------------------------------------------------------------------------------*/

        public void MainDisplay()
        {
            string selectQuery = "SELECT Products.ProductName, ProductTypes.ProductType, COUNT(*) AS TotalSales FROM Sales " +
                                 "JOIN Products ON Sales.ProductID = Products.ProductID " +
                                 "JOIN ProductTypes ON Products.ProductTypeID = ProductTypes.ProductTypeID " +
                                 "GROUP BY Products.ProductName, ProductTypes.ProductType, Sales.ProductID";

            SqlConnection connection = ConnectionManager.DatabaseConnection();
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem listView = new ListViewItem("");
                    listView.SubItems.Add(reader["ProductName"].ToString());
                    listView.SubItems.Add(reader["ProductType"].ToString());
                    listView.SubItems.Add(reader["TotalSales"].ToString());

                    lvDashboard.Items.Add(listView);
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
