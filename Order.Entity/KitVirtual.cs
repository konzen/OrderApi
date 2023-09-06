namespace Order.Entity
{
    public class KitVirtual : Entity
    {
        public int ProdutoId { get; set; }

        public string? CodigoKit { get; set; }
        public int? SequencialKit { get; set; }

        public virtual Produto? Produto { get; set; }
    }
}
