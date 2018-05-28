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
    public class EquipesController : Controller
    {
        private EquipeContext db = new EquipeContext();

        // GET: Equipes
        public async Task<ActionResult> Index()
        {
            return View(await db.Equipes.ToListAsync());
        }

        // GET: Equipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = await db.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idEquipe,nomEquipe")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Equipes.Add(equipe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = await db.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idEquipe,nomEquipe")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = await db.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Equipe equipe = await db.Equipes.FindAsync(id);
            db.Equipes.Remove(equipe);
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
