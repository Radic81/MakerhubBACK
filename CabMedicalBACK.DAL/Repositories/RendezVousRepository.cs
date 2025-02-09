using Dapper;
using Npgsql;
using CabMedicalBACK.DAL.Entities;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.DAL.Repositories
{
    public class RendezVousRepository : IRendezVousRepository
    {
        private readonly NpgsqlConnection _connection;

        public RendezVousRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<RendezVous> GetAll()
        {
            const string query = @"
                SELECT
                    ""id_rendez_vous"" AS ""IdRendezVous"",
                    ""date_debut""     AS ""DateDebut"",
                    ""date_fin""       AS ""DateFin"",
                    ""description""    AS ""Description"",
                    ""motif_rdv""      AS ""MotifRdv"",
                    ""id_patient""     AS ""IdPatient"",
                    ""id_utilisateur"" AS ""IdUtilisateur""
                FROM ""rendez_vous"";
            ";

            return _connection.Query<RendezVous>(query);
        }

        public RendezVous? GetById(int id)
        {
            const string query = @"
                SELECT
                    ""id_rendez_vous"" AS ""IdRendezVous"",
                    ""date_debut""     AS ""DateDebut"",
                    ""date_fin""       AS ""DateFin"",
                    ""description""    AS ""Description"",
                    ""motif_rdv""      AS ""MotifRdv"",
                    ""id_patient""     AS ""IdPatient"",
                    ""id_utilisateur"" AS ""IdUtilisateur""
                FROM ""rendez_vous""
                WHERE ""id_rendez_vous"" = @Id;
            ";

            return _connection.QuerySingleOrDefault<RendezVous>(query, new { Id = id });
        }

        public int Create(RendezVous rendezVous)
        {
            const string query = @"
                INSERT INTO ""rendez_vous""
                (
                    ""date_debut"",
                    ""date_fin"",
                    ""description"",
                    ""motif_rdv"",
                    ""id_patient"",
                    ""id_utilisateur""
                )
                VALUES
                (
                    @DateDebut,
                    @DateFin,
                    @Description,
                    @MotifRdv,
                    @IdPatient,
                    @IdUtilisateur
                )
                RETURNING ""id_rendez_vous"" AS ""IdRendezVous"";
            ";

            return _connection.QuerySingle<int>(query, new
            {
                rendezVous.DateDebut,
                rendezVous.DateFin,
                rendezVous.Description,
                rendezVous.MotifRdv,
                rendezVous.IdPatient,
                rendezVous.IdUtilisateur
            });
        }

        public bool Update(RendezVous rendezVous)
        {
            const string query = @"
                UPDATE ""rendez_vous""
                SET
                    ""date_debut""     = @DateDebut,
                    ""date_fin""       = @DateFin,
                    ""description""    = @Description,
                    ""motif_rdv""      = @MotifRdv,
                    ""id_patient""     = @IdPatient,
                    ""id_utilisateur"" = @IdUtilisateur
                WHERE ""id_rendez_vous"" = @IdRendezVous;
            ";

            int affectedRows = _connection.Execute(query, new
            {
                rendezVous.DateDebut,
                rendezVous.DateFin,
                rendezVous.Description,
                rendezVous.MotifRdv,
                rendezVous.IdPatient,
                rendezVous.IdUtilisateur,
                IdRendezVous = rendezVous.IdRendezVous
            });

            
            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            // Suppression définitive
            const string query = @"
                DELETE FROM ""rendez_vous""
                WHERE ""id_rendez_vous"" = @Id;
            ";

            int affectedRows = _connection.Execute(query, new { Id = id });
            return affectedRows > 0;
        }
    }
}
