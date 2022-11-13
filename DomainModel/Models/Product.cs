using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SmallDescription { get; set; }
        public string Description { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<RelatedProduct> Products { get; set; }
        public ICollection<RelatedProduct> RelatedProducts { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ProductKeyWord> ProductKeyWords { get; set; }

        public Product()
        {
            this.Products = new List<RelatedProduct>();
            this.RelatedProducts = new List<RelatedProduct>();
            this.ProductFeatures = new List<ProductFeature>();
            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
