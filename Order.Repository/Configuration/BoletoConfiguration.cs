using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class BoletoConfiguration : Configuration<Boleto>
    {
        public override void Configure(EntityTypeBuilder<Boleto> builder)
        {
            base.Configure(builder);
        }
    }
}
