using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsuranceCompany.Business_Logic_Layer
{
    class Product
    {
        //Declare properties
        private int productID;
        private string productName, productType;
        private decimal yearlyPremium;

        //Get-Set properties
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public decimal YearlyPremium
        {
            get { return yearlyPremium; }
            set { yearlyPremium = value; }
        }

        //Default and Parameterised constructor
        public Product() { }

        public Product(int productID, string productType, string productName, decimal yearlyPremium)
        {
            ProductID = productID;
            ProductType = productType;
            ProductName = productName;
            YearlyPremium = yearlyPremium;
        }
    }
}
