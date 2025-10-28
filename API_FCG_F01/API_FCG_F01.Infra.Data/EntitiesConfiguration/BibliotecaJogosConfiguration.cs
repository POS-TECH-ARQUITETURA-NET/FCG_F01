using API_FCG_F01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration;

public sealed class BibliotecaJogosConfiguration : IEntityTypeConfiguration<BibliotecaJogos>
{
    public void Configure(EntityTypeBuilder<BibliotecaJogos> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Ativo).IsRequired();
        builder.Property(b => b.DataCriacao).IsRequired();
        builder.HasIndex(b => b.UsuarioId).IsUnique();
        builder.HasMany(b => b.Itens)
               .WithOne(i => i.Biblioteca)
               .HasForeignKey(i => i.BibliotecaJogosId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
