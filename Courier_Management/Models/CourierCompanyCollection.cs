using System.Collections.Generic;

namespace Courier_Management.Models
{
    public class CourierCompanyCollection
    {
        public List<Courier> courierList;

        public CourierCompanyCollection()
        {
            courierList = new List<Courier>();
        }
    }
}
