using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Models;

namespace DataAccessServiceContract.Services.Base
{
    public interface IBaseRepository<TModel, TKey>
    {
        OperationResult Delete(TKey id);
        OperationResult Update(TModel current);
        OperationResult AddNew(TModel current);
        TModel Get(TKey id);
        List<TModel> GetAll();
    }
}
