using Filmes.WebAPI.Intterface;
using Filmes.WebAPI.Models;
using Filmes.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
     

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
               
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201, novoUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

