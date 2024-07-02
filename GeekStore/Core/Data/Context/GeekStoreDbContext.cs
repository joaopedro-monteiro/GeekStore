using GeekStore.Core.Data.EntityConfig;
using GeekStore.Pages.Clientes.Models;
using GeekStore.Pages.Produtos.Infraestrutura.Models;
using GeekStore.Pages.Venda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Core.Data.Context
{
    public class GeekStoreDbContext : IdentityDbContext
    {
        public DbSet<Clientes> Clientes => Set<Clientes>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
        public DbSet<Produtos> Produtos => Set<Produtos>();
        public DbSet<Jogos> Jogos => Set<Jogos>();
        public DbSet<Acessorios> Acessorios => Set<Acessorios>();
        public DbSet<Venda> Vendas => Set<Venda>();
        public DbSet<VendaInfo> VendasInfo => Set<VendaInfo>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(
                "Server=localhost;Database=GeekStore;User Id=sa;Password=ef66b58b-6ff2-4c78-bcec-6b279312b625;TrustServerCertificate=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UsuariosEntityConfig());
            modelBuilder.ApplyConfiguration(new ClientesEntityConfig());
            modelBuilder.ApplyConfiguration(new ProdutosEntityConfig());
            modelBuilder.ApplyConfiguration(new JogosEntityConfig());
            modelBuilder.ApplyConfiguration(new AcessoriosEntityConfig());
            modelBuilder.ApplyConfiguration(new VendasInfoEntityConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
