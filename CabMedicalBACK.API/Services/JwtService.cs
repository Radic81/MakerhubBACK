using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CabMedicalBACK.API.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace CabMedicalBACK.API.Services;

public class JwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(UtilisateurLoginDTO utilisateur)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()),
            new Claim(ClaimTypes.Role, utilisateur.Role.ToString()),
        ];

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:Key"]!));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken token = new JwtSecurityToken(
            this._configuration["Jwt:Issuer"],
            this._configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}