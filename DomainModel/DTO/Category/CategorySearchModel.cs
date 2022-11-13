using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.BaseModel;

namespace DomainModel.DTO.Category
{
    public class CategorySearchModel:PageModel
    {
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
    }
}
