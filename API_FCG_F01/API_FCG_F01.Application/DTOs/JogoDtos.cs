namespace API_FCG_F01.Application.DTOs;

/// <summary>
/// DTO para criação de jogo
/// </summary>
/// <param name="Titulo"></param>
/// <param name="Descricao"></param>
/// <param name="Preco"></param>
public sealed record JogoCreateDto(string Titulo, string? Descricao, decimal Preco);

/// <summary>
/// DTO para atualização de jogo
/// </summary>
/// <param name="Id"></param>
/// <param name="Titulo"></param>
/// <param name="Descricao"></param>
/// <param name="Preco"></param>
/// <param name="Ativo"></param>
public sealed record JogoUpdateDto(Guid Id, string Titulo, string? Descricao, decimal Preco, bool Ativo);

/// <summary>
/// DTO para exibir um jogo
/// </summary>
/// <param name="Id"></param>
/// <param name="Titulo"></param>
/// <param name="Descricao"></param>
/// <param name="Preco"></param>
/// <param name="Ativo"></param>
/// <param name="DataCriacao"></param>
public sealed record JogoDto(Guid Id, string Titulo, string? Descricao, decimal Preco, bool Ativo, DateTimeOffset DataCriacao);
