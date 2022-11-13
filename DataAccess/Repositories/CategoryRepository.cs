using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessServiceContract.Services;
using DomainModel.DTO.Category;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopMashtiMahdiContext db;
        public CategoryRepository(EshopMashtiMahdiContext db)
        {
            this.db = db;

        }
        public OperationResult AddNew(Category current)
        {
            OperationResult op = new OperationResult("Add Category");
            try
            {
                db.Categories.Add(current);
                db.SaveChanges();
                return op.Succeed("Add SuccessFully", current.CategoryId);
            }
            catch (Exception ex)
            {

                return op.Failed("Add Failed" + ex.Message, current.CategoryId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Category", id);
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (cat == null)
            {
                return op.Failed("CategoryID Does Not Exist", id);
            }
            try
            {
                db.Categories.Remove(cat);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {

                return op.Failed("Delete Failed" + ex.Message, id);
            }
        }

        public bool DuplicateName(string CategoryName)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName);
        }

        public bool DuplicateName(string CategoryName, int id)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName && x.CategoryId!=id);
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public CategoryComplexResult GetChildren(int id)
        {
            List<string> errors = new List<string>();
            CategoryComplexResult result = new CategoryComplexResult();
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (cat == null)
            {
                errors.Add("Invalid CategoryID");
                result.Errors = errors;
                result.MainResults = null;
            }
            if (!cat.Children.Any())
            {
                errors.Add("This Node Has No Children");
                result.Errors = errors;
                result.MainResults = null;
            }
            result.MainResults = cat.Children.Select(x => new CategoryListItem
            {

                CategoryID = x.CategoryId
                ,
                CategoryName = x.CategoryName
                ,
                ParentID = x.ParentID.Value
                ,
                ParentNames = ""
                ,
                ChildCount = x.Children.Count
                ,
                ProductCount = x.Products.Count

            }).ToList();
            result.Errors = null;
            return result;
        }

        public CategoryComplexResult GetParent(int id)
        {
            List<string> err = new List<string>();
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (cat == null)
            {
                err.Add("Invalid Category Entered");
                return new CategoryComplexResult
                {
                    Errors = err,
                    MainResults = null
                };
            }
            if (cat.ParentID == null || cat.Parent == null)
            {

                err.Add("Parent Node Does Not Exist Or ParentID Is Wrong");
                return new CategoryComplexResult
                {
                    Errors = err,
                    MainResults = null
                };
            }
            List<CategoryListItem> Parents = new List<CategoryListItem>();
            CategoryListItem cli = new CategoryListItem
            {
                CategoryID = cat.Parent.CategoryId
                ,
                CategoryName = cat.Parent.CategoryName
                ,
                ParentID = cat.Parent.ParentID.Value
                ,
                ParentNames = ""
                ,
                ChildCount = cat.Children.Count
                ,
                ProductCount = cat.Parent.Products.Count
            };
            Parents.Add(cli);
            return new CategoryComplexResult
            {
                Errors = null,
                MainResults = Parents
            };
        }

        public CategoryComplexResult GetParentList(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasChild(int id)
        {
            return db.Categories.Any(x => x.ParentID == id);
        }

        public bool HasProduct(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            return cat.Products.Any();
        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int RecordCount)
        {
            List<string> ErrorList = new List<string>();
            List<CategoryListItem> CategoryListItems = new List<CategoryListItem>();
            RecordCount = 0;
            try
            {

                var q = from item in db.Categories
                        select new CategoryListItem
                        {
                            CategoryID = item.CategoryId
                            ,
                            CategoryName = item.CategoryName
                             ,
                            ParentNames = ""
                              ,
                            ChildCount = item.Children.Count
                             ,
                            ProductCount = item.Products.Count
                            ,
                            ParentID = item.ParentID.Value

                        };
                if (!string.IsNullOrEmpty(sm.CategoryName))
                {
                    q = q.Where(x => x.CategoryName.Contains(sm.CategoryName));
                }
                if (sm.ParentID != null)
                {
                    q = q.Where(x => x.ParentID == sm.ParentID.Value);
                }
                RecordCount = q.Count();
                CategoryListItems = q.OrderByDescending(x => x.CategoryID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = null
                    ,
                    MainResults = CategoryListItems

                };

                return results;
            }
            catch (Exception ex)
            {
                ErrorList.Add("خطا در بازیابی اطلاعات" + ex.Message);
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = ErrorList
                    ,
                    MainResults = null

                };
                RecordCount = 0;
                return results;
            }
        }

        public OperationResult Update(Category current)
        {
            OperationResult op = new OperationResult("Update Category", current.CategoryId);
            try
            {
                db.Categories.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update SuccessFully", current.CategoryId);
            }
            catch (Exception ex)
            {

                return op.Failed("Update Failed" + ex.Message, current.CategoryId);
            }
        }
    }
}
