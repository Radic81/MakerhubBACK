using CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.DAL.Interfaces
{
    public interface IRendezVousRepository
    {
        IEnumerable<RendezVous> GetAll();
        IEnumerable<RendezVous> GetByUtilisateur(int idUtilisateur);

        RendezVous? GetById(int id);

        int Create(RendezVous rendezVous);
        bool Update(RendezVous rendezVous);
        bool Delete(int id);
    }
}