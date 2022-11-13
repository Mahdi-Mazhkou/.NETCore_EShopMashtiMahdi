using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class ProductFeature
    {
        public int ProductFeatureID { get; set; }
        public int ProductID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureValue { get; set; }
        public Product Product { get; set; }
        public Feature Feature { get; set; }
    }
}
