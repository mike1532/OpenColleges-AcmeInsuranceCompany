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
    public partial class frmProductTypesSearch : Form
    {
        public frmProductTypesSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Code to search product types 
            //Ccode to search products
            if (rbListAll.Checked == true)
                GlobalVariable.productTypeSearchCriteria = "";
            if (rbCar.Checked == true)
                GlobalVariable.productTypeSearchCriteria = "WHERE ProductType LIKE '%car%'";
            if (rbHouseContents.Checked == true)
                GlobalVariable.productTypeSearchCriteria = "WHERE ProductType LIKE '%house%' OR ProductType LIKE '%contents%'";
            if (rbLife.Checked == true)
                GlobalVariable.productTypeSearchCriteria = "WHERE ProductType LIKE '%life%'";
            if (rbIncome.Checked == true)
                GlobalVariable.productTypeSearchCriteria = "WHERE ProductType LIKE '%income%'";
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
