using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Order.Model
{
    /// <summary>
    /// DataAnnotations usadas para expecificações OpenAPI. Validações são feitas com FluentValidation
    /// </summary>
    public sealed class Pedido
    {
        private string? fase;

        [Required]
        [StringLength(16, MinimumLength = 1)]
        public string? ResponsavelCadastro { get; set; }

        public long? NumeroPedido { get; set; } // Nullable<> - opcional

        [Required]
        [StringLength(16, MinimumLength = 1)]
        public string? NumeroPedidoCliente { get; set; }

        [Required]
        [Range(0.00, 999.99)]
        public double? ValorTaxaEntrega { get; set; } // Nullable<> - Força obrigatoriedade na requisição

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? TipoEntrega { get; set; }

        [Required]
        [Range(0, 2)]
        public int? TipoRetiradaLoja { get; set; }

        [Required]
        public bool? PedidoLoja { get; set; }

        [Required]
        [Range(1, 999)]
        public int? CodigoFilial { get; set; }

        [Required]
        public bool? PedidoSuperVendedor { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? OrigemPedido { get; set; }

        [Required]
        public bool? PedidoMarketplace { get; set; }

        [StringLength(16)]
        public string? CodigoFilialGerencial { get; set; }

        [StringLength(16)]
        public string? CodigoFilialAraujoTEM { get; set; }

        [Required]
        [StringLength(16)]
        public string? Fase { get => fase; set => fase = value?.ToLowerInvariant(); }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string? Ddd { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string? Telefone { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [StringLength(23, MinimumLength = 19)]
        public string? DataCadastro { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [StringLength(23, MinimumLength = 19)]
        public string? DataEntregaInicial { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [StringLength(23, MinimumLength = 19)]
        public string? DataEntregaFinal { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? TipoHorarioEntrega { get; set; }

        [StringLength(16)]
        public string? NumeroPedidoLote { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? CanalPedido { get; set; }

        [Required]
        public Cliente? Cliente { get; set; }

        [Required]
        public Endereco? EnderecoCliente { get; set; }

        [Required]
        public Endereco? EnderecoEntrega { get; set; }

        [Required]
        public List<Produto>? Produtos { get; set; }

        [Required]
        public Pagamento? Pagamento { get; set; }

        [JsonIgnore]
        public DateTime? DataCadastroAsDateTime => DataCadastro.ToDate();

        [JsonIgnore]
        public DateTime? DataEntregaInicialAsDateTime => DataEntregaInicial.ToDate();

        [JsonIgnore]
        public DateTime? DataEntregaFinalAsDateTime => DataEntregaFinal.ToDate();
    }
}
