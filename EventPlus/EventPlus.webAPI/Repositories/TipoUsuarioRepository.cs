using EventPlus.webAPI.BdContextEvent;
using EventPlus.webAPI.Interfaces;
using EventPlus.webAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.webAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Atualiza um tipo de usuario rastreamento automatico
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="tipoUsuario"></param>

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);
        if (tipoUsuarioBuscado != null)
        {
            tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            _context.SaveChanges();
        }
    }

    public TipoEvento BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// cadastra um novo tipo de usuario
    /// </summary>
    /// <param name="tipoUsuario">tipo de usuario a ser cadastrado</param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }
    /// <summary>
    /// deleta um tipo de usuario 
    /// </summary>
    /// <param name="id">id do tipo usuario a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);
        if (tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// busca a lista de tipos de usuarios cadastrados
    /// </summary>
    /// <returns>uma lista de tipo usuarios</returns>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.Titulo).ToList();
    }

    TipoUsuario ITipoUsuarioRepository.BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }
}
