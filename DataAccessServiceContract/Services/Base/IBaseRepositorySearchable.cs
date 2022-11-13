using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessServiceContract.Services.Base
{
    public interface IBaseRepositorySearchable<TModel, TKey, TSearchModel, TSearchResult> : IBaseRepository<TModel, TKey>
    {
        TSearchResult Search(TSearchModel sm, out int RecordCount);
    }
}
