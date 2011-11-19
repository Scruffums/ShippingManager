using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Abroad : Location
    {
        public Abroad(Address locationAddress, string[] zipCodes)
        {
            LocationAddress = locationAddress;
            LocationAddress.StreetAddress = zipCodes[0];
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

        public string ZipcodesString 
        {
            get
            {
                String[] zipCodes = ZipCodes;
                StringBuilder b = new StringBuilder();
                for(int i=0; i<zipCodes.Length; i++)
                {
                    b.Append(zipCodes[i]);
                    if(i<zipCodes.Length-1)
                        b.Append(",");
                }
                return b.ToString();
            }
        }
    }
}
