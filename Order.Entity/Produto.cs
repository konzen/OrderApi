namespace Order.Entity
{
    public class Produto : Entity
    {
        public int PedidoId { get; set; }

        public int CodigoProduto { get; set; }
        public string CodigoBarrasProduto { get; set; } = string.Empty;
        public int QuantidadeItem { get; set; }
        public int Vendedor { get; set; }
        public double PrecoUnitario { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoPromocional { get; set; }
        public double PrecoTotalSemDesconto { get; set; }
        public string Separador { get; set; } = string.Empty;
        public string SiglaUnidade { get; set; } = string.Empty;
        public bool ProdutoControlado { get; set; }

        public virtual Pbm? Pbm { get; set; }
        public virtual Convenio? Convenio { get; set; }
        public virtual KitVirtual? KitVirtual { get; set; }
        public virtual VencimentoCurto? VencimentoCurto { get; set; }
        public virtual Receita? Receita { get; set; }
        public virtual Pedido? Pedido { get; set; }
    }

    public static class ProdutoExt
    {
        public static Produto ToEntity(this Model.Produto model)
        {
            return new Produto
            {
                CodigoProduto = model.CodigoProduto.GetValueOrDefault(),
                CodigoBarrasProduto = model.CodigoBarrasProduto!,
                QuantidadeItem = model.QuantidadeItem.GetValueOrDefault(),
                Vendedor = model.Vendedor.GetValueOrDefault(),
                PrecoUnitario = model.PrecoUnitario.GetValueOrDefault(),
                PrecoVenda = model.PrecoVenda.GetValueOrDefault(),
                PrecoPromocional = model.PrecoPromocional.GetValueOrDefault(),
                PrecoTotalSemDesconto = model.PrecoTotalSemDesconto.GetValueOrDefault(),
                Separador = model.Separador!,
                SiglaUnidade = model.SiglaUnidade!,
                ProdutoControlado = model.ProdutoControlado.GetValueOrDefault(),
                //Pbm = model.Pbm.ToEntity(),
                Convenio = model.Convenio.ToEntity(),
                //KitVirtual = model.KitVirtual.ToEntity(),
                //VencimentoCurto = model.VencimentoCurto.ToEntity(),
                //Receita = model.Receita.ToEntity()
            };
        }

        public static List<Produto> ToEntity(this List<Model.Produto> models) => new List<Produto>(models.Select(ProdutoExt.ToEntity));
    }
}
