namespace Order.Entity
{
    public class Deposito : Entity
    {
        public int PagamentoId { get; set; }

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class DepositoExt
    {
        public static Deposito? ToEntity(this Model.Deposito? model)
        {
            if (model == null) return null;

            return new Deposito();
        }
    }
}
