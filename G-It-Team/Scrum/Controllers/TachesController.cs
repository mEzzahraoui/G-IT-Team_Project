using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scrum.Models;

namespace Scrum.Controllers
{
    public class TachesController : Controller
    {
        private TacheContext db = new TacheContext();

        // GET: Taches
        public async Task<ActionResult> Index()
        {
            var taches = db.Taches.Include(t => t.developpeur).Include(t => t.sprint);
            return View(await taches.ToListAsync());
        }

        // GET: Taches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = await db.Taches.FindAsync(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // GET: Taches/Create
        public ActionResult Create()
        {
            ViewBag.DeveloppeurId = new SelectList(db.Developpeurs, "DeveloppeurID", "Nom");
            ViewBag.SprintID = new SelectList(db.Sprints, "SprintID", "SprintName");
            return View();
        }

        // POST: Taches/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TacheID,nomTache,statusTache,coutTache,DeveloppeurId,SprintID")] Tache tache)
        {
            if (ModelState.IsValid)
            {
                db.Taches.Add(tache);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloppeurId = new SelectList(db.Developpeurs, "DeveloppeurID", "Nom", tache.DeveloppeurId);
            ViewBag.SprintID = new SelectList(db.Sprints, "SprintID", "SprintName", tache.SprintID);
            return View(tache);
        }

        // GET: Taches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = await db.Taches.FindAsync(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloppeurId = new SelectList(db.Developpeurs, "DeveloppeurID", "Nom", tache.DeveloppeurId);
            ViewBag.SprintID = new SelectList(db.Sprints, "SprintID", "SprintName", tache.SprintID);
            return View(tache);
        }

        // POST: Taches/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TacheID,nomTache,statusTache,coutTache,DeveloppeurId,SprintID")] Tache tache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tache).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloppeurId = new SelectList(db.Developpeurs, "DeveloppeurID", "Nom", tache.DeveloppeurId);
            ViewBag.SprintID = new SelectList(db.Sprints, "SprintID", "SprintName", tache.SprintID);
            return View(tache);
        }

        // GET: Taches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = await db.Taches.FindAsync(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // POST: Taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tache tache = await db.Taches.FindAsync(id);
            db.Taches.Remove(tache);
            await db.SaveChangesAsync();
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
