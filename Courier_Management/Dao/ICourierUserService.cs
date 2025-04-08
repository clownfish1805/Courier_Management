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
        bool placeOrder(Courier newCourier);
        string getOrderStatus(string trackingNumber);
        bool cancelOrder(string trackingNumber);
        List<Courier> getAssignedOrder(int employeeID);
        List<Courier> GetallCouriers();

    }
}
