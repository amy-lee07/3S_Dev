using EventPlus.webAPI.Models;

namespace EventPlus.webAPI.Interfaces;

public interface IPresencaRepository
{
     void Inscrever (Presenca Incricao);
    void Deletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid Id);
    List<Presenca> ListarMinhas(Guid IdUsuario);
    
}
