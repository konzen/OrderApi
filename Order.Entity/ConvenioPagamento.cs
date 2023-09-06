namespace Order.Entity
{
    public class ConvenioPagamento : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class ConvenioPagamentoExt
    {
        public static ConvenioPagamento? ToEntity(this Model.ConvenioPagamento? model)
        {
            if (model == null) return null;

            return new ConvenioPagamento();
        }
    }
}
