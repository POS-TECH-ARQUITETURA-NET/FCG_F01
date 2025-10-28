using API_FCG_F01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration;

public sealed class JogoConfiguration : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Titulo).HasMaxLength(200).IsRequired();
        builder.Property(j => j.Descricao).HasMaxLength(2000);
        builder.Property(j => j.Preco).HasPrecision(18, 2);
        builder.Property(j => j.Ativo).IsRequired();
        builder.Property(j => j.DataCriacao).IsRequired();
    }
}
