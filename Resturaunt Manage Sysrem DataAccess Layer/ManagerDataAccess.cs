using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class ManagerDataAccess
    {
        public static bool Insert(string firstName, string lastName, string phoneNumber,
                                  string email, DateTime hireDate, string accessLevel,
                                  string department, ref int newEmployeeId)
        {
            int employeeId = 0;
            bool baseOk = EmployeeDataAccess.InsertBase(firstName, lastName, phoneNumber,
                                                        email, hireDate, "MANAGER", ref employeeId);
            if (!baseOk) return false;

            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO manager (employee_id, access_level, department)
                    VALUES (@EmployeeId, @AccessLevel, @Department)", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@AccessLevel", accessLevel);
                    cmd.Parameters.AddWithValue("@Department", (object)department ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                    newEmployeeId = employeeId;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int employeeId,
                                   ref string firstName,
                                   ref string lastName,
                                   ref string phoneNumber,
                                   ref string email,
                                   ref DateTime hireDate,
                                   ref string role,
                                   ref string status,
                                   ref DateTime createdAt,
                                   ref string accessLevel,
                                   ref string department)
        {
            bool baseOk = EmployeeDataAccess.GetBaseById(employeeId,
                                                         ref firstName,
                                                         ref lastName,
                                                         ref phoneNumber,
                                                         ref email,
                                                         ref hireDate,
                                                         ref role,
                                                         ref status,
                                                         ref createdAt);
            if (!baseOk) return false;

            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT access_level, department FROM manager WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accessLevel = reader.GetString(reader.GetOrdinal("access_level"));
                            department = reader.IsDBNull(reader.GetOrdinal("department"))
                                        ? null : reader.GetString(reader.GetOrdinal("department"));
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /*
        public static bool GetAll(ref List<Manager> managers)
        {
            try
            {
                managers = new List<Manager>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT e.*, m.access_level, m.department
                    FROM employee e
                    JOIN manager m ON e.employee_id = m.employee_id
                    ORDER BY e.last_name, e.first_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var m = new Manager();
                        m.EmployeeId = reader.GetInt32(reader.GetOrdinal("employee_id"));
                        m.FirstName = reader.GetString(reader.GetOrdinal("first_name"));
                        m.LastName = reader.GetString(reader.GetOrdinal("last_name"));
                        m.PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                        m.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                        m.HireDate = reader.GetDateTime(reader.GetOrdinal("hire_date"));
                        m.Role = reader.GetString(reader.GetOrdinal("role"));
                        m.Status = reader.GetString(reader.GetOrdinal("status"));
                        m.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                        m.AccessLevel = reader.GetString(reader.GetOrdinal("access_level"));
                        m.Department = reader.IsDBNull(reader.GetOrdinal("department"))
                                      ? null : reader.GetString(reader.GetOrdinal("department"));
                        managers.Add(m);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        */

        public static bool Update(int employeeId, string firstName, string lastName,
                                  string phoneNumber, string email, DateTime hireDate,
                                  string accessLevel, string department)
        {
            bool baseOk = EmployeeDataAccess.UpdateBase(employeeId, firstName, lastName,
                                                        phoneNumber, email, hireDate);
            if (!baseOk) return false;

            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE manager
                    SET access_level = @AccessLevel,
                        department = @Department
                    WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@AccessLevel", accessLevel);
                    cmd.Parameters.AddWithValue("@Department", (object)department ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int employeeId)
        {
            return EmployeeDataAccess.Delete(employeeId);
        }
    }
}
