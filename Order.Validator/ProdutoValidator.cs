using FluentValidation;
using Order.Model;

namespace Order.Validator
{
    public sealed class ProdutoValidator : BaseValidator<Produto>
    {
        public ProdutoValidator(
            IValidator<Pbm?> pbmValidator,
            IValidator<Convenio?> convenioValidator,
            IValidator<KitVirtual?> kitVirtualValidator,
            IValidator<VencimentoCurto?> vencimentoCurtoValidator,
            IValidator<Receita?> receitaValidator)
        {
            RuleFor(x => x.CodigoProduto).NotNull().InclusiveBetween(1, 999999999);
            RuleFor(x => x.CodigoBarrasProduto).NotNull().Length(14).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.QuantidadeItem).NotNull().InclusiveBetween(1, 999);
            RuleFor(x => x.Vendedor).NotNull().InclusiveBetween(1, 999999999);
            RuleFor(x => x.PrecoUnitario).NotNull().InclusiveBetween(0.00, 999999.99);
            RuleFor(x => x.PrecoVenda).NotNull().InclusiveBetween(0.00, 999999.99);
            RuleFor(x => x.PrecoPromocional).NotNull().InclusiveBetween(0.00, 999999.99);
            RuleFor(x => x.PrecoTotalSemDesconto).NotNull().InclusiveBetween(0.00, 999999.99);
            RuleFor(x => x.Separador).NotNull().Length(1, 8).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.SiglaUnidade).NotNull().Length(1, 8);
            RuleFor(x => x.ProdutoControlado).NotNull();
            RuleFor(x => x.Pbm).SetValidator(pbmValidator);
            RuleFor(x => x.Convenio).SetValidator(convenioValidator);
            RuleFor(x => x.KitVirtual).SetValidator(kitVirtualValidator);
            RuleFor(x => x.VencimentoCurto).SetValidator(vencimentoCurtoValidator);
            RuleFor(x => x.Receita).SetValidator(receitaValidator);
        }
    }
}
