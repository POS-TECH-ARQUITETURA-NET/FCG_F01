using API_FCG_F01.Domain.Validation;

namespace API_FCG_F01.Domain.Entities
{
    public sealed class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string? Email { get; private set; }
        public string SenhaHash { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<BibliotecaJogos> BibliotecaJogos { get; set; } = new List<BibliotecaJogos>();

        public Usuario()
        {            
        }

        public Usuario(string nome, string email, string senhaHash, bool ativo)
        {
            ValidateDomain(nome);
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = ativo;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é requerido");
        }
    }
}
