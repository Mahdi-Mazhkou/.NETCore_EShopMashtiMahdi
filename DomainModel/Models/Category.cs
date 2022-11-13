using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SmallDescription { get; set; }
        public int? ParentID { get; set; }
        public ICollection<Category> Children { get; set; }
        public Category Parent { get; set; }
        public string LineAge { get; set; }
        public string ProductCount { get; set; }
        public int Depth { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
            this.Children = new List<Category>();
            this.CategoryFeatures = new List<CategoryFeature>();
        }
    }
}
