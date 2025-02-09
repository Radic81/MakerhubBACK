using CabMedicalBACK.API.DTOs;
using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.API.Mappers
{
    public static class TravailleurMapper
    {
        public static TravailleurDTO ToDTO(this Travailleur model)
        {
            return new TravailleurDTO
            {
                IdTravailleur = model.IdTravailleur,
                HoraireRegimeTravail = model.HoraireRegimeTravail,
                Couleur = model.Couleur
            };
        }

        public static Travailleur ToModel(this TravailleurDTO dto)
        {
            return new Travailleur
            {
                IdTravailleur = dto.IdTravailleur,
                HoraireRegimeTravail = dto.HoraireRegimeTravail,
                Couleur = dto.Couleur
            };
        }

        public static Travailleur ToModel(this TravailleurCreateDTO dto)
        {
            return new Travailleur
            {
                HoraireRegimeTravail = dto.HoraireRegimeTravail,
                Couleur = dto.Couleur
            };
        }

        public static Travailleur ToModel(this TravailleurUpdateDTO dto, int id)
        {
            return new Travailleur
            {
                IdTravailleur = id,
                HoraireRegimeTravail = dto.HoraireRegimeTravail,
                Couleur = dto.Couleur
            };
        }
    }
}