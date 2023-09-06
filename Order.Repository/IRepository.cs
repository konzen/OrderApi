using Order.Entity;

namespace Order.Repository
{
    /// <summary>
    /// Sem async por causa de DbContext
    /// </summary>
    public interface IRepository
    {
        void BeginUpdate();

        void EndUpdate(bool error = false);

        int Sync();

        Pedido Create(Pedido entity);

        Convenio Create(Convenio entity);
    }
}
