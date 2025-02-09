using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Mappers;
using CabMedicalBACK.BLL.Models;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            return _utilisateurRepository.GetAll()
                .Select(u => u.ToModel());
        }

        public Utilisateur? GetById(int idUtilisateur)
        {
            var entity = _utilisateurRepository.GetById(idUtilisateur);
            return entity?.ToModel();
        }

        public int Create(Utilisateur utilisateur)
        {
            // Exemple: c’est ici que tu pourrais gérer le hash du mot de passe avant d’appeler la DAL.
            var entity = utilisateur.ToEntity();
            return _utilisateurRepository.Create(entity);
        }

        public bool Update(Utilisateur utilisateur)
        {
            var entity = utilisateur.ToEntity();
            return _utilisateurRepository.Update(entity);
        }
    }
}