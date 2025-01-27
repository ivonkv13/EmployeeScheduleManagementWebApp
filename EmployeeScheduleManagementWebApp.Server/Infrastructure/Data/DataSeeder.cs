using EmployeeScheduleManagementWebApp.Server.Domain.Entities;

namespace EmployeeScheduleManagementWebApp.Server.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!context.Employees.Any())
                {
                    if (context.Employees.Any() || context.EmployeeRoles.Any())
                        return;

                    var roles = new List<EmployeeRole>
                    {
                        new EmployeeRole { Name = "Manager" },
                        new EmployeeRole { Name = "Chef" },
                        new EmployeeRole { Name = "Bartender" },
                        new EmployeeRole { Name = "Waiter" }
                    };

                    context.EmployeeRoles.AddRange(roles);
                    context.SaveChanges(); // Save roles to ensure they are tracked by EF

                    // Reload roles from the database to ensure they're tracked
                    var managerRole = context.EmployeeRoles.First(r => r.Name == "Manager");
                    var chefRole = context.EmployeeRoles.First(r => r.Name == "Chef");
                    var waiterRole = context.EmployeeRoles.First(r => r.Name == "Waiter");

                    // Seed employees and link to existing roles
                    var employees = new List<Employee>
                    {
                        new Employee
                        {
                            Name = "Max Payne",
                            EmployeeRoles = new List<EmployeeRole> { chefRole },
                            Shifts = new List<Shift>() // Empty shifts
                        },
                        new Employee
                        {
                            Name = "Flash",
                            EmployeeRoles = new List<EmployeeRole> { waiterRole },
                            Shifts = new List<Shift>()
                        },
                        new Employee
                        {
                            Name = "Chicho Adi",
                            EmployeeRoles = new List<EmployeeRole> { managerRole },
                            Shifts = new List<Shift>()
                        }
                    };

                    context.Employees.AddRange(employees);
                    context.SaveChanges();
                };
            }
        }
    }
}
