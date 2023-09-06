using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Order.Entity;
using Order.Model;
using Order.Repository;
using System.Net;

namespace Order.Processor
{
    public sealed class ProcessorPedido : IProcessor<Model.Pedido>
    {
        private readonly IValidator<Model.Pedido> validator;
        private readonly IUniqueId uniqueId;
        private readonly IServiceProvider serviceProvider;

        public ProcessorPedido(IValidator<Model.Pedido> validator, IUniqueId uniqueId, IServiceProvider serviceProvider)
        {
            this.validator = validator;
            this.uniqueId = uniqueId;
            this.serviceProvider = serviceProvider;
        }

        public async Task<IResult> ProcessAsync(Model.Pedido pedido)
        {
            pedido.Pagamento?.EntryToNull();

            pedido.Produtos?.ForEach(p =>
            {
                if (p.Convenio.IsEmpty()) p.Convenio = null;
            });

            var validationResult = await validator.ValidateAsync(pedido);

            if (!validationResult.IsValid)
            {
                // A especificação pede 413 (RequestEntityTooLarge), não acredito que esteja correto
                // 400 (BadRequest) seria melhor que 413 no meu ver, mas muito genérico
                // 422 (UnprocessableEntity) parece mais adequado
                return Results.ValidationProblem(validationResult.ToDictionary(), statusCode: (int)HttpStatusCode.RequestEntityTooLarge);
            }

            var id = uniqueId.GetId();
            pedido.NumeroPedido = id;

            ProcessContinue(serviceProvider, pedido);

            return Results.Created(string.Empty, id);
        }

        private static void ProcessContinue(IServiceProvider serviceProvider, Model.Pedido pedido)
        {
            var scope = serviceProvider.CreateScope();

            Task.Run(() =>
            {
                try
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IRepository>();

                    var entity = repository.Create(pedido.ToEntity());

                    if (entity.PedidoMarketplace)
                    {
                        ProcessMarketplace(scope, entity);
                    }
                    else
                    {
                        if (entity.Pagamento!.Cartao != null)
                        {
                            ProcessCredcard(scope, entity);
                        }
                    }
                }
                catch (Exception)
                {
                    // Implementar
                }
                finally
                {
                    scope.Dispose();
                }
            });
        }

        private static void ProcessMarketplace(IServiceScope scope, Entity.Pedido entity)
        {
            var uniqueId = scope.ServiceProvider.GetRequiredService<IUniqueId>();
            var repository = scope.ServiceProvider.GetRequiredService<IRepository>();

            repository.BeginUpdate();

            try
            {
                entity.Produtos!.ForEach(p =>
                {
                    p.Convenio = repository.Create(new Entity.Convenio
                    {
                        ProdutoId = p.Id,
                        NumeroAutorizacao = uniqueId.GetId()
                    });
                });

                entity.Fase = "marketplace";

                repository.Sync();

                repository.EndUpdate();
            }
            catch (Exception)
            {
                repository.EndUpdate(true);

                // Trantar erro
            }

            PostToWebHook(scope, entity);
        }

        private static void PostToWebHook(IServiceScope scope, Entity.Pedido entity)
        {
            // Implementar
        }

        private static void ProcessCredcard(IServiceScope scope, Entity.Pedido entity)
        {
            // Implementar
        }
    }
}
