using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.BaseModel;

namespace DomainModel.DTO.Supplier
{
    public class SupplierSearchModel:PageModel
    {
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
    }
}
