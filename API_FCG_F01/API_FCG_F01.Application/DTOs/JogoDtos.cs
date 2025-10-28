namespace API_FCG_F01.Application.DTOs;

public sealed record JogoCreateDto(string Titulo, string? Descricao, decimal Preco);
public sealed record JogoUpdateDto(Guid Id, string Titulo, string? Descricao, decimal Preco, bool Ativo);
public sealed record JogoDto(Guid Id, string Titulo, string? Descricao, decimal Preco, bool Ativo, DateTimeOffset DataCriacao);
