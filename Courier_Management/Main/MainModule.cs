using System;
using System.Collections.Generic;
using Courier_Management.Models;
using Courier_Management.Dao;
using Courier_Management.Util;
using Courier_Management.Exceptions;
using Microsoft.Data.SqlClient;

namespace Courier_Management.Main
{
    class MainModule
    {
        public void Start()
        {
            if (IsDatabaseConnected())
            {
                Console.WriteLine("Connected to the database");
            }

            MainModule program = new MainModule();


            while (true)
            {
                Console.WriteLine("\n==== Courier Management Application ====");
                Console.WriteLine("1. Courier Management System");
                Console.WriteLine("2. Admin Management System");
                Console.WriteLine("3. Crud");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        program.CourierManagement();
                        break;
                    case "2":
                        program.AdminManagement();
                        break;
                    case "3":
                        program.crud();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }

        private void crud()
        {
           
        }

        public void AdminManagement()
        {
            Console.WriteLine("\n=== Admin Management System ===");
            CourierAdminService adminService = new CourierAdminService();

            Console.WriteLine("Add a new courier staff member\n");

            Employee newStaff = new Employee();

            Console.WriteLine("Enter EmployeeID:");
            newStaff.EmployeeID = Convert.ToInt32(Console.ReadLine());  

            Console.Write("Enter Staff Name: ");
            newStaff.Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            newStaff.Email = Console.ReadLine();

            Console.Write("Enter Contact Number: ");
            newStaff.ContactNumber = Console.ReadLine();

            Console.Write("Enter Role: ");
            newStaff.Role = Console.ReadLine();

            Console.Write("Enter Salary: ");
            newStaff.Salary = Convert.ToDecimal(Console.ReadLine());

            int result = adminService.addCourierStaff(newStaff);

            if (result > 0)
                Console.WriteLine($"Courier Staff added successfully! Employee ID: {result}");
            else
                Console.WriteLine("Failed to add courier staff.");
        }

        public void CourierManagement()
        {
            Console.WriteLine("\n=== Courier Management System ===");
            CourierUserService courierService = new CourierUserService();



            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Place a new order");
                Console.WriteLine("2. View all couriers");
                Console.WriteLine("3. Get order status by tracking number");
                Console.WriteLine("4. Cancel an order");
                Console.WriteLine("5. View assigned orders by employee ID");
             
                Console.WriteLine("6. Back to main menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Courier newCourier = new Courier();

                        Console.Write("Courier ID: ");
                        newCourier.CourierID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Sender Name: ");
                        newCourier.SenderName = Console.ReadLine();

                        Console.Write("Sender Address: ");
                        newCourier.SenderAddress = Console.ReadLine();

                        Console.Write("Receiver Name: ");
                        newCourier.ReceiverName = Console.ReadLine();

                        Console.Write("Receiver Address: ");
                        newCourier.ReceiverAddress = Console.ReadLine();

                        Console.Write("Weight (kg): ");
                        newCourier.Weight = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Status: ");
                        newCourier.Status = Console.ReadLine();

                        Console.Write("Tracking Number (leave empty for auto): ");
                        string manualTrack = Console.ReadLine();
                        newCourier.TrackingNumber = string.IsNullOrWhiteSpace(manualTrack)
                            ? Guid.NewGuid().ToString().Substring(0, 10)
                            : manualTrack;

                        Console.Write("Expected Delivery Date (yyyy-mm-dd): ");
                        newCourier.DeliveryDate = DateOnly.Parse(Console.ReadLine());

                        Console.Write("Expected Shipped Date (yyyy-mm-dd): ");
                        newCourier.ShippedDate = DateOnly.Parse(Console.ReadLine());

                        Console.Write("Employee ID: ");
                        newCourier.EmployeeID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Location ID: ");
                        newCourier.LocationID = Convert.ToInt32(Console.ReadLine());

                        bool placed = courierService.placeOrder(newCourier);
                        Console.WriteLine(placed ? "Order placed successfully!" : "Failed to place order.");
                        break;

                    case "2":
                        List<Courier> couriers = courierService.GetallCouriers();
                        if (couriers.Count == 0)
                        {
                            Console.WriteLine("No couriers found.");
                        }
                        else
                        {
                            foreach (var c in couriers)
                            {
                                Console.WriteLine($"Tracking: {c.TrackingNumber}, Status: {c.Status}, Sender: {c.SenderName}, Receiver: {c.ReceiverName}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Tracking Number: ");
                        string tracking = Console.ReadLine();
                        try
                        {
                            string status = courierService.getOrderStatus(tracking);
                            Console.WriteLine($"Order Status: {status}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Tracking Number to cancel: ");
                        string cancelTrack = Console.ReadLine();
                        try
                        {
                            bool canceled = courierService.cancelOrder(cancelTrack);
                            Console.WriteLine(canceled ? "Order cancelled successfully." : "Unable to cancel order.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Employee ID: ");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        List<Courier> assigned = courierService.getAssignedOrder(empId);
                        if (assigned.Count == 0)
                        {
                            Console.WriteLine("No assigned orders found.");
                        }
                        else
                        {
                            foreach (var c in assigned)
                            {
                                Console.WriteLine($"Tracking: {c.TrackingNumber}, Receiver: {c.ReceiverName}, Status: {c.Status}");
                            }
                        }
                        break;

                   

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        public static bool IsDatabaseConnected()
        {
            Connection db = new Connection();
            using SqlConnection conn = db.GetConnection();
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
                return false;
            }
        }
    }
}
