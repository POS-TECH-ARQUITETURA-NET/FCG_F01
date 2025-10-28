using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Usuario?> GetByNameAsync(string nome, CancellationToken ct = default);
    Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Usuario entity, CancellationToken ct = default);
    Task UpdateAsync(Usuario entity, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    Task<Usuario?> GetByEmailAsync(string email, CancellationToken ct = default);
}
