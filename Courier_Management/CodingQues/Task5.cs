using System;
using Microsoft.Data.SqlClient;
using Courier_Management.Util;

namespace Courier_Management.CodingQues
{
    class Task5
    {
        private SqlConnection connection;

        public Task5()
        {
            Connection db = new Connection();
            connection = db.GetConnection();
        }

        public void PrintAllCouriers()
        {
            string query = "SELECT * FROM Courier";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Couriers ---");
                while (reader.Read())
                {
                    Console.WriteLine($"CourierID: {reader["CourierID"]}, Sender: {reader["SenderName"]}, Receiver: {reader["ReceiverName"]}, " +
                        $"Tracking No: {reader["TrackingNumber"]}, Status: {reader["Status"]}, Weight: {reader["Weight"]}, " +
                        $"Shipped: {reader["ShippedDate"]}, Delivery: {reader["DeliveryDate"]}");
                }
                reader.Close();
                connection.Close();
            }
        }

        public void PrintAllEmployees()
        {
            string query = "SELECT * FROM Employee";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Employees ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["Name"]}, Email: {reader["Email"]}, Role: {reader["Role"]}, Salary: {reader["Salary"]}");
                }
                reader.Close();
                connection.Close();
            }
        }

        public void PrintAllLocations()
        {
            string query = "SELECT * FROM Location";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Locations ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["LocationID"]}, Name: {reader["LocationName"]}, Address: {reader["Address"]}");
                }
                reader.Close();
                connection.Close();
            }
        }

        public void PrintAllUsers()
        {
            string query = "SELECT * FROM [User]";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Users ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["UserID"]}, Name: {reader["Name"]}, Email: {reader["Email"]}, Contact: {reader["ContactNumber"]}, Address: {reader["Address"]}");
                }
                reader.Close();
                connection.Close();
            }
        }

        public void PrintAllPayments()
        {
            string query = "SELECT * FROM Payment";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Payments ---");
                while (reader.Read())
                {
                    Console.WriteLine($"PaymentID: {reader["PaymentID"]}, CourierID: {reader["CourierID"]}, LocationID: {reader["LocationID"]}, " +
                        $"Amount: {reader["Amount"]}, Date: {reader["PaymentDate"]}, EmployeeID: {reader["EmployeeID"]}");
                }
                reader.Close();
                connection.Close();
            }
        }

    }
}
