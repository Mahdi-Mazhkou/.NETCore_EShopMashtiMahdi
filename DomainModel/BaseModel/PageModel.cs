﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.BaseModel
{
   public  class PageModel
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }
}
