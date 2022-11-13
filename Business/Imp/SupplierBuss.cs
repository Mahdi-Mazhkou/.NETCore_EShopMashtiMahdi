using System;
using System.Collections.Generic;
using System.Text;
using BusinessServiceContract.Services;
using DomainModel.DTO.Supplier;
using DomainModel.Models;


namespace Business.Imp
{
    public class SupplierBuss : ISupplierBuss
    {
        private SupplierAddEditModel ToAddEditModel(Supplier sup)
        {
            return new SupplierAddEditModel
            {
                SupplierName = sup.SupplierName
                ,
                Address = sup.Address
                ,
                Mobile = sup.Mobile
                
               , SupplierID = sup.SupplierID
                ,
                Tel = sup.Tel
            };
        }
        private Supplier ToModel(SupplierAddEditModel sup)
        {
            return new Supplier
            {
                SupplierName = sup.SupplierName
                ,
                Address = sup.Address
                ,
                Mobile = sup.Mobile
                ,
                SupplierID = sup.SupplierID
                ,
                Tel = sup.Tel
            };
        }
        private readonly DataAccessServiceContract.Services.ISupplierRepository repo;
        public SupplierBuss(DataAccessServiceContract.Services.ISupplierRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult AddNew(SupplierAddEditModel current)
        {
            OperationResult op = new OperationResult("Add Supplier");
            if (repo.HasDuplicateName(current.SupplierName))
            {
                return op.Failed("This Supplier Already Exists", null);
            }
            var sup = ToModel(current);
            return repo.AddNew(sup);
        }

        public OperationResult Delete(int id)
        {
            if (repo.HasRelatedProduct(id))
            {
                return new OperationResult("Delete Supplier", id).Failed("This Supplier Has Related Product", id);
            }
            return repo.Delete(id);

        }

        public SupplierAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount)
        {

            return repo.Search(sm, RecordCount: out RecordCount).MainResults;
        }

        public OperationResult Update(SupplierAddEditModel current)
        {
            if (repo.CheckSupplierNameExistForOtherID(current.SupplierID, current.SupplierName))
            {
                return new OperationResult("Update Supplier").Failed("Supplier Name Already Exits", current.SupplierID);
            }
            var sup = ToModel(current);
            return repo.Update(sup);
        }
    }
}
