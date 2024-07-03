using GestionStock.Data;
using GestionStock.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace GestionStock.Controllers
{
    public class BatimentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BatimentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Batiment> objModeleList = _db.Batiments;
            return View(objModeleList);
        }

        //GET
        public IActionResult Creation()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creation(Batiment obj)
        {
            var batimentDansBdd = _db.Batiments.Find(obj.Nom);
            if (batimentDansBdd != null)
            {
                ModelState.AddModelError("Nom", "Cette salle existe déjà");
            }
            if (ModelState.IsValid)
            {
                _db.Batiments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Batiment créé avec succès";
                return RedirectToAction("Creation");
            }
            return View(obj);
        }

        public IActionResult Suppression(string? nom)
        {
            if (nom == null)
            {
                return NotFound();
            }
            var modeleDansBdd = _db.Batiments.Find(nom);

            if (modeleDansBdd == null)
            {
                return NotFound();
            }
            return View(modeleDansBdd);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuppressionPOST(string? nom)
        {
            var obj = _db.Batiments.Find(nom);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Batiments.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Batiment supprimé avec succès";
            return RedirectToAction("index");
        }
    }
}
