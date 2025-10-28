namespace API_FCG_F01.Application.DTOs;

public sealed record UsuarioCreateDto(string Nome, string? Email, string Senha, bool IsAdministrador);
public sealed record UsuarioUpdateDto(Guid Id, string Nome, string? Email, string Senha, bool IsAdministrador, bool Ativo);
public sealed record UsuarioDto(Guid Id, string Nome, string? Email, bool IsAdministrador, bool Ativo, DateTimeOffset DataCriacao);
