using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.BLL.Interfaces
{
    public interface ITravailleurService
    {
        IEnumerable<Travailleur> GetAll();
        Travailleur? GetById(int id);
        int Create(Travailleur travailleur);
        bool Update(Travailleur travailleur);
        bool Delete(int id);
    }
}