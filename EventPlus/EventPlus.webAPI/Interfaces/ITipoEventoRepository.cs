using EventPlus.webAPI.DTO;
using EventPlus.webAPI.Models;
namespace EventPlus.webAPI.Interfaces;

    public interface ITipoEventoRepository
    {
        List<TipoEvento> Listar();
        void Cadastrar(TipoEvento tipoEvento);
        void Atualizar(Guid id, TipoEvento tipoEvento);
        void Deletar(Guid id);
            TipoEvento BuscarPorId(Guid id);
    void Atualizar(Guid id, TipoEventoDTO tipoEvento);
}

