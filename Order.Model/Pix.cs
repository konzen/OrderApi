using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Order.Model
{
    public sealed class Pix
    {
        [Required]
        [Range(0.00, 999999.99)]
        public double? Valor { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [StringLength(23, MinimumLength = 19)]
        public string? DataPagamento { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public string? NSU { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string? IdentificadorTransação { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string? IdentificadorPagamento { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string? OrigemTransacao { get; set; }

        [JsonIgnore]
        public DateTime? DataPagamentoAsDateTime => DataPagamento.ToDate();
    }
}
