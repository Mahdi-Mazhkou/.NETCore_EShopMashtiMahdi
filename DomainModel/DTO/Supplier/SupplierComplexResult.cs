using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DTO.Supplier
{
    public class SupplierComplexResult : IComplexObjectResult<List<SupplierListItem>, List<string>>
    {

        public List<SupplierListItem> MainResults { get; set; }
        public List<string> Errors { get; set; }
    }
}
