namespace Order.Entity
{
    public class Cheque : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class ChequeExt
    {
        public static Cheque? ToEntity(this Model.Cheque? model)
        {
            if (model == null) return null;

            return new Cheque();
        }
    }
}
