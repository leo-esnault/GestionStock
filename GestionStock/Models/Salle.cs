using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Salle
    {
        [Key]
        public string Nom { get; set; }

        [Required]
        public string Nom_Batiment { get; set; }

        [ValidateNever]
        public Batiment Batiment { get; set; }

        public ICollection<Emplacement> Emplacements { get; set; } = new List<Emplacement>();
        public ICollection<Materiel> Materiels { get; set; } = new List<Materiel>();
    }
}
