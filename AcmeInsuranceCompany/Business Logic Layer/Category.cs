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
