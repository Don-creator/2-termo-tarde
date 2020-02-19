using senai.Filmes.WebApi.Domains;
using System.Collections.Generic;


namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório filme
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filme
        /// </summary>
        /// <returns>Retorna uma lista de filme</returns>
        List<FilmeDomain> Listar();

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="filme">Objeto filme que será cadastrado</param>
        void Cadastrar(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme que será atualizado</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filme">Objeto filme que será atualizado</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um filme através do ID
        /// </summary>
        /// <param name="id">ID do filme que será buscado</param>
        /// <returns>Retorna um filme</returns>
        FilmeDomain BuscarPorId(int id);
    }
}