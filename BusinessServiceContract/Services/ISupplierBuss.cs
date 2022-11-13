using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;
using DomainModel.DTO.Supplier;

namespace BusinessServiceContract.Services
{
    public interface ISupplierBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(SupplierAddEditModel current);
        OperationResult AddNew(SupplierAddEditModel current);
        SupplierAddEditModel Get(int id);
        List<Supplier> GetAll();
        List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount);

    }
}
