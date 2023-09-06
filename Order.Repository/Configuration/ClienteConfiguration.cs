using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Entity;

namespace Order.Repository.Configuration
{
    public class ClienteConfiguration : Configuration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.NomeCliente).IsRequired().HasMaxLength(128);
            builder.Property(p => p.CpfCnpjCliente).IsRequired().HasMaxLength(14);
            builder.Property(p => p.TipoPessoa).IsRequired().HasMaxLength(1);
            builder.Property(p => p.Sexo).IsRequired().HasMaxLength(1);
            builder.Property(p => p.InscricaoEstadual).HasMaxLength(32);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Ddd).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Telefone).IsRequired().HasMaxLength(9);
            builder.Property(p => p.ContribuinteICMS).HasMaxLength(16);
            builder.Property(p => p.OpcaoRetencaoPessoaJuridica).HasMaxLength(1);

            builder.Reference(x => x.Endereco, x => x.Clientes, x => x.EnderecoId);

            builder.HasIndex(p => p.CpfCnpjCliente).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();

            base.Configure(builder);
        }
    }
}
