using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using EventPlus.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;
    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// endpoint da API que faz a chamada para o metodo de listar eventos filtrando pelo id do usuario
    /// </summary>
    /// <param name="IdUsuario">id do usuario para filtragem</param>
    /// <returns>status code e uma lista d eventos</returns>
    [HttpGet("Usuario/{IdUsuario}")]
    public IActionResult ListarPorId(Guid IdUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(IdUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// endpoint da API que faz a chamada para o metodo de listar eventos 
    /// </summary>
    /// <returns>status code 200 e a lista dos proximos eventos</returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximosEventos()
    {
        try
        {
            return Ok(_eventoRepository.ProximosEvento());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// listar todos os eventos cadastrados 
    /// </summary>
    /// <returns>status code 200 e a lista de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);

        }
    }

    /// <summary>
    /// busca o id dos eventos cadatrados
    /// </summary>
    /// <param name="id"></param>
    /// <returns>tatus code 200 e instituicao buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// cadastra novo evento
    /// </summary>
    /// <param name="evento">evento a ser cadastrado</param>
    /// <returns>status code 201 e a evento cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome,
                Descricao = evento.Descricao,
                DataEvento = evento.DataEvento,
                IdTipoEvento = evento.IdTipoEvento,
                IdInstituicao = evento.IdInstituicao

            };

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, novoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// atualiza um evento existente
    /// </summary>
    /// <param name="id">id da instituicao a ser a ser atualizado</param>
    /// <param name="evento">instituicao com os dados atualizados</param>
    /// <returns>status code 204 e a instituicao atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var eventoAtualizado = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento!,
                IdTipoEvento = evento.IdTipoEvento,
                IdInstituicao = evento.IdInstituicao
            };

            _eventoRepository.Atualizar(id, eventoAtualizado);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser excluido </param>
    /// <returns>status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _eventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}




