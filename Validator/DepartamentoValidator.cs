using EmployeeManagementAPI.Models;
using FluentValidation;

namespace EmployeeManagementAPI.Validator
{
    public class DepartamentoValidator : AbstractValidator<Departamento>
    {
        public DepartamentoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
        }
    }
}
