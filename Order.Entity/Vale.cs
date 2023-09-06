namespace Order.Entity
{
    public class Vale : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class ValeExt
    {
        public static Vale? ToEntity(this Model.Vale? model)
        {
            if (model == null) return null;

            return new Vale();
        }
    }
}
