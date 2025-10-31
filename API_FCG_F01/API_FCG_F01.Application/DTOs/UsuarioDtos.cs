namespace API_FCG_F01.Application.DTOs;

/// <summary>
/// DTO para criação de um novo usuário.
/// </summary>
/// <param name="Nome"></param>
/// <param name="Email"></param>
/// <param name="Senha"></param>
/// <param name="IsAdministrador"></param>
public sealed record UsuarioCreateDto(string Nome, string? Email, string Senha, bool IsAdministrador);

/// <summary>
/// DTO para atualização de um usuário existente.
/// </summary>
/// <param name="Id"></param>
/// <param name="Nome"></param>
/// <param name="Email"></param>
/// <param name="Senha"></param>
/// <param name="IsAdministrador"></param>
/// <param name="Ativo"></param>
public sealed record UsuarioUpdateDto(Guid Id, string Nome, string? Email, string Senha, bool IsAdministrador, bool Ativo);

/// <summary>
/// DTO que representa um usuário.
/// </summary>
/// <param name="Id"></param>
/// <param name="Nome"></param>
/// <param name="Email"></param>
/// <param name="IsAdministrador"></param>
/// <param name="Ativo"></param>
/// <param name="DataCriacao"></param>
public sealed record UsuarioDto(Guid Id, string Nome, string? Email, bool IsAdministrador, bool Ativo, DateTimeOffset DataCriacao);
