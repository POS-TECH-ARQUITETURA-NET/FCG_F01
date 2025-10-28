using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using AutoMapper;

namespace API_FCG_F01.Application.Services;

public sealed class BibliotecaJogosService : IBibliotecaJogosService
{
    private readonly IBibliotecaJogosRepository _bibliotecaRepo;
    private readonly IBibliotecaJogosItensRepository _itensRepo;
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly IJogoRepository _jogoRepo;
    private readonly IMapper _mapper;

    public BibliotecaJogosService(
        IBibliotecaJogosRepository bibliotecaRepo,
        IBibliotecaJogosItensRepository itensRepo,
        IUsuarioRepository usuarioRepo,
        IJogoRepository jogoRepo,
        IMapper mapper)
    {
        _bibliotecaRepo = bibliotecaRepo;
        _itensRepo = itensRepo;
        _usuarioRepo = usuarioRepo;
        _jogoRepo = jogoRepo;
        _mapper = mapper;
    }

    public async Task<BibliotecaDto?> GetByUsuarioAsync(Guid usuarioId, CancellationToken ct = default)
    {
        var biblioteca = await _bibliotecaRepo.GetByUsuarioIdAsync(usuarioId, ct);
        return biblioteca is null ? null : _mapper.Map<BibliotecaDto>(biblioteca);
    }

    public async Task<BibliotecaDto> GetOrCreateByUsuarioAsync(Guid usuarioId, CancellationToken ct = default)
    {
        var user = await _usuarioRepo.GetByIdAsync(usuarioId, ct) ?? throw new InvalidOperationException("Usuário não encontrado");
        var biblioteca = await _bibliotecaRepo.GetByUsuarioIdAsync(usuarioId, ct);
        if (biblioteca is null)
        {
            biblioteca = new BibliotecaJogos(usuarioId);
            await _bibliotecaRepo.AddAsync(biblioteca, ct);
        }
        var full = await _bibliotecaRepo.GetByUsuarioIdAsync(usuarioId, ct);
        return _mapper.Map<BibliotecaDto>(full!);
    }

    public async Task AddJogoAsync(BibliotecaAddJogoRequest request, CancellationToken ct = default)
    {
        var biblioteca = await _bibliotecaRepo.GetByUsuarioIdAsync(request.UsuarioId, ct);
        if (biblioteca is null)
        {
            biblioteca = new BibliotecaJogos(request.UsuarioId);
            await _bibliotecaRepo.AddAsync(biblioteca, ct);
        }

        var jogo = await _jogoRepo.GetByIdAsync(request.JogoId, ct) ?? throw new InvalidOperationException("Jogo não encontrado");

        var existente = await _itensRepo.GetAsync(biblioteca.Id, request.JogoId, ct);
        if (existente is null)
        {
            var item = new BibliotecaJogosItem(biblioteca.Id, jogo.Id);
            await _itensRepo.AddAsync(item, ct);
        }
    }

    public async Task RemoveJogoAsync(BibliotecaRemoveJogoRequest request, CancellationToken ct = default)
    {
        var biblioteca = await _bibliotecaRepo.GetByUsuarioIdAsync(request.UsuarioId, ct) 
                         ?? throw new InvalidOperationException("Biblioteca não encontrada para o usuário");
        await _itensRepo.RemoveAsync(biblioteca.Id, request.JogoId, ct);
    }
}
