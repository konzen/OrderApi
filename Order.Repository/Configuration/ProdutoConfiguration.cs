using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ProdutoConfiguration : Configuration<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.CodigoBarrasProduto).IsRequired().HasMaxLength(14);
            builder.Property(p => p.Separador).IsRequired().HasMaxLength(8);
            builder.Property(p => p.SiglaUnidade).IsRequired().HasMaxLength(8);

            builder.Child(x => x.Pbm, x => x.Produto, x => x.ProdutoId);
            builder.Child(x => x.Convenio, x => x.Produto, x => x.ProdutoId);
            builder.Child(x => x.KitVirtual, x => x.Produto, x => x.ProdutoId);
            builder.Child(x => x.VencimentoCurto, x => x.Produto, x => x.ProdutoId);
            builder.Child(x => x.Receita, x => x.Produto, x => x.ProdutoId);

            base.Configure(builder);

            builder.HasIndex(p => p.CodigoBarrasProduto);
            builder.HasIndex(p => p.Separador);

            base.Configure(builder);
        }
    }
}
