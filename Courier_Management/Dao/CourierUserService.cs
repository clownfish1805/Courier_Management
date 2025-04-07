using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Courier_Management.Models;
using Courier_Management.Util;
using Courier_Management.Exceptions;

namespace Courier_Management.Dao
{
    class CourierUserService : ICourierUserService
    {
        private Connection _db;

        public CourierUserService()
        {
            _db = new Connection();
        }
    
        public bool placeOrder(Courier courier)
        {
            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"INSERT INTO Courier (CourierID, SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, 
                Status, TrackingNumber, DeliveryDate, ShippedDate, EmployeeID, LocationID)
                VALUES (@CourierID, @SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, 
                @Weight, @Status, @TrackingNumber, @DeliveryDate, @ShippedDate, @EmployeeID, @LocationID)";

                cmd.Parameters.AddWithValue("@CourierID", courier.CourierID);
                cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
                cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
                cmd.Parameters.AddWithValue("@Weight", courier.Weight);
                cmd.Parameters.AddWithValue("@Status", courier.Status);
                cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
                cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
                cmd.Parameters.AddWithValue("@ShippedDate", courier.ShippedDate);
                cmd.Parameters.AddWithValue("@EmployeeID", courier.EmployeeID);
                cmd.Parameters.AddWithValue("@LocationID", courier.LocationID);
                cmd.Connection = connection;

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        public string getOrderStatus(string trackingNumber)
        {
            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Status FROM Courier WHERE TrackingNumber = @TrackingNumber";
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                cmd.Connection = connection;

                connection.Open();
                object result = cmd.ExecuteScalar();
                connection.Close();

                if (result == null)
                {
                    throw new TrackingNumberNotFoundException($"Tracking number '{trackingNumber}' not found.");
                }

                return result.ToString();
            }
        }

        public bool cancelOrder(string trackingNumber)
        {
            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Courier SET Status = 'Order Cancelled' WHERE TrackingNumber = @TrackingNumber";
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                cmd.Connection = connection;

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }
        }

        public List<Courier> getAssignedOrder(int employeeID)
        {
            List<Courier> assignedOrders = new List<Courier>();

            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courier WHERE EmployeeID = @EmployeeID", connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Courier courier = new Courier
                        (
                            Convert.ToInt32(reader["CourierID"]),
                            Convert.ToString(reader["SenderName"]),
                            Convert.ToString(reader["SenderAddress"]),
                            Convert.ToString(reader["ReceiverName"]),
                            Convert.ToString(reader["ReceiverAddress"]),
                            Convert.ToDouble(reader["Weight"]),
                            Convert.ToString(reader["Status"]),
                            Convert.ToString(reader["TrackingNumber"]),
                            Convert.ToDateTime(reader["DeliveryDate"]),
                            Convert.ToInt32(reader["EmployeeID"]),
                            Convert.ToInt32(reader["LocationID"])
                        );
                        assignedOrders.Add(courier);
                    }
                }

                connection.Close();
            }

            return assignedOrders;
        }

        public List<Courier> GetallCouriers()
        {
            List<Courier> couriers = new List<Courier>();

            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courier", connection))
            {
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Courier courier = new Courier
                        (
                            Convert.ToInt32(reader["CourierID"]),
                            Convert.ToString(reader["SenderName"]),
                            Convert.ToString(reader["SenderAddress"]),
                            Convert.ToString(reader["ReceiverName"]),
                            Convert.ToString(reader["ReceiverAddress"]),
                            Convert.ToDouble(reader["Weight"]),
                            Convert.ToString(reader["Status"]),
                            Convert.ToString(reader["TrackingNumber"]),
                            Convert.ToDateTime(reader["DeliveryDate"]),
                            Convert.ToInt32(reader["EmployeeID"]),
                            Convert.ToInt32(reader["LocationID"])
                        );
                        couriers.Add(courier);
                    }
                }

                connection.Close();
            }

            return couriers;
        }

        public bool AddCourier(Courier courier)
        {
            
            throw new NotImplementedException("AddCourier is not supported in CourierUserService.");
        }

        public Courier GetCourierById(int courierId)
        {
          
            throw new NotImplementedException("GetCourierById is not supported in CourierUserService.");
        }

        public bool RemoveCourier(int courierId)
        {
           
            throw new NotImplementedException("RemoveCourier is not supported in CourierUserService.");
        }

        
    }
}
