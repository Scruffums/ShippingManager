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
        private List<Warehouse> warehouses;
        private List<StoreFront> storeFronts;
        private List<Employee> employees;
        private List<Moveable> moveables;

        public ShippingSystem()
        {
            packages = new List<Package>();
            warehouses = new List<Warehouse>();
            storeFronts = new List<StoreFront>();
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

        
    }
}
