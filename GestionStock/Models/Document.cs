using System.ComponentModel.DataAnnotations;

namespace GestionStock.Models
{
    public class Document
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ID_Demande { get; set; }

        public DemandeSAV DemandeSAV { get; set; }
    }
}
