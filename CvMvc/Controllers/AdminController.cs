using CvMvc.Models;
using CvMvc.Models.EntityFramework;
using CvMvc.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class AdminController : BaseController
    {
        Cv db = new Cv();
        ProfileMe p = new ProfileMe();
        NoteDetails nd = new NoteDetails();
        // GET: Admin
        public ActionResult Index()
        {
            var skill = db.Skill.Count();
            ViewBag.Skill = skill;

            var web = db.Portfolio.Where(x => x.PortfolioCategoryId == 1).Count();
            ViewBag.Web = web;

            var desktop = db.Portfolio.Where(x => x.PortfolioCategoryId == 2).Count();
            ViewBag.Desktop = desktop;

            var photo = db.Portfolio.Where(x => x.PortfolioCategoryId == 3).Count();
            ViewBag.Photo = photo;

            var maxSkill = db.Skill.Max(x => x.Name);
            ViewBag.MaxSkill = maxSkill;

            var school = db.Education.OrderByDescending(x => x.Id).Select(x => x.Name).FirstOrDefault();
            ViewBag.School = school;

            var portfolio = db.Portfolio.OrderByDescending(x => x.Id).Select(x => x.Name).FirstOrDefault();
            ViewBag.Portfolio = portfolio;

            var note = db.Note.OrderByDescending(x => x.Id).Select(x => x.Message).FirstOrDefault();
            ViewBag.Note = note;

            var skillList = db.Skill.OrderByDescending(x => x.Point).Take(4).ToList();

            return View(skillList);
        }

        [HttpGet]
        public ActionResult About()
        {
            var about = db.About.FirstOrDefault();
            return View(about);
        }

        [HttpPost]
        public ActionResult About(About about)
        {
            var detail = db.About.FirstOrDefault();

            detail.Hood = about.Hood;
            detail.Explanation = about.Explanation;
            db.SaveChanges();
            return View("About");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var contact = db.Me.FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(Me me)
        {
            var contact = db.Me.FirstOrDefault();
            contact.FullName = me.FullName;
            contact.Email = me.Email;
            contact.Age = me.Age;
            contact.Profile = me.Profile;
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public ActionResult WebSite()
        {
            var detail = db.Detail.FirstOrDefault();
            return View(detail);
        }

        [HttpPost]
        public ActionResult WebSite(Detail detail)
        {
            var key = db.Detail.FirstOrDefault();
            key.CompanyName = detail.CompanyName;
            key.Image = detail.Image;
            db.SaveChanges();
            return View("WebSite");
        }

        public ActionResult Comment()
        {
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());

            var contact = db.Contact.Where(x => x.History == bugun).ToList();
            return View(contact);
        }

        public ActionResult Profile()
        {
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());

            p.me = db.Me.FirstOrDefault();
            p.about = db.About.FirstOrDefault();
            p.education = db.Education.OrderByDescending(x => x.Id).FirstOrDefault();
            p.skill = db.Skill.ToList();
            p.appellation = db.Appellation.ToList();
            p.portfolio = db.Portfolio.Where(x => x.History == bugun).OrderByDescending(x => x.Id).Take(5).ToList();
            return View(p);
        }

        [HttpPost]
        public ActionResult Profile(Me me)
        {
            var key = db.Me.Find(me.Id);
            db.SaveChanges();
            return View("Profile");
        }

        public ActionResult Note()
        {
            nd.note = db.Note.ToList();
            nd.noteDetail = db.NoteDetail.Where(x => x.Status == true).ToList();
            return View(nd);
        }

        [HttpPost]
        public ActionResult Note(Note note)
        {
            note.History = DateTime.Now;
            db.Note.Add(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NoteAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NoteAdd(Note note)
        {
            note.History = DateTime.Now;
            db.Note.Add(note);
            db.SaveChanges();
            return RedirectToAction("Note");
        }

        public ActionResult NoteList()
        {
            var note = db.Note.ToList();
            db.SaveChanges();
            return View(note);
        }

        [HttpGet]
        public ActionResult NoteEdit(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Note.Find(id);

            if (key == null)
            {

            }

            return View(key);
        }

        [HttpPost]
        public ActionResult NoteEdit(int id, Note note)
        {
            var key = db.Note.Find(id);
            key.Message = note.Message;
            db.SaveChanges();
            return RedirectToAction("Note");
        }

        [HttpGet]
        public ActionResult NoteDetailEdit(int? id)
        {
            if (id == null)
            {

            }

            var key = db.NoteDetail.Find(id);

            if (key == null)
            {

            }

            return View(key);
        }

        [HttpPost]
        public ActionResult NoteDetailEdit(int id, NoteDetail noteDetail)
        {
            var key = db.NoteDetail.Find(id);
            key.Detail = noteDetail.Detail;
            db.SaveChanges();
            return RedirectToAction("Note");
        }

        [HttpPost]
        public ActionResult NoteDetails(FormCollection detail, FormCollection key)
        {
            NoteDetail nd = new NoteDetail();
            string message = detail["txtAra"];
            string Id = key["key"];
            nd.NoteId = Convert.ToInt32(Id);
            nd.Detail = message;
            nd.History = DateTime.Now;
            nd.Status = true;
            db.NoteDetail.Add(nd);
            db.SaveChanges();
            return RedirectToAction("Note");
        }


        public ActionResult NoteDetailDelete(int id)
        {
            var key = db.NoteDetail.Find(id);

            key.Status = false;
            db.SaveChanges();
            return RedirectToAction("Note");
        }

        public ActionResult NoteDelete(int id)
        {
            var key = db.Note.Find(id);
            var info = db.NoteDetail.Where(x => x.NoteId == id);

            foreach (var item in info)
            {
                db.NoteDetail.Remove(item);
            }

            db.Note.Remove(key);
            db.SaveChanges();
            return RedirectToAction("Note");
        }

        [HttpGet]
        public ActionResult Skill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Skill(Skill skill)
        {
            db.Skill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Skill");
        }

        public ActionResult SkillList()
        {
            var skill = db.Skill.ToList();
            return View(skill);
        }

        [HttpGet]
        public ActionResult SkillEdit(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Skill.Find(id);

            if (key == null)
            {

            }

            return View(key);
        }

        [HttpPost]
        public ActionResult SkillEdit(int id, Skill skill)
        {
            var key = db.Skill.Find(id);
            key.Name = skill.Name;
            key.Point = skill.Point;
            db.SaveChanges();
            return RedirectToAction("Skill");
        }

        public ActionResult SkillDelete(int id)
        {
            var key = db.Skill.Find(id);
            db.Skill.Remove(key);
            db.SaveChanges();
            return RedirectToAction("Skill");
        }

        public ActionResult Reference()
        {
            var reference = db.References.ToList();
            return View(reference);
        }

        public ActionResult Experience()
        {
            var experience = db.Experience.OrderByDescending(x => x.Id).ToList();
            return View(experience);
        }

        public ActionResult Education()
        {
            var education = db.Education.OrderByDescending(x => x.Id).ToList();
            return View(education);
        }

        [HttpGet]
        public ActionResult EducationEdit(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Education.Find(id);

            if (key == null)
            {

            }

            return View(key);
        }

        [HttpPost]
        public ActionResult EducationEdit(int id, Education education)
        {
            var key = db.Education.Find(id);
            key.Type = education.Type;
            key.Name = education.Name;
            key.Detail = education.Detail;
            key.Explanation = education.Explanation;
            key.History = education.History;
            db.SaveChanges();
            return RedirectToAction("Education");
        }

        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationAdd(Education education)
        {
            db.Education.Add(education);
            db.SaveChanges();
            return RedirectToAction("Education");
        }

        [HttpGet]
        public ActionResult EducationDelete(int id)
        {
            var key = db.Education.Find(id);
            db.Education.Remove(key);
            db.SaveChanges();
            return RedirectToAction("Education");
        }

        public ActionResult Portfolio()
        {
            var portfolio = db.Portfolio.ToList();
            return View(portfolio);
        }

        [HttpGet]
        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Message(FormCollection messages, FormCollection messageList)
        {
            string mesaj = messages["txtAra"];
            var info = db.Contact.Where(x => x.FullName.Contains(mesaj)).ToList();

            string mesajList = messageList["txtList"];
            if (mesajList == "on")
            {
                var info2 = db.Contact.ToList();
                return View(info2);
            }


            return View(info);
        }

        public ActionResult MessageProfile(string email)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Social()
        {
            var social = db.Social.ToList();
            return View(social);
        }

        [HttpPost]
        public ActionResult Social(FormCollection social)
        {
            var socialList = social["txtSearch"];
            var List = db.Social.Where(x => x.Name.Contains(socialList)).ToList();
            return View(List);
        }

        [HttpGet]
        public ActionResult SocialEdit(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Social.Find(id);

            if (key == null)
            {

            }

            return View(key);
        }

        [HttpPost]
        public ActionResult SocialEdit(int id, Social social)
        {
            var key = db.Social.Find(id);
            key.Name = social.Name;
            key.Link = social.Link;
            key.Icon = social.Icon;
            key.Color = social.Color;
            db.SaveChanges();
            return RedirectToAction("Social");
        }

        [HttpGet]
        public ActionResult SocialAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SocialAdd(Social social)
        {
            db.Social.Add(social);
            db.SaveChanges();
            return RedirectToAction("Social");
        }

        [HttpGet]
        public ActionResult SocialDelete(int id)
        {
            var key = db.Social.Find(id);
            db.Social.Remove(key);
            db.SaveChanges();
            return RedirectToAction("Social");
        }
    }
}