using CabMedicalBACK.BLL.Models;

namespace CabMedicalBACK.BLL.Interfaces;

public interface IAuthService
{
    Utilisateur? Login(Utilisateur utilisateur);
}