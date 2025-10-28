using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API_FCG_F01.Infra.Data.Repositories;

public sealed class BibliotecaJogosRepository : IBibliotecaJogosRepository
{
    private readonly ApplicationDbContext _ctx;
    public BibliotecaJogosRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(BibliotecaJogos entity, CancellationToken ct = default)
    {
        await _ctx.Bibliotecas.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task<BibliotecaJogos?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.Bibliotecas
            .Include(b => b.Itens).ThenInclude(i => i.Jogo)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, ct);

    public async Task<BibliotecaJogos?> GetByUsuarioIdAsync(Guid usuarioId, CancellationToken ct = default)
        => await _ctx.Bibliotecas
            .Include(b => b.Itens).ThenInclude(i => i.Jogo)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.UsuarioId == usuarioId, ct);

    public async Task UpdateAsync(BibliotecaJogos entity, CancellationToken ct = default)
    {
        _ctx.Bibliotecas.Update(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}
