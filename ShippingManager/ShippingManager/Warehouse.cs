using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Warehouse : Location
    {
        private List<Route> routes;
        private List<Package> packages;
        private int currentVolume;

        public Warehouse(Address a, int volumeCapacity)
        {
            VolumeCapacity = volumeCapacity;
            LocationAddress = a;
            //this.zipCodesServed = new List<int>();
            //this.transports = new List<Transport>();
            //this.deliveryVehicles = new List<DeliveryVehicle>();

            routes = new List<Route>();
            packages = new List<Package>();
            //this.zipCodesServed.AddRange(zipCodesServed);
            //this.transports.AddRange(transports);
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

        public bool addPackage(Package package)
        {
            if (VolumeAvailable < package.Volume)
                return false;

            packages.Add(package);
            currentVolume += (int)package.Volume;
            return true;
        }

        public void removePackage(Package package)
        {
            packages.Remove(package);
            currentVolume -= (int)package.Volume;
        } 
        #endregion


        #region Public Properties
        public int VolumeAvailable { get { return VolumeCapacity - currentVolume; } }

        public int VolumeCapacity { get; set; }

        public Package[] Packages { get { return packages.ToArray(); } }

        public Route[] Routes { get { return routes.ToArray(); } } 
        #endregion
    }
}
