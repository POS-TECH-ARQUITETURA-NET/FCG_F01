using API_FCG_F01.Application.DTOs;

namespace API_FCG_F01.Application.Interfaces;

public interface IBibliotecaJogosService
{
    Task<BibliotecaDto> GetOrCreateByUsuarioAsync(Guid usuarioId, CancellationToken ct = default);
    Task<BibliotecaDto?> GetByUsuarioAsync(Guid usuarioId, CancellationToken ct = default);
    Task AddJogoAsync(BibliotecaAddJogoRequest request, CancellationToken ct = default);
    Task RemoveJogoAsync(BibliotecaRemoveJogoRequest request, CancellationToken ct = default);
}
