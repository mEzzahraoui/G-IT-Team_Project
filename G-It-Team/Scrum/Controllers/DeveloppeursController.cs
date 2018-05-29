using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scrum.Models;

namespace Scrum.Controllers
{
    public class DeveloppeursController : Controller
    {
        private ScrumContext db = new ScrumContext();

        // GET: Developpeurs
        public ActionResult Index()
        {
            return View(db.Developpeurs.ToList());
        }

        // GET: Developpeurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = db.Developpeurs.Find(id);
            if (developpeur == null)
            {
                return HttpNotFound();
            }
            return View(developpeur);
        }

        // GET: Developpeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developpeurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] Developpeur developpeur)
        {
            if (ModelState.IsValid)
            {
                db.Developpeurs.Add(developpeur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developpeur);
        }

        // GET: Developpeurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = db.Developpeurs.Find(id);
            if (developpeur == null)
            {
                return HttpNotFound();
            }
            return View(developpeur);
        }

        // POST: Developpeurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] Developpeur developpeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developpeur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(developpeur);
        }

        // GET: Developpeurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = db.Developpeurs.Find(id);
            if (developpeur == null)
            {
                return HttpNotFound();
            }
            return View(developpeur);
        }

        // POST: Developpeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Developpeur developpeur = db.Developpeurs.Find(id);
            db.Developpeurs.Remove(developpeur);
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
