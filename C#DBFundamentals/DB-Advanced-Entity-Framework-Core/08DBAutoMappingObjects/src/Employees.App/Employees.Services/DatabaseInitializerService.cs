using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class DatabaseInitializerService
    {
        private readonly EmployeesDbContext context;

        public DatabaseInitializerService(EmployeesDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.Migrate();
        }
    }
}
