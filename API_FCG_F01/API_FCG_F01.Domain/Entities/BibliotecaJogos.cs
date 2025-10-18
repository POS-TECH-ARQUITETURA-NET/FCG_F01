using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FCG_F01.Domain.Entities
{
    public class BibliotecaJogos : EntityBase
    {
        public Usuario Usuario { get; private set; }
        public Guid JogoId { get; private set; }
        public Jogo Jogo { get; private set; }

        public BibliotecaJogos(Usuario usuario, Guid jogoId, Jogo jogo, DateTime dataCompra)
        {
            Usuario = usuario;
            JogoId = jogoId;
            Jogo = jogo;
            DataCriacao = dataCompra;
        }
    }
}
