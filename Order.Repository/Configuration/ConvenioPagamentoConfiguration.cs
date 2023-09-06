using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ConvenioPagamentoConfiguration : Configuration<ConvenioPagamento>
    {
        public override void Configure(EntityTypeBuilder<ConvenioPagamento> builder)
        {
            base.Configure(builder);
        }
    }
}
