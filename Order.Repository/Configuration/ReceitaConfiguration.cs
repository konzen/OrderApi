using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ReceitaConfiguration : Configuration<Receita>
    {
        public override void Configure(EntityTypeBuilder<Receita> builder)
        {
            base.Configure(builder);
        }
    }
}
