using Dapper;
using Npgsql;
using CabMedicalBACK.DAL.Entities;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.DAL.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly NpgsqlConnection _connection;

        public UtilisateurRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Utilisateur> GetAll()
        {
            const string query = @"
                SELECT
                    ""id_utilisateur""       AS ""IdUtilisateur"",
                    ""mot_de_passe""         AS ""MotDePasse"",
                    ""email""                AS ""Email"",
                    ""role""              AS ""Role"",
                    ""nom""                  AS ""Nom"",
                    ""prenom""               AS ""Prenom"",
                    ""telephone""               AS ""Telephone""
                FROM ""utilisateur"";
            ";

            return _connection.Query<Utilisateur>(query);
        }

        public Utilisateur? GetById(int idUtilisateur)
        {
            const string query = @"
                SELECT
                   ""id_utilisateur""       AS ""IdUtilisateur"",
                    ""mot_de_passe""         AS ""MotDePasse"",
                    ""email""                AS ""Email"",
                    ""role""              AS ""Role"",
                    ""nom""                  AS ""Nom"",
                    ""prenom""               AS ""Prenom"",
                    ""telephone""               AS ""Telephone""
                FROM ""utilisateur""
                WHERE ""id_utilisateur"" = @Id;
            ";

            return _connection.QuerySingleOrDefault<Utilisateur>(query, new { Id = idUtilisateur });
        }

        public Utilisateur? GetByEmail(string email)
        {
            const string query = @"
                SELECT
                    ""mot_de_passe""         AS ""MotDePasse"",
                    ""email""                AS ""Email"",
                    ""role""              AS ""Role"",
                    ""id_utilisateur""       AS ""IdUtilisateur""
                FROM ""utilisateur""
                WHERE ""email"" = @Email;
            ";

            return _connection.QuerySingleOrDefault<Utilisateur>(query, new { Email = email });
        }

        public int Create(Utilisateur utilisateur)
        {
            const string query = @"
                INSERT INTO ""utilisateur""
                (
                    ""mot_de_passe"",
                    ""email"",
                    ""role"",
                    ""nom"",
                    ""prenom"",
                    ""telephone""
                )
                VALUES
                (
                    @MotDePasse,
                    @Email,
                    @Role,
                    @Nom,
                    @Prenom,
                    @Telephone
                )
                RETURNING ""id_utilisateur"";
            ";

            return _connection.QuerySingle<int>(query, new
            {
                utilisateur.MotDePasse,
                utilisateur.Email,
                utilisateur.Role,
                utilisateur.Nom,
                utilisateur.Prenom,
                utilisateur.Telephone
            });
        }

        public bool Update(Utilisateur utilisateur)
        {
            const string query = @"
                UPDATE ""utilisateur""
                   SET
                       ""mot_de_passe"" = @MotDePasse,
                       ""email""        = @Email,
                       ""role""      = @Role,
                       ""nom""          = @Nom,
                       ""prenom""       = @Prenom,
                       ""telephone""       = @Telephone
                 WHERE ""id_utilisateur"" = @IdUtilisateur;
            ";

            int affectedRows = _connection.Execute(query, new
            {
                utilisateur.MotDePasse,
                utilisateur.Email,
                utilisateur.Role,
                utilisateur.Nom,
                utilisateur.Prenom,
                utilisateur.Telephone,
                utilisateur.IdUtilisateur
            });

            return affectedRows > 0;
        }
    }
}