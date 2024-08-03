using EmployeeManagementAPI.ApiResponse;
using EmployeeManagementAPI.Dtos;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services.Interfaces
{
    public interface IDepartamentoService
    {
        Task<BaseResponse<List<Departamento>>> GetAllDepartamentosAsync();
        Task<BaseResponse<Departamento>> GetDepartamentoByIdAsync(Guid id);
        Task<BaseResponse<DepartamentoDto>> PostDepartamentoAsync(DepartamentoDto departamentoDto);
        Task<BaseResponse<Departamento>> PutDepartamentoAsync(Guid id, DepartamentoDto departamentoDto);
        Task<BaseResponse<Departamento>> DeleteDepartamentoAsync(Guid id);
    }
}
