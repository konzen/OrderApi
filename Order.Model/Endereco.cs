using System.ComponentModel.DataAnnotations;

namespace Order.Model
{
    /// <summary>
    /// DataAnnotations usadas para expecificações OpenAPI. Validações são feitas com FluentValidation
    /// </summary>
    public sealed class Endereco
    {
        [Required]
        [StringLength(128, MinimumLength = 4)]
        public string? Logradouro { get; set; }

        [StringLength(16)]
        public string? Complemento { get; set; }

        // A especificação não suporta por exemplo Nº 307B
        [Required]
        [Range(1, 999999999)]
        public int Numero { get; set; }

        [StringLength(32)]
        public string? Bairro { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string? CodigoPostal { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string? Estado { get; set; }
    }
}
