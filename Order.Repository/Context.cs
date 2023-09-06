using Microsoft.EntityFrameworkCore;
using Order.Entity;
using Order.Repository.Configuration;

namespace Order.Repository
{
#pragma warning disable CS8618

    public sealed class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Cheque> Cheque { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<ConvenioPagamento> ConvenioPagamento { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<KitVirtual> KitVirtual { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Pbm> Pbm { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pix> Pix { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Vale> Vale { get; set; }
        public DbSet<VencimentoCurto> VencimentoCurto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoletoConfiguration());
            modelBuilder.ApplyConfiguration(new CartaoConfiguration());
            modelBuilder.ApplyConfiguration(new ChequeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ConvenioConfiguration());
            modelBuilder.ApplyConfiguration(new ConvenioPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new DepositoConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new KitVirtualConfiguration());
            modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new PbmConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PixConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());
            modelBuilder.ApplyConfiguration(new ValeConfiguration());
            modelBuilder.ApplyConfiguration(new VencimentoCurtoConfiguration());
        }
    }

#pragma warning restore CS8618
}
