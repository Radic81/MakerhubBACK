using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Mappers;
using CabMedicalBACK.BLL.Models;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.BLL.Services
{
    public class RendezVousService : IRendezVousService
    {
        private readonly IRendezVousRepository _rendezVousRepository;

        public RendezVousService(IRendezVousRepository rendezVousRepository)
        {
            _rendezVousRepository = rendezVousRepository;
        }

        public IEnumerable<RendezVous> GetAll()
        {
            return _rendezVousRepository.GetAll()
                .Select(r => r.ToModel());
        }

        public RendezVous? GetById(int id)
        {
            var entity = _rendezVousRepository.GetById(id);
            return entity?.ToModel();
        }
        
        public IEnumerable<RendezVous> GetByUtilisateur(int idUtilisateur)
        {
            var list = _rendezVousRepository.GetByUtilisateur(idUtilisateur);
            return list.Select(r => r.ToModel());
        }


        public int Create(RendezVous rendezVous)
        {
            return _rendezVousRepository.Create(rendezVous.ToEntity());
        }

        public bool Update(RendezVous rendezVous)
        {
            return _rendezVousRepository.Update(rendezVous.ToEntity());
        }

        public bool Delete(int id)
        {
            return _rendezVousRepository.Delete(id);
        }
    }
}