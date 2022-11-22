namespace MedicalApp.Data.Repositories
{
    using Dapper;
    using MedicalApp.Domain.MedicalApp.Models;
    using MySql.Data.MySqlClient;

    public class RecordRepository : IRecordRepository
    {
        private readonly MySQLConfiguration _connectionsString;

        public RecordRepository(MySQLConfiguration mySQLConfiguration)
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

            var sql = @"DELETE FROM records WHERE id = @id";

            await db.ExecuteAsync(sql, new { id = id });
        }

        public async Task<IEnumerable<Record>> GetAll()
        {
            var db = DbConection();

            var sql = @"SELECT id, description, creationDate, medicalExams, specialty FROM records";

            return await db.QueryAsync<Record>(sql, new { });
        }

        public async Task<Record> GetById(int id)
        {
            var db = DbConection();

            var sql = @"SELECT id, description, creationDate, medicalExams, specialty FROM records
                        WHERE id = @id";

            return await db.QueryFirstOrDefaultAsync<Record>(sql, new { Id = id });
        }

        public async Task<bool> Insert(Record record)
        {
            var db = DbConection();

            var sql = @"INSERT INTO records (id, description, creationDate, medicalExams, specialty) 
                        VALUES (@Id, @Description, @CreationDate, @MedicalExams, @Specialty)";

            var result = await db.ExecuteAsync(sql, new
            {
                record.Id,
                record.Description,
                record.CreationDate,
                record.MedicalExams,
                record.Specialty
            });

            return result > 0;
        }

        public async Task<bool> Update(Record record)
        {
            var db = DbConection();

            var sql = @"UPDATE records SET id = @Id,
                                            description = @Description,
                                            creationDate = @CreationDate,
                                            medicalExams = @MedicalExams,
                                            specialty = @Specialty,
                                            office = @Office,
                                            schedule = @Schedule
                      WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new
            {
                record.Id,
                record.Description,
                record.CreationDate,
                record.MedicalExams,
                record.Specialty
            });

            return result > 0;
        }
    }
}
