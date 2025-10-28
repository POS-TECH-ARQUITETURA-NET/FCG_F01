
namespace API_FCG_F01.Domain.Entities
{
    public sealed class Compra : EntityBase
    {
        private IEnumerable<Guid> jogos;

        public Guid UsuarioId { get; private set; }
        public List<Guid> Jogos { get; private set; }

        public DateTime DataCompra { get; private set; } = DateTime.UtcNow;

        public bool Aprovada { get; private set; }

        public Compra(Guid usuarioId, List<Guid> jogos)
        {
            UsuarioId = usuarioId;
            Jogos = jogos;
            DataCriacao = DateTime.UtcNow;
            Aprovada = false;
        }

        public Compra(Guid usuarioId, IEnumerable<Guid> jogos)
        {
            UsuarioId = usuarioId;
            this.jogos = jogos;
        }

        public void AprovarCompra() => Aprovada = true;
    }
}
