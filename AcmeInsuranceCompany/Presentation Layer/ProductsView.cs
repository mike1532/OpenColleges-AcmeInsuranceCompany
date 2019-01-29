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
    public partial class frmProductsView : Form
    {
        public frmProductsView()
        {
            InitializeComponent();
        }

        //events
        private void frmProducts_Load(object sender, EventArgs e)
        {
            //TODO - code to load products
        }
        private void frmProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductsAdd productsAdd = new frmProductsAdd();
            productsAdd.ShowDialog();
            Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProductsAdd editForm = new frmProductsAdd();
            editForm.ChangeAddToEdit("Edit Product Details", " Edit Product Details", "Update");
            editForm.ShowDialog();
            Hide();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO - code to delete selected Product

            //message to show if category is able to be deleted
            DialogResult dialogResultAble = MessageBox.Show("Are you sure you wish to delete this product?",
                                            "Delete Product?", MessageBoxButtons.YesNo);
            if (dialogResultAble == DialogResult.No)
                return;
            //add code to check to see if Product is being used in a sale. if being used tell user that it is
            //unable to be deleted. Try/Catch block?
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmProductsSearch productsSearch = new frmProductsSearch();
            productsSearch.ShowDialog();            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

        //TODO - menu code
    }
}
