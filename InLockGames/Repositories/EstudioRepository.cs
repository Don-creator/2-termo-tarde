using InLockGames.WebApi.Domains;
using InLockGames.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockGames.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(estudio => estudio.IdEstudio == id);

            // Estudios e = new Estudios()
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }
    }
}
