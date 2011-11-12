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

        private float[,] groundWeightedPathMatrix, airWeightedPathMatrix;
        private int[,] groundPathMatrix, airPathMatrix;


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

        public Abroad[] Abroads { get { List<Abroad> temp = new List<Abroad>(); foreach (Location l in locations)if (l is Abroad)temp.Add(l as Abroad); return temp.ToArray(); } }

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
            Transport d = new Transport(id, (type==0)?Transport.TRANSPORT_TYPES.ground:Transport.TRANSPORT_TYPES.air, volumeCapacity, weightCapacity, temperatureControlled);
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
        public Route[] GroundRoutes { get { List<Route> temp = new List<Route>(); foreach (Route r in routes)if (r.CurrentMoveable is DeliveryVehicle || (r.CurrentMoveable as Transport).TransportType==Transport.TRANSPORT_TYPES.ground)temp.Add(r); return temp.ToArray(); } }

        public Moveable[] RoutelessMoveable { get { List<Moveable> temp = new List<Moveable>(); foreach (Moveable m in moveables)if (m.Routeless)temp.Add(m); return temp.ToArray(); } }

        public StoreFront[] StoreFronts { get{List<StoreFront> temp = new List<StoreFront>(); foreach (Location m in locations)if (m is StoreFront)temp.Add(m as StoreFront); return temp.ToArray(); } }
        public Warehouse[] Warehouses { get { List<Warehouse> temp = new List<Warehouse>(); foreach (Location m in locations)if (m is Warehouse)temp.Add(m as Warehouse); return temp.ToArray(); }  }

        public DeliveryVehicle[] DeliveryVehicles { get { List<DeliveryVehicle> temp = new List<DeliveryVehicle>(); foreach (DeliveryVehicle m in moveables)if (m is DeliveryVehicle)temp.Add(m as DeliveryVehicle); return temp.ToArray(); } }

        public Package AddPackage(int weight, float[] size, Package.SERVICE_TYPE mailService, bool fragile, bool irregular, bool perishable, Address source, Address destination)
        {
            Location destinationLocation = determineAbroad(destination.Zip);
            if(destinationLocation==null)
                return null;

            StoreFront sf = (LoggedInEmployee as AcceptanceEmployee).CurrentStoreFront;
            int travelTime = (mailService == Package.SERVICE_TYPE.Economy) ? determineGroundTravelTime(sf, destinationLocation) : determineAirTravelTime(sf, destinationLocation);

            Package p = new Package(weight,size,mailService,fragile,irregular,perishable,source,destination,sf,destinationLocation, travelTime);
            sf.addPackage(p);
            packages.Add(p);
            p.takeSnapshot("Package Accepted", sf);
            return p;
        }

        public Location nextLocation(Package p)
        {
            int start = locations.IndexOf(p.CurrentLocation);
            int end = locations.IndexOf(p.DestinationLocation);

            if (p.MailService == Package.SERVICE_TYPE.Air)
                return Locations[airPathMatrix[start, end]];
            return Locations[groundPathMatrix[start, end]];
        }

        private int determineAirTravelTime(Location startLocation, Location endLocation)
        {
            int start = locations.IndexOf(startLocation);
            int end = locations.IndexOf(endLocation);
            return (int)(airWeightedPathMatrix[start, end]+0.5);
        }

        private int determineGroundTravelTime(Location startLocation, Location endLocation)
        {
            int start = locations.IndexOf(startLocation);
            int end = locations.IndexOf(endLocation);
            return (int)(groundWeightedPathMatrix[start, end] + 0.5);
        }
        private Abroad determineAbroad(string zip)
        {
            foreach(Abroad a in Abroads)
                if(a.ContainsZipCode(zip))
                    return a;
            return null;
        }

        public void updateMatrices()
        {
            groundWeightedPathMatrix = weightedAdjacency(Locations, GroundRoutes);
            groundPathMatrix = path(ref groundWeightedPathMatrix);

            airWeightedPathMatrix = weightedAdjacency(Locations, Routes);
            airPathMatrix = path(ref airWeightedPathMatrix);
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

        private int[,] path(ref float[,] weightedPath)
        {
            int[,] path = new int[weightedPath.GetLength(0), weightedPath.GetLength(1)];
            
            //Seed path
            for (int i = 0; i < weightedPath.GetLength(0); ++i)
                for (int j = 0; j < weightedPath.GetLength(1); ++j)
                    if (weightedPath[i, j] != float.PositiveInfinity)
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
                                float weight = weightedPath[i, j] + weightedPath[j, k];
                                if (weight < weightedPath[i, k])
                                {
                                    path[i, k] = j;
                                    weightedPath[i, k] = weight;
                                }
                            }

            int[,] augmentedPath = new int[path.GetLength(0),path.GetLength(1)];
            //float[,] augmentedWeighted = new float[weightedPath.GetLength(0), weightedPath.GetLength(1)];
            bool change;

            do
            {
                change = false;
                Array.Copy(path, augmentedPath, augmentedPath.Length);
                //Array.Copy(weightedAdjacency, augmentedWeighted, weightedAdjacency.Length);

                for (int i = 0; i < path.GetLength(0); ++i)
                    for (int j = 0; j < path.GetLength(1); ++j)
                        if (path[i, j] > -1)
                            for (int k = 0; k < path.GetLength(1); ++k)
                                if (path[j, k] == -1 && k!=path[i,j])
                                {
                                    float weight = weightedPath[i, j] + weightedPath[j, k];//weightedAdjacency[i, path[i,j]] + weightedAdjacency[path[i,j], k]+ weightedAdjacency[j,k];
                                    if (weight < weightedPath[i, k])
                                    {
                                        change = true;
                                        augmentedPath[i, k] = path[i, j];
                                        //augmentedWeighted[i, k] = weight;
                                        weightedPath[i, k] = weight;
                                    }
                                }
                Array.Copy(augmentedPath, path, augmentedPath.Length);
                //Array.Copy(augmentedWeighted, weightedAdjacency, weightedAdjacency.Length);
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
