using DocumentValidator;
using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class ClienteValidator : BaseValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.NomeCliente).Length(8, 128);
            RuleFor(x => x.CpfCnpjCliente).Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(11)
                .Matches(digits)
                .WithMessage(invalidValue)
                .Must(x => CpfValidation.Validate(x))
                .WithMessage(invalidValue)
                .When(x => x.TipoPessoa == "F");
            RuleFor(x => x.CpfCnpjCliente).Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(14)
                .Matches(digits)
                .WithMessage(invalidValue)
                .Must(x => CnpjValidation.Validate(x))
                .WithMessage(invalidValue)
                .When(x => x.TipoPessoa == "J");
            RuleFor(x => x.TipoPessoa).NotNull().Length(1).Matches(@"^[FJ]$").WithMessage(invalidValue);
            RuleFor(x => x.Sexo).NotNull().Length(1).Matches(@"^[FM]$").WithMessage(invalidValue);
            RuleFor(x => x.OptanteSimples).NotNull().When(x => x.TipoPessoa == "J");
            RuleFor(x => x.OptanteSimples).Null().When(x => x.TipoPessoa != "J");
            RuleFor(x => x.TipoContribuintePessoaJuridica).NotNull().InclusiveBetween(1, 4).When(x => x.TipoPessoa == "J");
            RuleFor(x => x.TipoContribuintePessoaJuridica).Null().When(x => x.TipoPessoa != "J");
            RuleFor(x => x.RegraRetencaoImpostos).NotNull().InclusiveBetween(1, 6).When(x => x.TipoPessoa == "J");
            RuleFor(x => x.RegraRetencaoImpostos).Null().When(x => x.TipoPessoa != "J");
            RuleFor(x => x.InscricaoEstadual).NotNull().Length(1, 32).When(x => x.TipoPessoa == "J");
            RuleFor(x => x.InscricaoEstadual).Null().When(x => x.TipoPessoa != "J");
            RuleFor(x => x.Email).NotNull().Length(8, 128).EmailAddress();
            RuleFor(x => x.Ddd).NotNull().Length(2).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.Telefone).NotNull().Length(8, 9).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.ContribuinteICMS).NotNull().Length(1, 16).When(x => x.TipoPessoa == "J");
            RuleFor(x => x.ContribuinteICMS).Null().When(x => x.TipoPessoa != "J");
            RuleFor(x => x.OpcaoRetencaoPessoaJuridica).NotNull().Length(1).Matches(@"^[XY]$").WithMessage(invalidValue).When(x => x.TipoPessoa == "J");
            RuleFor(x => x.OpcaoRetencaoPessoaJuridica).Null().When(x => x.TipoPessoa != "J");
        }
    }
}
