using CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.DAL.Interfaces
{
    public interface ITravailleurRepository
    {
        IEnumerable<Travailleur> GetAll();
        Travailleur? GetById(int id);
        int Create(Travailleur travailleur);
        bool Update(Travailleur travailleur);
        bool Delete(int id);
    }
}