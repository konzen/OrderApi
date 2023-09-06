namespace Order.Entity
{
    public class Pix : Entity
    {
        public int PagamentoId { get; set; }

        public double Valor { get; set; }

        public DateTime DataPagamento { get; set; }

        public string NSU { get; set; } = string.Empty;

        public string IdentificadorTransação { get; set; } = string.Empty;

        public string IdentificadorPagamento { get; set; } = string.Empty;

        public string OrigemTransacao { get; set; } = string.Empty;

        public virtual Pagamento? Pagamento { get; set; }
    }

    public static class PixExt
    {
        public static Pix? ToEntity(this Model.Pix? model)
        {
            if (model == null) return null;

            return new Pix
            {
                Valor = model.Valor.GetValueOrDefault(),
                DataPagamento = model.DataPagamentoAsDateTime.GetValueOrDefault(),
                NSU = model.NSU!,
                IdentificadorTransação = model.IdentificadorTransação!,
                IdentificadorPagamento = model.IdentificadorPagamento!,
                OrigemTransacao = model.OrigemTransacao!,
            };
        }
    }
}
