using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionTestWithNetFramework.DataContext;
using TransactionTestWithNetFramework.Response;

namespace TransactionTestWithNetFramework.Controllers
{
    public class AuthController : Controller
    {
        private TransactionContext db = new TransactionContext();

        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string Username, string Password)
        {
            var res = new Auth();
            var login = db.Users.Where(e => e.Username == Username && e.Password == Password).FirstOrDefault();
            if (login == null)
                return Json("Invalid Password Or Email");
            res.Username = login.Username;
            res.Status = true;
            res.Message = "Login Successfully";
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}