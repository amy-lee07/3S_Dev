using Filmes.WebAPI.Models;
namespace Filmes.WebAPI.Intterface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario novoUsuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string email, string senha);
}
