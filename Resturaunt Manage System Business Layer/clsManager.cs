using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsManager : clsEmployee
    {
        public string AccessLevel { get; set; } = "";
        public string Department { get; set; }


        // Default constructor
        public clsManager() { }
        
        // Parameterized constructor
        public clsManager(string firstName, string lastName, string phoneNumber,
                       DateTime hireDate, string accessLevel,
                       string email = null, string department = null)
            : base(firstName, lastName, phoneNumber, hireDate, "MANAGER", email)
        {
            AccessLevel = accessLevel;
            Department = department;
        }


        public static clsManager Insert(clsManager manager)
        {
            int newEmployeeId = 0;
            bool success = ManagerDataAccess.Insert(manager.FirstName,
                                                    manager.LastName,
                                                    manager.PhoneNumber,
                                                    manager.Email,
                                                    manager.HireDate,
                                                    manager.AccessLevel,
                                                    manager.Department,
                                                    ref newEmployeeId);
            if (success)
            {
                manager.EmployeeId = newEmployeeId;
                return manager;
            }
            return null;
        }

        public static clsManager GetById(int employeeId)
        {
            string firstName = "", lastName = "", phoneNumber = "", email = "";
            DateTime hireDate = DateTime.MinValue;
            string role = "", status = "", accessLevel = "", department = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = ManagerDataAccess.GetById(employeeId,
                                                   ref firstName,
                                                   ref lastName,
                                                   ref phoneNumber,
                                                   ref email,
                                                   ref hireDate,
                                                   ref role,
                                                   ref status,
                                                   ref createdAt,
                                                   ref accessLevel,
                                                   ref department);
            if (found)
            {
                return new clsManager
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
                    AccessLevel = accessLevel,
                    Department = department
                };
            }
            return null;
        }

        /*
        public static List<clsManager> GetAll()
        {
            List<clsManager> managers = null;
            bool success = ManagerDataAccess.GetAll(ref managers);
            return success ? managers : new List<clsManager>();
        }
        */

        public static bool Update(clsManager manager)
        {
            return ManagerDataAccess.Update(manager.EmployeeId,
                                            manager.FirstName,
                                            manager.LastName,
                                            manager.PhoneNumber,
                                            manager.Email,
                                            manager.HireDate,
                                            manager.AccessLevel,
                                            manager.Department);
        }

        public static bool Delete(int employeeId)
        {
            return ManagerDataAccess.Delete(employeeId);
        }
    }
}
