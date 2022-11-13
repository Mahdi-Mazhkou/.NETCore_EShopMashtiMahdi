using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Order  Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
        public long TotalPrice { get; set; }
    }
}
