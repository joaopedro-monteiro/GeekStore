using GeekStore.Pages.Produtos.Infraestrutura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekStore.Core.Data.EntityConfig
{
    public class ProdutosEntityConfig : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.UseTpcMappingStrategy().ToTable("Produtos");
        }
    }
}
