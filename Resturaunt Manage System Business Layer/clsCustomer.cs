using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsCustomer
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }


        // Default constructor
        public  clsCustomer() { }

        // Parameterized constructor
        public clsCustomer(string phoneNumber, string firstName, string lastName,
                        string email = null, string address = null)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public static bool Insert(clsCustomer customer)
        {
            int newCustomerId = 0;
           return CustomerDataAccess.Insert(customer.PhoneNumber,
                                                     customer.FirstName,
                                                     customer.LastName,
                                                     customer.Email,
                                                     customer.Address,
                                                     ref newCustomerId);
        }

        public static clsCustomer GetById(int customerId)
        {
            string phoneNumber = "", firstName = "", lastName = "", email = "", address = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = CustomerDataAccess.GetById(customerId,
                                                    ref phoneNumber,
                                                    ref firstName,
                                                    ref lastName,
                                                    ref email,
                                                    ref address,
                                                    ref createdAt);
            if (found)
            {
                return new clsCustomer
                {
                    CustomerId = customerId,
                    PhoneNumber = phoneNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address = address,
                    CreatedAt = createdAt
                };
            }
            return null;
        }

        /*
        public static List<clsCustomer> GetAll()
        {
            List<clsCustomer> customers = null;
            bool success = CustomerDataAccess.GetAll(ref customers);
            return success ? customers : new List<Customer>();
        }
        */

        public static clsCustomer GetByPhone(string phoneNumber)
        {
            int customerId = 0;
            string firstName = "", lastName = "", email = "", address = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = CustomerDataAccess.GetByPhone(phoneNumber,
                                                       ref customerId,
                                                       ref firstName,
                                                       ref lastName,
                                                       ref email,
                                                       ref address,
                                                       ref createdAt);
            if (found)
            {
                return new clsCustomer
                {
                    CustomerId = customerId,
                    PhoneNumber = phoneNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Address = address,
                    CreatedAt = createdAt
                };
            }
            return null;
        }

        public static bool Update(clsCustomer customer)
        {
            return CustomerDataAccess.Update(customer.CustomerId,
                                             customer.PhoneNumber,
                                             customer.FirstName,
                                             customer.LastName,
                                             customer.Email,
                                             customer.Address);
        }

        public static bool Delete(int customerId)
        {
            return CustomerDataAccess.Delete(customerId);
        }
    }

}
