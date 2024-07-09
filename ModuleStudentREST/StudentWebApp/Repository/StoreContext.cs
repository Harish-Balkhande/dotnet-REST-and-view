using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentWebApp.Entity;
using System.Security.Cryptography.X509Certificates;

namespace StudentWebApp.Repository
{
    public class StoreContext : DbContext
    {
        public DbSet<Students> studContext { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DBurl = @"server=localhost;" +
                "port=3306;" +
                "database=module;" +
                "user=root;" +
                "password=iacsd@123;";
            optionsBuilder.UseMySQL(DBurl);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
            });
            modelBuilder.Entity<Students>().ToTable("students");
        }
    }
}
