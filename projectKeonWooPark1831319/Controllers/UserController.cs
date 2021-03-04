using projectKeonWooPark1831319.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectKeonWooPark1831319.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                try
                {
                    var loginUser = context.Users.Single(x => x.Username == user.Username && x.Password == user.Password);
                    Session["userId"] = loginUser.Id;
                    ViewBag.Message = null;
                    return RedirectToAction("UserProfile", "Sale", new { @id = loginUser.Id } );
                } catch (Exception)
                {
                    ViewBag.Message = "Incorrect username and / or password";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                JivivContext context = new JivivContext();
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("Index");
        }
    }
}