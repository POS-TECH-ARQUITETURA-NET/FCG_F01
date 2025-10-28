using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API_FCG_F01.Infra.Data.Repositories;

public sealed class CompraRepository : ICompraRepository
{
    private readonly ApplicationDbContext _ctx;
    public CompraRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(Compra entity, CancellationToken ct = default)
    {
        await _ctx.Compras.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Compra entity, CancellationToken ct = default)
    {
        if (entity is null) return;
        _ctx.Compras.Remove(entity);
        await _ctx.SaveChangesAsync(ct);
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Compra>> GetAllAsync(CancellationToken ct = default)
        => await _ctx.Compras.AsNoTracking().ToListAsync(ct);

    public async Task<Compra?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.Compras.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task UpdateAsync(Compra entity, CancellationToken ct = default)
    {
        _ctx.Compras.Update(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}