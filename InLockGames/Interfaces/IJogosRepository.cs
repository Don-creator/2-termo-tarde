using InLockGames.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockGames.WebApi.Interfaces
{
    interface IJogosRepository
    {
        List<Jogos> Listar();

        Jogos BuscarPorId(int id);

        void Cadastrar(Jogos jogoNovo);




    }
}
