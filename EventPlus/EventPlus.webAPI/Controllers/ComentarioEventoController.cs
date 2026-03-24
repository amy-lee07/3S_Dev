using Azure;
using Azure.AI.ContentSafety;
using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;
    private readonly IComentarioEventoRepository _comentarioEventoRepository;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }

    /// <summary>
    /// Endpoint da PI que cadastra e modera um comentario
    /// </summary>
    /// <param name="comentarioEventoDTO">comentario a ser moderado</param>
    /// <returns>Status code 201 e o comentario criado</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar (ComentarioEventoDTO comentarioEventoDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEventoDTO.Descricao))
            {
                return BadRequest("O texto a ser moderado nao pode estar vazio");
            }
            var request = new AnalyzeTextOptions(comentarioEventoDTO.Descricao);
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);
            bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(comentario => comentario.Severity > 0);
            var novoComentario = new ComentarioEvento
            {
                Descricao = comentarioEventoDTO.Descricao,
                IdUsuario = comentarioEventoDTO.IdUsuario,
                IdEvento = comentarioEventoDTO.IdEvento,
                DataComentarioEvento = DateTime.Now,

                Exibe = !temConteudoImproprio
            };
             _comentarioEventoRepository.Cadastrar(novoComentario);
            return StatusCode(201, novoComentario);
        }


        catch (Exception e){

            return BadRequest(e.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de listar os comentarios de um evento
    /// </summary>
    /// <param name="IdEvento"></param>
    /// <returns></returns>
    [HttpGet("{IdEvento}")]
    public IActionResult Listar(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.Listar(IdEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um comentario de um evento
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de listar somente os comentarios de um evento que tem a propriedade Exibe como true
    /// </summary>
    /// <param name="IdEvento"></param>
    /// <returns></returns>
    [HttpGet("Exibe/{IdEvento}")]
    public IActionResult ListarSomenteExibe(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(IdEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
