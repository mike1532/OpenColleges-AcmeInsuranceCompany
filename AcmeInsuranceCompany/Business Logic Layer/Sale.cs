using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeInsuranceCompany.Business_Logic_Layer
{
    class Sale
    {
        //Declare properties and Get/Set
        private int saleID;
        private string customerName, productName, payable; 
        private DateTime startDate;        

        public int SaleID
        {
            get { return saleID; }
            set { saleID = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string Payable
        {
            get { return payable; }
            set { payable = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        //Default and parameterised constructor
        public Sale() { }

        public Sale(int saleID, string customerName, string productName, string payable, DateTime startDate)
        {
            SaleID = saleID;
            CustomerName = customerName;
            ProductName = productName;
            Payable = payable;
            StartDate = startDate;
        }
    }
}
