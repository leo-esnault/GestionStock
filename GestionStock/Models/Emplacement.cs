using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Emplacement
    {
        [Key, Column(Order = 0)]
        public string Nom { get; set; }

        [Key, Column(Order = 1)]
        public string Nom_Salle { get; set; }

        [Required]
        public string Reference_Modele { get; set; }

        public Salle Salle { get; set; }

        public Modele Modele { get; set; }

        public ICollection<Materiel> Materiels { get; set; } = new List<Materiel>();
    }
}
