using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Application.Interfaces;
using API_FCG_F01.Domain.Entities;
using API_FCG_F01.Domain.Interfaces;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace API_FCG_F01.Application.Services;

public sealed class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(UsuarioCreateDto dto, CancellationToken ct = default)
    {
        ValidarSenha(dto.Senha);
        var hash = ComputeSha256(dto.Senha);
        var usuario = new Usuario(dto.Nome, dto.Email, hash, dto.IsAdministrador);
        await _repo.AddAsync(usuario, ct);
        return usuario.Id;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        => await _repo.DeleteAsync(id, ct);

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync(CancellationToken ct = default)
    {
        var users = await _repo.GetAllAsync(ct);
        return users.Select(_mapper.Map<UsuarioDto>);
    }

    public async Task<UsuarioDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var user = await _repo.GetByIdAsync(id, ct);
        return user is null ? null : _mapper.Map<UsuarioDto>(user);
    }

    public async Task UpdateAsync(UsuarioUpdateDto dto, CancellationToken ct = default)
    {
        var user = await _repo.GetByIdAsync(dto.Id, ct) ?? throw new InvalidOperationException("Usuário não encontrado");

        if (!string.IsNullOrEmpty(dto.Senha))
        {
            ValidarSenha(dto.Senha);
            var hash = ComputeSha256(dto.Senha);
            user.AlterarSenhaHash(hash);
        }

        user.AlterarNome(dto.Nome);
        user.AlterarEmail(dto.Email);
        if (dto.Ativo) user.Ativar(); else user.Desativar();
        await _repo.UpdateAsync(user, ct);
    }

    private static string ComputeSha256(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(bytes);
    }

    private static void ValidarSenha(string senha)
    {
        if (string.IsNullOrEmpty(senha))
            throw new ArgumentException("A senha não pode ser vazia.");

        if (senha.Length < 8)
            throw new ArgumentException("A senha deve ter no mínimo 8 caracteres.");

        var regexLetras = new Regex("[a-zA-Z]");
        var regexNumeros = new Regex("[0-9]");
        var regexEspeciais = new Regex("[!@#$%^&*(),.?\":{}|<>]");

        if (!regexLetras.IsMatch(senha))
            throw new ArgumentException("A senha deve conter pelo menos uma letra.");

        if (!regexNumeros.IsMatch(senha))
            throw new ArgumentException("A senha deve conter pelo menos um número.");

        if (!regexEspeciais.IsMatch(senha))
            throw new ArgumentException("A senha deve conter pelo menos um caractere especial.");
    }
}
