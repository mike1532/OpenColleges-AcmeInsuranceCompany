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
           //TODO - code to search sales records
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
