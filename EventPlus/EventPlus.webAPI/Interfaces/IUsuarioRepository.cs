using EventPlus.webAPI.Models;
namespace EventPlus.webAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BuscarPorId (Guid id);
    Usuario BuscarPorEmailESenha (string Email, string Senha);
}
