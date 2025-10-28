using API_FCG_F01.Application.DTOs;

namespace API_FCG_F01.Application.Interfaces;

public interface ICompraService
{
    Task<CompraDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<CompraDto>> GetAllAsync(CancellationToken ct = default);
    Task<Guid> CreateAsync(CompraCreateDto dto, CancellationToken ct = default);
    Task UpdateAsync(CompraUpdateDto dto, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}