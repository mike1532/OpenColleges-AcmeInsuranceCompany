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
    public partial class frmCategoriesView : Form
    {
        public frmCategoriesView()
        {
            InitializeComponent();
        }
        //events
        private void frmCategoriesView_Load(object sender, EventArgs e)
        {
            //code to load categories
        }
        private void frmCategoriesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoriesAdd categoriesAdd = new frmCategoriesAdd();
            categoriesAdd.ShowDialog();
            Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmCategoriesAdd editForm = new frmCategoriesAdd();
            editForm.ChangeAddToEdit("Edit Category", " Edit Category", "Update");
            editForm.ShowDialog();
            Hide();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //TODO - code to delete selected category

            //message to show if category is able to be deleted
            DialogResult dialogResultAble = MessageBox.Show("Are you sure you wish to delete this category?",
                                            "Delete Customer Record?", MessageBoxButtons.YesNo);
            if (dialogResultAble == DialogResult.No)
                return;
            //add code to check to see if category is being used. if being used tell user that it is
            //unable to be deleted. Try/Catch block?
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmCategoriesSearch categoriesSearch = new frmCategoriesSearch();
            categoriesSearch.ShowDialog();                       
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMainForm mainForm = new frmMainForm();
            mainForm.Show();
            Hide();
        }

        //TODO menu code
    }
}
