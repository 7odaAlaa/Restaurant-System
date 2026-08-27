using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class WaiterDataAccess
    {
        public static bool Insert(string firstName, string lastName, string phoneNumber,
                                  string email, DateTime hireDate, string section,
                                  string serviceArea, ref int newEmployeeId)
        {
            int employeeId = 0;
            bool baseOk = EmployeeDataAccess.InsertBase(firstName, lastName, phoneNumber,
                                                        email, hireDate, "WAITER", ref employeeId);
            if (!baseOk) return false;

            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO waiter (employee_id, section, service_area)
                    VALUES (@EmployeeId, @Section, @ServiceArea)", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@ServiceArea", (object)serviceArea ?? DBNull.Value);
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
                                   ref string section,
                                   ref string serviceArea)
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
                    SELECT section, service_area FROM waiter WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            section = reader.GetString(reader.GetOrdinal("section"));
                            serviceArea = reader.IsDBNull(reader.GetOrdinal("service_area"))
                                          ? null : reader.GetString(reader.GetOrdinal("service_area"));
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
        public static bool GetAll(ref List<Waiter> waiters)
        {
            try
            {
                waiters = new List<Waiter>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT e.*, w.section, w.service_area
                    FROM employee e
                    JOIN waiter w ON e.employee_id = w.employee_id
                    ORDER BY e.last_name, e.first_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var w = new Waiter();
                        w.EmployeeId = reader.GetInt32(reader.GetOrdinal("employee_id"));
                        w.FirstName = reader.GetString(reader.GetOrdinal("first_name"));
                        w.LastName = reader.GetString(reader.GetOrdinal("last_name"));
                        w.PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                        w.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                        w.HireDate = reader.GetDateTime(reader.GetOrdinal("hire_date"));
                        w.Role = reader.GetString(reader.GetOrdinal("role"));
                        w.Status = reader.GetString(reader.GetOrdinal("status"));
                        w.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                        w.Section = reader.GetString(reader.GetOrdinal("section"));
                        w.ServiceArea = reader.IsDBNull(reader.GetOrdinal("service_area")) ? null : reader.GetString(reader.GetOrdinal("service_area"));
                        waiters.Add(w);
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
                                  string section, string serviceArea)
        {
            bool baseOk = EmployeeDataAccess.UpdateBase(employeeId, firstName, lastName,
                                                        phoneNumber, email, hireDate);
            if (!baseOk) return false;

            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE waiter
                    SET section = @Section,
                        service_area = @ServiceArea
                    WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@ServiceArea", (object)serviceArea ?? DBNull.Value);
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
