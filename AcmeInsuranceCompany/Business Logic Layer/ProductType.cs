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
