using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class PedidoConfiguration : Configuration<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(p => p.ResponsavelCadastro).IsRequired().HasMaxLength(16);
            builder.Property(p => p.NumeroPedidoCliente).IsRequired().HasMaxLength(16);
            builder.Property(p => p.TipoEntrega).IsRequired().HasMaxLength(1);
            builder.Property(p => p.OrigemPedido).HasMaxLength(1);
            builder.Property(p => p.CodigoFilialGerencial).HasMaxLength(16);
            builder.Property(p => p.CodigoFilialAraujoTEM).HasMaxLength(16);
            builder.Property(p => p.Fase).IsRequired().HasMaxLength(16);
            builder.Property(p => p.Ddd).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Telefone).IsRequired().HasMaxLength(9);
            builder.Property(p => p.TipoHorarioEntrega).IsRequired().HasMaxLength(1);
            builder.Property(p => p.NumeroPedidoLote).HasMaxLength(16);
            builder.Property(p => p.CanalPedido).IsRequired().HasMaxLength(1);

            builder.Reference(x => x.Cliente, x => x.Pedidos, x => x.ClienteId);
            builder.Reference(x => x.EnderecoEntrega, x => x.Pedidos, x => x.EnderecoEntregaId);
            builder.Children(x => x.Produtos, x => x.Pedido, x => x.PedidoId);
            builder.Child(x => x.Pagamento, x => x.Pedido, x => x.PedidoId);

            builder.HasIndex(p => p.NumeroPedidoCliente);

            base.Configure(builder);
        }
    }
}
