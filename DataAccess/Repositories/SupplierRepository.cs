using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessServiceContract.Services;
using DomainModel.DTO.Supplier;
using DomainModel.BaseModel;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Repositories
{
   public  class SupplierRepository : ISupplierRepository
    {
        private readonly EshopMashtiMahdiContext db;
        public SupplierRepository(EshopMashtiMahdiContext db)
        {
            this.db = db;
        }
        public OperationResult AddNew(Supplier current)
        {
            OperationResult op = new OperationResult("Add New Supplier",current.SupplierID);
            try
            {
                db.Suppliers.Add(current);
                db.SaveChanges();
                return op.Succeed("Supplier Added Successfully", current.SupplierID);
            }
            catch (Exception ex)
            {

                return op.Failed("Supplier Add Failed" + ex.Message, null);
            }
        }

        public bool CheckSupplierNameExistForOtherID(int id, string supplierName)
        {
            return db.Suppliers.Any(x => x.SupplierID != id && x.SupplierName == supplierName);
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
            if (sup == null)
            {
                return op.Failed("Supplier ID Not Exist", id);
            }
            try
            {
                db.Suppliers.Remove(sup);
                db.SaveChanges();
                return op.Succeed("Success", id);

            }
            catch (Exception ex)
            {

                return op.Failed("Supplier Failed" + ex.Message, id);
            }
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool HasDuplicateName(string Name)
        {
            return db.Suppliers.Any(x => x.SupplierName == Name);
        }

        public bool HasRelatedProduct(int id)
        {
            return db.Products.Any(x => x.SupplierID == id);
        }

        public SupplierComplexResult Search(SupplierSearchModel sm, out int RecordCount)
        {
           
            try
            {
                var Suppliers = from item in db.Suppliers select item;
                if (!string.IsNullOrEmpty(sm.SupplierName))
                {
                    Suppliers = Suppliers.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
                }
                if (!string.IsNullOrEmpty(sm.Mobile))
                {
                    Suppliers = Suppliers.Where(x => x.Mobile.StartsWith(sm.Mobile));
                }
                if (!string.IsNullOrEmpty(sm.Tel))
                {
                    Suppliers = Suppliers.Where(x => x.Mobile.StartsWith(sm.Tel));
                }
                var q = from item in Suppliers
                        select new SupplierListItem
                        {
                            SupplierID = item.SupplierID
                            ,
                            SupplierName = item.SupplierName
                            ,
                            Mobile = item.Mobile
                            ,
                            Tel = item.Tel
                            ,
                            ProductCount = item.Products.Count
                        };
                RecordCount = q.Count();
                var r = q.OrderByDescending(x=>x.SupplierID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).AsNoTracking().ToList();
                return new SupplierComplexResult
                {
                    MainResults = r,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطایی رخ داده است " + ex.Message);
                RecordCount = 0;
                return new SupplierComplexResult
                {
                    Errors = errors
                    ,
                    MainResults = null
                };

            }
          
        }

        public OperationResult Update(Supplier current)
        {
            OperationResult op = new OperationResult("Update", current.SupplierID);
            try
            {
                var sup = db.Set<Supplier>().FirstOrDefault(x => x.SupplierID == current.SupplierID);
                sup.SupplierName = current.SupplierName;
                sup.Mobile = current.Mobile;
                sup.Address = current.Address;
                sup.Tel = current.Tel;
                db.SaveChanges();
                return op.Succeed("Update SuccessFully", current.SupplierID);
                //db.Suppliers.Attach(current);
                //db.Entry<Supplier>(current).State = EntityState.Modified;
                //db.SaveChanges();
                //return op.Succeed("Update Successfully", current.SupplierID);
            }
            catch (Exception e)
            {

                return op.Failed("Update Failed" + e.Message, current.SupplierID);
            }


        }
    }
}
