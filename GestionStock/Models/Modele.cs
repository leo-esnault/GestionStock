using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Modele
    {
        [Key]
        [Required(ErrorMessage = "La référence est requise.")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Le nom du modèle est requis.")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Range(1,100, ErrorMessage = "La garantie doit être positive et inferieure a 100 ans")]
        public int? DureeGarantie { get; set; }

        public ICollection<Emplacement> Emplacements { get; set; } = new List<Emplacement>();

        public ICollection<ServicesModele> ServicesModeles { get; set; } = new List<ServicesModele>();

        public ICollection<Materiel> Materiels { get; set; } = new List<Materiel>();
    }
}
