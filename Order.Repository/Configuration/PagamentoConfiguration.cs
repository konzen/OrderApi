using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class PagamentoConfiguration : Configuration<Pagamento>
    {
        public override void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.Child(x => x.Cartao, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.Pix, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.Cheque, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.Convenio, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.Boleto, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.DepositoBancario, x => x.Pagamento, x => x.PagamentoId);
            builder.Child(x => x.Vale, x => x.Pagamento, x => x.PagamentoId);

            base.Configure(builder);
        }
    }
}
