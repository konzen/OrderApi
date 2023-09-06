using FluentValidation;
using FluentValidation.Internal;
using Order.Model;
using Order.Validator;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ValidatorExt
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            ValidatorOptions.Global.PropertyNameResolver = PropertyNameResolver;
            ValidatorOptions.Global.MessageFormatterFactory = () => new MessageFormatterPropertyNameFix();

            services.AddScoped<IValidator<Cliente>, ClienteValidator>();
            services.AddScoped<IValidator<Convenio>, ConvenioValidator>();
            services.AddScoped<IValidator<Endereco>, EnderecoValidator>();
            services.AddScoped<IValidator<KitVirtual>, KitVirtualValidator>();
            services.AddScoped<IValidator<Pagamento>, PagamentoValidator>();
            services.AddScoped<IValidator<Pbm>, PbmValidator>();
            services.AddScoped<IValidator<Pedido>, PedidoValidator>();
            services.AddScoped<IValidator<Pix>, PixValidator>();
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            services.AddScoped<IValidator<Receita>, ReceitaValidator>();
            services.AddScoped<IValidator<VencimentoCurto>, VencimentoCurtoValidator>();

            return services;
        }

        public static int CountNotNull<T>(this T? obj) where T : class => (obj == null) ? 0 : typeof(T).GetProperties().Count(p => p.GetValue(obj) != null);

        private static string? PropertyNameResolver(Type type, MemberInfo memberInfo, LambdaExpression expression) =>
            ToCamelCase(DefaultPropertyNameResolver(type, memberInfo, expression));

        private static string? DefaultPropertyNameResolver(Type type, MemberInfo memberInfo, LambdaExpression expression)
        {
            if (expression != null)
            {
                var chain = PropertyChain.FromExpression(expression);
                if (chain.Count > 0) return chain.ToString();
            }

            return memberInfo?.Name;
        }

        private static string? ToCamelCase(string? s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0])) return s;

            var chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i])) break;

                bool hasNext = (i + 1 < chars.Length);

                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1])) break;

                chars[i] = char.ToLowerInvariant(chars[i]);
            }

            return new string(chars);
        }

        private sealed class MessageFormatterPropertyNameFix : MessageFormatter
        {
            public override string BuildMessage(string messageTemplate)
            {
                if (PlaceholderValues.TryGetValue(PropertyName, out var value) && value != null)
                {
                    var name = (string)value;
                    PlaceholderValues[PropertyName] = char.ToUpperInvariant(name[0]) + name.Substring(1);
                }

                return base.BuildMessage(messageTemplate);
            }
        }
    }
}
