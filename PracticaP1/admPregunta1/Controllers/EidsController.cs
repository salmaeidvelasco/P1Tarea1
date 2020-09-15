using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admPregunta1.Models;

namespace admPregunta1.Controllers
{
    public class EidsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Eids
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Eids.ToList());
        }

        // GET: Eids/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eid eid = db.Eids.Find(id);
            if (eid == null)
            {
                return HttpNotFound();
            }
            return View(eid);
        }

        // GET: Eids/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eids/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eidID,Friendofeid,Place,Email,Birthday")] Eid eid)
        {
            if (ModelState.IsValid)
            {
                db.Eids.Add(eid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eid);
        }

        // GET: Eids/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eid eid = db.Eids.Find(id);
            if (eid == null)
            {
                return HttpNotFound();
            }
            return View(eid);
        }

        // POST: Eids/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eidID,Friendofeid,Place,Email,Birthday")] Eid eid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eid);
        }

        // GET: Eids/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eid eid = db.Eids.Find(id);
            if (eid == null)
            {
                return HttpNotFound();
            }
            return View(eid);
        }

        // POST: Eids/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eid eid = db.Eids.Find(id);
            db.Eids.Remove(eid);
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
