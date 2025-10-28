using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Domain.Interfaces;

public interface IJogoRepository
{
    Task<Jogo?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Jogo>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Jogo entity, CancellationToken ct = default);
    Task UpdateAsync(Jogo entity, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
