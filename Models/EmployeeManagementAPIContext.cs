using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeManagementAPIContext : DbContext
    {
        public EmployeeManagementAPIContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

    }
}
