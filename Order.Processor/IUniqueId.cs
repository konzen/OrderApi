namespace Order.Processor
{
    /// <summary>
    /// Obtém um ID único
    /// </summary>
    public interface IUniqueId : IDisposable
    {
        long GetId();
    }
}
