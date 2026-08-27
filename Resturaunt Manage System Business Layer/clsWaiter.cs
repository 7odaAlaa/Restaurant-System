using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class ClsWaiter : clsEmployee
    {
        public string Section { get; set; } = "";
        public string ServiceArea { get; set; }


        // Default constructor
        public ClsWaiter() { }

        // Parameterized constructor
        public ClsWaiter(string firstName, string lastName, string phoneNumber,
                      DateTime hireDate, string section,
                      string email = null, string serviceArea = null)
            : base(firstName, lastName, phoneNumber, hireDate, "WAITER", email)
        {
            Section = section;
            ServiceArea = serviceArea;
        }

        public static ClsWaiter Insert(ClsWaiter waiter)
        {
            int newEmployeeId = 0;
            bool success = WaiterDataAccess.Insert(waiter.FirstName,
                                                   waiter.LastName,
                                                   waiter.PhoneNumber,
                                                   waiter.Email,
                                                   waiter.HireDate,
                                                   waiter.Section,
                                                   waiter.ServiceArea,
                                                   ref newEmployeeId);
            if (success)
            {
                waiter.EmployeeId = newEmployeeId;
                return waiter;
            }
            return null;
        }

        public static ClsWaiter GetById(int employeeId)
        {
            string firstName = "", lastName = "", phoneNumber = "", email = "";
            DateTime hireDate = DateTime.MinValue;
            string role = "", status = "", section = "", serviceArea = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = WaiterDataAccess.GetById(employeeId,
                                                  ref firstName,
                                                  ref lastName,
                                                  ref phoneNumber,
                                                  ref email,
                                                  ref hireDate,
                                                  ref role,
                                                  ref status,
                                                  ref createdAt,
                                                  ref section,
                                                  ref serviceArea);
            if (found)
            {
                return new ClsWaiter
                {
                    EmployeeId = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    HireDate = hireDate,
                    Role = role,
                    Status = status,
                    CreatedAt = createdAt,
                    Section = section,
                    ServiceArea = serviceArea
                };
            }
            return null;
        }

        
        /*
        public static List<Waiter> GetAll()
        {
            List<Waiter> waiters = null;
            bool success = WaiterDataAccess.GetAll(ref waiters);
            return success ? waiters : new List<Waiter>();
        }
        */


        public static bool Update(ClsWaiter waiter)
        {
            return WaiterDataAccess.Update(waiter.EmployeeId,
                                           waiter.FirstName,
                                           waiter.LastName,
                                           waiter.PhoneNumber,
                                           waiter.Email,
                                           waiter.HireDate,
                                           waiter.Section,
                                           waiter.ServiceArea);
        }

        public static bool Delete(int employeeId)
        {
            return WaiterDataAccess.Delete(employeeId);
        }
    }
}
