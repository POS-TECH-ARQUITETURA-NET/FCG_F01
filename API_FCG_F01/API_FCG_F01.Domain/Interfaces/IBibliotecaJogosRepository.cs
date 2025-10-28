using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Domain.Interfaces;

public interface IBibliotecaJogosRepository
{
    Task<BibliotecaJogos?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<BibliotecaJogos?> GetByUsuarioIdAsync(Guid usuarioId, CancellationToken ct = default);
    Task AddAsync(BibliotecaJogos entity, CancellationToken ct = default);
    Task UpdateAsync(BibliotecaJogos entity, CancellationToken ct = default);
}
