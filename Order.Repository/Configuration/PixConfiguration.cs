using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class PixConfiguration : Configuration<Pix>
    {
        public override void Configure(EntityTypeBuilder<Pix> builder)
        {
            builder.Property(p => p.NSU).IsRequired().HasMaxLength(8);
            builder.Property(p => p.IdentificadorTransação).IsRequired().HasMaxLength(16);
            builder.Property(p => p.IdentificadorPagamento).IsRequired().HasMaxLength(32);
            builder.Property(p => p.OrigemTransacao).IsRequired().HasMaxLength(32);

            builder.HasIndex(p => p.IdentificadorTransação).IsUnique();
            builder.HasIndex(p => p.IdentificadorPagamento).IsUnique();

            base.Configure(builder);
        }
    }
}
