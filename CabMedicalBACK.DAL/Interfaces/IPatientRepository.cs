using CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.DAL.Interfaces
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient? GetById(int id);
        int Create(Patient patient);
        bool Update(Patient patient);
        bool Delete(int id);
    }
}