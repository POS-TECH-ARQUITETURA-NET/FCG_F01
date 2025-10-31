namespace API_FCG_F01.Application.DTOs;

/// <summary>
/// DTO para registro de usuário
/// </summary>
/// <param name="Nome"></param>
/// <param name="Email"></param>
/// <param name="Senha"></param>
public sealed record RegisterDto(string Nome, string Email, string Senha);

/// <summary>
/// DTO para login de usuário
/// </summary>
/// <param name="Email"></param>
/// <param name="Senha"></param>
public sealed record LoginDto(string Email, string Senha);

/// <summary>
/// DTO para resposta de autenticação
/// </summary>
/// <param name="AccessToken"></param>
/// <param name="ExpiresAtUtc"></param>
/// <param name="Email"></param>
/// <param name="Roles"></param>
public sealed record AuthResponseDto(string AccessToken, DateTime ExpiresAtUtc, string Email, string[] Roles);
