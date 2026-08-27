using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string Role { get; set; } = "";
        public string Status { get; set; } = "ACTIVE";
        public DateTime CreatedAt { get; set; }


        public clsEmployee() { }

        // Parameterized constructor
        public clsEmployee(string firstName, string lastName, string phoneNumber,
                        DateTime hireDate, string role, string email = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            HireDate = hireDate;
            Role = role;
            Email = email;
            Status = "ACTIVE";
        }
    }
}
