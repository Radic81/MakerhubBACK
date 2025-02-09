using CabMedicalBACK.BLL.Models;
using entities = CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.BLL.Mappers
{
    public static class RendezVousMapper
    {
        public static RendezVous ToModel(this entities.RendezVous entity)
        {
            return new RendezVous
            {
                IdRendezVous = entity.IdRendezVous,
                DateDebut = entity.DateDebut,
                DateFin = entity.DateFin,
                Description = entity.Description,
                MotifRdv = entity.MotifRdv,
                IdPatient = entity.IdPatient,
                IdUtilisateur = entity.IdUtilisateur
            };
        }

        public static entities.RendezVous ToEntity(this RendezVous model)
        {
            return new entities.RendezVous 
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
    }
}