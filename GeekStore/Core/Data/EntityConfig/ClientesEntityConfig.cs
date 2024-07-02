using GeekStore.Pages.Clientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekStore.Core.Data.EntityConfig
{
    public class ClientesEntityConfig : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasOne(e => e.Endereco).WithMany().HasForeignKey(x => x.EnderecoId);
        }
    }
}
