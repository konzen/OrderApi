using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class ConvenioValidator : BaseValidator<Convenio>
    {
        public ConvenioValidator()
        {
            RuleFor(x => x.NumeroAutorizacao).Null();
        }
    }
}
