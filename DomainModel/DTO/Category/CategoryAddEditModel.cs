using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.DTO.Category
{
    class CategoryAddEditModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "نام رده")]
        public string CategoryName { get; set; }
        [StringLength(100, MinimumLength = 0, ErrorMessage = "توضیح حداکثر 100 حرف")]
        public string SmallDescription { get; set; }
        public int? ParentID { get; set; }
       

    }
}
