using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Transport : Moveable
    {
        public enum TRANPORT_TYPES
        {
            truck,
            train,
            air
        }

        public Transport(string id, int transportType, int volumeCapacity, int weightCapacity, bool tempControlled, Route route)
            : base(id, volumeCapacity,weightCapacity,route)
        {
            TransportType = transportType;
            TempControlled = tempControlled;
        }

        public Transport(string id, int transportType, int volumeCapacity, int weightCapacity, bool tempControlled)
            : base(id, volumeCapacity, weightCapacity)
        {
            TransportType = transportType;
            TempControlled = tempControlled;
        }


        public int TransportType { get; set; }

        public bool TempControlled { get; set; }
    }
}

