using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.webAPI.Repositories;

public class ComentarioEventoReposity : IComentarioEventoRepository
{
    private readonly EventContext _eventContext;
    public ComentarioEventoReposity(EventContext context)
    {
        _eventContext = context;
    }
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        return _eventContext.ComentarioEventos
            .Include(c => c .IdUsuarioNavigation)
            .Include(c => c .IdEventoNavigation)
            .FirstOrDefault(p=>p.IdEvento == IdEvento)!;
    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _eventContext.ComentarioEventos.Add(comentarioEvento);
        _eventContext.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var ComentarioBuscado = _eventContext.ComentarioEventos.Find(id);
        if (ComentarioBuscado != null)
        {
            _eventContext.ComentarioEventos.Remove(ComentarioBuscado);
            _eventContext.SaveChanges();
        }
    }
    
    public List<ComentarioEvento> Listar(Guid IdEvento)
    {
        return _eventContext.ComentarioEvento
            .OrderBy(ComentarioEvento => ComentarioEvento.Descricao)
            .ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        throw new NotImplementedException();
    }
}
