using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.BLL.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient? GetById(int id);
        int Create(Patient patient);
        bool Update(Patient patient);
        bool Delete(int id);
    }
}