using System;
using Microsoft.Data.SqlClient;

namespace Courier_Management.Util
{
    class Connection
    {
        private SqlConnection connection;

        public Connection()
        {
            try
            {
                connection = new SqlConnection("Server=DESKTOP-S6D65HG\\SQLEXPRESS01;Database=CourierDB;Trusted_Connection=True;Encrypt=False;");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        
    }
}
