namespace MedicalApp.Data.Repositories
{
    using Dapper;
    using MedicalApp.Domain.MedicalApp.Models;
    using MySql.Data.MySqlClient;

    public class DoctorRepository : IDoctorRepository
    {
        private readonly MySQLConfiguration _connectionsString;

        public DoctorRepository(MySQLConfiguration mySQLConfiguration)
        {
            _connectionsString = mySQLConfiguration;
        }

        protected MySqlConnection DbConection()
        {
            return new MySqlConnection(_connectionsString.ConnectionString);
        }

        public async Task Delete(int id)
        {
            var db = DbConection();

            var sql = @"DELETE FROM doctors WHERE identification = @id";

            await db.ExecuteAsync(sql, new { id = id });
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var db = DbConection();

            var sql = @"SELECT identification, name, lastName, phoneNumber, specialty, office, schedule FROM doctors";

            return await db.QueryAsync<Doctor>(sql, new { });
        }

        public async Task<Doctor> GetById(int id)
        {
            var db = DbConection();

            var sql = @"SELECT identification, name, lastName, phoneNumber, specialty, office, schedule FROM doctors
                        WHERE identification = @id";

            return await db.QueryFirstOrDefaultAsync<Doctor>(sql, new { Id = id });
        }

        public async Task<bool> Insert(Doctor doctor)
        {
            var db = DbConection();

            var sql = @"INSERT INTO doctors (identification, name, lastName, phoneNumber, specialty, office, schedule) 
                        VALUES (@Identification, @Name, @LastName, @PhoneNumber, @Specialty, @Office, @Schedule)";

            var result = await db.ExecuteAsync(sql, new
            { doctor.Identification,
              doctor.Name,
              doctor.LastName,
              doctor.PhoneNumber,
              doctor.Specialty,
              doctor.Office,
              doctor.Schedule });

            return result > 0;
        }

        public async Task<bool> Update(Doctor doctor)
        {
            var db = DbConection();

            var sql = @"UPDATE doctors SET identification = @Identification,
                                            name = @Name,
                                            lastName = @LastName,
                                            phoneNumber = @PhoneNumber,
                                            specialty = @Specialty,
                                            office = @Office,
                                            schedule = @Schedule
                      WHERE identification = @Identification ";

            var result = await db.ExecuteAsync(sql, new
            {
                doctor.Identification,
                doctor.Name,
                doctor.LastName,
                doctor.PhoneNumber,
                doctor.Specialty,
                doctor.Office,
                doctor.Schedule
            });

            return result > 0;
        }
    }
}
