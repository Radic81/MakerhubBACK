using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Mappers;
using CabMedicalBACK.BLL.Models;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.BLL.Services
{
    public class TravailleurService : ITravailleurService
    {
        private readonly ITravailleurRepository _travailleurRepository;

        public TravailleurService(ITravailleurRepository travailleurRepository)
        {
            _travailleurRepository = travailleurRepository;
        }

        public IEnumerable<Travailleur> GetAll()
        {
            return _travailleurRepository
                .GetAll()
                .Select(t => t.ToModel());
        }

        public Travailleur? GetById(int id)
        {
            var entity = _travailleurRepository.GetById(id);
            return entity?.ToModel();
        }

        public int Create(Travailleur travailleur)
        {
            return _travailleurRepository.Create(travailleur.ToEntity());
        }

        public bool Update(Travailleur travailleur)
        {
            return _travailleurRepository.Update(travailleur.ToEntity());
        }

        public bool Delete(int id)
        {
            return _travailleurRepository.Delete(id);
        }
    }
}