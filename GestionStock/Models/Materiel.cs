using Azure;
using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Materiel
    {
        [Key]
        public string NumeroSerie { get; set; }

        public DateTime? DateEntree { get; set; }

        public DateTime? DateSortie { get; set; }

        [Required]
        public Etat Etat { get; set; }
        public string? Nom_Salle { get; set; }
        public Salle? Salle { get; set; }
        public string? Nom_Emplacement { get; set; }

        [Required]
        public string Reference_Modele { get; set; }
        public Modele Modele { get; set; }
        public Emplacement? Emplacement { get; set; }

        public ICollection<DemandeSAV> DemandesSAV { get; set; } = new List<DemandeSAV>();
    }
}
