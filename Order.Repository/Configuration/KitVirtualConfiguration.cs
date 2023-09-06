using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class KitVirtualConfiguration : Configuration<KitVirtual>
    {
        public override void Configure(EntityTypeBuilder<KitVirtual> builder)
        {
            base.Configure(builder);
        }
    }
}
