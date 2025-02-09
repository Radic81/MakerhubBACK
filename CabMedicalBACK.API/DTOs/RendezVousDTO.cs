namespace CabMedicalBACK.API.DTOs
{
    public class RendezVousDTO
    {
        public int IdRendezVous { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; }
        public string? MotifRdv { get; set; }
        public int IdPatient { get; set; }
        public int IdUtilisateur { get; set; }
    }

    public class RendezVousCreateDTO
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; }
        public string? MotifRdv { get; set; }
        public int IdPatient { get; set; }
        public int IdUtilisateur { get; set; }
    }

    public class RendezVousUpdateDTO
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; }
        public string? MotifRdv { get; set; }
        public int IdPatient { get; set; }
        public int IdUtilisateur { get; set; }
    }
}