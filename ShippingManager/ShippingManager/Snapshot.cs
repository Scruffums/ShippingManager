using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
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
