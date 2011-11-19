using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class DeliveryEmployee : Employee
    {
        public DeliveryEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
        }

        public Route CurrentRoute
        {
            get;
            set;
        }
    }
}
