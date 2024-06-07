using Domain;
using Domain.Entities;

namespace WebApplication92.Services
{
    public interface IUsuariosServices
    {
        public Task<Response<List<Usuario>>> GetUsuarios();

        public Task<Response<UsuarioResponse>> CrearUsuario(UsuarioResponse request);

        public Task<Response<int>> DeleteUsuario(int id);
        public Task<Response<int>> UpdateUsuario(int id, UsuarioResponse request);

        public  Task<Response<Usuario>> GetById(int id);
    }
}
