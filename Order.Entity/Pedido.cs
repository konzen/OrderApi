namespace Order.Entity
{
    public class Pedido : Entity
    {
        public int ClienteId { get; set; }
        public int EnderecoEntregaId { get; set; }

        public string ResponsavelCadastro { get; set; } = string.Empty;
        public long NumeroPedido { get; set; }
        public string NumeroPedidoCliente { get; set; } = string.Empty;
        public double ValorTaxaEntrega { get; set; }
        public string TipoEntrega { get; set; } = string.Empty;
        public int TipoRetiradaLoja { get; set; }
        public bool PedidoLoja { get; set; }
        public int CodigoFilial { get; set; }
        public bool PedidoSuperVendedor { get; set; }
        public string OrigemPedido { get; set; } = string.Empty;
        public bool PedidoMarketplace { get; set; }
        public string? CodigoFilialGerencial { get; set; }
        public string? CodigoFilialAraujoTEM { get; set; }
        public string Fase { get; set; } = string.Empty;
        public string Ddd { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntregaInicial { get; set; }
        public DateTime DataEntregaFinal { get; set; }
        public string TipoHorarioEntrega { get; set; } = string.Empty;
        public string? NumeroPedidoLote { get; set; }
        public string CanalPedido { get; set; } = string.Empty;

        public virtual Cliente? Cliente { get; set; }
        public virtual Endereco? EnderecoEntrega { get; set; }
        public virtual List<Produto>? Produtos { get; set; }
        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class PedidoExt
    {
        public static Pedido ToEntity(this Model.Pedido model)
        {
            return new Pedido
            {
                ResponsavelCadastro = model.ResponsavelCadastro!,
                NumeroPedido = model.NumeroPedido.GetValueOrDefault(),
                NumeroPedidoCliente = model.NumeroPedidoCliente!,
                ValorTaxaEntrega = model.ValorTaxaEntrega.GetValueOrDefault(),
                TipoEntrega = model.TipoEntrega!,
                TipoRetiradaLoja = model.TipoRetiradaLoja.GetValueOrDefault(),
                PedidoLoja = model.PedidoLoja.GetValueOrDefault(),
                CodigoFilial = model.CodigoFilial.GetValueOrDefault(),
                PedidoSuperVendedor = model.PedidoSuperVendedor.GetValueOrDefault(),
                OrigemPedido = model.OrigemPedido!,
                PedidoMarketplace = model.PedidoMarketplace.GetValueOrDefault(),
                CodigoFilialGerencial = model.CodigoFilialGerencial,
                CodigoFilialAraujoTEM = model.CodigoFilialAraujoTEM,
                Fase = model.Fase!,
                Ddd = model.Ddd!,
                Telefone = model.Telefone!,
                DataCadastro = model.DataCadastroAsDateTime.GetValueOrDefault(),
                DataEntregaInicial = model.DataEntregaInicialAsDateTime.GetValueOrDefault(),
                DataEntregaFinal = model.DataEntregaFinalAsDateTime.GetValueOrDefault(),
                TipoHorarioEntrega = model.TipoHorarioEntrega!,
                NumeroPedidoLote = model.NumeroPedidoLote,
                CanalPedido = model.CanalPedido!,
                Cliente = model.Cliente!.ToEntity(model.EnderecoCliente!),
                EnderecoEntrega = model.EnderecoEntrega!.ToEntity(TipoEndereco.EnderecoEntrega),
                Produtos = model.Produtos!.ToEntity(),
                Pagamento = model.Pagamento!.ToEntity()
            };
        }
    }
}
