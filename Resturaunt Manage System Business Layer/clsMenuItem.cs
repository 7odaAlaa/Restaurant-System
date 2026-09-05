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
        enum enMode {Add , Update};
        enMode _Mode;

        public enum enType { Italian = 1 , Spanish  = 2  , Frenech = 3}


        public int ItemId { set; get; }
        public int SupplierId { set; get; }
        public string Name { set; get; } = "";
        public string Description { set; get; }
        public decimal Price { set; get; }
        public enType type { set; get; }
        public string ImageLink { set; get; }
        public bool IsAvailable { set; get; } = true;
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }


        // Default constructor
        public clsMenuItem() 
        {
            ImageLink = "";
            _Mode = enMode.Add;
        }

        // Parameterized constructor
        public clsMenuItem(int supplierId, string name, decimal price, enType type,
                        string description = null, string imageLink = null,
                        bool isAvailable = true)
        {
            this.SupplierId = supplierId;
            this.Name = name;
            this.Price = price;
            this.type = type;
            this.Description = description;
            this.ImageLink = imageLink;
            this.IsAvailable = isAvailable;
            _Mode =enMode.Update;
        }

        private  bool _Insert()
        {
            int newItemId = 0;

            newItemId = MenuItemDataAccess.Insert(this.SupplierId,
                                                     this.Name,
                                                     this.Description,
                                                     this.Price,
                                                     (int)this.type,
                                                     this.ImageLink,
                                                     this.IsAvailable);
            return newItemId != -1;
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

        
        private bool _Update()
        {
            return MenuItemDataAccess.Update(this.ItemId,
                                             this.SupplierId,
                                             this.Name,
                                             this.Description,
                                             this.Price,
                                             (int)this.type,
                                             this.ImageLink,
                                             this.IsAvailable);
        }

        public static bool Delete(int itemId)
        {
            return MenuItemDataAccess.Delete(itemId);
        }


        public bool Save() 
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_Insert())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;

        }
    }
}
