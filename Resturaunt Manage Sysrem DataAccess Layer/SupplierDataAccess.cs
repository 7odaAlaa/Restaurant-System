using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_Sysrem_DataAccess_Layer
{
    public static class SupplierDataAccess
    {
        public static bool Insert(string supplierName, string contactPhone, string contactEmail,
                                  string address, string type, ref int newSupplierId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    INSERT INTO supplier (supplier_name, contact_phone, contact_email, address, type, created_at)
                    VALUES (@SupplierName, @ContactPhone, @ContactEmail, @Address, @Type, @CreatedAt);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@ContactPhone", (object)contactPhone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactEmail", (object)contactEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    newSupplierId = (int)cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool GetById(int supplierId,
                                   ref string supplierName,
                                   ref string contactPhone,
                                   ref string contactEmail,
                                   ref string address,
                                   ref string type,
                                   ref DateTime createdAt)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM supplier WHERE supplier_id = @SupplierId", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplierName = reader.GetString(reader.GetOrdinal("supplier_name"));
                            contactPhone = reader.IsDBNull(reader.GetOrdinal("contact_phone")) ? null : reader.GetString(reader.GetOrdinal("contact_phone"));
                            contactEmail = reader.IsDBNull(reader.GetOrdinal("contact_email")) ? null : reader.GetString(reader.GetOrdinal("contact_email"));
                            address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address"));
                            type = reader.GetString(reader.GetOrdinal("type"));
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
        public static bool GetAll(ref List<Supplier> suppliers)
        {
            try
            {
                suppliers = new List<Supplier>();
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    SELECT * FROM supplier ORDER BY supplier_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var s = new Supplier();
                        s.SupplierId = reader.GetInt32(reader.GetOrdinal("supplier_id"));
                        s.SupplierName = reader.GetString(reader.GetOrdinal("supplier_name"));
                        s.ContactPhone = reader.IsDBNull(reader.GetOrdinal("contact_phone")) ? null : reader.GetString(reader.GetOrdinal("contact_phone"));
                        s.ContactEmail = reader.IsDBNull(reader.GetOrdinal("contact_email")) ? null : reader.GetString(reader.GetOrdinal("contact_email"));
                        s.Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address"));
                        s.Type = reader.GetString(reader.GetOrdinal("type"));
                        s.CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                        suppliers.Add(s);
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

        public static bool Update(int supplierId, string supplierName, string contactPhone,
                                  string contactEmail, string address, string type)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    UPDATE supplier
                    SET supplier_name = @SupplierName,
                        contact_phone = @ContactPhone,
                        contact_email = @ContactEmail,
                        address = @Address,
                        type = @Type
                    WHERE supplier_id = @SupplierId", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@ContactPhone", (object)contactPhone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactEmail", (object)contactEmail ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int supplierId)
        {
            try
            {
                using (var conn = DbHelper.CreateConnection())
                using (var cmd = new SqlCommand(@"
                    DELETE FROM supplier WHERE supplier_id = @SupplierId", conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
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
