using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FCG_F01.Domain.Entities;

namespace API_FCG_F01.Infra.Data.EntitiesConfiguration
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UsuarioId)
                .IsRequired();

            builder.Property(c => c.DataCompra)
                .IsRequired();

            builder.Property(c => c.Aprovada)
                .IsRequired();

            // Mapeamento da lista de jogos como string (caso não haja entidade intermediária)
            builder.Property(c => c.Jogos)
                .HasConversion(
                    v => string.Join(";", v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList()
                )
                .HasColumnName("Jogos")
                .IsRequired();

            builder.Property(c => c.DataCriacao)
                .IsRequired();

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}