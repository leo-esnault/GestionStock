using GestionStock.Data;
using GestionStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Common;

namespace GestionStock.Controllers
{
    public class SalleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SalleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Salle> objSalleList = _db.Salles;
            return View(objSalleList);
        }

        //GET
        public IActionResult Creation()
        {
            ViewData["Nom_Batiment"] = new SelectList(_db.Batiments, "Nom", "Nom");
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creation(Salle obj)
        {
            var salleDansBdd = _db.Salles.Find(obj.Nom);
            if (salleDansBdd != null)
            {
                ModelState.AddModelError("Nom", "Cette salle existe déjà");
            }
            if (ModelState.IsValid)
            {
                _db.Salles.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Modèle créé avec succès";
                return RedirectToAction("Creation");
            }
            ViewData["Nom_Batiment"] = new SelectList(_db.Batiments, "Nom", "Nom", obj.Nom_Batiment);
            return View(obj);
        }

        public IActionResult Modification(string? nom)
        {
            if (nom == null)
            {
                return NotFound();
            }
            var salleDansBdd = _db.Salles.Find(nom);

            if (salleDansBdd == null)
            {
                return NotFound();
            }
            ViewData["Nom_Batiment"] = new SelectList(_db.Batiments, "Nom", "Nom", salleDansBdd.Nom_Batiment);
            return View(salleDansBdd);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modification(Salle obj)
        {
            if (ModelState.IsValid)
            {
                _db.Salles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Modèle modifié avec succès";
                return RedirectToAction("Index");
            }
            ViewData["Nom_Batiment"] = new SelectList(_db.Batiments, "Nom", "Nom", obj.Nom_Batiment);
            return View(obj);
        }

        public IActionResult Suppression(string? nom)
        {
            if (nom == null)
            {
                return NotFound();
            }
            var salleDansBdd = _db.Salles.Find(nom);

            if (salleDansBdd == null)
            {
                return NotFound();
            }
            return View(salleDansBdd);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuppressionPOST(string? nom)
        {
            var obj = _db.Salles.Find(nom);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Salles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Modèle supprimé avec succès";
            return RedirectToAction("index");
        }
    }
}
