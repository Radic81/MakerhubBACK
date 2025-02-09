using CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.DAL.Interfaces
{
    public interface IRendezVousRepository
    {
        IEnumerable<RendezVous> GetAll();
        RendezVous? GetById(int id);
        int Create(RendezVous rendezVous);
        bool Update(RendezVous rendezVous);
        bool Delete(int id);
    }
}