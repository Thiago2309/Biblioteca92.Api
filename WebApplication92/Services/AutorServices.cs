using Dapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication92.context;

namespace WebApplication92.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly AplicationDBContext _context;

        public AutorServices(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                response = result.ToList();

                return new Response<List<Autor>>( response );
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :)" + ex.Message);
            }
        }

        public async Task<Response<Autor>> CrearAutor(Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new {i.Nombre,i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>( result );
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :)" + ex.Message);
            }
        }

        public async Task<Response<int>> EditarAutor(int id, Autor i)
        {
            var res = await _context.Autores.FirstAsync(x => x.PkAutor == id);

            if (res == null)
            {
                return new Response<int>
                {
                    Success = false,
                    Message = "Autor no encontrado"
                };
            }
            res.Nombre = i.Nombre;
            res.Nacionalidad = i.Nacionalidad;



            await _context.SaveChangesAsync();

            return new Response<int>
            {
                Success = true,
                Message = "Autor actualizado correctamente"
            };
        }

        public async Task<Response<int>> DeleteAutor(int id)
        {
            Autor res = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<int>(id, "Autor eliminado correctamente");
        }

        public async Task<Response<Autor>> GetByIdAutor(int id)
        {
            try
            {
                Autor res = await _context.Autores.FindAsync(id);
                return new Response<Autor>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Te dio un error" + ex.Message);
            }
        }
    }
}
