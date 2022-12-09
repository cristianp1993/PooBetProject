using BetProject.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetProject.Controllers
{
    public class HomeController : Controller
    {
        PersonRepository per = new PersonRepository();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ValidateUser(string user, string password)
        {

            bool exists = per.Login(user, password);

            if (exists)
            {
                return RedirectToAction("Index","Menu");
            }
            else
            {
                return RedirectToAction("Index");
            }

            

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}