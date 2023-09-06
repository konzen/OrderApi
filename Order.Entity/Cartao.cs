namespace Order.Entity
{
    public class Cartao : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class CartaoExt
    {
        public static Cartao? ToEntity(this Model.Cartao? model)
        {
            if (model == null) return null;

            return new Cartao();
        }
    }
}
