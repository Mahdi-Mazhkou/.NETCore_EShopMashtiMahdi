using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServiceContract.Services;
using DomainModel.DTO.Supplier;

namespace EShopMashtiMahdi.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierBuss _supBuss;

        public SupplierController(ISupplierBuss supBuss)
        {
            _supBuss = supBuss;
        }
        public IActionResult Index(SupplierSearchModel sm)
        {
            return View(sm);
        }

        public IActionResult AddNew()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddNew(SupplierAddEditModel supp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var op = _supBuss.AddNew(supp);
        //        if (op.Success)
        //        {
        //            return RedirectToAction("Index", "Supplier");
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = op.Message;
        //            return View(supp);
        //        }
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Some Message";
        //        return View(supp);
        //    }

        //}

        [HttpPost]
        public JsonResult AddNew(SupplierAddEditModel supp)
        {
            var op = _supBuss.AddNew(supp);
            return Json(op);

        }

       
        public IActionResult Update(int supplierId)
        {
            var sup = _supBuss.Get(supplierId);
            return View(sup);
        }
        [HttpPost]
        public JsonResult Update(SupplierAddEditModel supp)
        {
            var op = _supBuss.Update(supp);
            return Json(op);
        }
        public IActionResult List(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierSearchList", sm);
        }

        [HttpPost]
        public IActionResult Delete(int supplierId)
        {
            var op = _supBuss.Delete(supplierId);
            return Json(op);
        }
    }
}
