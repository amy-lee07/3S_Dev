using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.webAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;
    public EventoRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// atualiza o evento buscado
    /// </summary>
    /// <param name="id">id do evento a ser a atualizado</param>
    /// <param name="Evento">novos dados de evento</param>
    public void Atualizar(Guid id, Evento evento)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if (eventoBuscado != null)
        {
            eventoBuscado.Nome = evento.Nome;
            eventoBuscado.Descricao= evento.Descricao;
            eventoBuscado.DataEvento = evento.DataEvento;
            eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            eventoBuscado.IdInstituicao = evento.IdInstituicao;

            _context.SaveChanges();
        }
    }
    /// <summary>
    /// buscar um evento por id
    /// </summary>
    /// <param name="id">id do evento a ser buscado</param>
    /// <returns>Objeto de Evento com as informações de evento buscado</returns>
    public Evento BuscarPorId(Guid id)
    {
        return _context.Eventos.Find(id)!;
    }
    /// <summary>
    /// cadastra um novo tipo de vento 
    /// </summary>
    /// <param name="evento">evento a ser cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }
    /// <summary>
    /// deleta um evento
    /// </summary>
    /// <param name="IdEvento">id de evento a ser deletado</param>
    public void Deletar(Guid IdEvento)
    {
        var eventoBuscado = _context.Eventos.Find(IdEvento);

        if (eventoBuscado != null)
        {
            _context.Eventos.Remove(eventoBuscado);
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// busca a lista de evnto cadastrado
    /// </summary>
    /// <returns>uma lista de evento</returns>
    public List<Evento> Listar()
    {
        return _context.Eventos.ToList();
    }
    /// <summary>
    /// metodo que busca eventos no qual um usuario confirmou presenca
    /// </summary>
    /// <param name="IdUsuario">Id d o usuario a ser buscado</param>
    /// <returns>uma lista de eventos</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation)
                                .Include(e => e.IdInstituicaoNavigation)
                                .Where(e => e.Presencas
                                .Any(p => p.IdUsuario == IdUsuario && p.Situacao == true)).ToList();
    }
    /// <summary>
    /// metodo que traz a lista de proximos eventos 
    /// </summary>
    /// <returns>uma lista de eventos </returns>
    public List<Evento> ProximosEvento()
    {
        return _context.Eventos.Include(e => e.IdTipoEventoNavigation)
                               .Include(e => e.IdInstituicaoNavigation)
                               .Where(e => e.DataEvento >= DateTime.Now)
                               .OrderBy(e => e.DataEvento).ToList();
    }
}
