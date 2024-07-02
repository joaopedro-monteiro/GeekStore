using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Core.Data.EntityConfig
{
    public class JogosEntityConfig : IEntityTypeConfiguration<Jogos>
    {
        public void Configure(EntityTypeBuilder<Jogos> builder)
        {
            builder.ToTable("Jogos");
        }
    }
}
