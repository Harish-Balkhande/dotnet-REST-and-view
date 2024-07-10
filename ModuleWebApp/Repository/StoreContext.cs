using Microsoft.EntityFrameworkCore;
using ModuleWebApp.Models;

namespace ModuleWebApp.Repository
{
    public class StoreContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

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
                entity.Property(e => e.name).IsRequired().HasMaxLength(20); ;
                entity.Property(e => e.email).IsRequired().HasMaxLength(20); ;
                entity.Property(e => e.mobile_no).IsRequired().HasMaxLength(20); ;
                entity.Property(e => e.address).IsRequired().HasMaxLength(80); ;
                entity.Property(e => e.admission_date).HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.fees).IsRequired();
                entity.Property(e => e.status).HasColumnType("Enum").HasDefaultValue("Active");

            });
            modelBuilder.Entity<Students>().ToTable("students");
        }



    }
}
