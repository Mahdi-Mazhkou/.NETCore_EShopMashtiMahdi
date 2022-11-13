using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public interface IComplexObjectResult<TModel,TErrorList>
    {
         TModel MainResults { get; set; }
         TErrorList Errors { get; set; }
    }
}
