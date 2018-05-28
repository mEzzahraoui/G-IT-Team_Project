using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Scrum.Models
{
    public class DeveloppeurToEquipesController : Controller
    {
        private DeveloppeurToEquipeContext db = new DeveloppeurToEquipeContext();

        // GET: DeveloppeurToEquipes
        public async Task<ActionResult> Index()
        {
            var developpeurToEquipes = db.DeveloppeurToEquipes.Include(d => d.equipe);
            return View(await developpeurToEquipes.ToListAsync());
        }

        // GET: DeveloppeurToEquipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloppeurToEquipe developpeurToEquipe = await db.DeveloppeurToEquipes.FindAsync(id);
            if (developpeurToEquipe == null)
            {
                return HttpNotFound();
            }
            return View(developpeurToEquipe);
        }

        // GET: DeveloppeurToEquipes/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipe = new SelectList(db.Equipes, "idEquipe", "nomEquipe");
            return View();
        }

        // POST: DeveloppeurToEquipes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "developpeurToEqipeId,IdDeveloppeur,IdEquipe")] DeveloppeurToEquipe developpeurToEquipe)
        {
            if (ModelState.IsValid)
            {
                db.DeveloppeurToEquipes.Add(developpeurToEquipe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipe = new SelectList(db.Equipes, "idEquipe", "nomEquipe", developpeurToEquipe.IdEquipe);
            return View(developpeurToEquipe);
        }

        // GET: DeveloppeurToEquipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloppeurToEquipe developpeurToEquipe = await db.DeveloppeurToEquipes.FindAsync(id);
            if (developpeurToEquipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipe = new SelectList(db.Equipes, "idEquipe", "nomEquipe", developpeurToEquipe.IdEquipe);
            return View(developpeurToEquipe);
        }

        // POST: DeveloppeurToEquipes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "developpeurToEqipeId,IdDeveloppeur,IdEquipe")] DeveloppeurToEquipe developpeurToEquipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developpeurToEquipe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipe = new SelectList(db.Equipes, "idEquipe", "nomEquipe", developpeurToEquipe.IdEquipe);
            return View(developpeurToEquipe);
        }

        // GET: DeveloppeurToEquipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloppeurToEquipe developpeurToEquipe = await db.DeveloppeurToEquipes.FindAsync(id);
            if (developpeurToEquipe == null)
            {
                return HttpNotFound();
            }
            return View(developpeurToEquipe);
        }

        // POST: DeveloppeurToEquipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DeveloppeurToEquipe developpeurToEquipe = await db.DeveloppeurToEquipes.FindAsync(id);
            db.DeveloppeurToEquipes.Remove(developpeurToEquipe);
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
