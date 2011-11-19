using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    /// <summary>
    /// Represents all required information to describe a step in a package's route. (i.e. leaving a warehouse)
    /// </summary>
    [Serializable()]
    public class Snapshot
    {
        private Location location;
        private DateTime date;
        private string message;

        public Snapshot(string message, Location location)
        {
            this.message = message;
            this.location = location;
            date = DateTime.Now;
        }

        public override string ToString()
        {
            return message+": "+location+": "+date;
        }
    }
}
