namespace CabMedicalBACK.API.DTOs
{
    public class TravailleurDTO
    {
        public int IdTravailleur { get; set; }
        public string? HoraireRegimeTravail { get; set; }
        public string? Couleur { get; set; }
    }

    public class TravailleurCreateDTO
    {
        public string? HoraireRegimeTravail { get; set; }
        public string? Couleur { get; set; }
    }

    public class TravailleurUpdateDTO
    {
        public string? HoraireRegimeTravail { get; set; }
        public string? Couleur { get; set; }
    }
}