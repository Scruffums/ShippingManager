using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Abroad : Location
    {
        //private int[] zipCodes;

        public Abroad(Address locationAddress, string[] zipCodes)
        {
            LocationAddress = locationAddress;
            ZipCodes = zipCodes;
        }

        public String[] ZipCodes
        {
            get;
            set;
        }

        public bool ContainsZipCode(string zipCode)
        {
            foreach (string i in ZipCodes)
                if (i == zipCode)
                    return true;

            return false;
        }
    }
}
