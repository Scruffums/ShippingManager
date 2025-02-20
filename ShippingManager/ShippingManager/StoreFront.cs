﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Represents all pertinent information to describe a store front which consists of routes and packages.
    /// </summary>
    [Serializable()]
    public class StoreFront : Location
    {
        private List<Package> packages;
        private List<Route> routes;

        public StoreFront(Address locationAddress)
        {
            LocationAddress = locationAddress;
            routes = new List<Route>();
            packages = new List<Package>();
            //this.deliveryVehicles = new List<DeliveryVehicle>();
            //this.deliveryVehicles.AddRange(deliveryVehicles);
        }

        #region Public Methods
        public bool addRoute(Route r)
        {
            if (routes.Contains(r))
                return false;
            routes.Add(r);
            return true;
        }

        public void removeRoute(Route r)
        {
            routes.Remove(r);
        }

        public void addPackage(Package package)
        {
            packages.Add(package);
        }

        public void removePackage(Package package)
        {
            packages.Remove(package);
        } 
        #endregion

        #region Public Properties
        public Package[] Packages { get { return packages.ToArray(); } }

        public Route[] Routes { get { return routes.ToArray(); } } 
        #endregion
    }
}
