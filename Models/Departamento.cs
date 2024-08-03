namespace EmployeeManagementAPI.Models
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
