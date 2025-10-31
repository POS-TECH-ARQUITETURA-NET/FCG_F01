namespace API_FCG_F01.Application.DTOs;

/// <summary>
/// DTO para criação de uma nova compra.
/// </summary>
/// <param name="UsuarioId"></param>
/// <param name="Jogos"></param>
public sealed record CompraCreateDto(Guid UsuarioId, IEnumerable<Guid> Jogos);

/// <summary>
/// DTO para atualização de uma compra existente.
/// </summary>
/// <param name="Id"></param>
/// <param name="Jogos"></param>
/// <param name="Aprovada"></param>
public sealed record CompraUpdateDto(Guid Id, IEnumerable<Guid> Jogos, bool Aprovada);

/// <summary>
/// DTO que representa uma compra.
/// </summary>
/// <param name="Id"></param>
/// <param name="UsuarioId"></param>
/// <param name="Jogos"></param>
/// <param name="Aprovada"></param>
/// <param name="DataCompra"></param>
/// <param name="DataCriacao"></param>
public sealed record CompraDto(Guid Id, Guid UsuarioId, IEnumerable<Guid> Jogos, bool Aprovada, DateTimeOffset DataCompra, DateTimeOffset DataCriacao);