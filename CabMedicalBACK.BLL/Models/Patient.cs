namespace CabMedicalBACK.BLL.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string Prenom { get; set; } = default!;
        public string Nom { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string NumeroIdentite { get; set; } = default!;
    }
}