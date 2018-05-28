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
    public class DeveloppeursController : Controller
    {
        private DeveloppeurContext db = new DeveloppeurContext();

        // GET: Developpeurs
        public async Task<ActionResult> Index()
        {
            return View(await db.Developpeurs.ToListAsync());
        }

        // GET: Developpeurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = await db.Developpeurs.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] Developpeur developpeur)
        {
            if (ModelState.IsValid)
            {
                db.Developpeurs.Add(developpeur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(developpeur);
        }

        // GET: Developpeurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = await db.Developpeurs.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email")] Developpeur developpeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developpeur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(developpeur);
        }

        // GET: Developpeurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developpeur developpeur = await db.Developpeurs.FindAsync(id);
            if (developpeur == null)
            {
                return HttpNotFound();
            }
            return View(developpeur);
        }

        // POST: Developpeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Developpeur developpeur = await db.Developpeurs.FindAsync(id);
            db.Developpeurs.Remove(developpeur);
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
