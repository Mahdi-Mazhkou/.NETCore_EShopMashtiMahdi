using System;
using System.Collections.Generic;
using System.Text;
using DataAccessServiceContract.Services.Base;
using DomainModel.Models;
using DomainModel.DTO.Category;


namespace DataAccessServiceContract.Services
{
    public interface ICategoryRepository : IBaseRepositorySearchable<Category, int, CategorySearchModel, CategoryComplexResult>
    {
        CategoryComplexResult GetParent(int id);
        CategoryComplexResult GetChildren(int id);
        CategoryComplexResult GetParentList(int id);
        bool HasProduct(int id);
        bool HasChild(int id);
        bool DuplicateName(string CategoryName);
        bool DuplicateName(string CategoryName, int id);
    }
}
