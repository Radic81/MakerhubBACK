using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.BLL.Interfaces
{
    public interface IRendezVousService
    {
        IEnumerable<RendezVous> GetAll();
        RendezVous? GetById(int id);
        int Create(RendezVous rendezVous);
        bool Update(RendezVous rendezVous);
        bool Delete(int id);
    }
}