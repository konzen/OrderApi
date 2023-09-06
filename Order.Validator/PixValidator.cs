using FluentValidation;
using Order.Config;
using Order.Model;

namespace Order.Validator
{
    public sealed class PixValidator : BaseValidator<Pix>
    {
        public PixValidator(IAppConfig config)
        {
            RuleFor(x => x.Valor).NotNull().InclusiveBetween(0.00, 999999.99);
            RuleFor(x => x.DataPagamento).NotNull().Matches(dateTimeExpression);
            RuleFor(x => x.DataPagamentoAsDateTime).InclusiveBetween(config.MinimumDate, DateTime.Now).OverridePropertyName(x => x.DataPagamento);
            RuleFor(x => x.NSU).NotNull().Length(1, 8).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.IdentificadorTransação).NotNull().Length(8, 16).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.IdentificadorPagamento).NotNull().Length(32).Matches(digitsHex).WithMessage(invalidValue);
            RuleFor(x => x.IdentificadorTransação).NotNull().Length(4, 32);
        }
    }
}
