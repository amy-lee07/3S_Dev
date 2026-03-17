using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;
    public TipoEventoController (ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }
    /// <summary>
    /// Endpoint da API que faz chamada para o metodo de listar os tipos de evento
    /// </summary>
    /// <returns> Sttatus code 200 e a lista de tipos de evento</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);

        }
    }
    /// <summary>
    /// Enpont da API que faz a chamada para o metodo de buscar um tipo de evento especifico 
    /// </summary>
    /// <param name="id">id do tipo de evento buscado</param>
    /// <returns>Status code 200 e tipo de evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento"> tipo de evento a ser cadastrado</param>
    /// <returns>status code 201 e o tipo de evento cadastrado</returns>
    [HttpPost]
     public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201, tipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest (erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo de evento a ser a ser atualizado </param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados</param>
    /// <returns>status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar (Guid id, TipoEventoDTO tipoEvento)
    {
 
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            {

                Titulo = tipoEvento.Titulo
            };
            _tipoEventoRepository.Atualizar(id, tipoEvento);
            return StatusCode(204, tipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo do eventyo a ser excluido </param>
    /// <returns>status code 204</returns>    
  
    
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


}
