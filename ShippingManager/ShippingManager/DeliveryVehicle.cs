﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Sublcass of Moveable, which represents all of the pertaining details for a delivery vehicle.
    /// </summary>
    [Serializable()]
    public class DeliveryVehicle : Moveable
    {
        private DeliveryEmployee driver;

        public DeliveryVehicle(string id, int volumeCapacity, int weightCapacity, Route route)
            : base(id, volumeCapacity,weightCapacity,route)
        {
        }

        public DeliveryVehicle(string id, int volumeCapacity, int weightCapacity)
            : base(id, volumeCapacity, weightCapacity)
        {
        }


        public bool assignDriver(DeliveryEmployee em)
        {
            if (Driverless)
            {
                driver = em;
                return true;
            }
            return false;
        }

        public void removeDriver(DeliveryEmployee em)
        {
            if (driver.Equals(em))
                driver = null;
        }


        public bool Driverless { get { return driver == null; } }

    }
}
