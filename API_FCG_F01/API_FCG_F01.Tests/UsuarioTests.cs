using API_FCG_F01.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace API_FCG_F01.Tests
{
    public class UsuarioTests
    {
        // Teste 1: Deve falhar ao criar usuário com nome nulo
        [Fact(DisplayName = "Criar Usuário Com Nome Nulo Deve Lançar Exceção")]
        public void CriarUsuario_ComNomeNulo_DeveLancarExcecao()
        {
            // Arrange & Act
            Action action = () => new Usuario(null, "email@teste.com", "senhaHash123", false);

            // Assert
            action.Should().Throw<ArgumentNullException>()
                         .WithMessage("Value cannot be null. (Parameter 'nome')");
        }

        // Teste 2: Deve falhar ao tentar alterar email para um formato inválido (refatoração)
        [Theory(DisplayName = "Alterar Email Com Formato Inválido Deve Lançar Exceção")]
        [InlineData("emailinvalido")]
        [InlineData("@.com")]
        [InlineData("teste@")]
        public void AlterarEmail_ComFormatoInvalido_DeveLancarExcecao(string emailInvalido)
        {
            // Arrange
            var usuario = new Usuario("Teste", "email@valido.com", "senhaHash123", false);

            // Act
            Action action = () => usuario.AlterarEmail(emailInvalido);

            // Assert
            action.Should().Throw<ArgumentException>()
                         .WithMessage("Formato de email inválido");
        }

        // Teste 3: Deve passar ao criar usuário com dados válidos
        [Fact(DisplayName = "Criar Usuário Com Dados Válidos Deve Ser Bem Sucedido")]
        public void CriarUsuario_ComDadosValidos_DeveSerBemSucedido()
        {
            // Arrange
            string nome = "Usuario Teste";
            string email = "teste@email.com";
            string senhaHash = "senhaHash123";
            bool isAdmin = false;

            // Act
            var usuario = new Usuario(nome, email, senhaHash, isAdmin);

            // Assert
            usuario.Should().NotBeNull();
            usuario.Nome.Should().Be(nome);
            usuario.Email.Should().Be(email);
            usuario.Senha.Should().Be(senhaHash);
            usuario.IsAdministrador.Should().Be(isAdmin);
            usuario.Ativo.Should().BeTrue();
        }

        // Teste 4: Deve passar ao desativar e reativar usuário
        [Fact(DisplayName = "Desativar E Reativar Usuário Deve Funcionar Corretamente")]
        public void DesativarEReativar_Usuario_DeveAlterarEstadoCorretamente()
        {
            // Arrange
            var usuario = new Usuario("Teste", "email@teste.com", "senhaHash123", false);

            // Act & Assert
            usuario.Ativo.Should().BeTrue(); // Estado inicial

            usuario.Desativar();
            usuario.Ativo.Should().BeFalse(); // Após desativação

            usuario.Ativar();
            usuario.Ativo.Should().BeTrue(); // Após reativação
        }
    }
}