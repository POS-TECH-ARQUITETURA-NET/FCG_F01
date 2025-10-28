using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API_FCG_F01.Infra.Data.Repositories;

public sealed class BibliotecaJogosItensRepository : IBibliotecaJogosItensRepository
{
    private readonly ApplicationDbContext _ctx;
    public BibliotecaJogosItensRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(BibliotecaJogosItem entity, CancellationToken ct = default)
    {
        await _ctx.BibliotecaItens.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task<BibliotecaJogosItem?> GetAsync(Guid bibliotecaId, Guid jogoId, CancellationToken ct = default)
        => await _ctx.BibliotecaItens
            .Include(i => i.Jogo)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.BibliotecaJogosId == bibliotecaId && i.JogoId == jogoId, ct);

    public async Task RemoveAsync(Guid bibliotecaId, Guid jogoId, CancellationToken ct = default)
    {
        var entity = await _ctx.BibliotecaItens.FindAsync(new object?[] { bibliotecaId, jogoId }, ct);
        if (entity is null) return;
        _ctx.BibliotecaItens.Remove(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}
