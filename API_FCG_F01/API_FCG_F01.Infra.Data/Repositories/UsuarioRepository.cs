using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API_FCG_F01.Infra.Data.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _ctx;
    public UsuarioRepository(ApplicationDbContext ctx) => _ctx = ctx;

    public async Task AddAsync(Usuario entity, CancellationToken ct = default)
    {
        await _ctx.Usuarios.AddAsync(entity, ct);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _ctx.Usuarios.FindAsync(new object?[] { id }, ct);
        if (entity is null) return;
        _ctx.Usuarios.Remove(entity);
        await _ctx.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken ct = default)
        => await _ctx.Usuarios.AsNoTracking().ToListAsync(ct);

    public async Task<Usuario?> GetByEmailAsync(string email, CancellationToken ct = default)
    => await _ctx.Usuarios
        .AsNoTracking()
        .FirstOrDefaultAsync(u => u.Email == email, ct);

    public async Task<Usuario?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _ctx.Usuarios.Include(u => u.Biblioteca)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(u => u.Id == id, ct);

    public async Task<Usuario?> GetByNameAsync(string nome, CancellationToken ct = default)
        => await _ctx.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Nome == nome, ct);

    public async Task UpdateAsync(Usuario entity, CancellationToken ct = default)
    {
        _ctx.Usuarios.Update(entity);
        await _ctx.SaveChangesAsync(ct);
    }
}
