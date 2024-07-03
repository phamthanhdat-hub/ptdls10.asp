using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PtdK22CNT3Lesson10.Models;

namespace PtdK22CNT3Lesson10.Controllers
{
    public class PtdHomeController : Controller
    {
        public ActionResult PtdIndex()
        {
            if (Session["PtdAccount"] != null)
            {
                var PtdAccount = Session["PtdAccount"] as PtdAccount;
                ViewBag.FullName = PtdAccount.PtdFullName;
            }
            return View();
        }

        public ActionResult PtdAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PtdContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}