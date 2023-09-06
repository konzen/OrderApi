using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class VencimentoCurtoConfiguration : Configuration<VencimentoCurto>
    {
        public override void Configure(EntityTypeBuilder<VencimentoCurto> builder)
        {
            base.Configure(builder);
        }
    }
}
