using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using DataAccessServiceContract.Services.Base;
using DomainModel.DTO.Supplier;

namespace DataAccessServiceContract.Services
{
    public interface ISupplierRepository : IBaseRepositorySearchable<Supplier, int, SupplierSearchModel, SupplierComplexResult>
    {
        bool HasRelatedProduct(int id);
        bool HasDuplicateName(string Name);
        bool CheckSupplierNameExistForOtherID(int id, string supplierName);
    }
}
