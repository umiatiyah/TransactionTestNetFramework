using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransactionTestWithNetFramework.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult IndexOrder()
        {
            return View();
        }
    }
}