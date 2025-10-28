using API_FCG_F01.Domain.Validation;

namespace API_FCG_F01.Domain.Entities
{
    public sealed class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string? Email { get; private set; }
        public string Senha { get; private set; }
        public bool IsAdministrador { get; private set; }
        public bool Ativo { get; private set; }
        public BibliotecaJogos? Biblioteca { get; private set; }

        private Usuario() { }

        public Usuario(string nome, string? email, string senhaHash, bool isAdministrador)
        {            
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException( nameof(email));
            Senha = senhaHash ?? throw new ArgumentNullException(nameof(senhaHash));
            IsAdministrador = isAdministrador;
            Ativo = true;
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarNome(string novoNome) => Nome = novoNome ?? throw new ArgumentNullException(nameof(novoNome));
        public void AlterarEmail(string? novoEmail) => Email = novoEmail;
        public void AlterarSenhaHash(string novoHash) => Senha = novoHash ?? throw new ArgumentNullException(nameof(novoHash));
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome invalido. Nome é requerido");
        }
    }
}
