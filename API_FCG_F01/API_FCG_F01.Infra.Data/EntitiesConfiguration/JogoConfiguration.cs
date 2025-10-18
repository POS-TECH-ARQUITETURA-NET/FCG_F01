using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();

            builder.Property(p => p.Titulo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .IsRequired();
        }
    }
}