using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Intterface;
using Filmes.WebAPI.Models;
using Filmes.WebAPI.Repositories;

namespace Filmes.WebAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly FilmeContext _context;
        public GeneroRepository(FilmeContext context)
        {
            _context = context;
        }
        public void AtualizarIdCorpo(Genero generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(Guid id, Genero generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Genero BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
            _context.Generos.Add(novoGenero);
            _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Genero> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
