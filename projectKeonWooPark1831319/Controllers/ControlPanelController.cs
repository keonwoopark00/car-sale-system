using projectKeonWooPark1831319.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectKeonWooPark1831319.Controllers
{
    public class ControlPanelController : Controller
    {
        // GET: ControlPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrandDetail()
        {
            JivivContext context = new JivivContext();
            var brands = context.Brands.ToList();
            return View(brands);
        }

        [HttpGet]
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                context.Brands.Add(brand);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBrand(int id)
        {
            JivivContext context = new JivivContext();
            var brand = context.Brands.Single(x => x.Id== id);
            return View(brand);
        }

        [HttpPost]
        public ActionResult EditBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                var updatedBrand = context.Brands.Find(brand.Id);
                updatedBrand.Name = brand.Name;
                context.SaveChanges();
                return RedirectToAction("BrandDetail");
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult DeleteBrand(int id)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                var models = context.Models.Where(x => x.BrandId == id).ToList();
                foreach (var mod in models)
                {
                    context.Models.Remove(mod);
                    context.SaveChanges();
                }
                var deletedValue = context.Brands.Find(id);
                context.Brands.Remove(deletedValue);
                context.SaveChanges();
                return RedirectToAction("BrandDetail");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ModelDetail(int? brand)
        {
            JivivContext context = new JivivContext();
            var models = context.Models.Where(x => x.BrandId == brand).ToList();
            var brands = context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "Name");
            return View(models);
        }

        [HttpGet]
        public ActionResult CreateModel()
        {
            JivivContext context = new JivivContext();
            var brands = context.Brands.ToList();
            ViewBag.brandName = new SelectList(brands, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateModel(CarModel model)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                context.Models.Add(model);
                context.SaveChanges();
                return RedirectToAction("ModelDetail", new { @brand = model.BrandId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditModel(int id)
        {
            JivivContext context = new JivivContext();
            var model = context.Models.Single(x => x.Id== id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditModel(CarModel mod)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                var updatedModel = context.Models.Find(mod.Id);
                updatedModel.Name = mod.Name;
                context.SaveChanges();
                return RedirectToAction("ModelDetail", new { @brand = mod.BrandId });
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteModel(int id)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                var deletedValue = context.Models.Find(id);
                int brandId = deletedValue.BrandId;
                context.Models.Remove(deletedValue);
                context.SaveChanges();
                return RedirectToAction("ModelDetail", new { @brand = brandId });
            }
            return View();
        }
    }
}