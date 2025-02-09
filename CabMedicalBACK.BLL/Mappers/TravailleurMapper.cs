using CabMedicalBACK.BLL.Models;
using entities = CabMedicalBACK.DAL.Entities;

namespace CabMedicalBACK.BLL.Mappers
{
    public static class TravailleurMapper
    {
        public static Travailleur ToModel(this entities.Travailleur entity)
        {
            return new Travailleur
            {
                IdTravailleur = entity.IdTravailleur,
                HoraireRegimeTravail = entity.HoraireRegimeTravail,
                Couleur = entity.Couleur
            };
        }

        public static entities.Travailleur ToEntity(this Travailleur model)
        {
            return new entities.Travailleur
            {
                IdTravailleur = model.IdTravailleur,
                HoraireRegimeTravail = model.HoraireRegimeTravail,
                Couleur = model.Couleur
            };
        }
    }
}