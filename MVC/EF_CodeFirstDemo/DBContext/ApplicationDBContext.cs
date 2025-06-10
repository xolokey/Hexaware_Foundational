using EF_CodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_CodeFirstDemo.DBContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        {

        }
        public DbSet<Department> Departments { get; set; }
    }
}
