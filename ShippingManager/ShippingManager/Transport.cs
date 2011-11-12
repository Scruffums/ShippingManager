using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Transport : Moveable
    {
        public enum TRANSPORT_TYPES
        {
            ground,
            air
        }

        public Transport(string id, TRANSPORT_TYPES transportType, int volumeCapacity, int weightCapacity, bool tempControlled, Route route)
            : base(id, volumeCapacity,weightCapacity,route)
        {
            TransportType = transportType;
            TempControlled = tempControlled;
        }

        public Transport(string id, TRANSPORT_TYPES transportType, int volumeCapacity, int weightCapacity, bool tempControlled)
            : base(id, volumeCapacity, weightCapacity)
        {
            TransportType = transportType;
            TempControlled = tempControlled;
        }

        
        public TRANSPORT_TYPES TransportType { get; set; }

        public bool TempControlled { get; set; }
    }
}

