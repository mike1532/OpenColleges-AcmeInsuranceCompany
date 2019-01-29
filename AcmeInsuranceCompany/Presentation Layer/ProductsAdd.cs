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
    public partial class frmProductsAdd : Form
    {
        public frmProductsAdd()
        {
            InitializeComponent();
        }

        //events
        private void frmProductsAdd_Load(object sender, EventArgs e)
        {
            //TODO load event
        }
        private void frmProductsAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProductsView productsView = new frmProductsView();
            productsView.Show();
            Hide();
        }

        //button events
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO - code to clear entered data
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO - code to add product
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //change from add to edit form
        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            btnClear.Visible = false;
            btnClose.Top = btnClear.Top;
            btnClose.Left = btnClear.Left;
        }

    }
}
