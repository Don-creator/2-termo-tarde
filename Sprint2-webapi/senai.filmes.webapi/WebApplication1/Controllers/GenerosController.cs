using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    /// <summary>
    /// Controller respons�vel pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API ser� no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisi��o ser� no formato dom�nio/api/NomeController
    [Route("api/[controller]")]

    // Define que � um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que ir� receber todos os m�todos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a refer�ncia aos m�todos no reposit�rio
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os g�neros
        /// </summary>
        /// <returns>Retorna uma lista de g�neros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            // Faz a chamada para o m�todo .Listar();
            return _generoRepository.Listar();
        }

        /// <summary>
        /// Cadastra um novo g�nero
        /// </summary>
        /// <param name="novoGenero">Objeto genero recebido na requisi��o</param>
        /// <returns>Retorna um status code 201 (created)</returns>
        /// dominio/api/Generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o m�todo .Cadastrar();
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um g�nero atrav�s do seu ID
        /// </summary>
        /// <param name="id">ID do g�nero buscado</param>
        /// <returns>Retorna um g�nero buscado</returns>
        /// dominio/api/Generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que ir� receber o g�nero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum g�nero foi encontrado
            if (generoBuscado == null)
            {
                // Caso n�o seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum g�nero encontrado");
            }

            // Caso seja encontrado, retorna o g�nero buscado
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Atualiza um g�nero existente passando o ID no corpo da requisi��o
        /// </summary>
        /// <param name="generoAtualizado">Objeto g�nero que ser� atualizado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        /// dominio/api/Generos
        [HttpPut]
        public IActionResult PutIdCorpo(GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que ir� receber o g�nero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.IdGenero);

            // Verifica se algum g�nero foi encontrado
            if (generoBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o m�todo .AtualizarIdCorpo();
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

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

            // Caso n�o seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "G�nero n�o encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Atualiza um g�nero existente passando o ID no recurso
        /// </summary>
        /// <param name="id">ID do g�nero que ser� atualizado</param>
        /// <param name="generoAtualizado">Objeto g�nero que ser� atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Generos/1
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // Cria um objeto generoBuscado que ir� receber o g�nero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum g�nero foi encontrado
            if (generoBuscado == null)
            {
                // Caso n�o seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "G�nero n�o encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o m�todo .AtualizarIdUrl();
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

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
        /// Deleta um g�nero passando o ID
        /// </summary>
        /// <param name="id">ID do g�nero que ser� deletado</param>
        /// <returns>Retorna um status code com uma mensagem personalizada</returns>
        /// dominio/api/Generos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o m�todo .Deletar();
            _generoRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("G�nero deletado");
        }
    }
}