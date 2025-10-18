namespace API_FCG_F01.Domain.Entities
{
    public sealed class Compra : EntityBase
    {
        public Guid UsuarioId { get; private set; }
        public List<Guid> Jogos { get; private set; }

        public DateTime DataCompra { get; private set; } = DateTime.UtcNow;

        public bool Aprovada { get; private set; }

        public Compra(Guid usuarioId, List<Guid> jogos)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Jogos = jogos;
            DataCriacao = DateTime.UtcNow;
            Aprovada = false;
        }

        public void AprovarCompra() => Aprovada = true;
    }
}
