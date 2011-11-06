using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShippingManager
{
    [Serializable()]
    public class ShippingSystem
    {
        [field: NonSerialized()]
        private Employee loggedInEmployee;

        private List<Package> packages;
        private List<Location> locations;
        private List<Employee> employees;
        private List<Moveable> moveables;
        private List<Route> routes;

        public ShippingSystem()
        {
            packages = new List<Package>();
            locations = new List<Location>();
            employees = new List<Employee>();
            moveables = new List<Moveable>();
            routes = new List<Route>();
        }

        public Employee validateEmployeeLogin(string id, string plainTextPassword)
        {
            foreach (Employee e in employees)
                if (e.IdMatch(id))
                    if (e.PasswordMatch(plainTextPassword))
                    {
                        loggedInEmployee = e;
                        return e;
                    }
            return null;
        }

        public int indexOf(Location location)
        {
            return locations.IndexOf(location);
        }

        public bool addAdminEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            AdminEmployee a = new AdminEmployee(firstName, middleName, lastName, id, plainTextPassword);
            return addEmployee(a);
        }

        public bool addAcceptanceEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword, StoreFront s)
        {
            AcceptanceEmployee a = new AcceptanceEmployee(firstName, middleName, lastName, id, plainTextPassword);
            a.CurrentStoreFront = s;
            return addEmployee(a);
        }

        public bool addWarehouseEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword, Location l)
        {
            WarehouseEmployee a = new WarehouseEmployee(firstName, middleName, lastName, id, plainTextPassword);
            a.CurrentLocation = l;
            return addEmployee(a);
        }

        public bool addDeliveryEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword, Route r)
        {
            DeliveryEmployee a = new DeliveryEmployee(firstName, middleName, lastName, id, plainTextPassword);
            a.CurrentRoute = r;
            return addEmployee(a);
        }

        public bool addEmployee(Employee e)
        {
            if (employees.Contains(e))
                return false;
            employees.Add(e);
            return true;
        }

        public Employee getEmployee(string id)
        {
            foreach (Employee e in employees)
                if (e.Id.Equals(id))
                    return e;
            return null;
        }

        public Employee LoggedInEmployee { get { return loggedInEmployee; } }

        public int EmployeeCount { get { return employees.Count; } }

        public Employee[] Employees { get { return employees.ToArray(); } }

        public void logOut()
        {
            loggedInEmployee = null;
        }



        public Location[] Locations { get { return locations.ToArray(); } }

        public bool addStoreFront(string id, string streetAddress, string zipcode)
        {
            Address a = new Address(id,streetAddress,zipcode);
            StoreFront sf = new StoreFront(a);
            if (locations.Contains(sf))
                return false;
            locations.Add(sf);
            return true;
        }

        public bool addWarehouse(string id, string streetAddress, string zipcode, int volumeCapacity)
        {
            Address a = new Address(id, streetAddress, zipcode);
            Warehouse sf = new Warehouse(a, volumeCapacity);
            if (locations.Contains(sf))
                return false;
            locations.Add(sf);
            return true;
        }

        public bool addAbroad(string id, string streetAddress, string zipcode, string[] zipcodesServed)
        {
            Address a = new Address(id, streetAddress, zipcode);
            Abroad sf = new Abroad(a, zipcodesServed);
            if (locations.Contains(sf))
                return false;
            locations.Add(sf);
            return true;
        }

        public Moveable[] Moveables { get { return moveables.ToArray(); } }



        public bool addDeliveryVehicle(string id, int volumeCapacity, int weightCapacity)
        {
            DeliveryVehicle d = new DeliveryVehicle(id, volumeCapacity, weightCapacity);
            if (moveables.Contains(d))
                return false;
            moveables.Add(d);
            return true;
        }

        public bool addTransport(string id, int type, int volumeCapacity, int weightCapacity, bool temperatureControlled)
        {
            Transport d = new Transport(id, type, volumeCapacity, weightCapacity, temperatureControlled);
            if (moveables.Contains(d))
                return false;
            moveables.Add(d);
            return true;
        }

        public bool addRoute(String id, float duration, Location one, Location two, Moveable move)
        {
            Route r = new Route(id, duration, one, two, move);
            if (routes.Contains(r))
                return false;
            move.assignRoute(r);
            routes.Add(r);
            foreach (Location rLocation in r.Locations)
            {
                if ( rLocation is StoreFront)
                    (rLocation as StoreFront).addRoute(r);
                else if( rLocation is Warehouse )
                    (rLocation as Warehouse).addRoute(r);
            }
            return true;
        }


        public Route[] Routes { get { return routes.ToArray(); } }
        public Moveable[] RoutelessMoveable { get { List<Moveable> temp = new List<Moveable>(); foreach (Moveable m in moveables)if (m.Routeless)temp.Add(m); return temp.ToArray(); } }

        public StoreFront[] StoreFronts { get{List<StoreFront> temp = new List<StoreFront>(); foreach (Location m in locations)if (m is StoreFront)temp.Add(m as StoreFront); return temp.ToArray(); } }
        public Warehouse[] Warehouses { get { List<Warehouse> temp = new List<Warehouse>(); foreach (Location m in locations)if (m is Warehouse)temp.Add(m as Warehouse); return temp.ToArray(); }  }

        public DeliveryVehicle[] DeliveryVehicles { get { List<DeliveryVehicle> temp = new List<DeliveryVehicle>(); foreach (DeliveryVehicle m in moveables)if (m is DeliveryVehicle)temp.Add(m as DeliveryVehicle); return temp.ToArray(); } }
    }
}
