using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class VencimentoCurtoValidator : BaseValidator<VencimentoCurto>
    {
        public VencimentoCurtoValidator()
        {
            RuleFor(x => x.ValidadeVencimentoCurto).InclusiveBetween(1, 30);
        }
    }
}
