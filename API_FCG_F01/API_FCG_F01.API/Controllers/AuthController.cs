using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_FCG_F01.API.Controllers;

/// <summary>
/// Controller responsável pela autenticação e registro de usuários
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Realiza o login do usuário
    /// </summary>
    /// <param name="login">Dados de login do usuário</param>
    /// <param name="ct">Token de cancelamento</param>
    /// <returns>Token de autenticação e informações do usuário</returns>
    /// <response code="200">Login realizado com sucesso</response>
    /// <response code="401">Email ou senha inválidos</response>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto login, CancellationToken ct)
    {
        try
        {
            var response = await _authService.LoginAsync(login, ct);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Registra um novo usuário no sistema
    /// </summary>
    /// <param name="register">Dados do novo usuário</param>
    /// <param name="ct">Token de cancelamento</param>
    /// <returns>Token de autenticação e informações do usuário</returns>
    /// <response code="200">Usuário registrado com sucesso</response>
    /// <response code="400">Email já cadastrado ou dados inválidos</response>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto register, CancellationToken ct)
    {
        try
        {
            var response = await _authService.RegisterAsync(register, ct);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}