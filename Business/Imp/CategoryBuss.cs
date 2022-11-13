using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServiceContract.Services;
using DataAccessServiceContract.Services;
using DomainModel.DTO.Category;
using Microsoft.Data.SqlClient.Server;

namespace Business.Imp
{
   public  class CategoryBuss:ICatBuss
   {
       private readonly DataAccessServiceContract.Services.ICategoryRepository repo;

       public CategoryBuss(ICategoryRepository repo)
       {
           this.repo = repo;
       }
        public CategoryComplexResult GetParent(int id)
        {
            return repo.GetParent(id);
        }

        public CategoryComplexResult GetChildren(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryComplexResult GetParentList(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasChild(int id)
        {
            throw new NotImplementedException();
        }

        public bool DuplicateName(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public bool DuplicateName(string CategoryName, int id)
        {
            throw new NotImplementedException();
        }
    }
}
