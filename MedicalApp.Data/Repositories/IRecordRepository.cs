using MedicalApp.Domain.MedicalApp.Models;

namespace MedicalApp.Data.Repositories
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAll();

        Task<Record> GetById(int id);

        Task<bool> Insert(Record record);

        Task<bool> Update(Record record);

        Task Delete(int id);
    }
}
