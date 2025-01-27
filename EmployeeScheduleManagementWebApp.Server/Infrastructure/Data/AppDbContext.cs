using EmployeeScheduleManagementWebApp.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduleManagementWebApp.Server.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
