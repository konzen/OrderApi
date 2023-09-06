using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class PagamentoValidator : BaseValidator<Pagamento>
    {
        public PagamentoValidator(IValidator<Pix?> pixValidator)
        {
            //RuleFor(x => x.Cartao).SetValidator(cartaoValidator);
            RuleFor(x => x.Pix).SetValidator(pixValidator);
            //RuleFor(x => x.Cheque).SetValidator(chequeValidator);
            //RuleFor(x => x.Convenio).SetValidator(convenioPagamentoValidator);
            //RuleFor(x => x.Boleto).SetValidator(boletoValidator);
            //RuleFor(x => x.DepositoBancario).SetValidator(depositoValidator);
            //RuleFor(x => x.Vale).SetValidator(valeValidator);
        }
    }
}
