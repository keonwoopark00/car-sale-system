using projectKeonWooPark1831319.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectKeonWooPark1831319.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? brand, int? model)
        {
            JivivContext context = new JivivContext();
            var models = context.Models.Where(x => x.BrandId == brand).ToList();
            var brands = context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "Name");
            ViewBag.Models = new SelectList(models, "Id", "Name");
            var detail = new DetailSaleInformation();
            var lstBrands = new List<Brand>();
            var lstModels = new List<CarModel>();
            var lstUsers = new List<User>();
            var sales = context.Sales.Where(x => x.BrandId == brand && x.ModelId == model).ToList();
            foreach (var item in sales)
            {
                lstBrands.Add(context.Brands.Find(item.BrandId));
                lstModels.Add(context.Models.Find(item.ModelId));
                lstUsers.Add(context.Users.Find(item.UserId));
            }
            detail.Brands = lstBrands;
            detail.Models = lstModels;
            detail.Users = lstUsers;
            detail.Sales = sales;
            return View(detail);
        }
    }
}