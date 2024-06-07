using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication92.context;

namespace WebApplication92.Services
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly AplicationDBContext _context;

        public UsuarioServices(AplicationDBContext context)
        {
            _context = context;

        }

        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(y=> y.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Te dio un error"+ex.Message);
            }
        }

        public async Task<Response<Usuario>> GetById(int id)
        {
            try
            {   
                Usuario res = await _context.Usuarios.FindAsync(id);
                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Te dio un error" + ex.Message);
            }
        }

        public async Task<Response<UsuarioResponse>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = request.Nombre;
                usuario.UserName = request.UserName;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync(); //para que se guarde en la base de datos

                return new Response<UsuarioResponse>(request); //Retorna los datos
            }
            catch (Exception ex)
            {
                throw new Exception("Te dio un error" + ex.Message);
            }
        }

        public async Task<Response<int>> DeleteUsuario(int id)
        {
            Usuario res = await _context.Usuarios .FindAsync(id);
            _context.Usuarios.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<int>(id, "Usuario eliminado correctamente");
        }

        public async Task<Response<int>> UpdateUsuario(int id, UsuarioResponse request)
        {
            var res = await _context.Usuarios.FirstAsync(x => x.PkUsuario == id);

            if (res == null)
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Usuario no encontrado"
                };
            }   
            res.Nombre = request.Nombre;
            res.UserName = request.UserName;
            res.Password = request.Password;
            res.FkRol = request.FkRol;


            await _context.SaveChangesAsync();

            return new Response<int>
            {
                Success = true,
                Message = "Usuario actualizado correctamente"
            };
        }
    }
}
