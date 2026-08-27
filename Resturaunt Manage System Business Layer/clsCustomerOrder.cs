using Resturaunt_Manage_Sysrem_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturaunt_Manage_System_Business_Layer
{
    public class clsCustomerOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int? TakenByEmployeeId { get; set; }
        public DateTime OrderTimestamp { get; set; }
        public string Status { get; set; } = "PENDING";
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderType { get; set; } = "DINE_IN";
        public string SpecialNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();


        // Default constructor
        public clsCustomerOrder()
        {
            //OrderDetails = new List<OrderDetail>();
        }

        // Parameterized constructor
        public clsCustomerOrder(int takenByEmployeeId, string paymentMethod, string specialNotes ,
                                int customerId, string orderType = "DINE_IN")
        {
            CustomerId = customerId;
            OrderType = orderType;
            TakenByEmployeeId = takenByEmployeeId;
            PaymentMethod = paymentMethod;
            SpecialNotes = specialNotes;
            Status = "PENDING";
            OrderTimestamp = DateTime.Now;
            TotalAmount = 0;
            //OrderDetails = new List<OrderDetail>();
        }

        public static clsCustomerOrder Insert(clsCustomerOrder order)
        {
            int newOrderId = 0;
            bool success = CustomerOrderDataAccess.Insert(order.CustomerId,
                                                          order.OrderTimestamp,
                                                          order.Status,
                                                          order.PaymentMethod,
                                                          order.TotalAmount,
                                                          order.OrderType,
                                                          order.SpecialNotes,
                                                          ref newOrderId);
            if (success)
            {
                order.OrderId = newOrderId;
                return order;
            }
            return null;
        }

        public static clsCustomerOrder GetById(int orderId)
        {
            int customerId = 0;
            DateTime orderTimestamp = DateTime.MinValue;
            string status = "", paymentMethod = "", orderType = "", specialNotes = "";
            decimal totalAmount = 0;
            DateTime createdAt = DateTime.MinValue, updatedAt = DateTime.MinValue;

            bool found = CustomerOrderDataAccess.GetById(orderId,
                                                         ref customerId,
                                                         ref orderTimestamp,
                                                         ref status,
                                                         ref paymentMethod,
                                                         ref totalAmount,
                                                         ref orderType,
                                                         ref specialNotes,
                                                         ref createdAt,
                                                         ref updatedAt);
            if (found)
            {
                return new clsCustomerOrder
                {
                    OrderId = orderId,
                    CustomerId = customerId,
                    OrderTimestamp = orderTimestamp,
                    Status = status,
                    PaymentMethod = paymentMethod,
                    TotalAmount = totalAmount,
                    OrderType = orderType,
                    SpecialNotes = specialNotes,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt
                };
            }
            return null;
        }

        /*
        public static List<clsCustomerOrder> GetAll()
        {
            List<clsCustomerOrder> orders = null;
            bool success = CustomerOrderDataAccess.GetAll(ref orders);
            return success ? orders : new List<clsCustomerOrder>();
        }
        */


        /*
        public static List<CustomerOrder> GetByCustomer(int customerId)
        {
            List<CustomerOrder> orders = null;
            bool success = CustomerOrderDataAccess.GetByCustomer(customerId, ref orders);
            return success ? orders : new List<CustomerOrder>();
        }
        */

        public static bool Update(clsCustomerOrder order)
        {
            return CustomerOrderDataAccess.Update(order.OrderId,
                                                  order.CustomerId,
                                                  order.OrderTimestamp,
                                                  order.Status,
                                                  order.PaymentMethod,
                                                  order.TotalAmount,
                                                  order.OrderType,
                                                  order.SpecialNotes);
        }

        public static bool Delete(int orderId)
        {
            return CustomerOrderDataAccess.Delete(orderId);
        }
    }
}
