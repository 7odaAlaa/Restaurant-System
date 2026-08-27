using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsOrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineSubtotal { get; set; }
        public string SpecialInstructions { get; set; }
        public int? PreparedByChefId { get; set; }
        public DateTime CreatedAt { get; set; }


        // Default constructor
        public clsOrderDetail() { }

        // Parameterized constructor
        public clsOrderDetail(int orderId, int itemId, int quantity, decimal unitPrice, int preparedByChefId, 
                           string specialInstructions = null)
        {
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            SpecialInstructions = specialInstructions;
            PreparedByChefId = preparedByChefId;
            LineSubtotal = quantity * unitPrice;
        }

       
         public static clsOrderDetail Insert(clsOrderDetail detail)
         {
             int newOrderDetailId = 0;
             bool success = OrderDetailDataAccess.Insert(detail.OrderId,
                                                         detail.ItemId,
                                                         detail.Quantity,
                                                         detail.UnitPrice,
                                                         detail.SpecialInstructions,
                                                         ref newOrderDetailId);
             if (success)
             {
                 detail.OrderDetailId = newOrderDetailId;
                 detail.LineSubtotal = detail.Quantity * detail.UnitPrice;
                 return detail;
             }
             return null;
         }

         public static clsOrderDetail GetById(int orderDetailId)
         {
             int orderId = 0, itemId = 0, quantity = 0;
             decimal unitPrice = 0, lineSubtotal = 0;
             string specialInstructions = "";
             DateTime createdAt = DateTime.MinValue;

             bool found = OrderDetailDataAccess.GetById(orderDetailId,
                                                        ref orderId,
                                                        ref itemId,
                                                        ref quantity,
                                                        ref unitPrice,
                                                        ref specialInstructions,
                                                        ref createdAt,
                                                        ref lineSubtotal);
             if (found)
             {
                 return new clsOrderDetail
                 {
                     OrderDetailId = orderDetailId,
                     OrderId = orderId,
                     ItemId = itemId,
                     Quantity = quantity,
                     UnitPrice = unitPrice,
                     SpecialInstructions = specialInstructions,
                     CreatedAt = createdAt,
                     LineSubtotal = lineSubtotal
                 };
             }
             return null;
         }

        
        /*
         public static List<clsOrderDetail> GetByOrderId(int orderId)
         {
             List<clsOrderDetail> details = null;
             bool success = OrderDetailDataAccess.GetByOrderId(orderId, ref details);
             return success ? details : new List<clsOrderDetail>();
         }
         */


         public static bool Update(clsOrderDetail detail)
         {
             return OrderDetailDataAccess.Update(detail.OrderDetailId,
                                                 detail.OrderId,
                                                 detail.ItemId,
                                                 detail.Quantity,
                                                 detail.UnitPrice,
                                                 detail.SpecialInstructions);
         }

         public static bool Delete(int orderDetailId)
         {
             return OrderDetailDataAccess.Delete(orderDetailId);
         }
    }
}
