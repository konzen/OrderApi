using Microsoft.AspNetCore.Mvc;
using Order.Config;
using Order.Model;
using Order.Processor;
using Order.Repository;
using System.Globalization;

namespace Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Injeções de dependência para o Repositório
            builder.Services.AddRepository(builder.Configuration.GetConnectionString("DefaultConnection"));

            // Injeção de dependência para configuração de API
            builder.Services.AddSingleton<IAppConfig>((provider) => new AppConfig(provider.GetService<IConfiguration>()));

            // Injeções de dependência para os Validadores
            builder.Services.AddValidators();

            // Injeções de dependência para os Processadores
            builder.Services.AddProcessors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options => options.SerializeAsV2 = true);
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Para microsserviços é uma boa solução ao invés do tradicional Controller
            // Usar versão na rota é uma boa prática para permitir a evolução da API sem perder compatibilidade
            app.MapPost("/v1/pedido", async ([FromBody] Pedido pedido, [FromServices] IProcessor<Pedido> process) =>
            {
                return await process.ProcessAsync(pedido);
            })
            .WithName("Pedido");

            app.Run();
        }
    }
}
