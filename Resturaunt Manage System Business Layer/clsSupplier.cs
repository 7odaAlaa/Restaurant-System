using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsSupplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = "";
        public string ContactPhone { get; set; }
        public string  ContactEmail { get; set; }
        public string Address { get; set; }
        public string Type { get; set; } = "";
        public DateTime CreatedAt { get; set; }


        // Default constructor
        public clsSupplier() { }

        // Parameterized constructor
        public clsSupplier(string supplierName, string type,
                        string contactPhone = null, string contactEmail = null,
                        string address = null)
        {
            SupplierName = supplierName;
            Type = type;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
            Address = address;
        }

        public static clsSupplier Insert(clsSupplier supplier)
        {
            int newSupplierId = 0;
            bool success = SupplierDataAccess.Insert(supplier.SupplierName,
                                                     supplier.ContactPhone,
                                                     supplier.ContactEmail,
                                                     supplier.Address,
                                                     supplier.Type,
                                                     ref newSupplierId);
            if (success)
            {
                supplier.SupplierId = newSupplierId;
                return supplier;
            }
            return null;
        }

        public static clsSupplier GetById(int supplierId)
        {
            string supplierName = "", contactPhone = "", contactEmail = "", address = "", type = "";
            DateTime createdAt = DateTime.MinValue;

            bool found = SupplierDataAccess.GetById(supplierId,
                                                    ref supplierName,
                                                    ref contactPhone,
                                                    ref contactEmail,
                                                    ref address,
                                                    ref type,
                                                    ref createdAt);
            if (found)
            {
                return new clsSupplier
                {
                    SupplierId = supplierId,
                    SupplierName = supplierName,
                    ContactPhone = contactPhone,
                    ContactEmail = contactEmail,
                    Address = address,
                    Type = type,
                    CreatedAt = createdAt
                };
            }
            return null;
        }

        /*
        public static List<clsSupplier> GetAll()
        {
            List<clsSupplier> suppliers = null;
            bool success = SupplierDataAccess.GetAll(ref suppliers);
            return success ? suppliers : new List<clsSupplier>();
        }
        */

        public static bool Update(clsSupplier supplier)
        {
            return SupplierDataAccess.Update(supplier.SupplierId,
                                             supplier.SupplierName,
                                             supplier.ContactPhone,
                                             supplier.ContactEmail,
                                             supplier.Address,
                                             supplier.Type);
        }

        public static bool Delete(int supplierId)
        {
            return SupplierDataAccess.Delete(supplierId);
        }
    }
}
