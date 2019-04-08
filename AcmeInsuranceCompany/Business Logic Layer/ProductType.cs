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
    class ProductType
    {
        //Declare, then Get/Set
        private int productTypeID;
        private string productName;

        public int ProductTypeID
        {
            get { return productTypeID; }
            set { productTypeID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        //Default and parameterised constructors
        public ProductType() { }

        public ProductType(int productTypeID, string productName)
        {
            ProductTypeID = productTypeID;
            ProductName = productName;
        }

    }
}
