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
    public class CreateurDeProjetsController : Controller
    {
        private ScrumContext db = new ScrumContext();

        // GET: CreateurDeProjets
        public ActionResult Index()
        {
            return View(db.Developpeurs.ToList());
        }

        // GET: CreateurDeProjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = db.CreateurDeProjets.Find(id);
            if (createurDeProjet == null)
            {
                return HttpNotFound();
            }
            return View(createurDeProjet);
        }

        // GET: CreateurDeProjets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateurDeProjets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] CreateurDeProjet createurDeProjet)
        {
            if (ModelState.IsValid)
            {
                db.Developpeurs.Add(createurDeProjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createurDeProjet);
        }

        // GET: CreateurDeProjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = db.CreateurDeProjets.Find(id);
            if (createurDeProjet == null)
            {
                return HttpNotFound();
            }
            return View(createurDeProjet);
        }

        // POST: CreateurDeProjets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] CreateurDeProjet createurDeProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createurDeProjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createurDeProjet);
        }

        // GET: CreateurDeProjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = db.CreateurDeProjets.Find(id);
            if (createurDeProjet == null)
            {
                return HttpNotFound();
            }
            return View(createurDeProjet);
        }

        // POST: CreateurDeProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateurDeProjet createurDeProjet = db.CreateurDeProjets.Find(id);
            db.Developpeurs.Remove(createurDeProjet);
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
