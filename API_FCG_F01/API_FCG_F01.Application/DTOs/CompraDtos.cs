namespace API_FCG_F01.Application.DTOs;

public sealed record CompraCreateDto(Guid UsuarioId, IEnumerable<Guid> Jogos);
public sealed record CompraUpdateDto(Guid Id, IEnumerable<Guid> Jogos, bool Aprovada);
public sealed record CompraDto(Guid Id, Guid UsuarioId, IEnumerable<Guid> Jogos, bool Aprovada, DateTimeOffset DataCompra, DateTimeOffset DataCriacao);