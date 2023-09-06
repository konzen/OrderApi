namespace Order.Entity
{
    public class Convenio : Entity
    {
        public int ProdutoId { get; set; }

        public long NumeroAutorizacao { get; set; }

        public virtual Produto? Produto { get; set; }
    }

    public static class ConvenioExt
    {
        public static Convenio? ToEntity(this Model.Convenio? model)
        {
            if (model == null) return null;

            return new Convenio
            {
                NumeroAutorizacao = model.NumeroAutorizacao.GetValueOrDefault()
            };
        }
    }
}
