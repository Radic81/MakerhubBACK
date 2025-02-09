using CabMedicalBACK.API.DTOs;
using Models = CabMedicalBACK.BLL.Models;
using System.Linq;

namespace CabMedicalBACK.API.Mappers
{
    public static class UtilisateurMapper
    {
        // BLL => DTO (lecture)
        public static UtilisateurDTO ToDTO(this Models.Utilisateur utilisateur)
        {
            return new UtilisateurDTO
            {
                IdUtilisateur = utilisateur.IdUtilisateur,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }

        public static Models.Utilisateur ToModel(this UtilisateurDTO utilisateur)
        {
            return new Models.Utilisateur()
            {
                IdUtilisateur = utilisateur.IdUtilisateur,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }

        // DTO => BLL (création)
        public static Models.Utilisateur ToModel(this UtilisateurCreateDTO utilisateur)
        {
            return new Models.Utilisateur()
            {
                MotDePasse = utilisateur.MotDePasse,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }

        // DTO => BLL (mise à jour)
        public static Models.Utilisateur ToModel(this UtilisateurUpdateDTO utilisateur, int id)
        {
            return new Models.Utilisateur()
            {
                MotDePasse = utilisateur.MotDePasse,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Telephone = utilisateur.Telephone
            };
        }

        public static Models.Utilisateur ToModel(this UtilisateurLoginFormDTO utilisateur)
        {
            return new Models.Utilisateur
            {
                MotDePasse = utilisateur.MotDePasse,
                Email = utilisateur.Email
            };
        }

        public static UtilisateurLoginDTO ToLoginDTO(this Models.Utilisateur utilisateur)
        {
            return new UtilisateurLoginDTO
            {
                Id = utilisateur.IdUtilisateur,
                Role = utilisateur.Role
            };
        }
    }
}