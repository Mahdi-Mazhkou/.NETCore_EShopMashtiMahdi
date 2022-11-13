using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.DTO.Supplier
{
    public class SupplierAddEditModel
    {
        public int SupplierID { get; set; }

        [Required (ErrorMessage ="نام را وارد کنید")]
        [StringLength(100, ErrorMessage = "حداقل 10 تا حداکثر 400 تا", MinimumLength = 10)]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "آدرس را وارد کنید")]
        [StringLength(400,ErrorMessage ="حداقل 10 تا حداکثر 400 تا",MinimumLength =10)]
        public string Address { get; set; }
        [Required(ErrorMessage = "تلفن را وارد نمایید")]
        [StringLength(50, ErrorMessage = "حداقل 10 تا حداکثر 400 تا", MinimumLength = 10)]
        public string Tel { get; set; }
        [Required(ErrorMessage = "موبایل را وارد نمایید")]
        [StringLength(50, ErrorMessage = "حداقل 10 تا حداکثر 400 تا", MinimumLength = 10)]
        public string Mobile { get; set; }
        public int ProductCount { get; set; }
    }
}
