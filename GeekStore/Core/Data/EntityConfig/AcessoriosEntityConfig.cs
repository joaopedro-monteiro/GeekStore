using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Core.Data.EntityConfig
{
    public class AcessoriosEntityConfig : IEntityTypeConfiguration<Acessorios>
    {
        public void Configure(EntityTypeBuilder<Acessorios> builder)
        {
            builder.ToTable("Acessorios");
        }
    }
}
