using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smatrves.Models;

namespace Smatrves.Controllers
{
    public class SiteController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Site/

        public ActionResult Index()
        {
            return View(db.Sites.ToList());
        }

        //
        // GET: /Site/Details/5

        public ActionResult Details(int id = 0)
        {
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        //
        // GET: /Site/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Site/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Site site)
        {
            if (ModelState.IsValid)
            {
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site);
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        //
        // POST: /Site/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Site site)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Site site = db.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        //
        // POST: /Site/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSiteApp()
        {
            if (Session["bla"] == null)
                Session["bla"] = 1;
            List<Site> sites = db.Sites.ToList();
            Random randosha = new Random();
            int site_count = sites.Count;
            int index_view = randosha.Next(0, site_count - 1);
            Site view_site = sites[index_view];
            ViewData["ReturnText"] = "OK||"+view_site.SiteID+"||"+view_site.SiteAdress+"||"+view_site.ShowTime+"||"+view_site.Referrer+"||0||f1f1c572ed61256af41e7ce4f379d0f9||" + Session["bla"] + "||"+db.Sites.Count()+"||5180092||0||";
            if ((int)Session["bla"] == site_count)
            {
                ViewData["ReturnText"] = "ERR||Ожидание просмотра следующего сайта||0||300||0||0||0||0||0||0||0||";
            }
            Session["bla"] = (int)Session["bla"] + 1;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}