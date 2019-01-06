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
        }

        //buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO - code to search databse
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
