using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Sublcass of Employee, which represents an employee who does not actually work at any specified location, but does have all possible admin responsibilities
    /// </summary>
    [Serializable()]
    public class AdminEmployee : Employee
    {
        public AdminEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
        }
    }
}
