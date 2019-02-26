using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added
using System.Data.SqlClient;

namespace AcmeInsuranceCompany.Data_Access_Layer
{
    class ConnectionManager
    {
        //establish connection between program and database
        public static SqlConnection DatabaseConnection()
        {
            string connection = "Data Source=laptop-hq36brdd\\sqlexpress; Initial Catalog=Acme; User=sa; Password=sqlexpress";
            SqlConnection conn = new SqlConnection(connection);
            return conn;
        }
    }
}
