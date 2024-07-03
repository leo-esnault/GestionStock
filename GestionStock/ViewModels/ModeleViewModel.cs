namespace GestionStock.ViewModels
{
    public class ModeleViewModel
    {
        public string Reference { get; set; }
        public string Nom { get; set; }
        public int DureeGarantie { get; set; }
        public List<string> SelectedServiceNames { get; set; }
    }
}