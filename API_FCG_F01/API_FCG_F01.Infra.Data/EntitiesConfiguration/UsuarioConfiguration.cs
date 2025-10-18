using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=> p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(60);
            builder.Property(p => p.SenhaHash).IsRequired();

            // Configuração do relacionamento com BibliotecaJogos
            builder.HasMany<BibliotecaJogos>()
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
