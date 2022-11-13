using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServiceContract.Services;
using DomainModel.DTO.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace EShopMashtiMahdi.ViewComponents
{
    [ViewComponent(Name = "SupplierSearchList")]
    public class SupplierSearchListViewComponent : ViewComponent
    {
        private readonly ISupplierBuss supBuss;

        public SupplierSearchListViewComponent(ISupplierBuss supBuss)
        {
            this.supBuss = supBuss;
        }
        public IViewComponentResult Invoke(SupplierSearchModel sm)
        {
            int rc = 0;
            if (sm == null || sm.PageSize == 0)
            {
               sm=new SupplierSearchModel {PageSize = 10};
            }

            List<SupplierListItem> sr = supBuss.Search(sm, out rc);
            return View(sr);
        }
    }
}
