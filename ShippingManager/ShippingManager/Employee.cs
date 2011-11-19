using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ShippingManager
{
    /// <summary>
    /// Abstract class which states required implemenation for any subclasses. Responsibilites are password hashing and matching, and id matching.
    /// Also represents basic employee information pertinent to any employee (name, id, password).
    /// </summary>
    [Serializable()]
    public abstract class Employee
    {
        #region Protected Fields
        protected string firstName;
        protected string lastName;
        protected string middleName;
        protected string id;
        protected string passwordHash;
        [field: NonSerialized()]
        protected static MD5CryptoServiceProvider hashFunction; 
        #endregion

        protected Employee(string firstName, string middleName, string lastName, string id, string plainTextPassword)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Id = id;

            initializeHashFunction();
            passwordHash = hashPassword(plainTextPassword);
        }


        #region Private and Protected Methods
        private void initializeHashFunction()
        {
            if (hashFunction == null)
                hashFunction = new System.Security.Cryptography.MD5CryptoServiceProvider();
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
        #endregion

        #region Public Methods
        /// <summary>
        /// Determines whether the provided string id and the id of an instance of this class match.
        /// </summary>
        /// <param name="id">string id to be matched against</param>
        /// <returns>Returns true if id matches</returns>
        public bool IdMatch(string id)
        {
            return id.Equals(Id);
        }

        /// <summary>
        /// Hashes provided plain text password and checks for a match against this instance's password hash value
        /// </summary>
        /// <param name="plainTextPassword">string of a plaint text password</param>
        /// <returns>Returns true if the plain text password matches</returns>
        public bool PasswordMatch(string plainTextPassword)
        {
            return hashPassword(plainTextPassword).Equals(passwordHash);
        }

        /// <summary>
        /// Password of this instance is changed if oldPassword matches the current password of this instance.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool changePassword(string oldPassword, string newPassword)
        {
            if (PasswordMatch(oldPassword))
            {
                setPassword(newPassword);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Password of this instance is changed if the employee is of type AdminEmployee.
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool changePassword(Employee employee, string newPassword)
        {
            if (employee is AdminEmployee)
            {
                setPassword(newPassword);
                return true;
            }
            return false;
        } 
        #endregion

        #region Overriden Methods
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
            return StringType + ": " + Id + ": " + FirstName + " " + LastName;
        } 
        #endregion

        #region Public Fields
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

        public String StringType { get { if (this is AdminEmployee)return "Admin"; else if (this is AcceptanceEmployee)return "Acceptance"; else if (this is WarehouseEmployee)return "Warehouse"; else return "Delivery"; } }

        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }

        } 
        #endregion

    }
}
