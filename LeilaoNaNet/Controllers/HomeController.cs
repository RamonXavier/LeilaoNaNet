using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LeilaoNaNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                return RedirectToAction("Index","Produtos");
            }
            return RedirectToAction("Login","Home");
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Logoff()
        {
            Session.Abandon();
            Session["Login"] = null;
            Session["IdUser"] = null;
            return RedirectToAction("Login", "Home");
        }

    }
}