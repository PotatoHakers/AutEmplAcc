using AutEmplAcc.Model;
using Microsoft.EntityFrameworkCore;

namespace AutEmplAcc.Data
{
    public class AutEmplAccContext : DbContext
    {
        public AutEmplAccContext() { }

        public AutEmplAccContext(DbContextOptions<AutEmplAccContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS06;Initial Catalog = EmployeeAccounting; Integrated Security = True; TrustServerCertificate= True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
       .HasOne(e => e.Branch)
       .WithMany(b => b.Employees)
       .HasForeignKey(e => e.BranchId)
       .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
