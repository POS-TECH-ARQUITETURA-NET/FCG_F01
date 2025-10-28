using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using API_FCG_F01.Application.Interfaces;

namespace API_FCG_F01.Application.Services;

public sealed class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUsuarioService _usuarioService;

    public AuthService(
        IConfiguration configuration,
        IUsuarioRepository usuarioRepository,   
        IUsuarioService usuarioService)
    {
        _configuration = configuration;
        _usuarioRepository = usuarioRepository;
        _usuarioService = usuarioService;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto login, CancellationToken ct = default)
    {
        var usuario = await _usuarioRepository.GetByEmailAsync(login.Email, ct)
            ?? throw new UnauthorizedAccessException("Email ou senha inválidos");

        var senhaHash = ComputeSha256(login.Senha);
        if (usuario.Senha != senhaHash)
            throw new UnauthorizedAccessException("Email ou senha inválidos");

        if (!usuario.Ativo)
            throw new UnauthorizedAccessException("Usuário inativo");

        var token = GerarToken(usuario);
        var roles = new[] { usuario.IsAdministrador ? "Administrador" : "Usuario" };

        return new AuthResponseDto(token, DateTime.UtcNow.AddHours(8), usuario.Email, roles);
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto register, CancellationToken ct = default)
    {
        var usuarioExistente = await _usuarioRepository.GetByEmailAsync(register.Email, ct);
        if (usuarioExistente != null)
            throw new InvalidOperationException("Email já cadastrado");

        var dto = new UsuarioCreateDto(register.Nome, register.Email, register.Senha, false);
        var id = await _usuarioService.CreateAsync(dto, ct);

        var usuario = await _usuarioRepository.GetByIdAsync(id, ct)
            ?? throw new InvalidOperationException("Erro ao criar usuário");

        var token = GerarToken(usuario);
        var roles = new[] { "Usuario" };

        return new AuthResponseDto(token, DateTime.UtcNow.AddHours(8), usuario.Email, roles);
    }

    private string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key não configurado"));

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, usuario.Email),
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Role, usuario.IsAdministrador ? "Administrador" : "Usuario")
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiresMinutes"] ?? "120")),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static string ComputeSha256(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }
}