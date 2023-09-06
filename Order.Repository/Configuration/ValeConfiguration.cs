using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ValeConfiguration : Configuration<Vale>
    {
        public override void Configure(EntityTypeBuilder<Vale> builder)
        {
            base.Configure(builder);
        }
    }
}
