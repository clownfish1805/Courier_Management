using Courier_Management.Models;
using System.Collections.Generic;
using System.Linq;

namespace Courier_Management.Dao
{
    public class CourierCompanyCollection
    {
        public List<Employee> employeeList = new List<Employee>();
        public List<Courier> courierList = new List<Courier>();
    }

    public class CourierUserServiceCollectionImpl : ICourierUserService
    {
        protected CourierCompanyCollection companyObj;

        public CourierUserServiceCollectionImpl()
        {
            companyObj = new CourierCompanyCollection();
        }

        public bool placeOrder(Courier newCourier)
        {
            companyObj.courierList.Add(newCourier);
            return true;
        }

        public string getOrderStatus(string trackingNumber)
        {
            var courier = companyObj.courierList.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
            return courier != null ? courier.Status : "Tracking number not found";
        }

        public bool cancelOrder(string trackingNumber)
        {
            var courier = companyObj.courierList.FirstOrDefault(c => c.TrackingNumber == trackingNumber);
            if (courier != null)
            {
                courier.Status = "Cancelled";
                return true;
            }
            return false;
        }

        public List<Courier> getAssignedOrder(int employeeID)
        {
            return companyObj.courierList.Where(c => c.EmployeeID == employeeID).ToList();
        }

        public List<Courier> GetallCouriers()
        {
            return companyObj.courierList;
        }
    }
}
