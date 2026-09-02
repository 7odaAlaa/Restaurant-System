using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsMenuItem
    {
        public enum enType { Italian = 1 , Spanish  = 2  , Frenech = 3}


        public int ItemId { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; }
        public decimal Price { get; set; }
        public enType type { get; set; }
        public string ImageLink { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Default constructor
        public clsMenuItem() 
        {
            ImageLink = "";
        }

        // Parameterized constructor
        public clsMenuItem(int supplierId, string name, decimal price, enType type,
                        string description = null, string imageLink = null,
                        bool isAvailable = true)
        {
            SupplierId = supplierId;
            Name = name;
            Price = price;
            type = type;
            Description = description;
            ImageLink = imageLink;
            IsAvailable = isAvailable;
        }

        public static  clsMenuItem Insert( clsMenuItem item)
        {
            int newItemId = 0;
            bool success = MenuItemDataAccess.Insert(item.SupplierId,
                                                     item.Name,
                                                     item.Description,
                                                     item.Price,
                                                     (int)item.type,
                                                     item.ImageLink,
                                                     item.IsAvailable,
                                                     ref newItemId);
            if (success)
            {
                item.ItemId = newItemId;
                return item;
            }
            return null;
        }

        public static clsMenuItem GetById(int itemId)
        {
            int supplierId = 0 , type = 0;
            string name = "", description = "" , imageLink = "";
            decimal price = 0;
            bool isAvailable = false;
            DateTime createdAt = DateTime.MinValue, updatedAt = DateTime.MinValue;

            bool found = MenuItemDataAccess.GetById(itemId,
                                                    ref supplierId,
                                                    ref name,
                                                    ref description,
                                                    ref price,
                                                    ref type,
                                                    ref imageLink,
                                                    ref isAvailable,
                                                    ref createdAt,
                                                    ref updatedAt);
            if (found)
            {
                return new clsMenuItem
                {
                    ItemId = itemId,
                    SupplierId = supplierId,
                    Name = name,
                    Description = description,
                    Price = price,
                    type = (enType)type,
                    ImageLink = imageLink,
                    IsAvailable = isAvailable,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt
                };
            }
            return null;
        }

        public static List<clsMenuItem> GetAll()
        {
            List<clsMenuItem> items = new List<clsMenuItem>();   
            
            DataTable dataTable = MenuItemDataAccess.GetAll();

            foreach (DataRow row in dataTable.Rows)
            {
                clsMenuItem m = new clsMenuItem();
                m.ItemId = row.Field<int>("item_id");
                m.SupplierId = row.Field<int>("supplier_id");
                m.Name = row.Field<string>("name");
                m.Description = row.Field<string>("description"); // returns null if DBNull
                m.Price = row.Field<decimal>("price");
                m.type = row.Field<enType>("type");
                m.ImageLink = row.Field<string>("image_link");
                m.IsAvailable = row.Field<bool>("is_available");
                m.CreatedAt = row.Field<DateTime>("created_at");
                m.UpdatedAt = row.Field<DateTime>("updated_at");
                items.Add(m);
            }

            return  items;
        }
        

        /*
        public static List<MenuItem> GetBySupplier(int supplierId)
        {
            List<MenuItem> items = null;
            bool success = MenuItemDataAccess.GetBySupplier(supplierId, ref items);
            return success ? items : new List<MenuItem>();
        }
        */

        
        public static bool Update(clsMenuItem item)
        {
            return MenuItemDataAccess.Update(item.ItemId,
                                             item.SupplierId,
                                             item.Name,
                                             item.Description,
                                             item.Price,
                                             (int)item.type,
                                             item.ImageLink,
                                             item.IsAvailable);
        }

        public static bool Delete(int itemId)
        {
            return MenuItemDataAccess.Delete(itemId);
        }
    }
}
