using InLockGames.WebApi.Domains;
using InLockGames.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace InLockGames.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos jogoNovo)
        {
            ctx.Jogos.Add(jogoNovo);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }
    }
}
