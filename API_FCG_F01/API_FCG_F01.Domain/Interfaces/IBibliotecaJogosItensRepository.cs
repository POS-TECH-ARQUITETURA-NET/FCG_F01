using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Domain.Interfaces;

public interface IBibliotecaJogosItensRepository
{
    Task<BibliotecaJogosItem?> GetAsync(Guid bibliotecaId, Guid jogoId, CancellationToken ct = default);
    Task AddAsync(BibliotecaJogosItem entity, CancellationToken ct = default);
    Task RemoveAsync(Guid bibliotecaId, Guid jogoId, CancellationToken ct = default);
}
