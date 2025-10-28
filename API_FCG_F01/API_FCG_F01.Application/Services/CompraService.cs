using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using AutoMapper;

namespace API_FCG_F01.Application.Services;

public sealed class CompraService : ICompraService
{
    private readonly ICompraRepository _repo;
    private readonly IMapper _mapper;

    public CompraService(ICompraRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CompraCreateDto dto, CancellationToken ct = default)
    {
        var compra = new Compra(dto.UsuarioId, dto.Jogos);
        await _repo.AddAsync(compra, ct);
        return compra.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        => await _repo.DeleteAsync(id, ct);

    public async Task<IEnumerable<CompraDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(_mapper.Map<CompraDto>);
    }

    public async Task<CompraDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity is null ? null : _mapper.Map<CompraDto>(entity);
    }

    public async Task UpdateAsync(CompraUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(dto.Id, ct) ?? throw new InvalidOperationException("Compra não encontrada");
        // Atualiza aprovação caso solicitado (a entidade só expõe AprovarCompra)
        if (dto.Aprovada && !entity.Aprovada)
            entity.AprovarCompra();

        await _repo.UpdateAsync(entity, ct);
    }
}