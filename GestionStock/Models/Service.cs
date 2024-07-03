using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Service
    {
        [Key]
        public string Nom { get; set; }

        public ICollection<ServicesModele> ServicesModeles { get; set; } = new List<ServicesModele>();
    }
}
