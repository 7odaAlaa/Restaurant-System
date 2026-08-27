using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class OrderDetailDataAccess
    {
        public static bool Insert(int orderId, int itemId, int quantity,
                                  decimal unitPrice, string specialInstructions,
                                  ref int newOrderDetailId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO order_detail (order_id, item_id, quantity, unit_price, special_instructions, created_at)
                    VALUES (@OrderId, @ItemId, @Quantity, @UnitPrice, @SpecialInstructions, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@SpecialInstructions", (object)specialInstructions ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    newOrderDetailId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int orderDetailId,
                                   ref int orderId,
                                   ref int itemId,
                                   ref int quantity,
                                   ref decimal unitPrice,
                                   ref string specialInstructions,
                                   ref DateTime createdAt,
                                   ref decimal lineSubtotal)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM order_detail WHERE order_detail_id = @OrderDetailId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orderId = reader.GetInt32(reader.GetOrdinal("order_id"));
                            itemId = reader.GetInt32(reader.GetOrdinal("item_id"));
                            quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                            unitPrice = reader.GetDecimal(reader.GetOrdinal("unit_price"));
                            specialInstructions = reader.IsDBNull(reader.GetOrdinal("special_instructions"))
                                                  ? null : reader.GetString(reader.GetOrdinal("special_instructions"));
                            createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            lineSubtotal = quantity * unitPrice;
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
        public static bool GetByOrderId(int orderId, ref List<OrderDetail> orderDetails)
        {
            try
            {
                orderDetails = new List<OrderDetail>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM order_detail WHERE order_id = @OrderId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var d = new OrderDetail();
                            d.OrderDetailId = reader.GetInt32(reader.GetOrdinal("order_detail_id"));
                            d.OrderId = reader.GetInt32(reader.GetOrdinal("order_id"));
                            d.ItemId = reader.GetInt32(reader.GetOrdinal("item_id"));
                            d.Quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                            d.UnitPrice = reader.GetDecimal(reader.GetOrdinal("unit_price"));
                            d.SpecialInstructions = reader.IsDBNull(reader.GetOrdinal("special_instructions"))
                                                    ? null : reader.GetString(reader.GetOrdinal("special_instructions"));
                            d.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            d.LineSubtotal = d.Quantity * d.UnitPrice;
                            orderDetails.Add(d);
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

        public static bool Update(int orderDetailId, int orderId, int itemId, int quantity,
                                  decimal unitPrice, string specialInstructions)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE order_detail
                    SET order_id = @OrderId,
                        item_id = @ItemId,
                        quantity = @Quantity,
                        unit_price = @UnitPrice,
                        special_instructions = @SpecialInstructions
                    WHERE order_detail_id = @OrderDetailId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@SpecialInstructions", (object)specialInstructions ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int orderDetailId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM order_detail WHERE order_detail_id = @OrderDetailId", conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);
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
