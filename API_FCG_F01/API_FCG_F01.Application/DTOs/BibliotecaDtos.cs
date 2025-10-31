namespace API_FCG_F01.Application.DTOs;

/// <summary>
/// DTO que representa um item na biblioteca de jogos do usuário.
/// </summary>
/// <param name="JogoId"></param>
/// <param name="Titulo"></param>
/// <param name="Ativo"></param>
/// <param name="DataCriacao"></param>
public sealed record BibliotecaItemDto(Guid JogoId, string Titulo, bool Ativo, DateTimeOffset DataCriacao);

/// <summary>
/// DTO que representa a biblioteca de jogos de um usuário.
/// </summary>
/// <param name="Id"></param>
/// <param name="UsuarioId"></param>
/// <param name="Ativo"></param>
/// <param name="DataCriicao"></param>
/// <param name="Itens"></param>
public sealed record BibliotecaDto(Guid Id, Guid UsuarioId, bool Ativo, DateTimeOffset DataCriicao, IReadOnlyCollection<BibliotecaItemDto> Itens);

/// <summary>
/// DTO para adicionar um jogo à biblioteca do usuário.
/// </summary>
/// <param name="UsuarioId"></param>
/// <param name="JogoId"></param>
public sealed record BibliotecaAddJogoRequest(Guid UsuarioId, Guid JogoId);

/// <summary>
/// DTO para remover um jogo da biblioteca do usuário.
/// </summary>
/// <param name="UsuarioId"></param>
/// <param name="JogoId"></param>
public sealed record BibliotecaRemoveJogoRequest(Guid UsuarioId, Guid JogoId);
