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
    public partial class frmCategoriesSearch : Form
    {
        public frmCategoriesSearch()
        {
            InitializeComponent();
        }

        //change size of form to accomodate new additions to search criteria
        private void frmCategoriesSearch_Load(object sender, EventArgs e)
        {
           
        }               

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO code to search categories
            if (rbListAll.Checked == true)
                GlobalVariable.categorySearchCriteria = "";
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
