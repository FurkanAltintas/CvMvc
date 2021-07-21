using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Utils
{
    public class BaseController : Controller
    {
        public Cv db = new Cv();
        public string FullName { get; set; }
        public string Email { get; set; }

        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Email"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                FullName = Session["FullName"].ToString();
                Email = Session["Email"].ToString();

            }
            base.OnActionExecuting(filterContext);
        }
    }
}