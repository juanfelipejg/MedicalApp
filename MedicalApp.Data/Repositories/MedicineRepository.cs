namespace MedicalApp.Data.Repositories
{
    using Dapper;
    using MedicalApp.Domain.MedicalApp.Models;
    using MySql.Data.MySqlClient;

    public class MedicineRepository : IMedicineRepository
    {
        private readonly MySQLConfiguration _connectionsString;

        public MedicineRepository(MySQLConfiguration mySQLConfiguration)
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

            var sql = @"DELETE FROM medicines WHERE identification = @id";

            await db.ExecuteAsync(sql, new { id = id });
        }

        public async Task<IEnumerable<Medicine>> GetAll()
        {
            var db = DbConection();

            var sql = @"SELECT id, name, uses, availablePlaces, price, presentations FROM medicines";

            return await db.QueryAsync<Medicine>(sql, new { });
        }

        public async Task<Medicine> GetById(int id)
        {
            var db = DbConection();

            var sql = @"SELECT id, name, uses, availablePlaces, price, presentations FROM medicines
                        WHERE id = @id";

            return await db.QueryFirstOrDefaultAsync<Medicine>(sql, new { Id = id });
        }

        public async Task<bool> Insert(Medicine medicine)
        {
            var db = DbConection();

            var sql = @"INSERT INTO medicines (id, name, uses, availablePlaces, price, presentations) 
                        VALUES (@Id, @Name, @Uses, @AvailablePlaces, @Price, @Presentations)";

            var result = await db.ExecuteAsync(sql, new
            {
                medicine.Id,
                medicine.Name,
                medicine.Uses,
                medicine.AvailablePlaces,
                medicine.Price ,
                medicine.Presentations
            });

            return result > 0;
        }

        public async Task<bool> Update(Medicine medicine)
        {
            var db = DbConection();

            var sql = @"UPDATE medicines SET id = @Id,
                                            name = @Name,
                                            uses = @Uses,
                                            availablePlaces = @AvailablePlaces,
                                            price = @Price,
                                            presentations = @Presentations
                      WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new
            {
                medicine.Id,
                medicine.Name,
                medicine.Uses,
                medicine.AvailablePlaces,
                medicine.Price,
                medicine.Presentations
            });

            return result > 0;
        }
    }
}
