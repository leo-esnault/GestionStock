using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class ServicesModele
    {
        [Key, Column(Order = 0)]
        public string Reference_Modele { get; set; }

        [Key, Column(Order = 1)]
        public string Nom_Service { get; set; }

        public Modele Modele { get; set; }

        public Service Service { get; set; }
    }
}