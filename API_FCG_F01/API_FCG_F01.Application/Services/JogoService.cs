using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using AutoMapper;

namespace API_FCG_F01.Application.Services;

public sealed class JogoService : IJogoService
{
    private readonly IJogoRepository _repo;
    private readonly IMapper _mapper;

    public JogoService(IJogoRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(JogoCreateDto dto, CancellationToken ct = default)
    {
        var jogo = new Jogo(dto.Titulo, dto.Descricao, dto.Preco);
        await _repo.AddAsync(jogo, ct);
        return jogo.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        => await _repo.DeleteAsync(id, ct);

    public async Task<IEnumerable<JogoDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(_mapper.Map<JogoDto>);
    }

    public async Task<JogoDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity is null ? null : _mapper.Map<JogoDto>(entity);
    }

    public async Task UpdateAsync(JogoUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(dto.Id, ct) ?? throw new InvalidOperationException("Jogo não encontrado");
        if (dto.Ativo) entity.Ativar(); else entity.Desativar();
        entity = new Jogo(dto.Titulo, dto.Descricao, dto.Preco);
        await _repo.UpdateAsync(entity, ct);
    }
}
