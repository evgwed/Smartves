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
    public class ShowReportController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /ShowReport/

        public ActionResult Index()
        {
            return View(db.ShowReports.ToList());
        }

        //
        // GET: /ShowReport/Details/5

        public ActionResult Details(int id = 0)
        {
            ShowReport showreport = db.ShowReports.Find(id);
            if (showreport == null)
            {
                return HttpNotFound();
            }
            return View(showreport);
        }

        //
        // GET: /ShowReport/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShowReport/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowReport showreport)
        {
            if (ModelState.IsValid)
            {
                db.ShowReports.Add(showreport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showreport);
        }

        //
        // GET: /ShowReport/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShowReport showreport = db.ShowReports.Find(id);
            if (showreport == null)
            {
                return HttpNotFound();
            }
            return View(showreport);
        }

        //
        // POST: /ShowReport/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowReport showreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showreport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showreport);
        }

        //
        // GET: /ShowReport/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShowReport showreport = db.ShowReports.Find(id);
            if (showreport == null)
            {
                return HttpNotFound();
            }
            return View(showreport);
        }

        //
        // POST: /ShowReport/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowReport showreport = db.ShowReports.Find(id);
            db.ShowReports.Remove(showreport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}