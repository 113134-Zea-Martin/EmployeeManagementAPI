using EmployeeManagementAPI.Dtos;
using FluentValidation;

namespace EmployeeManagementAPI.Validator
{
    public class DepartamentoDtoValidator : AbstractValidator<DepartamentoDto>
    {
        public DepartamentoDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
        }
    }
}
