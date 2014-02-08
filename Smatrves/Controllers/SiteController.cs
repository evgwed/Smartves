﻿using System;
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
            ViewData["ReturnText"] = "OK||8465||http://dengihalyava.blogspot.ru/||60||http://yandex.ru/yandsearch?text=%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0||0||f1f1c572ed61256af41e7ce4f379d0f9||1||59||5180092||0||";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}