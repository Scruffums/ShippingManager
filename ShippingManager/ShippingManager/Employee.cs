using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ShippingManager
{
    [Serializable()]
    public abstract class Employee
    {
        protected string firstName;
        protected string lastName;
        protected string middleName;
        protected string id;
        protected string passwordHash;
        [field: NonSerialized()]
        protected static MD5CryptoServiceProvider hashFunction;

        protected Employee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Id = id;

            initializeHashFunction();
            passwordHash = hashPassword(plainTextPassword);
        }

        private void initializeHashFunction()
        {
            if(hashFunction==null)
                hashFunction = new System.Security.Cryptography.MD5CryptoServiceProvider();
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        public char MiddleInitial
        {
            get
            {
                return MiddleName.Substring(0, 1).ToCharArray()[0];
            }
        }

        public string Id
        {
            get;
            set;
        }

        public bool IdMatch (string id)
        {
            return id.Equals(Id);
        }

        public String StringType { get { if (this is AdminEmployee)return "Admin"; else if (this is AcceptanceEmployee)return "Acceptance"; else if (this is WarehouseEmployee)return "Warehouse"; else return "Delivery"; } }

        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }

        }

        public bool PasswordMatch(string plainTextPassword)
        {
            return hashPassword(plainTextPassword).Equals(passwordHash);
        }

        public bool changePassword(string oldPassword, string newPassword)
        {
            if (PasswordMatch(oldPassword))
            {
                setPassword(newPassword);
                return true;
            }
            return false;
        }

        public bool changePassword(Employee employee, string newPassword)
        {
            if (employee is AdminEmployee)
            {
                setPassword(newPassword);
                return true;
            }
            return false;
        }

        private void setPassword(string plainTextPassword)
        {
            passwordHash = hashPassword(plainTextPassword);
        }

        protected string hashPassword(string plainTextPassword)
        {
            initializeHashFunction();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(plainTextPassword);
            data = hashFunction.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        /*
         * Every Employee must have a unique Id, therefore, we only need to check Id equivalency
         */ 
        public override bool Equals(object obj)
        {
            Employee input = obj as Employee;
            if (input == null)
                return false;
            return input.IdMatch(Id);
        }

        public override string ToString()
        {
            return StringType+": "+Id + ": " + FirstName + " " + LastName;
        }


    }
}
