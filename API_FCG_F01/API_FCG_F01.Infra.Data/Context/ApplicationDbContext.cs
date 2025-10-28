using API_FCG_F01.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FCG_F01.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {                
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Jogo> Jogos => Set<Jogo>();
        public DbSet<BibliotecaJogos> Bibliotecas => Set<BibliotecaJogos>();
        public DbSet<BibliotecaJogosItem> BibliotecaItens => Set<BibliotecaJogosItem>();
        public DbSet<Compra> Compras => Set<Compra>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
