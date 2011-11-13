using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Route
    {
        private Location[] locations;

        public Route (string id, float durationInDays, Location one, Location two, Moveable move)
        {
            locations = new Location[] { one, two };
            Id = id;
            DurationInDays = durationInDays;
            CurrentMoveable = move;
        }

        public override bool Equals(object obj)
        {
            Route r = obj as Route;
            if (r == null)
                return false;
            return r.Id == Id;
        }

        public bool containsLocation(Location location)
        {
            return Locations[0].Equals(location) || Locations[1].Equals(location);
        }

        public override string ToString()
        {
            return CurrentMoveable.StringType+": "+locations[0].Id+" "+CurrentMoveable.Id+" "+locations[1].Id;
        }

        public Moveable CurrentMoveable { get; set; }
        public bool Moveableless { get { return CurrentMoveable == null; } }
        public float DurationInDays { get; set; }
        public string Id { get; set; }
        public Location[] Locations { get { return locations; } }

    }
}
