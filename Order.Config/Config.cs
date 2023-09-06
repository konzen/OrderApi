using Microsoft.Extensions.Configuration;

namespace Order.Config
{
    public sealed class AppConfig : IAppConfig
    {
        public AppConfig(IConfiguration? configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            MinimumDate = configuration.GetValue("Validacao:DataMinimaValida", new DateTime(2018, 01, 01));
            MaximumDeliveryTime = configuration.GetValue("Validacao:PrazoMaximoEntrega", TimeSpan.FromDays(10));
            NodeId = configuration.GetValue<int?>("Cluster:NodeId", null) ?? throw new InvalidOperationException("ID do nó no cluster não especificado.");
        }

        public DateTime MinimumDate { get; }
        public TimeSpan MaximumDeliveryTime { get; }
        public int NodeId { get; }
    }

    /// <summary>
    /// Fornece as configurações da aplicação
    /// </summary>
    public interface IAppConfig
    {
        /// <summary>
        /// Data mínima permitida
        /// </summary>
        DateTime MinimumDate { get; }

        /// <summary>
        /// Prazo máximo de entrega
        /// </summary>
        TimeSpan MaximumDeliveryTime { get; }

        /// <summary>
        /// ID do nó no cluster
        /// </summary>
        int NodeId { get; }
    }
}
