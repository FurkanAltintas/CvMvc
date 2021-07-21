using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvMvc.Controllers
{
    public class AccountController : Controller
    {
        Cv db = new Cv();
        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var key = db.Admin.Where(x => x.UserName == admin.UserName && x.Password == admin.Password).FirstOrDefault();

            var me = db.Me.Where(x => x.Id == key.Id).FirstOrDefault();

            if (key != null)
            {
                FormsAuthentication.SetAuthCookie(key.UserName, false);
                Session["FullName"] = me.FullName;
                Session["Profile"] = me.Profile;
                Session["Email"] = me.Email;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Email veya Şifre Hatalı";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Login");
        }
    }
}