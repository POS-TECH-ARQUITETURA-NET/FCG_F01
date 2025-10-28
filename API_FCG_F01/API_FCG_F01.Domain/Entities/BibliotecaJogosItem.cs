using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FCG_F01.Domain.Entities
{
    public sealed class BibliotecaJogosItem : EntityBase
    {
        public Guid BibliotecaJogosId { get; private set; }
        public Guid JogoId { get; private set; }
        public bool Ativo { get; private set; }
        public BibliotecaJogos? Biblioteca { get; private set; }
        public Jogo? Jogo { get; private set; }

        private BibliotecaJogosItem() { }

        public BibliotecaJogosItem(Guid bibliotecaJogosId, Guid jogoId)
        {
            BibliotecaJogosId = bibliotecaJogosId;
            JogoId = jogoId;
            Ativo = true;
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
