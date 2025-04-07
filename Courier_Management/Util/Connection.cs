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

        public void InsertOrder(string sender, string receiver, string status, double cost)
        {
            string query = "INSERT INTO Orders (Sender, Receiver, Status, Cost, CreatedDate) VALUES (@sender, @receiver, @status, @cost, GETDATE())";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@sender", sender);
                cmd.Parameters.AddWithValue("@receiver", receiver);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@cost", cost);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Order inserted successfully.");
            }
        }

        public void UpdateCourierStatus(int orderId, string status)
        {
            string query = "UPDATE Orders SET Status = @status WHERE OrderId = @orderId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Courier status updated.");
            }
        }

        public void GetDeliveryHistory(int orderId)
        {
            string query = "SELECT * FROM Orders WHERE OrderId = @orderId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@orderId", orderId);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Delivery History:");
                while (reader.Read())
                {
                    Console.WriteLine($"OrderID: {reader["OrderId"]}, Sender: {reader["Sender"]}, Receiver: {reader["Receiver"]}, Status: {reader["Status"]}, Date: {reader["CreatedDate"]}");
                }

                reader.Close();
                connection.Close();
            }
        }

        public void GenerateShipmentStatusReport()
        {
            string query = "SELECT Status, COUNT(*) as Total FROM Orders GROUP BY Status";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Shipment Status Report:");
                while (reader.Read())
                {
                    Console.WriteLine($"Status: {reader["Status"]}, Count: {reader["Total"]}");
                }

                reader.Close();
                connection.Close();
            }
        }

        public void GenerateRevenueReport()
        {
            string query = "SELECT MONTH(CreatedDate) as Month, SUM(Cost) as Revenue FROM Orders GROUP BY MONTH(CreatedDate)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Revenue Report by Month:");
                while (reader.Read())
                {
                    Console.WriteLine($"Month: {reader["Month"]}, Revenue: {reader["Revenue"]}");
                }

                reader.Close();
                connection.Close();
            }
        }
    }
}
