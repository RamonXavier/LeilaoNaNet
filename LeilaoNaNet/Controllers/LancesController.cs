using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeilaoNaNet.Models;

namespace LeilaoNaNet.Controllers
{
    public class LancesController : Controller
    {
        private Context db = new Context();

        // GET: Lances
        public ActionResult Index()
        {
            return View(db.Lances.ToList());
        }

        // GET: Lances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lances lances = db.Lances.Find(id);
            if (lances == null)
            {
                return HttpNotFound();
            }
            return View(lances);
        }

        // GET: Lances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Lances lances)
        {
            if (ModelState.IsValid)
            {
                db.Lances.Add(lances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lances);
        }

        // GET: Lances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lances lances = db.Lances.Find(id);
            if (lances == null)
            {
                return HttpNotFound();
            }
            return View(lances);
        }

        // POST: Lances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Lances lances)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lances).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lances);
        }

        // GET: Lances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lances lances = db.Lances.Find(id);
            if (lances == null)
            {
                return HttpNotFound();
            }
            return View(lances);
        }

        // POST: Lances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lances lances = db.Lances.Find(id);
            db.Lances.Remove(lances);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
