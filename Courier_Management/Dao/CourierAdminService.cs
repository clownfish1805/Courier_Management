using Courier_Management.Models;
using Courier_Management.Util;
using Microsoft.Data.SqlClient;
using System;

namespace Courier_Management.Dao
{
    class CourierAdminService : ICourierAdminService
    {
        private Connection _db;

        public CourierAdminService()
        {
            _db = new Connection();
        }

        public int addCourierStaff(Employee obj)
        {
            using (SqlConnection connection = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Employee (EmployeeID, Name, Email, ContactNumber, Role, Salary)
                    OUTPUT INSERTED.EmployeeID
                    VALUES (@EmployeeID, @Name, @Email, @ContactNumber, @Role, @Salary)";

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                cmd.Parameters.AddWithValue("@Role", obj.Role);
                cmd.Parameters.AddWithValue("@Salary", obj.Salary);

                cmd.Connection = connection;

                try
                {
                    connection.Open();
                    int insertedId = (int)cmd.ExecuteScalar();
                    return insertedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding staff: " + ex.Message);
                    return -1;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
