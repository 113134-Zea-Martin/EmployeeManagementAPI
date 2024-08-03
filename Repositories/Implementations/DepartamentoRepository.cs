using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repositories.Implementations
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly EmployeeManagementAPIContext _employeeManagementAPIContext;

        public DepartamentoRepository(EmployeeManagementAPIContext employeeManagementAPIContext)
        {
            _employeeManagementAPIContext = employeeManagementAPIContext;
        }
        public async Task DeleteDepartamentoAsync(Guid id)
        {
            var departamento = await _employeeManagementAPIContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (departamento != null)
            {
                _employeeManagementAPIContext.Departamentos.Remove(departamento);
                await _employeeManagementAPIContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteDepartamento(Guid id)
        {
            var response = await _employeeManagementAPIContext.Departamentos.AnyAsync(x => x.Id == id);
            return response;
        }

        public async Task<List<Departamento>> GetAllDepartamentosAsync()
        {
            var lDepartamentos = await _employeeManagementAPIContext.Departamentos.ToListAsync();
            return lDepartamentos;
        }

        public async Task<Departamento> GetDepartamentoByIdAsync(Guid id)
        {
            var departamento = await _employeeManagementAPIContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            return departamento;
        }

        public async Task<Departamento> PostDepartamentoAsync(Departamento departamento)
        {
            await _employeeManagementAPIContext.Departamentos.AddAsync(departamento);
            await _employeeManagementAPIContext.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> PutDepartamentoAsync(Guid id, Departamento departamento)
        {
            var departamentoAEditar = await _employeeManagementAPIContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
            departamentoAEditar.Name = departamento.Name;
            await _employeeManagementAPIContext.SaveChangesAsync();
            return departamentoAEditar;
        }
    }
}
