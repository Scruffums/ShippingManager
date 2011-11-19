using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Sublcass of Employee, which represents an employee who is designated to work in a store front.
    /// </summary>
    [Serializable()]
    public class AcceptanceEmployee : Employee
    {

        public AcceptanceEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
        }
        
        /// <summary>
        /// The current StoreFront this AcceptanceEmployee is designated.
        /// </summary>
        public StoreFront CurrentStoreFront
        {
            get;
            set;
        }

    }
}
