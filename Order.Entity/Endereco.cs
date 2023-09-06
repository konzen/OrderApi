namespace Order.Entity
{
    public class Endereco : Entity
    {
        public TipoEndereco Tipo { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string CodigoPostal { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public virtual List<Cliente>? Clientes { get; set; }
        public virtual List<Pedido>? Pedidos { get; set; }
    }

    public static class EnderecoExt
    {
        public static Endereco ToEntity(this Model.Endereco model, TipoEndereco tipo)
        {
            return new Endereco
            {
                Tipo = tipo,
                Logradouro = model.Logradouro!,
                Complemento = model.Complemento,
                Numero = model.Numero,
                Bairro = model.Bairro,
                CodigoPostal = model.CodigoPostal!,
                Cidade = model.Cidade!,
                Estado = model.Estado!,
            };
        }

        public static void Update(this Endereco db, Endereco entity)
        {
            //db.Tipo = entity.Tipo;
            db.Logradouro = entity.Logradouro;
            db.Complemento = entity.Complemento;
            db.Numero = entity.Numero;
            db.Bairro = entity.Bairro;
            db.CodigoPostal = entity.CodigoPostal;
            db.Cidade = entity.Cidade;
            db.Estado = entity.Estado;
        }
    }

    public enum TipoEndereco
    {
        EnderecoCliente,
        EnderecoEntrega
    }
}
