using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class MenuItemDataAccess
    {
        public static bool Insert(int supplierId, string name, string description,
                                  decimal price, string type, string imageLink,
                                  bool isAvailable, ref int newItemId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO menu_item (supplier_id, name, description, price, type, image_link, is_available, created_at, updated_at)
                    VALUES (@SupplierId, @Name, @Description, @Price, @Type, @ImageLink, @IsAvailable, @CreatedAt, @UpdatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@ImageLink", (object)imageLink ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    newItemId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int itemId,
                                   ref int supplierId,
                                   ref string name, ref string description, ref decimal price,
                                   ref string type,ref string imageLink,ref bool isAvailable,
                                   ref DateTime createdAt , ref DateTime updatedAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM menu_item WHERE item_id = @ItemId", conn))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplierId = reader.GetInt32(reader.GetOrdinal("supplier_id"));
                            name = reader.GetString(reader.GetOrdinal("name"));
                            description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description"));
                            price = reader.GetDecimal(reader.GetOrdinal("price"));
                            type = reader.GetString(reader.GetOrdinal("type"));
                            imageLink = reader.IsDBNull(reader.GetOrdinal("image_link")) ? null : reader.GetString(reader.GetOrdinal("image_link"));
                            isAvailable = reader.GetBoolean(reader.GetOrdinal("is_available"));
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
     
        public static DataTable GetAll()
        {
             DataTable MenuItemtable = new DataTable();
        
            try
            {
                using (var conn = DbHelper.CreateConnection())
                {
                    conn.Open();  // open explicitly inside the using block

                    using (var cmd = new SqlCommand(@"SELECT * FROM menu_item ORDER BY type, name", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            MenuItemtable.Load(reader);
                    }
                }
            }
            catch  (Exception ex) 
            {
               //Console.WriteLine(ex.ToString());
            }

            return MenuItemtable;
        }

       
        /*
        public static bool GetBySupplier(int supplierId, ref List<MenuItem> items)
        {
            try
            {
                items = new List<MenuItem>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM menu_item WHERE supplier_id = @SupplierId", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var m = new MenuItem();
                            m.ItemId = reader.GetInt32(reader.GetOrdinal("item_id"));
                            m.SupplierId = reader.GetInt32(reader.GetOrdinal("supplier_id"));
                            m.Name = reader.GetString(reader.GetOrdinal("name"));
                            m.Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description"));
                            m.Price = reader.GetDecimal(reader.GetOrdinal("price"));
                            m.Type = reader.GetString(reader.GetOrdinal("type"));
                            m.ImageLink = reader.IsDBNull(reader.GetOrdinal("image_link")) ? null : reader.GetString(reader.GetOrdinal("image_link"));
                            m.IsAvailable = reader.GetBoolean(reader.GetOrdinal("is_available"));
                            m.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                            m.UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"));
                            items.Add(m);
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

        public static bool Update(int itemId, int supplierId, string name, string description,
                                  decimal price, string type, string imageLink, bool isAvailable)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE menu_item
                    SET supplier_id = @SupplierId,
                        name = @Name,
                        description = @Description,
                        price = @Price,
                        type = @Type,
                        image_link = @ImageLink,
                        is_available = @IsAvailable,
                        updated_at = @UpdatedAt
                    WHERE item_id = @ItemId", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@ImageLink", (object)imageLink ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ItemId", itemId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int itemId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM menu_item WHERE item_id = @ItemId", conn))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
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
