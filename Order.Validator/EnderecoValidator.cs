using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class EnderecoValidator : BaseValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Logradouro).NotNull().Length(4, 128);
            RuleFor(x => x.Complemento).Length(0, 16);
            RuleFor(x => x.Numero).NotNull().InclusiveBetween(1, 999999999);
            RuleFor(x => x.Bairro).Length(0, 32);
            RuleFor(x => x.CodigoPostal).NotNull().Length(8).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.Cidade).NotNull().Length(4, 64);
            RuleFor(x => x.Estado).NotNull()
                .Length(2)
                .Matches("(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)")
                .WithMessage(invalidValue);
        }
    }
}
