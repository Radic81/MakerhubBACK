using CabMedicalBACK.BLL.Models;
using Entities = CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.BLL.Mappers
{
    public static class UtilisateurMapper
    {
        // DAL => BLL
        public static Utilisateur ToModel(this Entities.Utilisateur utilisateur)
        {
            return new Utilisateur
            {
                IdUtilisateur = utilisateur.IdUtilisateur,
                MotDePasse = utilisateur.MotDePasse,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }

        // BLL => DAL
        public static Entities.Utilisateur ToEntity(this Utilisateur utilisateur)
        {
            return new Entities.Utilisateur
            {
                IdUtilisateur = utilisateur.IdUtilisateur,
                MotDePasse = utilisateur.MotDePasse,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }
    }
}