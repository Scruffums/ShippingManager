using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class Warehouse : Location
    {
        //private List<int> zipCodesServed;
        private List<Route> routes;

        public Warehouse(Address a, int volumeCapacity)
        {
            VolumeCapacity = volumeCapacity;
            LocationAddress = a;
            //this.zipCodesServed = new List<int>();
            //this.transports = new List<Transport>();
            //this.deliveryVehicles = new List<DeliveryVehicle>();

            routes = new List<Route>();
            //this.zipCodesServed.AddRange(zipCodesServed);
            //this.transports.AddRange(transports);
            //this.deliveryVehicles.AddRange(deliveryVehicles);
        }

        public bool addRoute(Route r)
        {
            if (routes.Contains(r))
                return false;
            routes.Add(r);
            return true;
        }

        public void removeRoute(Route r)
        {
            routes.Remove(r);
        }

        //public bool addDeliveryVehicle(DeliveryVehicle deliveryVehicle)
        //{
        //    if (deliveryVehicles.Contains(deliveryVehicle))
        //        return false;
        //    deliveryVehicles.Add(deliveryVehicle);
        //    return true;
        //}

        //public void removeDeliveryVehicle(DeliveryVehicle deliveryVehicle)
        //{
        //    deliveryVehicles.Remove(deliveryVehicle);
        //}

        //public bool addTransport(Transport transport)
        //{
        //    if (transports.Contains(transport))
        //        return false;
        //    transports.Add(transport);
        //    return true;
        //}

        //public void removeTransport(Transport transport)
        //{
        //    transports.Remove(transport);
        //}

        public int VolumeCapacity { get; set; }
    }
}
