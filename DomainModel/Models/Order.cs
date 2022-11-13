using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class Order
    {
        public int  OrderID { get; set; }
        public int UserID { get; set; }
        public string  OrderDescription { get; set; }
        public DateTime  OrderDate { get; set; }
        public string  Address { get; set; }
        public DateTime?  RequiredDate { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
