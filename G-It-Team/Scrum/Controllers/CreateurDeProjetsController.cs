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
    public class CreateurDeProjetsController : Controller
    {
        private CreateurDeProjetContext db = new CreateurDeProjetContext();

        // GET: CreateurDeProjets
        public async Task<ActionResult> Index()
        {
            return View(await db.Developpeurs.ToListAsync());
        }

        // GET: CreateurDeProjets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = await db.Developpeurs.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email,idCreateur")] CreateurDeProjet createurDeProjet)
        {
            if (ModelState.IsValid)
            {
                db.Developpeurs.Add(createurDeProjet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createurDeProjet);
        }

        // GET: CreateurDeProjets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = await db.Developpeurs.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "DeveloppeurID,Nom,Prenom,Password,Email,idCreateur")] CreateurDeProjet createurDeProjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createurDeProjet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(createurDeProjet);
        }

        // GET: CreateurDeProjets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateurDeProjet createurDeProjet = await db.Developpeurs.FindAsync(id);
            if (createurDeProjet == null)
            {
                return HttpNotFound();
            }
            return View(createurDeProjet);
        }

        // POST: CreateurDeProjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CreateurDeProjet createurDeProjet = await db.Developpeurs.FindAsync(id);
            db.Developpeurs.Remove(createurDeProjet);
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
