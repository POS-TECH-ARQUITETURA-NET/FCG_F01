using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration
{
    public class BibliotecaJogosConfiguration : IEntityTypeConfiguration<BibliotecaJogos>
    {
        public void Configure(EntityTypeBuilder<BibliotecaJogos> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();

            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey("UsuarioId")
                .IsRequired();

            builder.HasOne(p => p.Jogo)
                .WithMany()
                .HasForeignKey(p => p.JogoId)
                .IsRequired();
        }
    }
}