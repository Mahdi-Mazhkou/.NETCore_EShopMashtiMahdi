using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DTO.Category
{
    public class CategoryListItem
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ParentNames { get; set; }
        public int ChildCount { get; set; }
        public int ProductCount { get; set; }
        public int ParentID { get; set; }
    }
}
