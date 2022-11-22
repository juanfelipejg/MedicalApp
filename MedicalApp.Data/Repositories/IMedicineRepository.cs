using MedicalApp.Domain.MedicalApp.Models;

namespace MedicalApp.Data.Repositories
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAll();

        Task<Medicine> GetById(int id);

        Task<bool> Insert(Medicine medicine);

        Task<bool> Update(Medicine medicine);

        Task Delete(int id);
    }
}
