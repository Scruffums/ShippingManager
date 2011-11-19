using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Sublcass of Employee, which represents an employee who is designated to work in a store front or warehouse.
    /// </summary>
    [Serializable()]
    public class WarehouseEmployee : Employee
    {
        

        public WarehouseEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
            
        }

        public Location CurrentLocation{ get; set; }
    }
}
