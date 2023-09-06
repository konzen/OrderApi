using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class CartaoConfiguration : Configuration<Cartao>
    {
        public override void Configure(EntityTypeBuilder<Cartao> builder)
        {
            base.Configure(builder);
        }
    }
}
