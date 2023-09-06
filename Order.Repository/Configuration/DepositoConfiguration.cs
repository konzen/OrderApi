using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class DepositoConfiguration : Configuration<Deposito>
    {
        public override void Configure(EntityTypeBuilder<Deposito> builder)
        {
            base.Configure(builder);
        }
    }
}
