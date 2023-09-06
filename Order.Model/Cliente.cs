using System.ComponentModel.DataAnnotations;

namespace Order.Model
{
    /// <summary>
    /// DataAnnotations usadas para expecificações OpenAPI. Validações são feitas com FluentValidation
    /// </summary>
    public sealed class Cliente
    {
        [Required]
        [StringLength(128, MinimumLength = 8)]
        public string? NomeCliente { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string? CpfCnpjCliente { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? TipoPessoa { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string? Sexo { get; set; }

        public bool? OptanteSimples { get; set; } // Nullable<> - opcional

        [Range(1, 4)]
        public int? TipoContribuintePessoaJuridica { get; set; } // Nullable<> - opcional

        [Range(1, 6)]
        public int? RegraRetencaoImpostos { get; set; } // Nullable<> - opcional

        [StringLength(32, MinimumLength = 1)]
        public string? InscricaoEstadual { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 8)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string? Ddd { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string? Telefone { get; set; }

        [StringLength(16)]
        public string? ContribuinteICMS { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string? OpcaoRetencaoPessoaJuridica { get; set; }
    }
}
