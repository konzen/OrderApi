using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Order.Entity;

namespace Order.Repository
{
    public sealed class Repository : IRepository
    {
        private readonly Context context;

        public Repository(IHostEnvironment environment, Context context)
        {
            this.context = context;

            // Em desenvolvimento cria o banco automaticamente
            if (environment.IsDevelopment()) context.Database.EnsureCreated();
        }

        public void BeginUpdate() => context.Database.BeginTransaction();

        public void EndUpdate(bool error = false)
        {
            if (error)
                context.Database.RollbackTransaction();
            else
                context.Database.CommitTransaction();
        }

        public int Sync() => context.SaveChanges();

        public Pedido Create(Pedido entity)
        {
            context.Database.BeginTransaction();

            try
            {
                entity.Cliente = Save(entity.Cliente!);

                context.Endereco.Add(entity.EnderecoEntrega!);
                context.SaveChanges();

                context.Pedido.Add(entity);
                context.SaveChanges();

                context.Database.CommitTransaction();

                return entity;
            }
            catch
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public Convenio Create(Convenio entity)
        {
            context.Convenio.Add(entity);
            context.SaveChanges();
            return entity;
        }

        private Cliente Save(Cliente cliente)
        {
            var db = context.Cliente.Include(x => x.Endereco).FirstOrDefault(x => x.CpfCnpjCliente == cliente.CpfCnpjCliente);

            if (db != null)
            {
                db.Update(cliente);
            }
            else
            {
                context.Endereco.Add(cliente.Endereco!);
                context.Cliente.Add(db = cliente);
            }

            context.SaveChanges();

            return db;
        }
    }
}
