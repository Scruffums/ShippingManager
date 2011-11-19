﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class AcceptanceEmployee : Employee
    {

        public AcceptanceEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
            : base(firstName, middleName, lastName, id, plainTextPassword)
        {
        }
        
        public StoreFront CurrentStoreFront
        {
            get;
            set;
        }

    }
}
