using System.ComponentModel.DataAnnotations;

namespace Order.Model
{
    /// <summary>
    /// DataAnnotations usadas para expecificações OpenAPI. Validações são feitas com FluentValidation
    /// </summary>
    public sealed class Produto
    {
        [Required]
        [Range(1, 999999999)]
        public int? CodigoProduto { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string? CodigoBarrasProduto { get; set; }

        [Required]
        [Range(1, 999)]
        public int? QuantidadeItem { get; set; }

        [Required]
        [Range(1, 999999999)]
        public int? Vendedor { get; set; }

        [Required]
        [Range(0.00, 999999.99)]
        public double? PrecoUnitario { get; set; }

        [Required]
        [Range(0.00, 999999.99)]
        public double? PrecoVenda { get; set; }

        [Required]
        [Range(0.00, 999999.99)]
        public double? PrecoPromocional { get; set; }

        [Required]
        [Range(0.00, 999999.99)]
        public double? PrecoTotalSemDesconto { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public string? Separador { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public string? SiglaUnidade { get; set; }

        [Required]
        public bool? ProdutoControlado { get; set; }

        public Pbm? Pbm { get; set; }

        public Convenio? Convenio { get; set; }

        public KitVirtual? KitVirtual { get; set; }

        public VencimentoCurto? VencimentoCurto { get; set; }

        public Receita? Receita { get; set; }
    }
}
