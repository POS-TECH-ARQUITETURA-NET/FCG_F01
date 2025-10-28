using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_FCG_F01.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class BibliotecasController : ControllerBase
{
    private readonly IBibliotecaJogosService _service;

    public BibliotecasController(IBibliotecaJogosService service) => _service = service;

    [HttpGet("usuario/{usuarioId:guid}")]
    public async Task<ActionResult<BibliotecaDto>> GetByUsuario(Guid usuarioId, CancellationToken ct)
    {
        var result = await _service.GetByUsuarioAsync(usuarioId, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("usuario/{usuarioId:guid}/ensure")]
    public async Task<ActionResult<BibliotecaDto>> EnsureBiblioteca(Guid usuarioId, CancellationToken ct)
    {
        var result = await _service.GetOrCreateByUsuarioAsync(usuarioId, ct);
        return Ok(result);
    }

    [HttpPost("adicionar")]
    public async Task<ActionResult> AddJogo([FromBody] BibliotecaAddJogoRequest request, CancellationToken ct)
    {
        await _service.AddJogoAsync(request, ct);
        return NoContent();
    }

    [HttpPost("remover")]
    public async Task<ActionResult> RemoveJogo([FromBody] BibliotecaRemoveJogoRequest request, CancellationToken ct)
    {
        await _service.RemoveJogoAsync(request, ct);
        return NoContent();
    }
}
