using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ChequeConfiguration : Configuration<Cheque>
    {
        public override void Configure(EntityTypeBuilder<Cheque> builder)
        {
            base.Configure(builder);
        }
    }
}
