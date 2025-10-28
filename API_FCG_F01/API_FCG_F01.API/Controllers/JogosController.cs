using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_FCG_F01.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class JogosController : ControllerBase
{
    private readonly IJogoService _service;
    public JogosController(IJogoService service) => _service = service;

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JogoDto>>> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<JogoDto>> GetById(Guid id, CancellationToken ct)
    {
        var result = await _service.GetByIdAsync(id, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] JogoCreateDto dto, CancellationToken ct)
    {
        var id = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] JogoUpdateDto dto, CancellationToken ct)
    {
        if (id != dto.Id) return BadRequest("Id inconsistente");
        await _service.UpdateAsync(dto, ct);
        return NoContent();
    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}
