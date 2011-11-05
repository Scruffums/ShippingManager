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

        public ShippingSystem()
        {
            packages = new List<Package>();
            locations = new List<Location>();
            employees = new List<Employee>();
            moveables = new List<Moveable>();
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

        public bool addAdminEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            AdminEmployee a = new AdminEmployee(firstName, middleName, lastName, id, plainTextPassword);
            return addEmployee(a);
        }

        public bool addAcceptanceEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            AcceptanceEmployee a = new AcceptanceEmployee(firstName, middleName, lastName, id, plainTextPassword);
            return addEmployee(a);
        }

        public bool addWarehouseEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            WarehouseEmployee a = new WarehouseEmployee(firstName, middleName, lastName, id, plainTextPassword);
            return addEmployee(a);
        }

        public bool addDeliveryEmployee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            DeliveryEmployee a = new DeliveryEmployee(firstName, middleName, lastName, id, plainTextPassword);
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
    }
}
