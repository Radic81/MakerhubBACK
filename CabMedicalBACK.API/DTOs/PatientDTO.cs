namespace CabMedicalBACK.API.DTOs
{
    public class PatientDTO
    {
        public int IdPatient { get; set; }
        public string Prenom { get; set; } = default!;
        public string Nom { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string NumeroIdentite { get; set; } = default!;
    }

    public class PatientCreateDTO
    {
        public string Prenom { get; set; } = default!;
        public string Nom { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string NumeroIdentite { get; set; } = default!;
    }

    public class PatientUpdateDTO
    {
        public string Prenom { get; set; } = default!;
        public string Nom { get; set; } = default!;
        public string? Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string NumeroIdentite { get; set; } = default!;
    }
}