namespace Order.Entity
{
    public class Pagamento : Entity
    {
        public int PedidoId { get; set; }

        public virtual Cartao? Cartao { get; set; }
        public virtual Pix? Pix { get; set; }
        public virtual Cheque? Cheque { get; set; }
        public virtual ConvenioPagamento? Convenio { get; set; }
        public virtual Boleto? Boleto { get; set; }
        public virtual Deposito? DepositoBancario { get; set; }
        public virtual Vale? Vale { get; set; }
        public virtual Pedido? Pedido { get; set; }
    }

    public static class PagamentoExt
    {
        public static Pagamento ToEntity(this Model.Pagamento model)
        {
            return new Pagamento
            {
                Cartao = model.Cartao.ToEntity(),
                Pix = model.Pix.ToEntity(),
                Cheque = model.Cheque.ToEntity(),
                Convenio = model.Convenio.ToEntity(),
                Boleto = model.Boleto.ToEntity(),
                DepositoBancario = model.DepositoBancario.ToEntity(),
                Vale = model.Vale.ToEntity()
            };
        }
    }
}
