

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Represents a generalized location determined by a group of zipcodes. (Typically used to represent all the zip codes of a county)
    /// </summary>
    [Serializable()]
    public class Abroad : Location
    {
        public Abroad(Address locationAddress, string[] zipCodes)
        {
            LocationAddress = locationAddress;
            LocationAddress.StreetAddress = zipCodes[0];
            ZipCodes = zipCodes;
        }

        /// <summary>
        /// An array of type string, where each string is a 5 digit zipcode.
        /// </summary>
        public string[] ZipCodes
        {
            get;
            set;
        }

        /// <summary>
        /// Used to determine whether a partcular Abroad object contains a specified zip code
        /// </summary>
        /// <param name="zipCode">A String representing a zip code</param>
        /// <returns></returns>
        public bool ContainsZipCode(string zipCode)
        {
            foreach (string i in ZipCodes)
                if (i == zipCode)
                    return true;

            return false;
        }

        /// <summary>
        /// A convenience method for formatting the contained zip code strings into a single string where each zip code is seperated by a comma.
        /// </summary>
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
