namespace CabMedicalBACK.API.DTOs
{
    public class UtilisateurDTO
    {
        public int IdUtilisateur { get; set; }
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string Telephone { get; set; } = null!;
    }

    public class UtilisateurCreateDTO
    {
        public string MotDePasse { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string Telephone { get; set; } = null!;
    }

    public class UtilisateurUpdateDTO
    {
        public string MotDePasse { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string Telephone { get; set; } = null!;
    }
    
    public class UtilisateurLoginFormDTO
    {
        public string Email { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;
    }
    
    public class UtilisateurLoginDTO
    {
        public int Id { get; set; } 
        public int Role { get; set; } 
    }
}