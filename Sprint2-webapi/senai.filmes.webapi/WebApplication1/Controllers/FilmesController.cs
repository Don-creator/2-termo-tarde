using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos filme
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _filmeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filme
        /// </summary>
        /// <returns>Retorna uma lista de filme</returns>
        /// dominio/api/filme
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return _filmeRepository.Listar();
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto filme recebido na requisição</param>
        /// <returns>Retorna um status code 201 (created)</returns>
        /// dominio/api/filme
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            // Faz a chamada para o método .Cadastrar();
            _filmeRepository.Cadastrar(novoFilme);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um filme através do seu ID
        /// </summary>
        /// <param name="id">ID do filme buscado</param>
        /// <returns>Retorna um filme buscado</returns>
        /// dominio/api/Generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto filmeBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se nenhum filme foi encontrado
            if (filmeBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }

            // Caso seja encontrado, retorna o filme buscado
            return Ok(filmeBuscado);
        }

        /// <summary>
        /// Atualiza um filme existente passando o ID no corpo da requisição
        /// </summary>
        /// <param name="filmeAtualizado">Objeto filme que será atualizado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        /// dominio/api/filme
        [HttpPut]
        public IActionResult PutIdCorpo(FilmeDomain filmeAtualizado)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

            // Verifica se algum filme foi encontrado
            if (filmeBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Atualiza um filme existente passando o ID no recurso
        /// </summary>
        /// <param name="id">ID do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto filme que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/filme/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (filmeBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um filme passando o ID
        /// </summary>
        /// <param name="id">ID do filme que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem personalizada</returns>
        /// dominio/api/Filme/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _filmeRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Filme deletado");
        }
    }
}