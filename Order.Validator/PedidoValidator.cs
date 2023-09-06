using DocumentValidator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Order.Config;
using Order.Model;

namespace Order.Validator
{
    public sealed class PedidoValidator : BaseValidator<Pedido>
    {
        public PedidoValidator(
            IAppConfig config,
            IValidator<Cliente?> clienteValidator,
            IValidator<Endereco?> enderecoValidator,
            IValidator<Produto?> produtoValidator,
            IValidator<Pagamento?> pagamentoValidator)
        {
            RuleFor(x => x.ResponsavelCadastro).NotNull().Length(1, 16);
            RuleFor(x => x.NumeroPedido).Equal(0L).When(x => x.NumeroPedido != null);
            RuleFor(x => x.NumeroPedidoCliente).NotNull().Length(1, 16);
            RuleFor(x => x.ValorTaxaEntrega).NotNull().InclusiveBetween(0.00, 999.99);
            RuleFor(x => x.TipoEntrega).NotNull().Length(1).Matches(@"^[RYZ]$").WithMessage(invalidValue);
            RuleFor(x => x.TipoRetiradaLoja).NotNull().InclusiveBetween(0, 2);
            RuleFor(x => x.PedidoLoja).NotNull();
            RuleFor(x => x.CodigoFilial).NotNull().InclusiveBetween(1, 999);
            RuleFor(x => x.PedidoSuperVendedor).NotNull();
            RuleFor(x => x.OrigemPedido).NotNull().Length(1).Matches(@"^[SYZ]$").WithMessage(invalidValue);
            RuleFor(x => x.PedidoMarketplace).NotNull();
            RuleFor(x => x.CodigoFilialGerencial).Length(0, 16);
            RuleFor(x => x.CodigoFilialAraujoTEM).Length(0, 16);
            RuleFor(x => x.Fase).Equal("atendido");
            RuleFor(x => x.Ddd).NotNull().Length(2).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.Telefone).NotNull().Length(8, 9).Matches(digits).WithMessage(invalidValue);
            RuleFor(x => x.DataCadastro).NotNull().Matches(dateTimeExpression);
            RuleFor(x => x.DataCadastroAsDateTime).InclusiveBetween(config.MinimumDate, DateTime.Now).OverridePropertyName(x => x.DataCadastro);
            RuleFor(x => x.DataEntregaInicial).NotNull().Matches(dateTimeExpression);
            RuleFor(x => x.DataEntregaInicialAsDateTime).GreaterThanOrEqualTo(x => x.DataCadastroAsDateTime)
                .LessThanOrEqualTo(x => x.DataCadastroAsDateTime + config.MaximumDeliveryTime)
                .When(x => x.DataCadastroAsDateTime != null)
                .OverridePropertyName(x => x.DataEntregaInicial);
            RuleFor(x => x.DataEntregaFinal).NotNull().Matches(dateTimeExpression);
            RuleFor(x => x.DataEntregaFinalAsDateTime).GreaterThanOrEqualTo(x => x.DataEntregaInicialAsDateTime)
                .LessThanOrEqualTo(x => x.DataCadastroAsDateTime + config.MaximumDeliveryTime)
                .When(x => x.DataCadastroAsDateTime != null && x.DataEntregaInicialAsDateTime != null)
                .OverridePropertyName(x => x.DataEntregaFinal);
            RuleFor(x => x.TipoHorarioEntrega).NotNull().Length(1).Matches(@"^[ABC]$").WithMessage(invalidValue);
            RuleFor(x => x.NumeroPedidoLote).NotNull().Length(1, 16).When(x => !string.IsNullOrEmpty(x.NumeroPedidoLote));
            RuleFor(x => x.CanalPedido).NotNull().Length(1).Matches(@"^[SXY]$").WithMessage(invalidValue);
            RuleFor(x => x.Cliente).NotNull().SetValidator(clienteValidator);
            RuleFor(x => x.Cliente!.InscricaoEstadual).Cascade(CascadeMode.Stop)
                .Matches(digits)
                .WithMessage(invalidValue)
                .Must((p, i) => InscricaoEstadualValidation.Validate(i, p.EnderecoCliente!.Estado))
                .WithMessage(invalidValue)
                .When(x => x.Cliente?.InscricaoEstadual != null && x.EnderecoCliente?.Estado != null);
            RuleFor(x => x.EnderecoCliente).NotNull().SetValidator(enderecoValidator);
            RuleFor(x => x.EnderecoEntrega).NotNull().SetValidator(enderecoValidator);
            RuleFor(x => x.Produtos).Cascade(CascadeMode.Stop).NotNull().Must(x => x?.Count > 0).WithMessage("'{PropertyName}' não pode ficar vazio.");
            RuleForEach(x => x.Produtos).NotNull().SetValidator(produtoValidator);
            RuleFor(x => x.Pagamento).Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(x => x?.CountNotNull() == 1)
                .WithMessage("'{PropertyName}' só pode ter um preenchido.")
                .SetValidator(pagamentoValidator);
        }
    }
}
