using API_FCG_F01.Application.DTOs;

namespace API_FCG_F01.Application.Interfaces;

public interface IJogoService
{
    Task<JogoDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<JogoDto>> GetAllAsync(CancellationToken ct = default);
    Task<Guid> CreateAsync(JogoCreateDto dto, CancellationToken ct = default);
    Task UpdateAsync(JogoUpdateDto dto, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
