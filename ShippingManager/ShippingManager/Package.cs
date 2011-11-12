using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Package
    {
        private DateTime acceptedDate;
        private DateTime deliveryEstimate;
        private  float[] size;
        private List<Snapshot> snapshots;
        private Location destinationLocation;

        public enum SERVICE_TYPE
        {
            Economy,
            Air
        }

        public enum WEIGHT_CLASS
        {
            _1oz_8oz,
            _9oz_1lb,
            _1lb_2lb,
            _2lb_3lb,
            _3lb_5lb,
            _5lb_8lb,
            _8lb_15lb,
            _15lb_25lb,
            _25lb_50lb,
            _50lb_greater
        }

        public Package(int weight, float[] size, SERVICE_TYPE mailService, bool fragile, bool irregular, bool perishable, Address source, Address destination, Location currentLocation, Location destinationLocation, int travelTime)
        {
            Weight = weight;
            Size = size;
            MailService = mailService;
            Fragile = fragile;
            Irregular = irregular;
            Perishable = perishable;
            Destination = destination;
            Source = source;
            TrackingNumber = generateTrackingNumber();
            CurrentLocation = currentLocation;
            this.destinationLocation = destinationLocation;
            snapshots = new List<Snapshot>();
            acceptedDate = DateTime.Now;
            deliveryEstimate = acceptedDate.AddDays(travelTime);
        }

        public void takeSnapshot(String message, Location location)
        {
            snapshots.Add(new Snapshot(message,location));
        }


        private String generateTrackingNumber()
        {
            return DateTime.Now.Ticks.ToString();
        }

        public override string ToString()
        {
            return TrackingNumber;
        }

        public override bool Equals(object obj)
        {
            Package p = obj as Package;
            if (p == null)
                return false;
            return p.TrackingNumber==TrackingNumber;
        }

        public float Volume { get { return size[0] * size[1] * size[3]; } }

        public DateTime AcceptedDate { get { return acceptedDate; } }

        public DateTime DeliveryEstimate { get { return deliveryEstimate; } }

        public String TrackingNumber { get; set; }

        public int Weight { get; set; }

        public float[] Size { get{return size;} set{size=value;} }

        public SERVICE_TYPE MailService { get; set; }

        public bool Fragile { get; set; }

        public bool Irregular { get; set; }

        public bool Perishable { get; set; }

        public Address Destination { get; set; }

        public Address Source { get; set; }

        public Location CurrentLocation { get; set; }

        public Location DestinationLocation { get { return destinationLocation; } }
    }
}
