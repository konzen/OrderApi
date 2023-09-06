using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class EnderecoConfiguration : Configuration<Endereco>
    {
        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(p => p.Logradouro).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Complemento).HasMaxLength(16);
            builder.Property(p => p.Bairro).HasMaxLength(32);
            builder.Property(p => p.CodigoPostal).IsRequired().HasMaxLength(8);
            builder.Property(p => p.Cidade).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Estado).IsRequired().HasMaxLength(2);

            base.Configure(builder);
        }
    }
}
