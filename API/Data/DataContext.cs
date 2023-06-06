using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Logger> Loggers { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .Ignore(a => a.Employee);
            modelBuilder.Entity<Employee>()
                .Ignore(a => a.Assignments)
                .Ignore(a => a.Manager)
                .Ignore(a => a.Loggers);
        }
    }
}