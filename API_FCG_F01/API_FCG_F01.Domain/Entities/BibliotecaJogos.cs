using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FCG_F01.Domain.Entities
{
    public class BibliotecaJogos : EntityBase
    {
        public Guid UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public ICollection<BibliotecaJogosItem> Itens { get; private set; } = new List<BibliotecaJogosItem>();
        public bool Ativo { get; private set; }

        private BibliotecaJogos() { }

        public BibliotecaJogos(Guid usuarioId)
        {            
            UsuarioId = usuarioId;
            Ativo = true;
            DataCriacao = DateTimeOffset.UtcNow;
        }

        public BibliotecaJogosItem AdicionarJogo(Guid jogoId)
        {
            var existente = Itens.FirstOrDefault(i => i.JogoId == jogoId);
            if (existente is not null) return existente;
            var item = new BibliotecaJogosItem(Id, jogoId);
            Itens.Add(item);
            return item;
        }

        public void RemoverJogo(Guid jogoId)
        {
            var existente = Itens.FirstOrDefault(i => i.JogoId == jogoId);
            if (existente is not null) Itens.Remove(existente);
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
