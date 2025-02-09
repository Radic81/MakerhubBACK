using Dapper;
using Npgsql;
using CabMedicalBACK.DAL.Entities;
using CabMedicalBACK.DAL.Interfaces;

namespace CabMedicalBACK.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly NpgsqlConnection _connection;

        public PatientRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Patient> GetAll()
        {
            const string query = @"
                SELECT
                    ""id_patient""     AS ""IdPatient"",
                    ""prenom""         AS ""Prenom"",
                    ""nom""            AS ""Nom"",
                    ""telephone""      AS ""Telephone"",
                    ""date_naissance"" AS ""DateNaissance"",
                    ""numero_identite"" AS ""NumeroIdentite""
                FROM ""patient"";
            ";

            return _connection.Query<Patient>(query);
        }

        public Patient? GetById(int id)
        {
            const string query = @"
                SELECT
                    ""id_patient""     AS ""IdPatient"",
                    ""prenom""         AS ""Prenom"",
                    ""nom""            AS ""Nom"",
                    ""telephone""      AS ""Telephone"",
                    ""date_naissance"" AS ""DateNaissance"",
                    ""numero_identite"" AS ""NumeroIdentite""
                FROM ""patient""
                WHERE ""id_patient"" = @Id;
            ";

            return _connection.QuerySingleOrDefault<Patient>(query, new { Id = id });
        }

        public int Create(Patient patient)
        {
            const string query = @"
                INSERT INTO ""patient""
                (
                    ""prenom"",
                    ""nom"",
                    ""telephone"",
                    ""date_naissance"",
                    ""numero_identite""
                )
                VALUES
                (
                    @Prenom,
                    @Nom,
                    @Telephone,
                    @DateNaissance,
                    @NumeroIdentite
                )
                RETURNING ""id_patient"" AS ""IdPatient"";
            ";

            return _connection.QuerySingle<int>(query, new
            {
                patient.Prenom,
                patient.Nom,
                patient.Telephone,
                patient.DateNaissance,
                patient.NumeroIdentite
            });
        }

        public bool Update(Patient patient)
        {
            const string query = @"
                UPDATE ""patient""
                SET
                    ""prenom""         = @Prenom,
                    ""nom""            = @Nom,
                    ""telephone""      = @Telephone,
                    ""date_naissance"" = @DateNaissance,
                    ""numero_identite"" = @NumeroIdentite
                WHERE ""id_patient"" = @IdPatient;
            ";

            int affectedRows = _connection.Execute(query, new
            {
                patient.Prenom,
                patient.Nom,
                patient.Telephone,
                patient.DateNaissance,
                patient.NumeroIdentite,
                patient.IdPatient
            });

            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            const string query = @"
                DELETE FROM ""patient""
                WHERE ""id_patient"" = @Id;
            ";

            int affectedRows = _connection.Execute(query, new { Id = id });
            return affectedRows > 0;
        }
    }
}
