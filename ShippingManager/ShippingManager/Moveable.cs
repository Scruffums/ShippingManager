using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public abstract class Moveable
    {
        #region Private Fields
        private List<Package> packages;
        private int currentWeight, currentVolume;
        private Location currentLocation;
        private Location home;
        private Route route; 
        #endregion


        //Maybe I should use a default value instead of overloading constructors...
        public Moveable(string id, int volumeCapacity, int weightCapacity) : this(id, volumeCapacity, weightCapacity, null)
        {
        }

        public Moveable(string id, int volumeCapacity, int weightCapacity, Route route)
        {
            packages = new List<Package>();

            VolumeCapacity = volumeCapacity;
            WeightCapacity = weightCapacity;
            CurrentRoute = route;
            Id = id;
        }

        #region Public Methods
        public bool hasPackage(Package p)
        {
            return -1 != packages.IndexOf(p);
        }

        public bool addPackage(Package package)
        {
            if (packages.Contains(package))
                return false;
            if (VolumeAvailable < package.Volume || WeightAvailable < package.Weight)
                return false;
            packages.Add(package);
            currentWeight += package.Weight;
            currentVolume += (int)package.Volume;
            return true;
        }

        public void removePackage(Package package)
        {
            if (packages.Contains(package))
            {
                packages.Remove(package);
                currentWeight -= package.Weight;
                currentVolume -= (int)package.Volume;
            }
        }

        public bool setHome(Location loc)
        {
            if (Homeless && !(loc is Abroad))
            {
                home = loc;
                return true;
            }
            return false;
        }

        public void clearHome()
        {
            home = null;
        }

        public override string ToString()
        {
            return StringType + ": " + Id;
        }

        public bool assignRoute(Route rou)
        {
            if (Routeless)
            {
                route = rou;
                return true;
            }
            return false;
        }

        public void removeRoute(Route rou)
        {
            if (route.Equals(rou))
                route = null;
        }

        public override bool Equals(object obj)
        {
            Moveable m = obj as Moveable;
            if (m == null)
                return false;
            return m.Id == Id;
        } 
        #endregion

        #region Public Properties
        public bool Routeless { get { return route == null; } }

        public String Id { get; set; }

        public String StringType { get { return (this is Transport) ? ((this as Transport).TransportType == 0) ? "Ground Transport" : "Air Transport" : "Delivery Vehicle"; } }

        public int VolumeAvailable { get { return VolumeCapacity - currentVolume; } }

        public int WeightAvailable { get { return WeightCapacity - currentWeight; } }

        public int VolumeCapacity { get; set; }

        public int WeightCapacity { get; set; }

        public Location CurrentLocation { get { return currentLocation; } }

        public bool Full { get { return (currentWeight > WeightCapacity || currentVolume > VolumeCapacity); } }

        public bool Homeless { get { return home == null; } }

        public Location Home { get { return home; } }

        public Route CurrentRoute { get { return route; } set { route = value; } }

        public void changeLocation()
        {
            currentLocation = (route.Locations[0] == currentLocation) ? route.Locations[1] : route.Locations[0];
        }

        public Package[] Packages { get { return packages.ToArray(); } } 
        #endregion
    }
}
