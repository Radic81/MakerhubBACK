namespace CabMedicalBACK.DAL.Entities
{
    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string MotDePasse { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string Telephone { get; set; } = null!;
    }
}