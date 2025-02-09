using Dapper;
using Npgsql;
using CabMedicalBACK.DAL.Entities;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.DAL.Repositories
{
    public class TravailleurRepository : ITravailleurRepository
    {
        private readonly NpgsqlConnection _connection;

        public TravailleurRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Travailleur> GetAll()
        {
            const string query = @"
                SELECT
                    ""id_travailleur""         AS ""IdTravailleur"",
                    ""horaire_regime_travail"" AS ""HoraireRegimeTravail"",
                    ""couleur""                AS ""Couleur""
                FROM ""travailleurs"";
            ";

            return _connection.Query<Travailleur>(query);
        }

        public Travailleur? GetById(int id)
        {
            const string query = @"
                SELECT
                    ""id_travailleur""         AS ""IdTravailleur"",
                    ""horaire_regime_travail"" AS ""HoraireRegimeTravail"",
                    ""couleur""                AS ""Couleur""
                FROM ""travailleurs""
                WHERE ""id_travailleur"" = @Id;
            ";

            return _connection.QuerySingleOrDefault<Travailleur>(query, new { Id = id });
        }

        public int Create(Travailleur travailleur)
        {
            const string query = @"
                INSERT INTO ""travailleurs""
                (
                    ""horaire_regime_travail"",
                    ""couleur""
                )
                VALUES
                (
                    @HoraireRegimeTravail,
                    @Couleur
                )
                RETURNING ""id_travailleur"" AS ""IdTravailleur"";
            ";

            return _connection.QuerySingle<int>(query, new
            {
                travailleur.HoraireRegimeTravail,
                travailleur.Couleur
            });
        }

        public bool Update(Travailleur travailleur)
        {
            const string query = @"
                UPDATE ""travailleurs""
                SET
                    ""horaire_regime_travail"" = @HoraireRegimeTravail,
                    ""couleur""                = @Couleur
                WHERE ""id_travailleur"" = @IdTravailleur;
            ";

            int affectedRows = _connection.Execute(query, new
            {
                travailleur.HoraireRegimeTravail,
                travailleur.Couleur,
                travailleur.IdTravailleur
            });

            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            const string query = @"
                DELETE FROM ""travailleurs""
                WHERE ""id_travailleur"" = @Id;
            ";

            int affectedRows = _connection.Execute(query, new { Id = id });
            return affectedRows > 0;
        }
    }
}
