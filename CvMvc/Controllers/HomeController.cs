using CvMvc.Models;
using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class HomeController : Controller
    {
        Cv db = new Cv();
        AboutInformation aı = new AboutInformation();
        ContactInformation cı = new ContactInformation();
        ProfileSocial ps = new ProfileSocial();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            aı.About = db.About.FirstOrDefault();
            aı.Me = db.Me.FirstOrDefault();

            return View(aı);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            cı.me = db.Me.FirstOrDefault();
            return View(cı);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            contact.History = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Time = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Education()
        {
            var education = db.Education.OrderByDescending(x => x.Id).ToList();
            return View(education);
        }

        public ActionResult Experience()
        {
            var experience = db.Experience.OrderByDescending(x => x.Id).ToList();
            return View(experience);
        }

        public ActionResult Footer()
        {
            var me = db.Me.FirstOrDefault();

            ViewBag.me = me.FullName;

            var footer = db.Social.ToList();
            return View(footer);
        }

        public ActionResult Portfolio()
        {
            var portfolio = db.Portfolio.ToList();
            return View(portfolio);
        }

        public ActionResult Profile()
        {
            ps.social = db.Social.ToList();
            ps.appellation = db.Appellation.ToList();
            ps.me = db.Me.FirstOrDefault();
            ps.detail = db.Detail.FirstOrDefault();
            return View(ps);
        }

        public ActionResult Reference()
        {
            var reference = db.References.ToList();
            return View(reference);
        }

        public ActionResult Skill()
        {
            var skill = db.Skill.ToList();
            return View(skill);
        }

    }
}