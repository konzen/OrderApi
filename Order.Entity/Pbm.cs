namespace Order.Entity
{
    public class Pbm : Entity
    {
        public int ProdutoId { get; set; }

        public string AutorizacaoPbmGbm { get; set; } = string.Empty;
        public string AutorizadoraPbmGbm { get; set; } = string.Empty;

        public virtual Produto? Produto { get; set; }
    }
}
