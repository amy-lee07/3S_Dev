using EventPlus.webAPI.Models;
namespace EventPlus.webAPI.Interfaces;

public interface IEventoRepository
{
        void Cadastrar(Evento evento);
        void Deletar(Guid IdEvento);
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Atualizar(Guid Id, Evento evento);
        List<Evento> ListarPorId(Guid IdUsuario);
        List<Evento> ProximosEvento();
}
