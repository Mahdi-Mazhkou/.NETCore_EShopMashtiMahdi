using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public Feature()
        {
            this.CategoryFeatures = new List<CategoryFeature>();
            this.ProductFeatures = new List<ProductFeature>();
        }
    }
}
