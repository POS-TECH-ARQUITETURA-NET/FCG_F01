using API_FCG_F01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration;

public sealed class BibliotecaJogosItemConfiguration : IEntityTypeConfiguration<BibliotecaJogosItem>
{
    public void Configure(EntityTypeBuilder<BibliotecaJogosItem> builder)
    {
        builder.HasKey(i => new { i.BibliotecaJogosId, i.JogoId });
        builder.Property(i => i.Ativo).IsRequired();
        builder.Property(i => i.DataCriacao).IsRequired();
        builder.HasOne(i => i.Biblioteca)
               .WithMany(b => b.Itens)
               .HasForeignKey(i => i.BibliotecaJogosId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(i => i.Jogo)
               .WithMany(j => j.Bibliotecas)
               .HasForeignKey(i => i.JogoId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
