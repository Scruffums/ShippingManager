using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class WarehouseEmployee : Employee
    {
        public Location CurrentLocation
        {
            get;
            set;
        }

        public WarehouseEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
            
        }
    }
}
