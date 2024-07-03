using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Batiment
    {
        [Key]
        public string Nom { get; set; }

        public ICollection<Salle> Salles { get; set; } = new List<Salle>();
    }
}
