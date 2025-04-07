using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier_Management.Models
{
    class CourierCompanyCollection
    {
        public List<Courier> CourierList { get; set; }

        public CourierCompanyCollection()
        {
            CourierList = new List<Courier>();
        }
        public void AddCourier(Courier courier)
        {
            CourierList.Add(courier);
        }
        public bool RemoveCourier(Courier courier)
        {
            return CourierList.Remove(courier);
        }

    }
}
