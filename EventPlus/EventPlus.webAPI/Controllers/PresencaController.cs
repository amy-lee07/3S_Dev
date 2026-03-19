using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using EventPlus.webAPI.Repositories;
using EventPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private readonly IPresencaRepository _presencaRepository;
    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    /// <summary>
    /// endpoint da API que retorna a presenca por Id
    /// </summary>
    /// <param name="id">id da presenca ser buscada</param>
    /// <returns> status code 200 e presenca buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint da API que retorna a lista de presencas do usuario logado
    /// </summary>
    /// <param name="idUsuario">id do usuario prar filtragem</param>
    /// <returns>lista de presencas filtrada no usario</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarPorUsuario(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de cadastrar uma presenca
    /// </summary>
    /// <param name="novaPresenca">presenca a ser cadastrada</param>
    /// <returns>status code 201 e a presenca cadastrada</returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {
                IdUsuario = presenca.IdUsuario,
                IdEvento = presenca.IdEvento,
                Situacao = presenca.Situacao
            };
            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint da API que faz a chamada para o metodo de deletar uma presenca existente no banco de dados
    /// </summary>
    /// <param name="id">id da presenca a ser deletada</param>
    /// <returns>status code 201 e a presenca deletada</returns>
    [HttpDelete("{id}")]
     public IActionResult Deletar(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// endpoint da API que faz a chamada para o metodo de atualizar uma presenca existente no banco de dados
    /// </summary>
    /// <param name="id">id da prsenca a ser atualizada</param>
    /// <returns>status code 201 e a presenca deletada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, PresencaDTO presenca)
    {
        try
        {
            var presencaAtualizada = new Presenca
            {
                Situacao = presenca.Situacao
            };

            _presencaRepository.Atualizar(id, presencaAtualizada);

            return StatusCode(204, presenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


}
