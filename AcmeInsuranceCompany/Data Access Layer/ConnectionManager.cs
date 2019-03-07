using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//access DB
using System.Data.SqlClient;

namespace AcmeInsuranceCompany.Data_Access_Layer
{
    class ConnectionManager
    {
        //establish connection between program and DB (database)
        public static SqlConnection DatabaseConnection()
        {
            //accesses DB on local drive - should be the location of required DB
            string connection = "Data Source=laptop-hq36brdd\\sqlexpress; Initial Catalog=Acme; User=sa; Password=sqlexpress";
            SqlConnection conn = new SqlConnection(connection);
            return conn;
        }
    }
}
