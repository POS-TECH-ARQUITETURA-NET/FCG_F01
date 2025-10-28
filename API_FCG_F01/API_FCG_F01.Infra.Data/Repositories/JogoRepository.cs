using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API_FCG_F01.Infra.Data.Repositories;

public sealed class JogoRepository : IJogoRepository
{
    private readonly ApplicationDbContext _ctx;
    public JogoRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(Jogo entity, CancellationToken ct = default)
    {
        await _ctx.Jogos.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _ctx.Jogos.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        _ctx.Jogos.Remove(entity);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Jogo>> GetAllAsync(CancellationToken ct = default)
        => await _ctx.Jogos.AsNoTracking().ToListAsync(ct);

    public async Task<Jogo?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.Jogos.AsNoTracking().FirstOrDefaultAsync(j => j.Id == id, ct);

    public async Task UpdateAsync(Jogo entity, CancellationToken ct = default)
    {
        _ctx.Jogos.Update(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}
