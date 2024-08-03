using AutoMapper;
using EmployeeManagementAPI.ApiResponse;
using EmployeeManagementAPI.Dtos;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.Implementations;
using EmployeeManagementAPI.Repositories.Interfaces;
using EmployeeManagementAPI.Services.Interfaces;

namespace EmployeeManagementAPI.Services.Implementations
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMapper _mapper;

        public DepartamentoService(IDepartamentoRepository departamentoRepository, IMapper mapper)
        {
            _departamentoRepository = departamentoRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Departamento>> DeleteDepartamentoAsync(Guid id)
        {
            BaseResponse<Departamento> response = new BaseResponse<Departamento>();

            if (await _departamentoRepository.ExisteDepartamento(id))
            {
                response.Success = true;
                response.Data = await _departamentoRepository.GetDepartamentoByIdAsync(id);
                response.Message = "Se ha borrado el departamento";
                await _departamentoRepository.DeleteDepartamentoAsync(id);
            }
            else
            {
                response.Success = false;
                response.Message = "El departamento no existe en la base de datos.";
            }

            return response;
        }

        public async Task<BaseResponse<List<Departamento>>> GetAllDepartamentosAsync()
        {
            BaseResponse<List<Departamento>> response = new BaseResponse<List<Departamento>>();

            var lDepartamentos = await _departamentoRepository.GetAllDepartamentosAsync();
            if (lDepartamentos != null)
            {
                response.Success = true;
                response.Data = lDepartamentos;
            }
            else
            {
                response.Success = false;
                response.Message = "No existen departamentos cargados en la base de datos.";
            }
            return response;
        }

        public async Task<BaseResponse<Departamento>> GetDepartamentoByIdAsync(Guid id)
        {
            BaseResponse<Departamento> response = new BaseResponse<Departamento>();

            var departamento = await _departamentoRepository.GetDepartamentoByIdAsync(id);
            if (departamento != null)
            {
                response.Success = true;
                response.Data = departamento;
            }
            else
            {
                response.Success = false;
                response.Message = "No se encontró el departamento";
            }
            return response;
        }

        public async Task<BaseResponse<DepartamentoDto>> PostDepartamentoAsync(DepartamentoDto departamentoDto)
        {
            BaseResponse<DepartamentoDto> response = new BaseResponse<DepartamentoDto>();

            var departamento = _mapper.Map<Departamento>(departamentoDto);
            departamento.Id = Guid.NewGuid();

            await _departamentoRepository.PostDepartamentoAsync(departamento);

            if (await _departamentoRepository.ExisteDepartamento(departamento.Id))
            {
                response.Success = true;
                response.Data = departamentoDto;
            } else
            {
                response.Success = false;
                response.Message = "No se ha podido crear el departamento";
            }

            return response;
        }

        public async Task<BaseResponse<Departamento>> PutDepartamentoAsync(Guid id, DepartamentoDto departamentoDto)
        {
            BaseResponse<Departamento> response = new BaseResponse<Departamento>();

            if (!await _departamentoRepository.ExisteDepartamento(id))
            {
                response.Success = false;
                response.Message = "El id ingresado no existe en la base de datos";
            } else
            {
                response.Success = true;

                var departamento = _mapper.Map<Departamento>(departamentoDto);
                response.Data = departamento;

                await _departamentoRepository.PutDepartamentoAsync(id, departamento);

                response.Message = "Se modificó el departamento.";
            }

            return response;
        }
    }
}
