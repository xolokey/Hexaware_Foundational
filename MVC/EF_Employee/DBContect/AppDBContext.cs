using EF_Employee.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_Employee.DBContect
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
