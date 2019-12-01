using ECommerce.Areas.Management.Models.Entities;
using ECommerce.Areas.Management.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Areas.Management.Controllers
{
    public class SubModelController : Controller
    {
        ModelRepository MR = new ModelRepository(new Models.Context.ApplicationDbContext());
        BrandRepository BR = new BrandRepository(new Models.Context.ApplicationDbContext());
        SubModelRepository SR = new SubModelRepository(new Models.Context.ApplicationDbContext());
        public ActionResult Index()
        {

            return View(SR.GetAll());
        }
        [HttpPost]
        public ActionResult getModels (int brandId)
        {
            return Json(MR.GetAll(brandId), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult getSubModels(int ModelId)
        {
            return Json(SR.GetAll(ModelId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.Brands = BR.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubModel model)
        {
            if (ModelState.IsValid)
                SR.Save(model);
            return RedirectToAction("/");
        }
        
    
        
        public ActionResult Edit(int id)
        {
            int brandCode = SR.Get(id).Model.Brand.Id;
            ViewBag.Brands = new SelectList(BR.GetAll(), "Id", "Name",brandCode);
            ViewBag.Models = new SelectList(MR.GetAll(), "Id", "Name", SR.Get(id).ModelId);
            return View(SR.Get(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubModel model)
        {
            if (ModelState.IsValid)
                SR.Update(model);
            return RedirectToAction("/");
        }
        public ActionResult Delete (int id)
        {
            return View(SR.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletex(int id)
        {
            if (ModelState.IsValid)
                SR.Delete(SR.Get(id));
            return RedirectToAction("/");
        }
    }
}
