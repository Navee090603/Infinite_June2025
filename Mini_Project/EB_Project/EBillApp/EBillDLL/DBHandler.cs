using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EBillDLL
{
    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EBillDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}