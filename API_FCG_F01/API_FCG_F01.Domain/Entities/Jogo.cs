namespace API_FCG_F01.Domain.Entities
{
    public sealed class Jogo : EntityBase
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }

        public Jogo(string titulo, string descricao, decimal preco, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
