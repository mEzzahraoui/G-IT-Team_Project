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
    public class ProjetsController : Controller
    {
        private ProjetContext db = new ProjetContext();

        // GET: Projets
        public async Task<ActionResult> Index()
        {
            return View(await db.Projets.ToListAsync());
        }

        // GET: Projets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = await db.Projets.FindAsync(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjectID,NomProjet,DateDebut,DateFin,EquipeID,CreateurDeProjetID")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Projets.Add(projet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(projet);
        }

        // GET: Projets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = await db.Projets.FindAsync(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjectID,NomProjet,DateDebut,DateFin,EquipeID,CreateurDeProjetID")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(projet);
        }

        // GET: Projets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = await db.Projets.FindAsync(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Projet projet = await db.Projets.FindAsync(id);
            db.Projets.Remove(projet);
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
