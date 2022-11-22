namespace MedicalApp.Data.Repositories
{
    using Dapper;
    using MedicalApp.Domain.MedicalApp.Models;
    using MySql.Data.MySqlClient;

    public class PatientRepository : IPatientRepository
    {
        private readonly MySQLConfiguration _connectionsString;

        public PatientRepository(MySQLConfiguration mySQLConfiguration)
        {
            this._connectionsString = mySQLConfiguration;
        }

        protected MySqlConnection DbConection()
        {
            return new MySqlConnection(_connectionsString.ConnectionString);
        }

        public async Task Delete(int id)
        {
            var db = DbConection();

            var sql = @"DELETE FROM patients WHERE identification = @id";

            await db.ExecuteAsync(sql, new { id = id });
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var db = DbConection();

            var sql = @"SELECT identification, name, lastName, birthdate, city, diseasesallergies, phonenumber, rh FROM patients";

            return await db.QueryAsync<Patient>(sql, new { });
        }

        public async Task<Patient> GetById(int id)
        {
            var db = DbConection();

            var sql = @"SELECT identification, name, lastName, birthdate, city, diseasesallergies, phonenumber, rh FROM patients
                        WHERE identification = @id";

            return await db.QueryFirstOrDefaultAsync<Patient>(sql, new { Id = id });
        }

        public async Task<bool> Insert(Patient patient)
        {
            var db = DbConection();

            var sql = @"INSERT INTO patients (identification, name, lastName, birthDate, city, diseasesAllergies, phoneNumber, rh) 
                        VALUES (@Identification, @Name, @LastName, @BirthDate, @City, @diseasesAllergies, @PhoneNumber, @Rh)";

            var result = await db.ExecuteAsync(sql, new
            {
                patient.Identification,
                patient.Name,
                patient.LastName,
                patient.BirthDate,
                patient.City,
                patient.DiseasesAllergies,
                patient.PhoneNumber,
                patient.Rh,
            });

            return result > 0;
        }

        public async Task<bool> Update(Patient patient)
        {
            var db = DbConection();

            var sql = @"UPDATE patients SET identification = @Identification,
                                            name = @Name,
                                            lastName = @LastName,
                                            birthDate = @BirthDate,
                                            city = @City,
                                            diseasesAllergies = @diseasesAllergies,
                                            phoneNumber = @PhoneNumber
                                            rh = @Rh
                      WHERE identification = @Identification ";

            var result = await db.ExecuteAsync(sql, new
            {
                patient.Identification,
                patient.Name,
                patient.LastName,
                patient.BirthDate,
                patient.City,
                patient.DiseasesAllergies,
                patient.PhoneNumber,
                patient.Rh,
            });

            return result > 0;
        }
    }
}
