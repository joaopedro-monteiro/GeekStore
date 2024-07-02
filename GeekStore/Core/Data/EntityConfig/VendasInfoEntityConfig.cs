using GeekStore.Pages.Venda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekStore.Core.Data.EntityConfig
{
    public class VendasInfoEntityConfig : IEntityTypeConfiguration<VendaInfo>
    {
        public void Configure(EntityTypeBuilder<VendaInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
