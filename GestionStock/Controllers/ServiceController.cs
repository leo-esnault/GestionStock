using GestionStock.Data;
using GestionStock.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace GestionStock.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Service> objServiceList = _db.Services;
            return View(objServiceList);
        }

        //GET
        public IActionResult Creation()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creation(Service obj)
        {
            var serviceDansBdd = _db.Services.Find(obj.Nom);
            if (serviceDansBdd != null)
            {
                ModelState.AddModelError("Nom", "Ce service existe déjà");
            }
            if (ModelState.IsValid)
            {
                _db.Services.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Service créé avec succès";
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
            var modeleDansBdd = _db.Services.Find(nom);

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
            var obj = _db.Services.Find(nom);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Services.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Service supprimé avec succès";
            return RedirectToAction("index");
        }
    }
}
