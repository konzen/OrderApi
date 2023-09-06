namespace Order.Entity
{
    public class Receita : Entity
    {
        public int ProdutoId { get; set; }

        public virtual Produto? Produto { get; set; }
    }
}
