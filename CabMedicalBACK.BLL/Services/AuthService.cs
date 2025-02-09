using System.Security.Cryptography;
using System.Text;
using CabMedicalBACK.BLL.Exceptions;
using CabMedicalBACK.BLL.Interfaces;
using CabMedicalBACK.BLL.Models;
using CabMedicalBACK.DAL.Interfaces;
using CabMedicalBACK.BLL.Mappers;

namespace CabMedicalBACK.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUtilisateurRepository _utilisateurRepository;

    public AuthService(IUtilisateurRepository utilisateurRepository)
    {
        _utilisateurRepository = utilisateurRepository;
    }
    
    public Utilisateur? Login(Utilisateur utilisateur)
    {
        string emailInput = utilisateur.Email.ToLower();
        Utilisateur? utilisateurDb = this._utilisateurRepository.GetByEmail(emailInput)?.ToModel();
        if (utilisateurDb != null && utilisateurDb.MotDePasse == this.GenerateHash(utilisateur.Email, utilisateur.MotDePasse))
        {
            return utilisateurDb;
        }

        throw new LoginException();

    }
    
    private string GenerateHash(string email, string password)
    {
        using SHA512 sha512Hash = SHA512.Create() ;

        byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes($"{email}:{password}"));

        StringBuilder builder = new StringBuilder();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}