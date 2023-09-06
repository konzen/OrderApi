namespace Order.Entity
{
    public class VencimentoCurto : Entity
    {
        public int ProdutoId { get; set; }

        public int ValidadeVencimentoCurto { get; set; }

        public virtual Produto? Produto { get; set; }
    }
}
