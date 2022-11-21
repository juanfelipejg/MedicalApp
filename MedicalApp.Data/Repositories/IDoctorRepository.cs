namespace MedicalApp.Data.Repositories
{
    using MedicalApp.Domain.MedicalApp.Models;

    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAll();

        Task<Doctor> GetById(int id);

        Task<bool> Insert(Doctor player);

        Task<bool> Update(Doctor player);

        Task Delete(int id);
    }
}
