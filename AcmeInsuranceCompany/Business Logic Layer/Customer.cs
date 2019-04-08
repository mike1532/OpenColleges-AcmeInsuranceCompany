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
    class Customer
    {
        //declare customer properties
        private string firstName, lastName, address, suburb, state, gender, category;
        private int customerID, postcode;
        private DateTime birthDate;


        //get-set properties
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public int Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        //default constructor
        public Customer() { }

        //parameterised constructor
        public Customer(int customerID, string category, string firstName, string lastName, string address, string suburb,
                        string state, int postcode, string gender, DateTime birthDate)
        {
            CustomerID = customerID;
            Category = category;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Suburb = suburb;
            State = state;
            Postcode = postcode;
            Gender = gender;
            BirthDate = birthDate;
        }


    }
}
