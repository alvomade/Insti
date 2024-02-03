using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Insti.Modules.Admin;
using Insti.Modules.Institution;
using Insti.Modules.AdminInstitution;
namespace Insti.Context
{
    public class InstiDb:DbContext
    {
        public InstiDb(DbContextOptions<InstiDb>options):base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Your entity configurations using modelBuilder go here

            modelBuilder.Entity<AdminModel>()
                .Property(aModel => aModel.createdAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<AdminModel>()
                .Property(aModel => aModel.updatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate(); // Optional, sets value on update

            modelBuilder.Entity<InstitutionModel>()
                .Property(iModel => iModel.createdAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<InstitutionModel>()
                .Property(iModel => iModel.updatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }

        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<InstitutionModel> Institutions { get; set; }
        public DbSet<AdminInstitutionModel> AdminInstitutions { get; set; }

    }
}
