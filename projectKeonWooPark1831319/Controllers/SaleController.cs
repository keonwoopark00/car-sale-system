using projectKeonWooPark1831319.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectKeonWooPark1831319.Controllers
{
    public class SaleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SellCar(int? brand, int? model, decimal? price)
        {
            JivivContext context = new JivivContext();
            var brands = context.Brands.ToList();
            var models = context.Models.Where(x => x.BrandId == brand).ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "Name");
            ViewBag.Models = new SelectList(models, "Id", "Name");
            if (price == null)
            {
                ViewBag.Message = "Please enter price";
            }
            if (brand != null && model != null && price != null)
            {
                Sale sale = new Sale();
                sale.BrandId = brand ?? default(int);
                sale.ModelId = model ?? default(int);
                sale.UserId = Convert.ToInt32(Session["userId"]);
                sale.Price = price ?? 0;
                context.Sales.Add(sale);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UserProfile(int id)
        {
            var detail = new DetailSaleInformation();
            var lstBrands = new List<Brand>();
            var lstModels = new List<CarModel>();
            JivivContext context = new JivivContext();
            var sales = context.Sales.Where(x => x.UserId == id).ToList();
            foreach(var item in sales)
            {
                lstBrands.Add(context.Brands.Find(item.BrandId));
                lstModels.Add(context.Models.Find(item.ModelId));
            }
            detail.Brands = lstBrands;
            detail.Models = lstModels;
            detail.Sales = sales;
            return View(detail);
        }
    }
}