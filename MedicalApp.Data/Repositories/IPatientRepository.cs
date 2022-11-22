using MedicalApp.Domain.MedicalApp.Models;

namespace MedicalApp.Data.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAll();

        Task<Patient> GetById(int id);

        Task<bool> Insert(Patient patient);

        Task<bool> Update(Patient patient);

        Task Delete(int id);
    }
}
