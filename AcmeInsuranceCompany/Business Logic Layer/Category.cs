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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsuranceCompany.Business_Logic_Layer
{
    class Category
    {
        //declare category properties
        private int categoryID;
        private string categoryType;

        //get/set properties
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        public string CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }

        //default and parametised constructor
       public Category() { }

        public Category(int categoryID, string categoryType)
        {
            CategoryID = categoryID;
            CategoryType = categoryType;
        }



    }
}
