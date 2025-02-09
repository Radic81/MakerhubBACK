using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.API.Mappers
{
    public static class RendezVousMapper
    {
        public static RendezVousDTO ToDTO(this RendezVous model)
        {
            return new RendezVousDTO
            {
                IdRendezVous = model.IdRendezVous,
                DateDebut = model.DateDebut,
                DateFin = model.DateFin,
                Description = model.Description,
                MotifRdv = model.MotifRdv,
                IdPatient = model.IdPatient,
                IdUtilisateur = model.IdUtilisateur
            };
        }

        public static RendezVous ToModel(this RendezVousDTO dto)
        {
            return new RendezVous
            {
                IdRendezVous = dto.IdRendezVous,
                DateDebut = dto.DateDebut,
                DateFin = dto.DateFin,
                Description = dto.Description,
                MotifRdv = dto.MotifRdv,
                IdPatient = dto.IdPatient,
                IdUtilisateur = dto.IdUtilisateur
            };
        }

        public static RendezVous ToModel(this RendezVousCreateDTO dto)
        {
            return new RendezVous
            {
                DateDebut = dto.DateDebut,
                DateFin = dto.DateFin,
                Description = dto.Description,
                MotifRdv = dto.MotifRdv,
                IdPatient = dto.IdPatient,
                IdUtilisateur = dto.IdUtilisateur
            };
        }

        public static RendezVous ToModel(this RendezVousUpdateDTO dto, int id)
        {
            return new RendezVous
            {
                IdRendezVous = id,
                DateDebut = dto.DateDebut,
                DateFin = dto.DateFin,
                Description = dto.Description,
                MotifRdv = dto.MotifRdv,
                IdPatient = dto.IdPatient,
                IdUtilisateur = dto.IdUtilisateur
            };
        }
    }
}
