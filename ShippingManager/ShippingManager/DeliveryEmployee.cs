using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Sublcass of Employee, which represents an employee who is designated to work in a delivery vehicle.
    /// </summary>
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
