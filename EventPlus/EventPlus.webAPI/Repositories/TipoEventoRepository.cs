using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _context;
    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Atualiza um tipo de evento rastreamento automatico
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="tipoEvento"></param>
    
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);
        if (tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// Busca um tipo de evento por id, rastreamento automatico
    /// </summary>
    /// <param name="id">Id do tipo evento a ser biscado</param>
    /// <returns>Objeto do tipoEvento com as informações do tipo de evento buscado</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
       return _context.TipoEventos.Find(id)!;
    }
    /// <summary>
    /// cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }
    /// <summary>
    /// deleta um tipo de evento 
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);
        if(tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// busca a lista de tipos de eventos cadastrados
    /// </summary>
    /// <returns>uma lista de tipo eventos</returns>

    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }
}
