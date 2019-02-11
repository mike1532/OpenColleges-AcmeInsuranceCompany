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
    public partial class frmProductTypesAdd : Form
    {
        public frmProductTypesAdd()
        {
            InitializeComponent();
        }

        //events        
        private void frmProductTypesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProductTypesView productTypesView = new frmProductTypesView();
            productTypesView.Show();
            Hide();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO - code to add a new product type
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO - code to clear entered information
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //change to edit screen
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;            
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }
    }
}
