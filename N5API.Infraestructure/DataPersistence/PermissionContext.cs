using Microsoft.EntityFrameworkCore;
using N5API.Domain.Entities;
using N5API.Infraestructure.Data.Seed;

namespace N5API.Infraestructure.DataPersistence
{
    public class PermissionContext : DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>()
                .HasData(PermissionDataSeed.GetPermissionsType());

            modelBuilder.Entity<Permission>()
                .HasData(PermissionDataSeed.GetPermission());
        }
    }
}
