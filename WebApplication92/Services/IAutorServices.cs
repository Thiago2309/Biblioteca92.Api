using Domain.Entities;

namespace WebApplication92.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> CrearAutor(Autor i);

        public Task<Response<int>> EditarAutor(int id, Autor i);

        public Task<Response<int>> DeleteAutor(int id);

        public Task<Response<Autor>> GetByIdAutor(int id);
    }
}
