using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento> GetDepartamentoByIdAsync(Guid id);
        Task<Departamento> PostDepartamentoAsync(Departamento departamento);
        Task<Departamento> PutDepartamentoAsync(Guid id, Departamento departamento);
        Task DeleteDepartamentoAsync(Guid id);
        Task<bool> ExisteDepartamento(Guid id);
    }
}
