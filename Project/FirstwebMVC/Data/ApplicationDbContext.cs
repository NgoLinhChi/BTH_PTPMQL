using FirstwebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstwebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Person> Person {get; set;}
        public DbSet<Employee> Employee {get; set;}
    }
}