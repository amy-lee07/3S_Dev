using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using EventPlus.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.webAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;
    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }
    /// <summary>
    /// Endpoint da API que faz chamada para o metodo de listar as instituicoes
    /// </summary>
    /// <returns> Sttatus code 200 e a lista de instituicoes</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);

        }
    }


    /// <summary>
    /// Enpont da API que faz a chamada para o metodo de buscar uma instituicao especifico 
    /// </summary>
    /// <param name="id">id da instituicao buscado</param>
    /// <returns>Status code 200 e instituicao buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de cadastrar uma instituicao
    /// </summary>
    /// <param name="instituicao"> instituicao a ser cadastrado</param>
    /// <returns>status code 201 e a instituicao cadastrada</returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia,
                Cnpj = instituicao.Cnpj,
                Endereco = instituicao.Endereco
            };

            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201, novaInstituicao);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de atualizar uma instituicao
    /// </summary>
    /// <param name="id">id da instituicao a ser a ser atualizado </param>
    /// <param name="instituicao">instituicao com os dados atualizados</param>
    /// <returns>status code 204 e a instituicao atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var instituicaoAtualizado = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!
            };

            _instituicaoRepository.Atualizar(id, instituicaoAtualizado);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar uma instituicao
    /// </summary>
    /// <param name="id">Id da instituicao a ser excluido </param>
    /// <returns>status code 204</returns>    


    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


}
