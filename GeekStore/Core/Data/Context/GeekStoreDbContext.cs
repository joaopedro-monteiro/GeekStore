using GeekStore.Core.Data.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Core.Data.Context
{
    public class GeekStoreDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                "Server=localhost;Database=GeekStore;User Id=sa;Password=ef66b58b-6ff2-4c78-bcec-6b279312b625;TrustServerCertificate=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UsuariosEntityConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
