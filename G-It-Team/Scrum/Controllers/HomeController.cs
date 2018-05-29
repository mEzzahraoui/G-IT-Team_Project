using Scrum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Accueil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Developpeur dev)
        {
            /* using(ScrumContext db=new ScrumContext())
             {
                var user = db.Developpeurs.First(p => p.Email.Equals(dev.Email) && p.Password.Equals(dev.Password));
                if (user != null)
                {
                    Session["DeveleppeurID"] = user.DeveloppeurID;
                    Session["DeveloppeurName"] = user.Nom.ToString();
                    return RedirectToAction("Accueil");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong");
                }
             }*/
            ViewBag.Message = dev.Email;
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Inscription()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}