using Filmes.WebAPI.Models;
namespace Filmes.WebAPI.Intterface;

public interface IFilmeRepository
{
    void Cadastrar(Filme novoFilme);
    void AtualizarIdCorpo(Filme filmeAtualizado);
    void AtualizarIdUrl(Guid id, Filme filmeatualizado);
    List<Filme> Listar();
    void Deletar(Guid id);
    Filme BuscarPorId(Guid id);

}
