using CabMedicalBACK.BLL.Models;
using entities = CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.BLL.Mappers
{
    public static class PatientMapper
    {
        public static Patient ToModel(this entities.Patient entity)
        {
            return new Patient
            {
                IdPatient = entity.IdPatient,
                Prenom = entity.Prenom,
                Nom = entity.Nom,
                Telephone = entity.Telephone,
                DateNaissance = entity.DateNaissance,
                NumeroIdentite = entity.NumeroIdentite
            };
        }

        public static entities.Patient ToEntity(this Patient model)
        {
            return new entities.Patient
            {
                IdPatient = model.IdPatient,
                Prenom = model.Prenom,
                Nom = model.Nom,
                Telephone = model.Telephone,
                DateNaissance = model.DateNaissance,
                NumeroIdentite = model.NumeroIdentite
            };
        }
    }
}