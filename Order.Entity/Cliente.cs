namespace Order.Entity
{
    public class Cliente : Entity
    {
        public int EnderecoId { get; set; }

        public string NomeCliente { get; set; } = string.Empty;
        public string CpfCnpjCliente { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public bool? OptanteSimples { get; set; }
        public int? TipoContribuintePessoaJuridica { get; set; }
        public int? RegraRetencaoImpostos { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Ddd { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? ContribuinteICMS { get; set; }
        public string? OpcaoRetencaoPessoaJuridica { get; set; }

        public virtual Endereco? Endereco { get; set; }
        public virtual List<Pedido>? Pedidos { get; set; }
    }

    public static class ClienteExt
    {
        public static Cliente ToEntity(this Model.Cliente model, Model.Endereco modelEnd)
        {
            return new Cliente
            {
                NomeCliente = model.NomeCliente!,
                CpfCnpjCliente = model.CpfCnpjCliente!,
                TipoPessoa = model.TipoPessoa!,
                Sexo = model.Sexo!,
                OptanteSimples = model.OptanteSimples,
                TipoContribuintePessoaJuridica = model.TipoContribuintePessoaJuridica,
                RegraRetencaoImpostos = model.RegraRetencaoImpostos,
                InscricaoEstadual = model.InscricaoEstadual,
                Email = model.Email!,
                Ddd = model.Ddd!,
                Telefone = model.Telefone!,
                ContribuinteICMS = model.ContribuinteICMS,
                OpcaoRetencaoPessoaJuridica = model.OpcaoRetencaoPessoaJuridica,
                Endereco = modelEnd.ToEntity(TipoEndereco.EnderecoCliente)
            };
        }

        public static void Update(this Cliente db, Cliente entity)
        {
            db.NomeCliente = entity.NomeCliente;
            //db.CpfCnpjCliente = entity.CpfCnpjCliente;
            //db.TipoPessoa = entity.TipoPessoa;
            db.Sexo = entity.Sexo;
            db.OptanteSimples = entity.OptanteSimples;
            db.TipoContribuintePessoaJuridica = entity.TipoContribuintePessoaJuridica;
            db.RegraRetencaoImpostos = entity.RegraRetencaoImpostos;
            db.InscricaoEstadual = entity.InscricaoEstadual;
            db.Email = entity.Email;
            db.Ddd = entity.Ddd;
            db.Telefone = entity.Telefone;
            db.ContribuinteICMS = entity.ContribuinteICMS;
            db.OpcaoRetencaoPessoaJuridica = entity.OpcaoRetencaoPessoaJuridica;
            db.Endereco!.Update(entity.Endereco!);
        }
    }
}
