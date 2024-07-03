using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class DemandeSAV
    {
        [Key]
        public int ID { get; set; }

        public int? RMA { get; set; }

        public int? OrdreReservation { get; set; }

        [Required]
        public DateTime DateDemande { get; set; }
        [Required]
        [StringLength(50)]
        public string RaisonDemande { get; set; }

        public DateTime? DateRetour { get; set; }

        [StringLength(100)]
        public string? travaux_effectués { get; set; }

        [Required]
        public string NumeroSerie_Materiel { get; set; }

        public Materiel Materiel { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
