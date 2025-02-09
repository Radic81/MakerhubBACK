using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.API.Mappers
{
    public static class PatientMapper
    {
        public static PatientDTO ToDTO(this Patient model)
        {
            return new PatientDTO
            {
                IdPatient = model.IdPatient,
                Prenom = model.Prenom,
                Nom = model.Nom,
                Telephone = model.Telephone,
                DateNaissance = model.DateNaissance,
                NumeroIdentite = model.NumeroIdentite
            };
        }

        public static Patient ToModel(this PatientDTO dto)
        {
            return new Patient
            {
                IdPatient = dto.IdPatient,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Telephone = dto.Telephone,
                DateNaissance = dto.DateNaissance,
                NumeroIdentite = dto.NumeroIdentite
            };
        }

        public static Patient ToModel(this PatientCreateDTO dto)
        {
            return new Patient
            {
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Telephone = dto.Telephone,
                DateNaissance = dto.DateNaissance,
                NumeroIdentite = dto.NumeroIdentite
            };
        }

        public static Patient ToModel(this PatientUpdateDTO dto, int id)
        {
            return new Patient
            {
                IdPatient = id,
                Prenom = dto.Prenom,
                Nom = dto.Nom,
                Telephone = dto.Telephone,
                DateNaissance = dto.DateNaissance,
                NumeroIdentite = dto.NumeroIdentite
            };
        }
    }
}