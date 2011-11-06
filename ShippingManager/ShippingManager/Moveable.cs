using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public abstract class Moveable
    {
        private List<Package> packages;
        private int currentWeight, currentVolume;
        private Location currentLocation;
        private Location home;


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

        public String Id { get; set; }

        public String StringType { get { return (this is Transport)? "Transport":"Delivery Vehicle"; } }

        public int VolumeAvailable { get { return VolumeCapacity - currentVolume; } }
        public int WeightAvailable { get { return WeightCapacity - currentWeight; } }

        public int VolumeCapacity { get; set; }

        public int WeightCapacity { get; set; }

        public Route CurrentRoute { get; set; }

        public Location CurrentLocation { get { return currentLocation; } }

        public bool Full { get { return (currentWeight > WeightCapacity || currentVolume > VolumeCapacity); } }

        public bool Homeless { get { return home == null; } }

        public Location Home { get { return home; } }
    }
}
