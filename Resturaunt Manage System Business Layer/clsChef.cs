using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsChef : clsEmployee
    {
        public string Specialty { get; set; } = "";
        public string CertificationLevel { get; set; }


        // Default constructor
        public clsChef() { }

        // Parameterized constructor
        public clsChef(string firstName, string lastName, string phoneNumber,
                    DateTime hireDate, string specialty,
                    string email = null, string certificationLevel = null)
            : base(firstName, lastName, phoneNumber, hireDate, "CHEF", email)
        {
            Specialty = specialty;
            CertificationLevel = certificationLevel;
        }

        public static clsChef Insert(clsChef chef)
        {
            int newEmployeeId = 0;
            bool success = ChefDataAccess.Insert(chef.FirstName,
                                                 chef.LastName,
                                                 chef.PhoneNumber,
                                                 chef.Email,
                                                 chef.HireDate,
                                                 chef.Specialty,
                                                 chef.CertificationLevel,
                                                 ref newEmployeeId);
            if (success)
            {
                chef.EmployeeId = newEmployeeId;
                return chef;
            }
            return null;
        }

        public static clsChef GetById(int employeeId)
        {
            string firstName = "", lastName = "", phoneNumber = "", email = "";
            DateTime hireDate = DateTime.MinValue;
            string role = "", status = "", specialty = "", certificationLevel = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = ChefDataAccess.GetById(employeeId,
                                                ref firstName,
                                                ref lastName,
                                                ref phoneNumber,
                                                ref email,
                                                ref hireDate,
                                                ref role,
                                                ref status,
                                                ref createdAt,
                                                ref specialty,
                                                ref certificationLevel);
            if (found)
            {
                return new clsChef
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
                    Specialty = specialty,
                    CertificationLevel = certificationLevel
                };
            }
            return null;
        }

        /*
        public static List<clsChef> GetAll()
        {
            List<clsChef> chefs = null;
            bool success = ChefDataAccess.GetAll(ref chefs);
            return success ? chefs : new List<clsChef>();
        }
        */

        public static bool Update(clsChef chef)
        {
            return ChefDataAccess.Update(chef.EmployeeId,
                                         chef.FirstName,
                                         chef.LastName,
                                         chef.PhoneNumber,
                                         chef.Email,
                                         chef.HireDate,
                                         chef.Specialty,
                                         chef.CertificationLevel);
        }

        public static bool Delete(int employeeId)
        {
            return ChefDataAccess.Delete(employeeId);
        }
    }
}
