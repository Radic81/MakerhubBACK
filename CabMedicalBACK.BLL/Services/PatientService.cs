using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Mappers;
using CabMedicalBACK.BLL.Models;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll()
                .Select(e => e.ToModel());
        }

        public Patient? GetById(int id)
        {
            var entity = _patientRepository.GetById(id);
            return entity?.ToModel();
        }

        public int Create(Patient patient)
        {
            return _patientRepository.Create(patient.ToEntity());
        }

        public bool Update(Patient patient)
        {
            return _patientRepository.Update(patient.ToEntity());
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
    }
}