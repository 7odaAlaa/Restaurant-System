using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class EmployeeDataAccess
    {
        public static bool InsertBase(string firstName, string lastName, string phoneNumber,
                                      string email, DateTime hireDate, string role,
                                      ref int newEmployeeId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO employee (first_name, last_name, phone_number, email, hire_date, role, status, created_at)
                    VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @HireDate, @Role, 'ACTIVE', @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HireDate", hireDate);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    newEmployeeId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateBase(int employeeId, string firstName, string lastName,
                                      string phoneNumber, string email, DateTime hireDate)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE employee
                    SET first_name = @FirstName,
                        last_name  = @LastName,
                        phone_number = @PhoneNumber,
                        email = @Email,
                        hire_date = @HireDate
                    WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HireDate", hireDate);
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
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM employee WHERE employee_id = @EmployeeId", conn))
                {
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

        public static bool GetBaseById(int employeeId,
                                       ref string firstName,
                                       ref string lastName,
                                       ref string phoneNumber,
                                       ref string email,
                                       ref DateTime hireDate,
                                       ref string role,
                                       ref string status,
                                       ref DateTime createdAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM employee WHERE employee_id = @EmployeeId", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            phoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                            email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                            hireDate = reader.GetDateTime(reader.GetOrdinal("hire_date"));
                            role = reader.GetString(reader.GetOrdinal("role"));
                            status = reader.GetString(reader.GetOrdinal("status"));
                            createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
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
    }
}
