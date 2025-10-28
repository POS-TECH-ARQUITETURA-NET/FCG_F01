namespace API_FCG_F01.Application.DTOs;

public sealed record BibliotecaItemDto(Guid JogoId, string Titulo, bool Ativo, DateTimeOffset DataCriacao);
public sealed record BibliotecaDto(Guid Id, Guid UsuarioId, bool Ativo, DateTimeOffset DataCriicao, IReadOnlyCollection<BibliotecaItemDto> Itens);

public sealed record BibliotecaAddJogoRequest(Guid UsuarioId, Guid JogoId);
public sealed record BibliotecaRemoveJogoRequest(Guid UsuarioId, Guid JogoId);
