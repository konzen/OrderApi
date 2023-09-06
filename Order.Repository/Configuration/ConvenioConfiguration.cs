using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ConvenioConfiguration : Configuration<Convenio>
    {
        public override void Configure(EntityTypeBuilder<Convenio> builder)
        {
            base.Configure(builder);
        }
    }
}
