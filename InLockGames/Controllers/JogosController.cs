using InLockGames.WebApi.Domains;
using InLockGames.WebApi.Interfaces;
using InLockGames.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InLockGames.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository;

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogosRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos jogoNovo)
        {
            _jogosRepository.Cadastrar(jogoNovo);

            return StatusCode(201);
        }
    }
}