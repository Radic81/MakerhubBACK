using CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur? GetById(int idUtilisateur);
        Utilisateur? GetByEmail(string email);
        int Create(Utilisateur utilisateur);
        bool Update(Utilisateur utilisateur);
    }
}