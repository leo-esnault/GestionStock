using GestionStock.Data;
using GestionStock.Models;
using GestionStock.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;

namespace GestionStock.Controllers
{
    public class ModeleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModeleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Modele> objModeleList = _db.Modeles;
            return View(objModeleList);
        }

        //GET
        public IActionResult Creation()
        {
            var services = _db.Services.Select(s => new SelectListItem
            {
                Value = s.Nom,
                Text = s.Nom
            }).ToList();

            ViewBag.Services = services;

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creation(ModeleViewModel modeleViewModel)
        {
            var modDansBdd = _db.Modeles.Find(modeleViewModel.Reference);
            if (modDansBdd != null)
            {
                ModelState.AddModelError("Reference", "Ce modèle existe déjà");
            }
            if (ModelState.IsValid)
            {
                var obj = new Modele
                {
                    Reference = modeleViewModel.Reference,
                    Nom = modeleViewModel.Nom,
                    DureeGarantie = modeleViewModel.DureeGarantie,
                    ServicesModeles = modeleViewModel.SelectedServiceNames
                        .Select(name => new ServicesModele { Nom_Service = name }).ToList()
                };
                _db.Modeles.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Modèle créé avec succès";
                return RedirectToAction("Creation");
            }
            return View(modeleViewModel);
        }

        public IActionResult Modification(string? reference)
        {
            if (reference == null)
            {
                return NotFound();
            }
            var modeleDansBdd = _db.Modeles.Find(reference);

            if (modeleDansBdd == null)
            {
                return NotFound();
            }
            return View(modeleDansBdd);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modification(Modele obj)
        {
            if (ModelState.IsValid)
            {
                _db.Modeles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Modèle modifié avec succès";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Suppression(string? reference)
        {
            if (reference == null)
            {
                return NotFound();
            }
            var modeleDansBdd = _db.Modeles.Find(reference);

            if (modeleDansBdd == null)
            {
                return NotFound();
            }
            return View(modeleDansBdd);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuppressionPOST(string? reference)
        {
            var obj = _db.Modeles.Find(reference);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Modeles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Modèle supprimé avec succès";
            return RedirectToAction("index");
        }
    }
}
