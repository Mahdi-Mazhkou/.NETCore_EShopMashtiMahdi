using System;
using System.Collections.Generic;
using System.Text;
using DomainModel;

namespace DomainModel.DTO.Category
{
    public class CategoryComplexResult : IComplexObjectResult<List<CategoryListItem>, List<string>>
    {
        private List<CategoryListItem> mainResult;
        public List<CategoryListItem> MainResults
        {
            get
            {
                return this.mainResult;
            }
            set
            {
                this.mainResult = value;
            }
        }
        private List<string> errors;
        public List<string> Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                this.errors = value;
            }
        }
    }
}
