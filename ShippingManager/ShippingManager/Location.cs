using System;
using System.Collections.Generic;

namespace ShippingManager
{
    /// <summary>
    /// Abstract class which states required implemenation for any subclasses. Contains required field, and properties.
    /// </summary>
    [Serializable()]
    public abstract class Location
    {
        private Address locationAddress;


        public override bool Equals(object obj)
        {
            Location l = obj as Location;
            if (l==null)
                return false;

            return l.LocationAddress.Equals(LocationAddress);
        }

        public override string ToString()
        {
            return StringType + ": " + locationAddress.Addressee;
        }


        public Address LocationAddress
        {
            get { return locationAddress; }
            set { locationAddress= value; }
        }

        public string StringType { get { if (this is StoreFront)return "Store Front"; else if (this is Warehouse)return "Warehouse"; else if (this is Abroad)return "Abroad"; else return "Delivery"; } }

        public string Id { get { return locationAddress.Addressee; } set { locationAddress.Addressee = value; } }

        public string StreetAddress { get { return locationAddress.StreetAddress; } set { locationAddress.StreetAddress = value; } }

        public string Zipcode { get { return locationAddress.Zip; } set { locationAddress.Zip = value; } }

    }
}
