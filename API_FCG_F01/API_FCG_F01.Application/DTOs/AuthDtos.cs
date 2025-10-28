namespace API_FCG_F01.Application.DTOs;

public sealed record RegisterDto(string Nome, string Email, string Senha);
public sealed record LoginDto(string Email, string Senha);
public sealed record AuthResponseDto(string AccessToken, DateTime ExpiresAtUtc, string Email, string[] Roles);
