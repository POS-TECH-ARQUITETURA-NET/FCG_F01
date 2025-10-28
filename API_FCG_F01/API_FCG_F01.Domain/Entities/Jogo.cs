namespace API_FCG_F01.Domain.Entities
{
    public sealed class Jogo : EntityBase
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<BibliotecaJogosItem> Bibliotecas { get; private set; } = new List<BibliotecaJogosItem>();

        private Jogo() { }

        public Jogo(string titulo, string descricao, decimal preco)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            Ativo = true;
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public void AtualizarPreco(decimal novoPreco) => Preco = novoPreco;
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
