using API_FCG_F01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration;

public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Nome).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Senha).HasMaxLength(512).IsRequired();
        builder.Property(u => u.IsAdministrador).IsRequired();
        builder.Property(u => u.Ativo).IsRequired();
        builder.Property(u => u.DataCriacao).IsRequired();

        builder.HasOne(u => u.Biblioteca)
               .WithOne(b => b.Usuario)
               .HasForeignKey<BibliotecaJogos>(b => b.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
