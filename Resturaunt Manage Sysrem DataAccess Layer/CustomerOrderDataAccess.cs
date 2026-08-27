using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class CustomerOrderDataAccess
    {
        public static bool Insert(int customerId, DateTime orderTimestamp, string status,
                                  string paymentMethod, decimal totalAmount, string orderType,
                                  string specialNotes, ref int newOrderId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO customer_order (customer_id, order_timestamp, status, payment_method, total_amount, order_type, special_notes, created_at, updated_at)
                    VALUES (@CustomerId, @OrderTimestamp, @Status, @PaymentMethod, @TotalAmount, @OrderType, @SpecialNotes, @CreatedAt, @UpdatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderTimestamp", orderTimestamp);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@PaymentMethod", (object)paymentMethod ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@OrderType", orderType);
                    cmd.Parameters.AddWithValue("@SpecialNotes", (object)specialNotes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    newOrderId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int orderId,
                                   ref int customerId,
                                   ref DateTime orderTimestamp,
                                   ref string status,
                                   ref string paymentMethod,
                                   ref decimal totalAmount,
                                   ref string orderType,
                                   ref string specialNotes,
                                   ref DateTime createdAt,
                                   ref DateTime updatedAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer_order WHERE order_id = @OrderId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                            orderTimestamp = reader.GetDateTime(reader.GetOrdinal("order_timestamp"));
                            status = reader.GetString(reader.GetOrdinal("status"));
                            paymentMethod = reader.IsDBNull(reader.GetOrdinal("payment_method"))
                                            ? null : reader.GetString(reader.GetOrdinal("payment_method"));
                            totalAmount = reader.GetDecimal(reader.GetOrdinal("total_amount"));
                            orderType = reader.GetString(reader.GetOrdinal("order_type"));
                            specialNotes = reader.IsDBNull(reader.GetOrdinal("special_notes"))
                                           ? null : reader.GetString(reader.GetOrdinal("special_notes"));
                            createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            updatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"));
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
        public static bool GetAll(ref List<CustomerOrder> orders)
        {
            try
            {
                orders = new List<CustomerOrder>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer_order ORDER BY order_timestamp DESC", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var o = new CustomerOrder();
                        o.OrderId = reader.GetInt32(reader.GetOrdinal("order_id"));
                        o.CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                        o.OrderTimestamp = reader.GetDateTime(reader.GetOrdinal("order_timestamp"));
                        o.Status = reader.GetString(reader.GetOrdinal("status"));
                        o.PaymentMethod = reader.IsDBNull(reader.GetOrdinal("payment_method"))
                                          ? null : reader.GetString(reader.GetOrdinal("payment_method"));
                        o.TotalAmount = reader.GetDecimal(reader.GetOrdinal("total_amount"));
                        o.OrderType = reader.GetString(reader.GetOrdinal("order_type"));
                        o.SpecialNotes = reader.IsDBNull(reader.GetOrdinal("special_notes"))
                                         ? null : reader.GetString(reader.GetOrdinal("special_notes"));
                        o.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                        o.UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"));
                        orders.Add(o);
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


        /*
        public static bool GetByCustomer(int customerId, ref List<CustomerOrder> orders)
        {
            try
            {
                orders = new List<CustomerOrder>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM customer_order
                    WHERE customer_id = @CustomerId
                    ORDER BY order_timestamp DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var o = new CustomerOrder();
                            o.OrderId = reader.GetInt32(reader.GetOrdinal("order_id"));
                            o.CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id"));
                            o.OrderTimestamp = reader.GetDateTime(reader.GetOrdinal("order_timestamp"));
                            o.Status = reader.GetString(reader.GetOrdinal("status"));
                            o.PaymentMethod = reader.IsDBNull(reader.GetOrdinal("payment_method"))
                                              ? null : reader.GetString(reader.GetOrdinal("payment_method"));
                            o.TotalAmount = reader.GetDecimal(reader.GetOrdinal("total_amount"));
                            o.OrderType = reader.GetString(reader.GetOrdinal("order_type"));
                            o.SpecialNotes = reader.IsDBNull(reader.GetOrdinal("special_notes"))
                                             ? null : reader.GetString(reader.GetOrdinal("special_notes"));
                            o.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            o.UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"));
                            orders.Add(o);
                        }
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


        public static bool Update(int orderId, int customerId, DateTime orderTimestamp,
                                  string status, string paymentMethod, decimal totalAmount,
                                  string orderType, string specialNotes)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE customer_order
                    SET customer_id = @CustomerId,
                        order_timestamp = @OrderTimestamp,
                        status = @Status,
                        payment_method = @PaymentMethod,
                        total_amount = @TotalAmount,
                        order_type = @OrderType,
                        special_notes = @SpecialNotes,
                        updated_at = @UpdatedAt
                    WHERE order_id = @OrderId", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderTimestamp", orderTimestamp);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@PaymentMethod", (object)paymentMethod ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@OrderType", orderType);
                    cmd.Parameters.AddWithValue("@SpecialNotes", (object)specialNotes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int orderId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM customer_order WHERE order_id = @OrderId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
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


