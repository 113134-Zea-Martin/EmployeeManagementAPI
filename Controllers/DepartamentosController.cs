using EmployeeManagementAPI.Dtos;
using EmployeeManagementAPI.Services.Implementations;
using EmployeeManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamentoAsync([FromRoute] Guid id)
        {
            var response = await _departamentoService.DeleteDepartamentoAsync(id);
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDepartamentosAsync()
        {
            var response = await _departamentoService.GetAllDepartamentosAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamentoByIdAsync([FromRoute] Guid id)
        {
            var response = await _departamentoService.GetDepartamentoByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartamentoAsync([FromBody] DepartamentoDto departamentoDto)
        {
            var response = await _departamentoService.PostDepartamentoAsync(departamentoDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentoAsync([FromRoute] Guid id,[FromBody] DepartamentoDto dto)
        {
            var response = await _departamentoService.PutDepartamentoAsync(id, dto);
            return Ok(response);
        }
    }
}
