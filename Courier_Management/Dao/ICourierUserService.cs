using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courier_Management.Models;

namespace Courier_Management.Dao
{
    interface ICourierUserService
    {
        public bool placeOrder(Courier newCourier);
        public string getOrderStatus(string trackingNumber);
        public bool cancelOrder(string trackingNumber);

        public List<Courier> getAssignedOrder(int employeeID);
        List<Courier> GetallCouriers();

       
    }
}
