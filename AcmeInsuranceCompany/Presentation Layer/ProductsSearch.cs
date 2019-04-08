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

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmProductsSearch : Form
    {
        public frmProductsSearch()
        {
            InitializeComponent();
        }

        private void frmProductsSearch_Load(object sender, EventArgs e)
        {

        }

        //buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Ccode to search products
            if (rbListAll.Checked == true)
                GlobalVariable.productSearchCriteria = "";
            if (rbCar.Checked == true)
                GlobalVariable.productSearchCriteria = "WHERE ProductName LIKE '%car%'";
            if (rbHouseContents.Checked == true)
                GlobalVariable.productSearchCriteria = "WHERE ProductName LIKE '%house%' OR ProductName LIKE '%contents%'";
            if (rbLife.Checked == true)
                GlobalVariable.productSearchCriteria = "WHERE ProductName LIKE '%life%'";
            if (rbIncome.Checked == true)
                GlobalVariable.productSearchCriteria = "WHERE ProductName LIKE '%income%'";
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
