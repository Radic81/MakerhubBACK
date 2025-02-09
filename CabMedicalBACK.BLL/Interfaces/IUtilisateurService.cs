using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.BLL.Interfaces
{
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetAll();
        Utilisateur? GetById(int idUtilisateur);
        int Create(Utilisateur utilisateur);
        bool Update(Utilisateur utilisateur);
    }
}