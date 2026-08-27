using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class CustomerDataAccess
    {
        public static bool Insert(string phoneNumber, string firstName, string lastName,
                                  string email, string address, ref int newCustomerId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO customer (phone_number, first_name, last_name, email, address, created_at)
                    VALUES (@PhoneNumber, @FirstName, @LastName, @Email, @Address, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    newCustomerId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int customerId,
                                   ref string phoneNumber,
                                   ref string firstName,
                                   ref string lastName,
                                   ref string email,
                                   ref string address,
                                   ref DateTime createdAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer WHERE customer_id = @CustomerId", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            phoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                            firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                            address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address"));
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

        /*
        public static bool GetAll(ref List<Customer> customers)
        {
            try
            {
                customers = new List<Customer>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer ORDER BY last_name, first_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Customer();
                        c.CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                        c.PhoneNumber = reader.GetString(reader.GetOrdinal("phone_number"));
                        c.FirstName = reader.GetString(reader.GetOrdinal("first_name"));
                        c.LastName = reader.GetString(reader.GetOrdinal("last_name"));
                        c.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                        c.Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address"));
                        c.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                        customers.Add(c);
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

        public static bool GetByPhone(string phoneNumber,
                                      ref int customerId,
                                      ref string firstName,
                                      ref string lastName,
                                      ref string email,
                                      ref string address,
                                      ref DateTime createdAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer WHERE phone_number = @PhoneNumber", conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                            firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            lastName = reader.GetString(reader.GetOrdinal("last_name"));
                            email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"));
                            address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address"));
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

        public static bool Update(int customerId, string phoneNumber, string firstName,
                                  string lastName, string email, string address)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE customer
                    SET phone_number = @PhoneNumber,
                        first_name   = @FirstName,
                        last_name    = @LastName,
                        email        = @Email,
                        address      = @Address
                    WHERE customer_id = @CustomerId", conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int customerId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM customer WHERE customer_id = @CustomerId", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
