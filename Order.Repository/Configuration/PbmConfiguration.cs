using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class PbmConfiguration : Configuration<Pbm>
    {
        public override void Configure(EntityTypeBuilder<Pbm> builder)
        {
            base.Configure(builder);
        }
    }
}
