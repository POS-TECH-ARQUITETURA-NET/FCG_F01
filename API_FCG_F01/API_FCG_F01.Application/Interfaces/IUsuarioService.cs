using API_FCG_F01.Application.DTOs;

namespace API_FCG_F01.Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<UsuarioDto>> GetAllAsync(CancellationToken ct = default);
    Task<Guid> CreateAsync(UsuarioCreateDto dto, CancellationToken ct = default);
    Task UpdateAsync(UsuarioUpdateDto dto, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
