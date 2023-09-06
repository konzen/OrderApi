namespace Order.Entity
{
    public class Boleto : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class BoletoExt
    {
        public static Boleto? ToEntity(this Model.Boleto? model)
        {
            if (model == null) return null;

            return new Boleto();
        }
    }
}
