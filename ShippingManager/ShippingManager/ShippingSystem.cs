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

        public Package AddPackage(int weight, float[] size, int mailService, bool fragile, bool irregular, bool perishable, Address source, Address destination)
        {
            Package p = new Package(weight,size,mailService,fragile,irregular,perishable,source,destination);
            (LoggedInEmployee as AcceptanceEmployee).CurrentStoreFront.addPackage(p);
            packages.Add(p);
            p.takeSnapshot("Package Accepted", (LoggedInEmployee as AcceptanceEmployee).CurrentStoreFront);
            return p;
        }

        public void updateadjacency()
        {
            path(weightedAdjacency(Locations, Routes));
        }

        private float[,] weightedAdjacency(Location[] locations, Route[] routes)
        {
            float[,] temp = new float[locations.Length, locations.Length];

            for(int i=0; i<locations.Length;++i)
                for(int j=0; j<locations.Length;++j)
                    temp[i,j] = float.PositiveInfinity;

            for (int i = 0; i < locations.Length - 1; ++i)
                for (int j = i + 1; j < locations.Length; ++j)
                    for (int m = 0; m < routes.Length; ++m)
                        if ((routes[m].Locations[0].Equals(locations[i]) && routes[m].Locations[1].Equals(locations[j])) || (routes[m].Locations[1].Equals(locations[i]) && routes[m].Locations[0].Equals(locations[j])))
                            temp[j, i] = temp[i, j] = routes[m].DurationInDays;
            return temp;
        }

        private int[,] path(float[,] weightedAdjacency)
        {
            int[,] path = new int[9, 9];
            
            //Seed path
            for (int i = 0; i < weightedAdjacency.GetLength(0); ++i)
                for (int j = 0; j < weightedAdjacency.GetLength(1); ++j)
                    if (weightedAdjacency[i, j] != float.PositiveInfinity)
                        path[i, j] = -1;
                    else
                        path[i, j] = int.MinValue;
            
            //Transitive closure
            for (int i = 0; i < path.GetLength(0); ++i)
                for (int j = 0; j < path.GetLength(1); ++j)
                    if (path[i, j] == -1)
                        for (int k = 0; k < path.GetLength(1); ++k)
                            if (path[j, k] == -1 && k != i)
                            {
                                float weight = weightedAdjacency[i, j] + weightedAdjacency[j, k];
                                if (weight < weightedAdjacency[i, k])
                                {
                                    path[i, k] = j;
                                    weightedAdjacency[i, k] = weight;
                                }
                            }

            int[,] augmentedPath;
            float[,] augmentedWeighted;
            bool change;

            do
            {
                change = false;
                augmentedPath = path;
                augmentedWeighted = weightedAdjacency;

                for (int i = 0; i < path.GetLength(0); ++i)
                    for (int j = 0; j < path.GetLength(1); ++j)
                        if (path[i, j] > -1)
                            for (int k = 0; k < path.GetLength(1); ++k)
                                if (path[j, k] == -1)
                                {
                                    float weight = weightedAdjacency[i, j] + weightedAdjacency[j, k];//weightedAdjacency[i, path[i,j]] + weightedAdjacency[path[i,j], k]+ weightedAdjacency[j,k];
                                    if (weight < weightedAdjacency[i, k])
                                    {
                                        change = true;
                                        augmentedPath[i, k] = path[i, j];
                                        augmentedWeighted[i, k] = weight;
                                    }
                                }
                path = augmentedPath;
                weightedAdjacency = augmentedWeighted;
            } while (change);
            


            return augmentedPath;
        }

        public Package lookupTrackingNumber(string trackingNumber)
        {
            foreach (Package p in packages)
                if (p.TrackingNumber == trackingNumber)
                    return p;
            return null;
        }
    }
}
