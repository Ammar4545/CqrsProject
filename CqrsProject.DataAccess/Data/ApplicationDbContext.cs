using CqrsProject.Entities.Dbset;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements   { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Achievement>(e =>
            {
                e.HasOne(d => d.Driver)
                .WithMany(d => d.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Driver");
            });
        }
    }
}
