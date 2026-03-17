
using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Controllers;
using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _context;
    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Atualiza a instituicao existente no banco de dados
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="instituicao"></param>

    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(id);
        if (InstituicaoBuscada != null)
        {
            InstituicaoBuscada.NomeFantasia = String.IsNullOrWhiteSpace(instituicao.NomeFantasia) ? InstituicaoBuscada.NomeFantasia
                :instituicao.NomeFantasia;
            InstituicaoBuscada.Cnpj = String.IsNullOrWhiteSpace(instituicao.Cnpj) ? InstituicaoBuscada.Cnpj
                : instituicao.Cnpj;
            InstituicaoBuscada.Endereco = String.IsNullOrWhiteSpace(instituicao.Endereco) ? InstituicaoBuscada.Endereco 
                : instituicao.Endereco;
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca uma instituicao por id, rastreamento automatico
    /// </summary>
    /// <param name="id">Id do tipo evento a ser biscado</param>
    /// <returns>Objeto da Instituicao com as informações do tipo de evento buscado</returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }
    /// <summary>
    /// cadastra uma instituicao
    /// </summary>
    /// <param name="tipoUsuario">instituicao a ser cadastrado</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    /// <summary>
    /// deleta um tipo de evento 
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find(id);
        if (InstituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(InstituicaoBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// busca a lista de tipos de eventos cadastrados
    /// </summary>
    /// <returns>uma lista de tipo eventos</returns>

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(instituicao => instituicao.NomeFantasia).ToList();    
    }
}

